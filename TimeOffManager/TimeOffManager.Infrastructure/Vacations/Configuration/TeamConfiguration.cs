namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
    using Domain.Vacations.Models.Requesters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Vacations.Models.ModelConstants.Common;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasIndex(p => p.Name)
                .IsUnique();

            builder
                .Property(p => p.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();
        }
    }
}