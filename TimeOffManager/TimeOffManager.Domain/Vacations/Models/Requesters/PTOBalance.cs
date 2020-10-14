namespace TimeOffManager.Domain.Vacations.Models.Requesters
{
    using Domain.Common.Models;

    public class PTOBalance : ValueObject
    {
        internal PTOBalance(
            int? initial,
            int? current
            )
        {
            this.Initial = initial;
            this.Current = current;
        }

        public int? Initial { get; private set; }

        public int? Current { get; private set; }
    }
}