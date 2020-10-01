namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public class RequestDate : Entity<int>
    {
        private static readonly IEnumerable<RequestType> AllowedTypes
            = new RequestTypeData().GetData().Cast<RequestType>();

        internal RequestDate(
            RequestType requestType,
            DateTime date,
            TimeSpan hours
            )
        {
            this.RequestType = requestType;
            this.Date = date;
            this.Hours = hours;
        }

        private RequestDate()
        {
            this.RequestType = default!;
            this.Date = default!;
            this.Hours = default!;
        }

        public RequestType RequestType { get; private set; }

        public DateTime Date { get; private set; }

        public TimeSpan Hours { get; private set; }
    }

    public class RequestDateComparer : IEqualityComparer<RequestDate>
    {
        public bool Equals(RequestDate x, RequestDate y)
            => DateTime.Compare(x.Date, y.Date) == 0;
        
        public int GetHashCode([DisallowNull] RequestDate obj)
            => (obj.RequestType.Name.ToString() + obj.Date.ToString()).GetHashCode();
    }
}