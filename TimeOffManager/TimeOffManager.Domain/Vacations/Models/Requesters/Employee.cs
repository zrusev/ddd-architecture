namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using TimeOffManager.Domain.Common.Models;

    public class Employee : Entity<int>
    {
        internal Employee(
            string firstName,
            string lastName,
            string employeeId,
            string email,
            string imageUrl,
            Employee manager,
            Team team
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmployeeId = employeeId;
            this.Email = email;
            this.ImageUrl = imageUrl;

            this.Manager = manager;
            this.Team = team;
        }

        private Employee(
            string firstName,
            string lastName,
            string employeeId,
            string email,
            string imageUrl
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmployeeId = employeeId;
            this.Email = email;
            this.ImageUrl = imageUrl;

            this.Manager = default!;
            this.Team = default!;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmployeeId { get; private set; }

        public string Email { get; private set; }

        public string ImageUrl { get; private set; }

        public Employee? Manager { get; private set; }

        public Team? Team { get; private set; }
    }
}