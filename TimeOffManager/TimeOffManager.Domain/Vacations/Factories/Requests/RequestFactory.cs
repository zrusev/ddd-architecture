namespace TimeOffManager.Domain.Vacations.Factories.Requests
{
    using Models.Shared;
    using Models.Requests;
    using System;
    using System.Collections.Generic;

    public class RequestFactory : IRequestFactory
    {
        private DateTimeRange dateTimeRange = default!;
        private int days = default!;
        private HashSet<RequestDate> requestDates = default!;
        private int? approverId = default!;
        private string? requesterComment = default!;
        private string? approverComment = default!;
        private Options options = default!;
        private PTOBalance? pTOBalance = default!;

        public RequestFactory()
        {
            this.requestDates = new HashSet<RequestDate>(new RequestDateComparer());
        }

        public IRequestFactory WithApprover(int? approverId)
        {
            if (!(approverId is null))
            {
                this.approverId = approverId;
            }

            return this;
        }

        public IRequestFactory WithPTOBalance(PTOBalance balance)
        {
            this.pTOBalance = new PTOBalance(balance.Initial, balance.Current, balance.Updated);

            return this;
        }

        public IRequestFactory WithDays(DateTime start, DateTime end)
        {
            this.days = new DateTimeRange(start, end).DurationInDays();

            this.days++; //Include current

            return this;
        }

        public IRequestFactory WithOptions(
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends
            )
        {
            this.options = new Options(
                isApproved,
                isPlanning,
                excludeHolidays,
                excludeWeekends);

            return this;
        }

        public IRequestFactory WithPeriod(DateTime start, DateTime end)
        {
            this.dateTimeRange = new DateTimeRange(start, end);

            return this;
        }

        public IRequestFactory WithRequestDates(
            RequestType type,
            TimeSpan hours, 
            bool excludeHolidays, 
            bool excludeWeekends,
            List<DateTime> holidays,
            List<DateTime> alreadyRequestedDays
            )
        {
            var dates = this.dateTimeRange.ToList();

            for (int i = 0; i < dates.Count; i++)
            {
                var current = i;

                if (excludeWeekends && (dates[current].DayOfWeek == DayOfWeek.Saturday || dates[current].DayOfWeek == DayOfWeek.Sunday))
                {
                    this.days--;
                    continue;
                }

                if (excludeHolidays && holidays.Contains(dates[current]))
                {
                    this.days--;
                    continue;
                }

                if (alreadyRequestedDays.Contains(dates[current]))
                {
                    continue;
                }

                this.requestDates.Add(new RequestDate(type, dates[current], hours));
            }

            return this;
        }

        public IRequestFactory WithRequesterComment(string? comment)
        {
            this.requesterComment = comment;

            return this;
        }

        public IRequestFactory WithApproverComment(string? comment)
        {
            this.approverComment = comment;

            return this;
        }

        public Request Build()
            => new Request(
                this.dateTimeRange,
                this.days,
                this.requestDates,
                this.approverId,
                this.requesterComment,
                this.approverComment,
                this.options,
                this.pTOBalance
                );
    }
}