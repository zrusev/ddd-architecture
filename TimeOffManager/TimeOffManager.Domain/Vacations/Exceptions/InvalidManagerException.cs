namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidManagerException : BaseDomainException
    {
        public InvalidManagerException()
        {
        }

        public InvalidManagerException(string error) => this.Error = error;
    }
}