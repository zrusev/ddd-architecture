namespace TimeOffManager.Domain.Vacations.Factories.Requests
{
    using Models.Requests;
    using System;

    public class RequestFactory : IRequestFactory
    {
        private DateTime from = default!;
        private DateTime till = default!;
        private int days = default!;
        private TimeSpan hours = default!;
        private string? requesterComment = default!;
        private string? approverComment = default!;
        private Options options = default!;


        public IRequestFactory WithDays(int days)
        {
            this.days = days;

            return this;
        }

        public IRequestFactory WithHours(TimeSpan hours)
        {
            this.hours = hours;

            return this;
        }

        public IRequestFactory WithOptions(
            RequestType requestType,
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends
            )
        {
            this.options = new Options(
                requestType,
                isApproved,
                isPlanning,
                excludeHolidays,
                excludeWeekends);

            return this;
        }

        public IRequestFactory WithPeriod(DateTime from, DateTime till)
        {
            this.from = from;
            this.till = till;

            return this;
        }

        public IRequestFactory WithRequesterComment(string comment)
        {
            this.requesterComment = comment;

            return this;
        }

        public IRequestFactory WithApproverComment(string comment)
        {
            this.approverComment = comment;

            return this;
        }

        public Request Build()
            => new Request(
                this.from,
                this.till,
                this.days,
                this.hours,
                this.requesterComment,
                this.approverComment,
                this.options);
    }
}
