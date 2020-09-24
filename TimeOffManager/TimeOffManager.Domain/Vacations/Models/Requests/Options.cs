namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using Common.Models;

    public class Options : ValueObject
    {
        internal Options(
            RequestType requestType,
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends
            )
        {
            this.RequestType = requestType;
            this.IsApproved = isApproved;
            this.IsPlanning = isPlanning;
            this.ExcludeHolidays = excludeHolidays;
            this.ExcludeWeekends = excludeWeekends;
        }

        private Options(
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends
            )
        {
            this.RequestType = default!;
            this.IsApproved = isApproved;
            this.IsPlanning = isPlanning;
            this.ExcludeHolidays = excludeHolidays;
            this.ExcludeWeekends = excludeWeekends;
        }

        public RequestType RequestType { get; set; }

        public bool IsApproved { get; private set; }

        public bool IsPlanning { get; private set; }

        public bool ExcludeHolidays { get; private set; }

        public bool ExcludeWeekends { get; private set; }
    }
}