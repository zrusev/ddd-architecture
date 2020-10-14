namespace TimeOffManager.Infrastructure.Vacations.Repositories
{
    using Application.Vacations.Requesters;
    using Application.Vacations.Requesters.Queries.Common;
    using AutoMapper;
    using Common.Persistence;
    using Domain.Vacations.Exceptions;
    using Domain.Vacations.Models.Requesters;
    using Domain.Vacations.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RequesterRepository : DataRepository<IVacationsDbContext, Requester>, 
        IRequesterDomainRepository, 
        IRequesterQueryRepository
    {
        private readonly IMapper mapper;

        public RequesterRepository(
            IVacationsDbContext db, 
            IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<RequesterOutputModel> GetDetails(
            int id, 
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<RequesterOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<RequesterOutputModel> GetDetailsWithRequests(
            int requesterId,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<RequesterOutputModel>(this
                    .All()
                    .Where(d => d.Id == requesterId)
                    .Include(u => u.Requests)
                        .ThenInclude(d => d.RequestDates)
                            .ThenInclude(m => m.RequestType)
                )
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<RequesterOutputModel>> GetDetailsByTeamId(
            int teamId, 
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<RequesterOutputModel>(this
                    .All()
                    .Where(t => t.Employee.Team!.Id == teamId 
                        && t.Requests.Any(o => o.Options.IsApproved))
                    .Include(e => e.Employee)
                        .ThenInclude(t => t.Team)
                    .Include(r => r.Requests)
                        .ThenInclude(d => d.RequestDates)
                            .ThenInclude(m => m.RequestType)
                )
            .ToListAsync(cancellationToken);

        public async Task<RequesterOutputModel> GetDetailsByRequestId(
            int requestId, 
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<RequesterOutputModel>(this
                    .All()
                    .Where(d => d.Requests.Any(c => c.Id == requestId)))
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<Requester> GetRequesterByRequestId(
            int requestId, 
            CancellationToken cancellationToken = default)
            => await this
                    .All()
                    .Where(d => d.Requests.Any(c => c.Id == requestId))
                    .Include(u => u.Requests)
                        .ThenInclude(d => d.RequestDates)
                            .ThenInclude(m => m.RequestType)
                    .Include(e => e.Employee)
                        .ThenInclude(p => p.PTOBalance)
                    .SingleOrDefaultAsync(cancellationToken);

        public async Task<Employee> FindByManagerId(
            int managerId, 
            CancellationToken cancellationToken = default)
            => await this.Data
                .Employees
                .FirstOrDefaultAsync(i => i.Id == managerId, cancellationToken);

        public async Task<Team> FindByTeamName(
            string name, 
            CancellationToken cancellationToken = default)
            => await this.Data
                .Teams
                .FirstOrDefaultAsync(i => i.Name == name, cancellationToken);

        public Task<int> GetRequesterId(
            string userId, 
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, requester => requester.Id, cancellationToken);

        public Task<Requester> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, requester => requester, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<Requester, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var requesterData = await this
                .All()
                .Where(u => u.UserId == userId)
                .Include(i => i.Employee)
                .Include(m => m.Employee.Manager)
                .Include(p => p.Employee.PTOBalance)
                .Select(selector)
                .SingleOrDefaultAsync(cancellationToken);

            if (requesterData == null)
            {
                throw new InvalidRequesterException("This user is not a requester.");
            }

            return requesterData;
        }
    }
}
