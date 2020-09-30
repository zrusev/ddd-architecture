namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using Exceptions;
    using Models.Requesters;
    using Models.Shared;
    using System;

    public class RequesterFactory : IRequesterFactory
    {
        private string firstName = default!;
        private string lastName = default!;
        private string employeeId = default!;
        private string email = default!;
        private string imageUrl = default!;
        private DateTime? hireDate = default;
        private DateTime? leaveDate = default;
        private Employee manager = default!;
        private Team team = default!;
        private PTOBalance? pTOBalance = default!;

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

        public IRequesterFactory WithHireDate(DateTime? hireDate)
        {
            this.hireDate = hireDate;

            return this;
        }

        public IRequesterFactory WithLeaveDate(DateTime? leaveDate)
        {
            this.leaveDate = leaveDate;

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
        public IRequesterFactory WithPTOBalance(int? initial, int? current, int? updated = null)
        {
            this.pTOBalance = new PTOBalance(initial, current, updated);

            return this;
        }

        public Requester Build(
            string firstName,
            string lastName,
            string employeeId,
            string email,
            string imageUrl,
            DateTime? hireDate,
            DateTime? leaveDate,
            Employee manager,
            Team team,
            int? initial, 
            int? current
            )
            => this
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithEmployeeId(employeeId)
                .WithEmail(email)
                .WithImageUrl(imageUrl)
                .WithHireDate(hireDate)
                .WithLeaveDate(leaveDate)
                .WithManager(manager)
                .WithTeam(team)
                .WithPTOBalance(initial, current, null)
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
                            this.hireDate,
                            this.leaveDate,
                            this.pTOBalance,
                            this.manager,
                            this.team)
                        );
        }
    }
}