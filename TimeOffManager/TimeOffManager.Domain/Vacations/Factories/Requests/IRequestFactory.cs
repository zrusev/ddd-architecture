namespace TimeOffManager.Domain.Vacations.Factories.Requests
{
    using Common;
    using Models.Requests;
    using System;

    public interface IRequestFactory : IFactory<Request>
    {
        IRequestFactory WithPeriod(DateTime from, DateTime till);

        IRequestFactory WithDays(int days);

        IRequestFactory WithHours(TimeSpan hours);

        IRequestFactory WithRequesterComment(string comment);

        IRequestFactory WithApproverComment(string comment);

        IRequestFactory WithOptions(
            RequestType requestType,
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends);
    }
}
