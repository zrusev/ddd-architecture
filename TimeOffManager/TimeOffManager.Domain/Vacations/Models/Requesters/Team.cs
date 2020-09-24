namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common.Models;
    
    public class Team : Entity<int>
    {
        internal Team(string name, Employee manager) 
        {
            this.Name = name;
            this.Manager = manager;
        }
        public string Name { get; set; }

        public Employee Manager { get; set; }
    }
}