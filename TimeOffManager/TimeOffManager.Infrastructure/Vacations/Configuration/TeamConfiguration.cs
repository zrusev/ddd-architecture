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
                .OwnsOne(
                    d => d.Manager,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.FirstName)
                            .IsRequired()
                            .HasMaxLength(MaxNameLength);

                        p.Property(pn => pn.LastName)
                            .IsRequired()
                            .HasMaxLength(MaxNameLength);

                        p.Property(pn => pn.EmployeeId)
                            .IsRequired()
                            .HasMaxLength(EIDLength);

                        p.Property(pn => pn.Email)
                            .IsRequired()
                            .HasMaxLength(MaxEmailLength);

                        p.Property(pn => pn.ImageUrl)
                            .IsRequired()
                            .HasMaxLength(MaxUrlLength);
                    }
                );

            builder
                .HasMany(d => d.Members)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
