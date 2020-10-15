namespace TimeOffManager.Infrastructure.Statistics.Repositories
{
    using Application.Statistics;
    using Common.Persistence;
    using Domain.Statistics.Exceptions;
    using Domain.Statistics.Models;
    using Domain.Statistics.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistic>,
        IStatisticsDomainRepository,
        IStatisticsQueryRepository
    {
        public StatisticsRepository(IStatisticsDbContext db)
            : base(db)
        {
        }

        public async Task AddRecord(
            string statisticName, 
            int requestId, 
            int currentBalance, 
            int revisedBalance, 
            CancellationToken cancellationToken = default)
        {
            var statistic = await this.Data
                .Statistics
                .Where(s => s.Name == statisticName)
                .SingleOrDefaultAsync(cancellationToken);

            if (statistic is null)
                throw new InvalidStatisticException($"Statistic named {statisticName} does not exists.");

            statistic.AddRecord(requestId, currentBalance, revisedBalance);

            await this.Save(statistic, cancellationToken);
        }
    }
}