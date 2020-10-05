namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Domain.Common.Models;
    using System;
    using Vacations.Exceptions;
    using Vacations.Models.Shared;
    using static ModelConstants.Common;

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
            Employee? manager,
            Team? team
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

        public Employee UpdateFirstName(string firstName)
        {
            this.ValidateName(firstName, nameof(this.FirstName));
            this.FirstName = firstName;

            return this;
        }

        public Employee UpdateLastName(string lastName)
        {
            this.ValidateName(lastName, nameof(this.LastName));
            this.FirstName = lastName;

            return this;
        }

        public Employee UpdateEmployeeId(string employeeId)
        {
            this.ValidateEmployeeId(employeeId);
            this.EmployeeId = employeeId;

            return this;
        }

        public Employee UpdateEmail(string email)
        {
            this.ValidateEmail(email);

            this.Email = email;
            return this;
        }

        public Employee UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;

            return this;
        }

        public Employee UpdateHireDate(DateTime hireDate)
        {
            this.ValidateDate(hireDate, nameof(this.HireDate));
            this.HireDate = hireDate;

            return this;
        }

        public Employee UpdateLeaveDate(DateTime? leaveDate)
        {
            if (!(leaveDate == default(DateTime)))
            {
                this.HireDate = leaveDate;
            };

            return this;
        }

        public Employee UpdatePTOBalance(PTOBalance? balance)
        {
            if (balance is null)
            {
                this.PTOBalance = new PTOBalance(0, 0, 0);
            }
            else
            {
                this.PTOBalance = new PTOBalance(balance.Initial, balance.Current, balance.Updated);
            }

            return this;
        }

        public Employee UpdateManager(Employee? manager)
        {
            if (!(manager is null))
            {
                this.Manager = manager;
            }

            return this;
        }


        public Employee UpdateTeam(Team? team)
        {
            if (!(team is null))
            {
                this.Team = team;
            }

            return this;
        }

        private void ValidateDate(DateTime date, string property)
            => Guard.AgainstEmptyDateTime<InvalidRequesterException>(
                date,
                property);

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidRequesterException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidateEmail(string email)
            => Guard.ForStringLength<InvalidRequesterException>(
                email,
                MaxEmailLength,
                MaxEmailLength,
                nameof(this.Email));

        private void ValidateName(string name, string property)
            => Guard.ForStringLength<InvalidRequesterException>(
                name,
                MinNameLength,
                MaxNameLength,
                property);

        private void ValidateEmployeeId(string employeeId)
            => Guard.ForStringLength<InvalidRequesterException>(
                employeeId,
                EIDLength,
                EIDLength,
                nameof(this.EmployeeId));

    }
}