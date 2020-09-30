namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
    using static Domain.Vacations.Models.ModelConstants.Common;

    using Domain.Vacations.Models.Requesters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(pn => pn.FirstName)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(pn => pn.LastName)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(pn => pn.EmployeeId)
                .IsRequired()
                .HasMaxLength(EIDLength);

            builder
                .Property(pn => pn.Email)
                .IsRequired()
                .HasMaxLength(MaxEmailLength);

            builder
                .Property(pn => pn.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            builder
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey("ManagerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.Team)
                .WithMany()
                .HasForeignKey("TeamId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(c => c.PTOBalance, o =>
                {
                    o.WithOwner();

                    o.Property(op => op!.Initial);
                    o.Property(op => op!.Current);
                });
        }
    }
}
