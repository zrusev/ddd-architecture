namespace TimeOffManager.Application.Vacations.Requesters
{
    using Common.Contracts;
    using Domain.Vacations.Models.Requesters;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters.Queries.Common;

    public interface IRequesterQueryRepository : IQueryRepository<Requester>
    {
        Task<Employee> FindByManagerId(int managerId, CancellationToken cancellationToken = default);

        Task<Team> FindByTeamId(int teamId, CancellationToken cancellationToken = default);

        Task<RequesterOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
     
        Task<RequesterOutputModel> GetDetailsByRequestId(int requestId, CancellationToken cancellationToken = default);
    }
}