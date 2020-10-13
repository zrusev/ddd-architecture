namespace TimeOffManager.Application.Common.Entities
{
    public class MailOutputModel
    {
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