namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidRequestException : BaseDomainException
    {
        public const string InvalidRequestMessage = "Request with ID {0} could not be found.";

        public InvalidRequestException()
        {
        }

        public InvalidRequestException(string error) => this.Error = error;
    }
}
