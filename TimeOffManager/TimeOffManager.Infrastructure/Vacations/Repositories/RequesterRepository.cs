namespace TimeOffManager.Infrastructure.Vacations.Repositories
{
    using Application.Vacations.Requesters;
    using Application.Vacations.Requesters.Queries.Common;
    using AutoMapper;
    using Common.Persistence;
    using Domain.Vacations.Exceptions;
    using Domain.Vacations.Models.Requesters;
    using Domain.Vacations.Repositories;
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RequesterRepository : DataRepository<IVacationsDbContext, Requester>, 
        IRequesterDomainRepository, 
        IRequesterQueryRepository
    {
        private readonly IMapper mapper;

        public RequesterRepository(IVacationsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default
            )
        {
            var requesterData = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (requesterData == null)
            {
                throw new InvalidRequesterException("This user is not a requester.");
            }

            return requesterData;
        }

        public async Task<RequesterOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<RequesterOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<RequesterOutputModel> GetDetailsByRequestId(int requestId, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<RequesterOutputModel>(this
                    .All()
                    .Where(d => d.Requests.Any(c => c.Id == requestId)))
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<Employee> FindByManagerId(int managerId, CancellationToken cancellationToken = default)
            => await this.Data
                .Employees
                .FirstOrDefaultAsync(i => i.Id == managerId, cancellationToken);

        public async Task<Team> FindByTeamId(int teamId, CancellationToken cancellationToken = default)
            => await this.Data
                .Teams
                .FirstOrDefaultAsync(i => i.Id == teamId, cancellationToken);
    }
}
