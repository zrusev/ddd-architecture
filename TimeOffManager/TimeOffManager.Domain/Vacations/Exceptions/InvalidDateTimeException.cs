namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidDateTimeException : BaseDomainException
    {
        public InvalidDateTimeException()
        {
        }

        public InvalidDateTimeException(string error) => this.Error = error;
    }
}
