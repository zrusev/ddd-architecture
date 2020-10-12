namespace TimeOffManager.Infrastructure.Vacations.Repositories
{
    using Application.Vacations.Requests.Queries;
    using Application.Vacations.Requests.Queries.Details;
    using AutoMapper;
    using Common.Persistence;
    using Domain.Vacations.Models.Requests;
    using Domain.Vacations.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RequestRepository : DataRepository<IVacationsDbContext, Request>,
        IRequestDomainRepository,
        IRequestQueryRepository
    {
        private readonly IMapper mapper;

        public RequestRepository(
            IVacationsDbContext db, 
            IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<List<DateTime>> GetNationalHolidays(
            CancellationToken cancellationToken = default)
            => await this.Data
                .NationalHolidays
                .Select(s => s.Date)
                .ToListAsync();

        public async Task<Request> GetRequest(
            int requestId, 
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(r => r.Id == requestId)
                .Include(d => d.RequestDates)
                .ThenInclude(d => d.RequestType)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<RequestType> GetRequestType(
            string name, 
            CancellationToken cancellationToken = default)
            => await this.Data
                .RequestTypes
                .Where(t => t.Name == name)
                .FirstOrDefaultAsync();

        public async Task<RequestDetailsOutputModel> GetDetails(
            int requestId, 
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<RequestDetailsOutputModel>(this
                    .All()
                    .Where(c => c.Id == requestId))
                .FirstOrDefaultAsync(cancellationToken);
    }
}