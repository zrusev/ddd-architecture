namespace TimeOffManager.Domain.Vacations.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Vacations.Exceptions;
    using Vacations.Models.Requests;
    using Vacations.Models.Shared;

    public class CurrentBalanceService : ICurrentBalanceService
    {
        private const string BelowZeroBalanceMessage = "Balance cannot decrease below zero.";

        private static readonly IEnumerable<RequestType> AllowedTypes
            = new RequestTypeData().GetData().Cast<RequestType>();

        public bool IsPaidLeaveType(string type)
            => AllowedTypes.Any(t => t.Name == type) &&
               AllowedTypes.First().Name == type;

        public int Calculate(
            int currentBalance,
            HashSet<RequestDate> currentDates,
            IEnumerable<RequestDateDetailsModel> previousDates)
        {
            var balance = currentBalance;

            foreach (var date in currentDates)
            {
                var isCurrentPaidLeaveType = this.IsPaidLeaveType(date.RequestType.Name);
                
                var isPreviousPaidLeaveType = this.IsPaidLeaveType(previousDates
                    .Where(d => DateTime.Equals(d.Date, date.Date))
                    .Select(n => n.TypeName)
                    .SingleOrDefault());
                
                if (isCurrentPaidLeaveType && !isPreviousPaidLeaveType)
                    balance--;

                if (!isCurrentPaidLeaveType && isPreviousPaidLeaveType)
                    balance ++;

                if (balance < 0)
                    throw new InvalidPTOBalanceException(BelowZeroBalanceMessage);
            }

            return balance;
        }
    }
}