namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class RequestTypeData : IInitialData
    {
        public Type EntityType => typeof(RequestType);

        public IEnumerable<object> GetData()
            => new List<RequestType>
            {
                new RequestType("Paid leave", "Paid leave description"),
                new RequestType("Other paid leave", "Other paid leave description"),
                new RequestType("Unpaid leave", "Unpaid leave description"),
                new RequestType("Sick leave - presented", "Sick leave - presented description"),
                new RequestType("Sick leave - not presented", "Sick leave - not presented description"),
                new RequestType("Compensation", "Compensation description"),
                new RequestType("Absent from work without notice/permission", "Absent from work without notice/permission description"),
                new RequestType("Matternity Leave", "Matternity Leave description"),
                new RequestType("Patternity Leave", "Patternity Leave description"),
                new RequestType("Holiday, Weekend", "Holiday, Weekend description"),
                new RequestType("Work from Home", "Work from Home description")
            };
    }
}
