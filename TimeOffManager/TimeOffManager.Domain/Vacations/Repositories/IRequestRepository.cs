namespace TimeOffManager.Domain.Vacations.Repositories
{
    using Common;
    using Models.Requests;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRequestRepository : IDomainRepository<Request>
    {
        Task<Request> Find(int id, CancellationToken cancellationToken = default);
    }
}