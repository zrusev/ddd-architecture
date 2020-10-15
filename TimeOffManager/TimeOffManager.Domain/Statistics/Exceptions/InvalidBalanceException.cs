namespace TimeOffManager.Domain.Statistics.Exceptions
{
    using Common;

    public class InvalidBalanceException : BaseDomainException
    {
        public InvalidBalanceException()
        {
        }

        public InvalidBalanceException(string error) => this.Error = error;
    }
}
