namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidEmployeeException : BaseDomainException
    {
        public InvalidEmployeeException()
        {
        }

        public InvalidEmployeeException(string error) => this.Error = error;
    }
}
