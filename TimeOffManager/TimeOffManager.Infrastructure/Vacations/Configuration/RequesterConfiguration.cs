namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
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
                .HasOne(d => d.Employee)
                .WithMany()
                .HasForeignKey("EmployeeId")
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