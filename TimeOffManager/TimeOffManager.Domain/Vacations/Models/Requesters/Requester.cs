namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common;
    using Common.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Vacations.Models.Requests;

    public class Requester : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Request> requests;

        internal Requester(
            Employee employee,
            Employee manager, 
            Team team
            )
        {
            this.Employee = employee;
            this.Manager = manager;
            this.Team = team;

            this.requests = new HashSet<Request>();
        }

        private Requester()
        {
            this.Employee = default!;
            this.Manager = default!;
            this.Team = default!;

            this.requests = new HashSet<Request>();
        }

        public Employee Employee { get; private set; }

        public Employee Manager { get; private set; }
    
        public Team? Team { get; private set; }

        public IReadOnlyCollection<Request> Requests => this.requests.ToList().AsReadOnly();

        public void HasEmployee(Employee employee)
            => this.Employee = employee;

        public void HasManager(Employee manager)
            => this.Manager = manager;

        public void HasTeam(Team team)
            => this.Team = team;
    }
}