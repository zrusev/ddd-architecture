﻿namespace TimeOffManager.Domain.Vacations.Services.Models
{
    using System;
    
    public class RequestDateDetailsModel
    {
        public RequestDateDetailsModel(
           string typeName,
           DateTime date)
        {
            this.TypeName = typeName;
            this.Date = date;
        }

        public string TypeName { get; private set; }

        public DateTime Date { get; private set; }
    }
}
