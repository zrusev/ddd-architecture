namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using Common;
    using Common.Models;
    using System;
    using System.Collections.Generic;

    public class Request: Entity<int>, IAggregateRoot
    {
        internal Request(
            DateTimeRange dateTimeRange,
            int days,
            HashSet<RequestDate> requestDates,
            int? approverId,
            string? requesterComment,
            string? approverComment,
            Options options
            )
        {
            this.DateTimeRange = dateTimeRange;
            this.Days = days;
            this.RequestDates = requestDates;
            this.ApproverId = approverId;
            this.RequesterComment = requesterComment;
            this.ApproverComment = approverComment;
            this.Options = options;
        }

        private Request(
            int days,
            int? approverId,
            string? requesterComment,
            string? approverComment
            )
        {
            this.Days = days;
            this.ApproverId = approverId;
            this.RequesterComment = requesterComment;
            this.ApproverComment = approverComment;

            this.DateTimeRange = default!;
            this.RequestDates = new HashSet<RequestDate>();
            this.Options = default!;
        }

        public DateTime RequestedOn { get; } = DateTime.Now;

        public DateTime? RevisedOn { get; private set; }

        public DateTimeRange DateTimeRange { get; private set; }
        
        public int Days { get; private set; }

        public HashSet<RequestDate> RequestDates { get; private set; }

        public int? ApproverId { get; private set; }

        public string? RequesterComment { get; private set; }

        public string? ApproverComment { get; private set; }

        public Options Options { get; private set; }

        public Request UpdateOptions(
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends
            )
        {
            this.Options = new Options(
                isApproved,
                isPlanning,
                excludeHolidays,
                excludeWeekends);

            return this;
        }

        public Request UpdateApprover(int approverId)
        {
            this.ApproverId = approverId;

            return this;
        }

        public Request UpdateApproverComment(string? comment)
        {
            this.ApproverComment = comment;

            return this;
        }

        public Request UpdateIsApproved(bool isApproved)
        {
            this.Options = new Options(
                isApproved, 
                this.Options.IsPlanning, 
                this.Options.ExcludeHolidays, 
                this.Options.ExcludeWeekends);

            return this;
        }

        public Request UpdateRevisedOn(DateTime revisedOn)
        {
            this.RevisedOn = revisedOn;

            return this;
        }
    }
}