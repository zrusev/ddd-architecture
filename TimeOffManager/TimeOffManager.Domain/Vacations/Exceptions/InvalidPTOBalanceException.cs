namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidPTOBalanceException : BaseDomainException
    {
        public InvalidPTOBalanceException()
        {
        }

        public InvalidPTOBalanceException(string error) => this.Error = error;
    }
}
