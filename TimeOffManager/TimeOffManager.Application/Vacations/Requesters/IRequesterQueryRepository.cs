namespace TimeOffManager.Application.Vacations.Requesters
{
    using Common.Contracts;
    using Domain.Vacations.Models.Requesters;
    using System.Threading;
    using System.Threading.Tasks;
    using TimeOffManager.Domain.Common;
    using Vacations.Requesters.Queries.Common;

    public interface IRequesterQueryRepository : IQueryRepository<Requester>
    {
        Task<RequesterOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<RequesterOutputModel> GetDetailsByRequestId(int requestId, CancellationToken cancellationToken = default);
    }
}