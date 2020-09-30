namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Domain.Common.Models;
    using System;
    using Vacations.Models.Shared;

    public class Employee : Entity<int>
    {
        internal Employee(
            string firstName,
            string lastName,
            string employeeId,
            string email,
            string imageUrl,
            DateTime? hireDate,
            DateTime? leaveDate,
            PTOBalance? pTOBalance,
            Employee manager,
            Team team
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmployeeId = employeeId;
            this.Email = email;
            this.ImageUrl = imageUrl;
            this.HireDate = hireDate;
            this.LeaveDate = leaveDate;

            this.PTOBalance = pTOBalance!;
            this.Manager = manager;
            this.Team = team;
        }

        private Employee(
            string firstName,
            string lastName,
            string employeeId,
            string email,
            string imageUrl,
            DateTime? hireDate,
            DateTime? leaveDate
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmployeeId = employeeId;
            this.Email = email;
            this.ImageUrl = imageUrl;
            this.HireDate = hireDate;
            this.LeaveDate = leaveDate;

            this.PTOBalance = default!;
            this.Manager = default!;
            this.Team = default!;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmployeeId { get; private set; }

        public string Email { get; private set; }

        public string ImageUrl { get; private set; }

        public DateTime? HireDate { get; private set; }

        public DateTime? LeaveDate { get; private set; }

        public PTOBalance? PTOBalance { get; private set; }

        public Employee? Manager { get; private set; }

        public Team? Team { get; private set; }
    }
}