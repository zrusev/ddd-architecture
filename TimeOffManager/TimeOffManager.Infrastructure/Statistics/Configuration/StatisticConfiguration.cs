namespace TimeOffManager.Infrastructure.Statistics.Configuration
{
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Statistics.Models.ModelConstants.Common;

    public class StatisticConfiguration : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder)
        {
            const string id = "Id";

            builder
                .Property<int>(id);

            builder
                .HasKey(id);

            builder
                .HasIndex(p => p.Name)
                .IsUnique();

            builder
                .Property(n => n.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .Property(n => n.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired();

            builder
                .HasMany(d => d.Records)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("records");
        }
    }
}