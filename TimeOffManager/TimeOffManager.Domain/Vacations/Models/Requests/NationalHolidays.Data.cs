namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class NationalHolidaysData : IInitialData
    {
        public Type EntityType => typeof(NationalHolidays);

        public IEnumerable<object> GetData()
            => new List<NationalHolidays>
            {
                new NationalHolidays(new DateTime(2020, 1, 1)),
                new NationalHolidays(new DateTime(2020, 3, 3)),
                new NationalHolidays(new DateTime(2020, 4, 17)),
                new NationalHolidays(new DateTime(2020, 4, 19)),
                new NationalHolidays(new DateTime(2020, 4, 20)),
                new NationalHolidays(new DateTime(2020, 5, 1)),
                new NationalHolidays(new DateTime(2020, 5, 6)),
                new NationalHolidays(new DateTime(2020, 5, 24)),
                new NationalHolidays(new DateTime(2020, 5, 25)),
                new NationalHolidays(new DateTime(2020, 9, 6)),
                new NationalHolidays(new DateTime(2020, 9, 22)),
                new NationalHolidays(new DateTime(2020, 12, 24)),
                new NationalHolidays(new DateTime(2020, 12, 25)),
                new NationalHolidays(new DateTime(2020, 12, 26))
            };
    }
}