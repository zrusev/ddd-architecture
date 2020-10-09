namespace TimeOffManager.Application.Vacations.Requests.Queries
{
    using Common.Contracts;
    using Domain.Vacations.Models.Requests;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TimeOffManager.Application.Vacations.Requests.Queries.Details;

    public interface IRequestQueryRepository : IQueryRepository<Request>
    {
        Task<Request> GetRequest(int requestId, CancellationToken cancellationToken = default);
        
        Task<RequestType> GetRequestType(string name, CancellationToken cancellationToken = default);

        Task<List<DateTime>> GetNationalHolidays(CancellationToken cancellationToken = default);

        Task<List<DateTime>> GetAlreadyRequestedDays(
            int requesterId, 
            DateTime start, 
            DateTime end, 
            CancellationToken cancellationToken = default);

        Task<RequestDetailsOutputModel> GetDetails(int requestId, CancellationToken cancellationToken = default);
    }
}