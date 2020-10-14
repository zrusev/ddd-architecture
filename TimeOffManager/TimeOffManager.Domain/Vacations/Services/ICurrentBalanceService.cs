namespace TimeOffManager.Domain.Vacations.Services
{
    using System.Collections.Generic;
    using Vacations.Models.Requests;
    using Vacations.Services.Models;

    public interface ICurrentBalanceService
    {
        bool IsPaidLeaveType(string type);

        int Calculate(int currentBalance, HashSet<RequestDate> currentDates, IEnumerable<RequestDateDetailsModel> previousDates);
    }
}
