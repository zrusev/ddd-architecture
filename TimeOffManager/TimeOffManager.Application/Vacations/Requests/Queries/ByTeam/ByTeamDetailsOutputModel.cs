namespace TimeOffManager.Application.Vacations.Requests.Queries.ByTeam
{
    using Common.Mapping;
    using Domain.Vacations.Models.Requesters;
    using System.Collections.Generic;

    public class ByTeamDetailsOutputModel : IMapTo<Employee>
    {
        public ByTeamDetailsOutputModel(
            string firstName,
            string lastName,
            Employee manager,
            Team team,
            IEnumerable<ByTeamRequestDateDetailsModel> dates
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Manager = manager;
            this.Team = team;
            this.Dates = dates;
        }

        public ByTeamDetailsOutputModel()
        {
            this.FirstName = default!;
            this.LastName = default!;
            this.Manager = default!;
            this.Team = default!;
            this.Dates = default!;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Employee Manager { get; private set; }

        public Team Team { get; private set; }

        public IEnumerable<ByTeamRequestDateDetailsModel> Dates { get; private set; }
    }
}