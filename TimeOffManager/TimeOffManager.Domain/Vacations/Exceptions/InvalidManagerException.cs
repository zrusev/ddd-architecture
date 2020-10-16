namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidManagerException : BaseDomainException
    {
        public const string NonExistingManger = "Manager does not exists";

        public InvalidManagerException()
        {
        }

        public InvalidManagerException(string error) => this.Error = error;
    }
}