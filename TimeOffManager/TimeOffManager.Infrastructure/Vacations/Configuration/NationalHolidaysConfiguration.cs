namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
    using Domain.Vacations.Models.Requests;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class NationalHolidaysConfiguration : IEntityTypeConfiguration<NationalHolidays>
    {
        public void Configure(EntityTypeBuilder<NationalHolidays> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Date)
                .IsRequired();
        }
    }
}