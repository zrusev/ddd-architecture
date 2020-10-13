namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common.Models;

    public class Team : Entity<int>
    {
        internal Team(string name) 
            => this.Name = name;
        
        public string Name { get; private set; }
    }
}