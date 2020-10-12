namespace TimeOffManager.Application.Vacations.Requests.Queries.ByTeam
{
    using System.Collections.Generic;
    
    public class ByTeamDetailsOutputModel
    {
        public ByTeamDetailsOutputModel()
        {
            this.Requesters = new List<List<DetailsOutputModel>>();
        }
        public List<List<DetailsOutputModel>> Requesters { get; set; } = default!;
    }
}
