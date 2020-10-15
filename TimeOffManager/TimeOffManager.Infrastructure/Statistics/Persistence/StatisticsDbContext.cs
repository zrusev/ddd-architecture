namespace TimeOffManager.Infrastructure.Statistics.Persistence
{
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;
    using Statistics;
    using System.Reflection;
 
    public class StatisticsDbContext : DbContext,
        IStatisticsDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Statistic> Statistics { get; set; } = default!;

        public DbSet<BalanceRecord> BalanceRecords { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}