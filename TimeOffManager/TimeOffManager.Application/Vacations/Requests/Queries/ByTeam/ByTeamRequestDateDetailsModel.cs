namespace TimeOffManager.Application.Vacations.Requests.Queries.ByTeam
{
    using Domain.Vacations.Services.Models;
    using System;

    public class ByTeamRequestDateDetailsModel : RequestDateDetailsModel
    {
        public ByTeamRequestDateDetailsModel(
            string typeName, 
            TimeSpan hours, 
            DateTime date
            ) 
            : base(typeName, date)
            => this.Hours = hours;
        
        public TimeSpan Hours { get; private set; }
    }
}