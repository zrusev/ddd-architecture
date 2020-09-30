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

        public IRequestFactory WithApprover(int? approverId)
        {
            this.approverId = approverId;

            return this;
        }

        public IRequestFactory WithPTOBalance(int? initial, int? current, int? updated)
        {
            this.pTOBalance = new PTOBalance(initial, current, updated);

            return this;
        }

        public IRequestFactory WithDays(int days)
        {
            this.days = days;

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

        public IRequestFactory WithRequestDates(HashSet<RequestDate> requestDates)
        {
            this.requestDates = requestDates;

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