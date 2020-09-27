namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using TimeOffManager.Domain.Common.Models;

    public class Employee : ValueObject
    {
        internal Employee(
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
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmployeeId { get; private set; }

        public string Email { get; private set; }

        public string ImageUrl { get; private set; }
    }
}