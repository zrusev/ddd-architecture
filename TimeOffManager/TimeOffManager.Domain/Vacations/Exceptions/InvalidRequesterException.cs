namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidRequesterException : BaseDomainException
    {
        public InvalidRequesterException()
        {
        }

        public InvalidRequesterException(string error) => this.Error = error;
    }
}
