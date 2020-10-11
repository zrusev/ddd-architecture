namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidRequestedDatesException : BaseDomainException
    {
        public InvalidRequestedDatesException()
        {
        }

        public InvalidRequestedDatesException(string error) => this.Error = error;
    }
}
