﻿namespace TimeOffManager.Application.Vacations.Requests.Queries.Details
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Vacations.Models.Requests;
    using System;

    public class RequestDetailsOutputModel : IMapFrom<Request>
    {
        public DateTime RequestedOn { get; private set; }

        public DateTime? ApprovedOn { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public int Days { get; private set; }

        public int ApproverId { get; private set; }

        public string RequesterComment { get; private set; } = default!;

        public string ApproverComment { get; private set; } = default!;

        public bool IsApproved { get; private set; }

        public bool IsPlanning { get; private set; }

        public bool ExcludeHolidays { get; private set; }

        public bool ExcludeWeekends { get; private set; }

        public int? Initial { get; private set; }

        public int? Current { get; private set; }

        public int? Updated { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Request, RequestDetailsOutputModel>()
                .ForMember(r => r.IsApproved, cfg => cfg
                    .MapFrom(ad => ad.Options.IsApproved))
                .ForMember(r => r.IsPlanning, cfg => cfg
                    .MapFrom(ad => ad.Options.IsPlanning))
                .ForMember(r => r.ExcludeHolidays, cfg => cfg
                    .MapFrom(ad => ad.Options.ExcludeHolidays))
                .ForMember(r => r.ExcludeWeekends, cfg => cfg
                    .MapFrom(ad => ad.Options.ExcludeWeekends))
                .ForMember(r => r.Initial, cfg => cfg
                    .MapFrom(ad => ad.PTOBalance.Initial))
                .ForMember(r => r.Current, cfg => cfg
                    .MapFrom(ad => ad.PTOBalance.Current))
                .ForMember(r => r.Updated, cfg => cfg
                    .MapFrom(ad => ad.PTOBalance.Updated))
                .ForMember(r => r.Start, cfg => cfg
                    .MapFrom(ad => ad.DateTimeRange.Start))
                .ForMember(r => r.End, cfg => cfg
                    .MapFrom(ad => ad.DateTimeRange.End));
    }
}