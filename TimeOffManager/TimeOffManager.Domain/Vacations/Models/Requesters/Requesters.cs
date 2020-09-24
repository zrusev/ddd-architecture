namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common;
    using Common.Models;

    public class Requesters : Entity<int>, IAggregateRoot
    {
        internal Requesters(Employee requester, Team team)
        {
            this.Requester = requester;
            this.Team = team;
        }

        public Employee Requester { get; set; }

        public Team Team { get; set; }
    }
}