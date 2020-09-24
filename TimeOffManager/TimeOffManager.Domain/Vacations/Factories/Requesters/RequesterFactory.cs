namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using Models.Requesters;

    public class RequesterFactory : IRequesterFactory
    {
        private Employee employee = default!;
        private Team team = default!;

        public IRequesterFactory WithEmployee(Employee employee)
        {
            this.employee = employee;
            
            return this;
        }

        public IRequesterFactory WithTeam(Team team)
        {
            this.team = team;

            return this;
        }

        public Requester Build()
            => new Requester(
                this.employee,
                this.team);

        public Requester Build(Employee employee, Team team)
            => this
                .WithEmployee(employee)
                .WithTeam(team)
                .Build();
    }
}