namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using Domain.Common.Models;
    using System;

    public class NationalHolidays : Entity<int>
    {
        internal NationalHolidays(DateTime date)
        {
            this.Date = date;
        }

        public DateTime Date { get; private set; }
    }
}