namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common.Models;
    using System.Collections.Generic;

    public class Team : Entity<int>
    {
        internal Team(
            string name, 
            Employee manager
            ) 
        {
            this.Name = name;
            this.Manager = manager;

            this.Members = new HashSet<Requester>();
        }

        private Team(
            string name
            )
        {
            this.Name = name;
            this.Manager = default!;

            this.Members = new HashSet<Requester>();
        }

        public string Name { get; private set; }

        public Employee Manager { get; private set; }

        public HashSet<Requester> Members { get; private set; }
    }
}