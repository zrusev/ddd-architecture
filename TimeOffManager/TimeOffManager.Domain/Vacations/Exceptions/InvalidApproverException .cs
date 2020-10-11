namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidApproverException : BaseDomainException
    {
        public InvalidApproverException()
        {
        }

        public InvalidApproverException(string error) => this.Error = error;
    }
}
