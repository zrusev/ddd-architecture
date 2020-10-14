namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using Common.Models;
    using Vacations.Exceptions;

    public class DateTimeRange : ValueObject
    {
        internal DateTimeRange(DateTime start, DateTime end)
        {
            this.ValidateDates(
                start, 
                end, 
                nameof(this.Start), 
                nameof(this.End));

            this.Start = start;
            this.End = end;
        }

        internal DateTimeRange(DateTime start, TimeSpan duration)
            : this(start, start.Add(duration))
        {
        }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public int DurationInMinutes()
            => (this.End - this.Start).Minutes;

        public int DurationInDays()
            => (this.End - this.Start).Days;

        public DateTimeRange NewEnd(DateTime newEnd)
            => new DateTimeRange(this.Start, newEnd);

        public DateTimeRange NewDuration(TimeSpan newDuration)
            => new DateTimeRange(this.Start, newDuration);

        public DateTimeRange NewStart(DateTime newStart)
            => new DateTimeRange(newStart, this.End);

        public static DateTimeRange CreateOneDayRange(DateTime day)
            => new DateTimeRange(day, day.AddDays(1));

        public static DateTimeRange CreateOneWeekRange(DateTime startDay)
            => new DateTimeRange(startDay, startDay.AddDays(7));

        public bool Overlaps(DateTimeRange dateTimeRange)
            => this.Start < dateTimeRange.End &&
            this.End > dateTimeRange.Start;

        public List<DateTime> ToList()
        {
            var dates = new List<DateTime>();
            
            for (var dt = this.Start; dt <= this.End; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }

        private void ValidateDate(DateTime date, string property)
            => Guard.AgainstEmptyDateTime<InvalidDateTimeException>(
                date,
                property);

        private void ValidateDates(DateTime start, DateTime end, string startProperty, string endProperty)
        {
            this.ValidateDate(start, startProperty);
            this.ValidateDate(start, endProperty);

            Guard.AgainstLaterDateTime<InvalidDateTimeException>(
                    start,
                    end,
                    startProperty,
                    endProperty);
        }
    }
}