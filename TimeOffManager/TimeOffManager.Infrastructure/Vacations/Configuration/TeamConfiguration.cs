namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
    using static Domain.Vacations.Models.ModelConstants.Common;

    using Domain.Vacations.Models.Requesters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .HasMany(d => d.Members)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("members");
        }
    }
}
