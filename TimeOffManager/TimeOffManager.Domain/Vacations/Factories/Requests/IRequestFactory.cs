namespace TimeOffManager.Domain.Vacations.Factories.Requests
{
    using Common;
    using Models.Requests;
    using System;
    using System.Collections.Generic;

    public interface IRequestFactory : IFactory<Request>
    {
        IRequestFactory WithPeriod(DateTime start, DateTime end);

        IRequestFactory WithDays(int days);

        IRequestFactory WithRequestDates(HashSet<RequestDate> requestDates);

        IRequestFactory WithRequesterComment(string comment);

        IRequestFactory WithApproverComment(string comment);

        IRequestFactory WithOptions(
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends);
    }
}
