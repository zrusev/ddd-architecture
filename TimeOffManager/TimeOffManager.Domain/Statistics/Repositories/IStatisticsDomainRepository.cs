namespace TimeOffManager.Domain.Statistics.Repositories
{
    using Common;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStatisticsDomainRepository : IDomainRepository<Statistic>
    {
        Task AddRecord(
            string statisticName, 
            int requestId, 
            int currentBalance, 
            int revisedBalance, 
            CancellationToken cancellationToken = default);
    }
}