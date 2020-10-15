namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common;
    using Common.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Vacations.Events.Requests;
    using Vacations.Models.Requests;

    public class Requester : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Request> requests;

        internal Requester(
            string userId,
            Employee employee
            )
        {
            this.UserId = userId;
            this.Employee = employee;

            this.requests = new HashSet<Request>();
        }

        private Requester(string userId)
        {
            this.UserId = userId;
            this.Employee = default!;

            this.requests = new HashSet<Request>();
        }

        public string UserId { get; private set; }

        public Employee Employee { get; private set; }

        public IReadOnlyCollection<Request> Requests => this.requests.ToList().AsReadOnly();

        public void AddRequest(Request request)
            => this.requests.Add(request);
        
        public void ApproveRequest(int requestId, int currentBalance, int revisedBalance)
            => this.RaiseEvent(new RequestAddedEvent(requestId, currentBalance, revisedBalance));
        
        public void HasEmployee(Employee employee)
            => this.Employee = employee;

        public void UpdatePTOBalance(int? initial, int? current)
            => this.Employee.UpdatePTOBalance(initial, current);
    }
}