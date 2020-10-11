namespace TimeOffManager.Domain.Vacations.Factories.Requests
{
    using Common;
    using Models.Requests;
    using System;
    using System.Collections.Generic;
    using TimeOffManager.Domain.Vacations.Models.Shared;

    public interface IRequestFactory : IFactory<Request>
    {
        IRequestFactory WithPeriod(DateTime start, DateTime end);

        IRequestFactory WithPTOBalance(PTOBalance balance);

        IRequestFactory WithApprover(int? approverId);

        IRequestFactory WithDays(DateTime start, DateTime end);

        IRequestFactory WithRequestDates(
            RequestType type, 
            TimeSpan hours, 
            bool excludeHolidays, 
            bool ExcludeWeekends, 
            List<DateTime> holidays);

        IRequestFactory WithRequesterComment(string? comment);

        IRequestFactory WithApproverComment(string? comment);

        IRequestFactory WithOptions(
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends);
    }
}