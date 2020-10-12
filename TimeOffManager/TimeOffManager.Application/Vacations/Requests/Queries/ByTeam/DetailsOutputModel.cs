namespace TimeOffManager.Application.Vacations.Requests.Queries.ByTeam
{
    using System;

    public class DetailsOutputModel
    {
        public DetailsOutputModel(
            string firstName,
            string lastName,
            string typeName,
            DateTime date
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.TypeName = typeName;
            this.Date = date;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string TypeName { get; private set; }

        public DateTime Date { get; private set; }
    }
}
