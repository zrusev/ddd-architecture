namespace TimeOffManager.Domain.Vacations.Services
{
    using System.Collections.Generic;
    using Vacations.Models.Requests;
    using Vacations.Models.Shared;

    public interface ICurrentBalanceService
    {
        bool IsPaidLeaveType(string type);

        int Calculate(int currentBalance, HashSet<RequestDate> currentDates, IEnumerable<RequestDateDetailsModel> previousDates);
    }
}
