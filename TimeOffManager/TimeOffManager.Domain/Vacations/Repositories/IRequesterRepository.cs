namespace TimeOffManager.Domain.Vacations.Repositories
{
    using Models.Requesters;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRequesterRepository
    {
        Task<Requester> FindByUser(string userId, CancellationToken cancellationToken = default);
    }
}
