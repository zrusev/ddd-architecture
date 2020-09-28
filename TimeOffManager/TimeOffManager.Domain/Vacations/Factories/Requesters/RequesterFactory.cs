namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using Models.Requesters;
    using Vacations.Exceptions;

    public class RequesterFactory : IRequesterFactory
    {
        private string firstName = default!;
        private string lastName = default!;
        private string employeeId = default!;
        private string email = default!;
        private string imageUrl = default!;
        private Employee manager = default!;
        private Team team = default!;

        private bool hasManagerFlag = false;
        private bool hasTeamFlag = false;

        public IRequesterFactory WithFirstName(string firstName)
        {
            this.firstName = firstName;

            return this;
        }

        public IRequesterFactory WithLastName(string lastName)
        {
            this.lastName = lastName;

            return this;
        }

        public IRequesterFactory WithEmployeeId(string employeeId)
        {
            this.employeeId = employeeId;

            return this;
        }

        public IRequesterFactory WithEmail(string email)
        {
            this.email = email;

            return this;
        }

        public IRequesterFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;

            return this;
        }

        public IRequesterFactory WithManager(Employee manager)
        {
            this.hasManagerFlag = true;
            this.manager = manager;

            return this;
        }

        public IRequesterFactory WithTeam(Team team)
        {
            this.hasTeamFlag = true;
            this.team = team;

            return this;
        }

        public Requester Build(
            string firstName,
            string lastName,
            string employeeId,
            string email,
            string imageUrl,
            Employee manager,
            Team team
            )
            => this
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithEmployeeId(employeeId)
                .WithEmail(email)
                .WithImageUrl(imageUrl)
                .WithManager(manager)
                .WithTeam(team)
                .Build();

        public Requester Build()
        {
            if (!this.hasManagerFlag || !this.hasTeamFlag)
            {
                throw new InvalidRequesterException("Manager and team must have a value.");
            }

            return new Requester(
                        new Employee(
                            this.firstName, 
                            this.lastName, 
                            this.employeeId, 
                            this.email, 
                            this.imageUrl,
                            this.manager,
                            this.team));
        }
    }
}