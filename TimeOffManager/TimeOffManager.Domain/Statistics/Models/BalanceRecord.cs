namespace TimeOffManager.Domain.Statistics.Models
{
    using Common.Models;
    
    public class BalanceRecord : Entity<int>
    {
        internal BalanceRecord(int requestId, int currentBalance, int revisedBalance)
        {
            this.RequestId = requestId;
            this.CurrentBalance = currentBalance;
            this.RevisedBalance = revisedBalance;
        }

        private BalanceRecord()
        {
        }

        public int RequestId { get; private set; }

        public int CurrentBalance { get; private set; }

        public int RevisedBalance { get; private set; }
    }
}