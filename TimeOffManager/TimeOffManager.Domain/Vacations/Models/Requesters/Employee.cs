﻿namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common.Models;

    public class Employee : Entity<int>
    {
        public Employee(
            string firstName,
            string lastName,
            string employeeId,
            string email,
            string imageUrl,
            Employee manager
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmployeeId = employeeId;
            this.Email = email;
            this.ImageUrl = imageUrl;
            this.Manager = manager;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmployeeId { get; private set; }

        public string Email { get; private set; }

        public string ImageUrl { get; private set; }

        public Employee Manager { get; private set; }
    }
}