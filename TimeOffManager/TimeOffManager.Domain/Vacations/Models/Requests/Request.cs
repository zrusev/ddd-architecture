namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using Common;
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Request: Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<RequestType> AllowedTypes
            = new RequestTypeData().GetData().Cast<RequestType>();

        internal Request(
            DateTime from,
            DateTime till,
            int days,
            TimeSpan hours,
            string? requesterComment, 
            string? approverComment,
            Options options
            )
        {
            //TODO: Validations

            this.From = from;
            this.Till = till;
            this.Days = days;
            this.Hours = hours;
            this.RequesterComment = requesterComment;
            this.ApproverComment = approverComment;
            this.Options = options;
        }

        private Request(
            DateTime from,
            DateTime till,
            int days,
            TimeSpan hours,
            string? requesterComment,
            string? approverComment
            )
        {
            this.From = from;
            this.Till = till;
            this.Days = days;
            this.Hours = hours;
            this.RequesterComment = requesterComment;
            this.ApproverComment = approverComment;
            this.Options = default!;
        }

        public DateTime RequestedOn { get; } = DateTime.Now;

        public DateTime From { get; private set; }

        public DateTime Till { get; private set; }

        public int Days { get; private set; }

        public TimeSpan Hours { get; private set; }

        public string? RequesterComment { get; private set; }

        public string? ApproverComment { get; private set; }

        public Options Options { get; private set; }

        public Request UpdateOptions(
            RequestType requestType,
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends
            )
        {
            this.Options = new Options(
                requestType,
                isApproved,
                isPlanning,
                excludeHolidays,
                excludeWeekends);

            return this;
        }
    }
}