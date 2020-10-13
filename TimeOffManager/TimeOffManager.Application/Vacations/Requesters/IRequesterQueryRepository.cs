namespace TimeOffManager.Application.Vacations.Requesters
{
    using Common.Contracts;
    using Domain.Vacations.Models.Requesters;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters.Queries.Common;

    public interface IRequesterQueryRepository : IQueryRepository<Requester>
    {
        Task<Employee> FindByManagerId(int managerId, CancellationToken cancellationToken = default);

        Task<Team> FindByTeamName(string name, CancellationToken cancellationToken = default);

        Task<int> GetRequesterId(string userId, CancellationToken cancellationToken = default);

        Task<Requester> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<RequesterOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
     
        Task<RequesterOutputModel> GetDetailsByRequestId(int requestId, CancellationToken cancellationToken = default);

        Task<RequesterOutputModel> GetDetailsWithRequests(int requesterId, CancellationToken cancellationToken = default);

        Task<Requester> GetRequesterByRequestId(int requestId, CancellationToken cancellationToken = default);

        Task<IEnumerable<RequesterOutputModel>> GetDetailsByTeamId(int teamId, CancellationToken cancellationToken = default);
    }
}