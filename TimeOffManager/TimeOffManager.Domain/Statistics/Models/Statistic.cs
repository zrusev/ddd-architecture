namespace TimeOffManager.Domain.Statistics.Models
{
    using Common;
    using System.Collections.Generic;
    using System.Linq;

    public class Statistic : IAggregateRoot
    {
        private readonly HashSet<BalanceRecord> records;

        internal Statistic(string name, string description)
        {
            this.Name = name;
            this.Description = description;

            this.records = new HashSet<BalanceRecord>();
        }

        public IReadOnlyCollection<BalanceRecord> Records
            => this.records.ToList().AsReadOnly();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public void AddRecord(int requestId, int currentBalance, int revisedBalance)
        {
            this.records.Add(
                new BalanceRecord(
                    requestId, 
                    currentBalance, 
                    revisedBalance));
        }
    }
}