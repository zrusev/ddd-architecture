﻿namespace TimeOffManager.Infrastructure.Vacations.Configuration
{
    using Domain.Vacations.Models.Requests;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Vacations.Models.ModelConstants.Request;

    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(p => p.RequestedOn)
                .IsRequired();

            builder
                .OwnsOne(d => d.DateTimeRange, o =>
                {
                    o.WithOwner();

                    o.Property(op => op.Start);
                    o.Property(op => op.End);
                });

            builder
                .Property(p => p.Days)
                .IsRequired();

            builder
                .Property(p => p.RequesterComment)
                .HasMaxLength(MaxCommentLength);

            builder
                .Property(p => p.ApproverComment)
                .HasMaxLength(MaxCommentLength);

            builder
                .OwnsOne(c => c.Options, o =>
                {
                    o.WithOwner();

                    o.Property(op => op.IsApproved);
                    o.Property(op => op.IsPlanning);
                    o.Property(op => op.ExcludeWeekends);
                    o.Property(op => op.ExcludeHolidays);
                });

            //builder
            //    .OwnsOne(c => c.PTOBalance, o =>
            //    {
            //        o.WithOwner();

            //        o.Property(op => op.Initial);
            //        o.Property(op => op.Current);
            //        o.Property(op => op.Updated);
            //    });
        }
    }
}
