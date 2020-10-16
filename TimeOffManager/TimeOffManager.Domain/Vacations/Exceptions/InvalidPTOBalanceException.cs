namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidPTOBalanceException : BaseDomainException
    {
        public const string NonExistingPTOBalance = "PTO Balance does not exists";

        public InvalidPTOBalanceException()
        {
        }

        public InvalidPTOBalanceException(string error) => this.Error = error;
    }
}
