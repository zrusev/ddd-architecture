namespace TimeOffManager.Application.Vacations.Requests.Queries
{
    using Common.Contracts;
    using Domain.Vacations.Models.Requests;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRequestQueryRepository : IQueryRepository<Request>
    {
        Task<RequestType> GetRequestType(string name, CancellationToken cancellationToken = default);

        Task<List<DateTime>> GetNationalHolidays(CancellationToken cancellationToken = default);

        Task<List<DateTime>> GetAlreadyRequestedDays(
            int requesterId, 
            DateTime start, 
            DateTime end, 
            CancellationToken cancellationToken = default);
    }
}