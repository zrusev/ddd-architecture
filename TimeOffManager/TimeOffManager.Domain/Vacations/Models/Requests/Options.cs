namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using Common.Models;

    public class Options : ValueObject
    {
        internal Options(
            bool isApproved,
            bool isPlanning,
            bool excludeHolidays,
            bool excludeWeekends
            )
        {
            this.IsApproved = isApproved;
            this.IsPlanning = isPlanning;
            this.ExcludeHolidays = excludeHolidays;
            this.ExcludeWeekends = excludeWeekends;
        }
        public bool IsApproved { get; private set; }

        public bool IsPlanning { get; private set; }

        public bool ExcludeHolidays { get; private set; }

        public bool ExcludeWeekends { get; private set; }
    }
}