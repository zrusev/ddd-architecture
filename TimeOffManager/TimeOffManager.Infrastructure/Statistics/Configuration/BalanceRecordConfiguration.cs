namespace TimeOffManager.Infrastructure.Statistics.Configuration
{
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BalanceRecordConfiguration : IEntityTypeConfiguration<BalanceRecord>
    {
        public void Configure(EntityTypeBuilder<BalanceRecord> builder)
        { 
            builder
                .HasKey(r => r.Id);

            builder
                .Property(i => i.RequestId)
                .IsRequired();

            builder
                .Property(i => i.CurrentBalance)
                .IsRequired();

            builder
                .Property(i => i.RevisedBalance)
                .IsRequired();
        }
    }
}
