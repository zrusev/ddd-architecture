namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
    using Domain.Vacations.Models.Requests;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Vacations.Models.ModelConstants.RequestType;

    public class RequestTypeConfiguration : IEntityTypeConfiguration<RequestType>
    {
        public void Configure(EntityTypeBuilder<RequestType> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);
        }
    }
}
