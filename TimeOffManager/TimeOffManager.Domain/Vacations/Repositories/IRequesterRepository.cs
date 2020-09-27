namespace TimeOffManager.Domain.Vacations.Repositories
{
    using Common;
    using Models.Requesters;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRequesterRepository : IDomainRepository<Requester>
    {
        Task<Requester> FindByUser(string userId, CancellationToken cancellationToken = default);
    }
}
