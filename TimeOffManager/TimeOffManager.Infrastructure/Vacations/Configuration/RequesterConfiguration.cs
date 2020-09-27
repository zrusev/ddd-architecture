namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
    using static Domain.Vacations.Models.ModelConstants.Common;

    using Domain.Vacations.Models.Requesters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RequesterConfiguration : IEntityTypeConfiguration<Requester>
    {
        public void Configure(EntityTypeBuilder<Requester> builder)
        {            
            builder
                .HasKey(d => d.Id);

            builder
                .OwnsOne(
                    d => d.Employee,
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
                .OwnsOne(
                    d => d.Manager,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.Email);
                    });

            builder
                .HasOne(c => c.Team)
                .WithMany()
                .HasForeignKey("TeamId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(d => d.Requests)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("requests");
        }
    }
}