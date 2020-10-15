namespace TimeOffManager.Application.Statistics
{
    using Common.Contracts;
    using Domain.Statistics.Models;
    
    public interface IStatisticsQueryRepository : IQueryRepository<Statistic>
    {
    }
}
