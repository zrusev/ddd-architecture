namespace TimeOffManager.Domain.Statistics.Models
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class StatisticData : IInitialData
    {
        public Type EntityType => typeof(Statistic);

        public IEnumerable<object> GetData()
            => new List<Statistic>
            {
                new Statistic("BalanceRecords", "Contains the PTO balance history on each approved request."),
            };
    }
}
