namespace TimeOffManager.Domain.Vacations.Repositories
{
    using Common;
    using Models.Requests;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRequestDomainRepository : IDomainRepository<Request>
    {
        Task<Request> Find(int id, CancellationToken cancellationToken = default);
    }
}