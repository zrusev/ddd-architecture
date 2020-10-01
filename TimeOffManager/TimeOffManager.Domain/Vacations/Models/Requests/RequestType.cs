namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using Common.Models;

    public class RequestType : Entity<int>
    {
        internal RequestType(
            string name,
            string description
            )
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }
    }
}