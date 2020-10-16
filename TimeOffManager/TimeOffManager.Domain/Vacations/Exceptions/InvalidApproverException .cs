namespace TimeOffManager.Domain.Vacations.Exceptions
{
    using Common;

    public class InvalidApproverException : BaseDomainException
    {
        public const string InvalidApproverTokenMessage = "Invalid approver token submitted.";
        public const string InvalidApproverMessage = "You are not allowed to approve this request.";
        public const string DuplicateApprovalMessage = "This request has already been approved.";

        public InvalidApproverException()
        {
        }

        public InvalidApproverException(string error) => this.Error = error;
    }
}
