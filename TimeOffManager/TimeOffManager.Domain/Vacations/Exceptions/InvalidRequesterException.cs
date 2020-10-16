namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidRequesterException : BaseDomainException
    {
        public const string DuplicateRegistrationMessage = "Requester has already been registered.";
        public const string InvalidRequestMessage = "You cannot edit this requester.";

        public InvalidRequesterException()
        {
        }

        public InvalidRequesterException(string error) => this.Error = error;
    }
}
