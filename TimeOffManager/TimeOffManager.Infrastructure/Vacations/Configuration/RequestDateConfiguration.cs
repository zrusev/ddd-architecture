namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
    using static Domain.Vacations.Models.ModelConstants.Common;

    using Domain.Vacations.Models.Requests;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RequestDateConfiguration : IEntityTypeConfiguration<RequestDate>
    {
        public void Configure(EntityTypeBuilder<RequestDate> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Date)
                .IsRequired();

            builder
                .Property(h => h.Hours)
                .IsRequired();
        }
    }
}