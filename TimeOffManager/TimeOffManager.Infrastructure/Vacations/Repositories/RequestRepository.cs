namespace TimeOffManager.Infrastructure.Vacations.Repositories
{
    using Application.Vacations.Requests.Queries;
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

        public RequestRepository(IVacationsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<List<DateTime>> GetNationalHolidays(CancellationToken cancellationToken = default)
            => await this.Data
                .NationalHolidays
                .Select(s => s.Date)
                .ToListAsync();

        public async Task<List<DateTime>> GetAlreadyRequestedDays(
            int requesterId,
            DateTime start,
            DateTime end,
            CancellationToken cancellationToken = default)
            => await this.Data
                .RequestDates
                .Where(r => r.Date >= start && r.Date <= end)    
                .Select(d => d.Date)
                .ToListAsync();

        public async Task<RequestType> GetRequestType(string name, CancellationToken cancellationToken = default)
            => await this.Data
                .RequestTypes
                .Where(t => t.Name == name)
                .FirstOrDefaultAsync();
    }
}