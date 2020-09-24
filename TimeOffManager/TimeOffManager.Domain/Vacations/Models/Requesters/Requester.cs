namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common;
    using Common.Models;

    public class Requester : Entity<int>, IAggregateRoot
    {
        internal Requester(Employee employee, Team team)
        {
            this.Employee = employee;
            this.Team = team;
        }

        public Employee Employee { get; set; }

        public Team Team { get; set; }
    }
}