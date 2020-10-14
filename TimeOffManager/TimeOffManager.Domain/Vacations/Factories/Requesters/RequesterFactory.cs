namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using Models.Requesters;
    using System;
    using Vacations.Exceptions;

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
        private string requesterUserId = default!;

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

        public IRequesterFactory WithManager(Employee? manager)
        {
            this.manager = manager!;

            return this;
        }

        public IRequesterFactory WithTeam(Team team)
        {
            this.team = team;

            return this;
        }

        public IRequesterFactory WithTeam(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new InvalidTeamException("Team name cannot be blank.");
            }

            this.team = new Team(name);

            return this;
        }

        public IRequesterFactory WithPTOBalance(int? initial, int? current)
        {
            this.pTOBalance = new PTOBalance(initial, current);

            return this;
        }

        public IRequesterFactory FromUser(string userId)
        {
            this.requesterUserId = userId;

            return this;
        }

        public Requester Build()
        {
            return new Requester(
                        this.requesterUserId,
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
                            this.team));
        }
    }
}