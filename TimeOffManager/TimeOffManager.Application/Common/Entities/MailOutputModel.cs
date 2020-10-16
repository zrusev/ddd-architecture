namespace TimeOffManager.Application.Common.Entities
{
    public class MailOutputModel
    {
        public const string ApproveCommandRequestSubject = "Request approval";
        public const string ApproveCommandRequestBody = "Your request has been ";
        public const string CreateCommandRequestSubject = "Request approval";
        public const string CreateCommandRequestBody = "Please approve this request";

        public MailOutputModel(
            string name,
            string email,
            string subject,
            string body
            )
        {
            this.Name = name;
            this.Email = email;
            this.Subject = subject;
            this.Body = body;
        }

        public string Name { get; private set; } = default!;

        public string Email { get; private set; } = default!;
        
        public string Subject { get; private set; } = default!;
        
        public string Body { get; private set; } = default!;
    }
}