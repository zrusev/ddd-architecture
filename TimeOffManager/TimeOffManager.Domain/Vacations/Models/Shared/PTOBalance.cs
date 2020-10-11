namespace TimeOffManager.Domain.Vacations.Models.Shared
{
    using Domain.Common.Models;
    using System.Collections.Generic;

    public class PTOBalance : ValueObject
    {
        internal PTOBalance(
            int? initial,
            int? current,
            int? updated
            )
        {
            this.Initial = initial;
            this.Current = current;
            this.Updated = updated;
        }

        public int? Initial { get; private set; }

        public int? Current { get; private set; }

        public int? Updated { get; private set; }
    }
}