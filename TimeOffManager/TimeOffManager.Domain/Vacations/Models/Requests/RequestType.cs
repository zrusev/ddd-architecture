namespace TimeOffManager.Domain.Vacations.Models.Requests
{
    using Common.Models;

    public class RequestType : ValueObject
    {
        internal RequestType(
            string name,
            string description
            )
        {
            this.Name = name;
            this.Description = description;
        }

        private RequestType()
        {
            this.Name = default!;
            this.Description = default!;
        }

        public string Name { get; }

        public string Description { get; }
    }
}