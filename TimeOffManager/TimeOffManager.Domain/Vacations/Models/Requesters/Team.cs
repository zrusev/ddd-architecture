namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Common.Models;

    public class Team : Entity<int>
    {
        internal Team(
            string name, 
            string description
            ) 
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}