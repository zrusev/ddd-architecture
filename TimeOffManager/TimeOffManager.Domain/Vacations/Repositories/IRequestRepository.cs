namespace TimeOffManager.Domain.Vacations.Repositories
{
    using Models.Requests;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRequestRepository
    {
        Task<Request> Find(int id, CancellationToken cancellationToken = default);
    }
}