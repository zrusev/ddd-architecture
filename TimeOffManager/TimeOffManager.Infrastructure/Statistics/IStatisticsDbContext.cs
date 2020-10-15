namespace TimeOffManager.Infrastructure.Statistics
{
    using Common.Persistence;
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface IStatisticsDbContext : IDbContext
    {
        DbSet<Statistic> Statistics { get; }

        DbSet<BalanceRecord> BalanceRecords { get; }
    }
}