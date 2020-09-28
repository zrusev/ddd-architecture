namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Team : Entity<int>
    {
        private readonly HashSet<Employee> members;
        
        internal Team(string name) 
        {
            this.Name = name;

            this.members = new HashSet<Employee>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<Employee> Members => this.members.ToList().AsReadOnly();
    }
}