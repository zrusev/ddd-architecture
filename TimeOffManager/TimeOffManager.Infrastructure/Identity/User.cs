namespace TimeOffManager.Infrastructure.Identity
{
    using Application.Identity;
    using Domain.Vacations.Exceptions;
    using Domain.Vacations.Models.Requesters;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public Requester? Requester { get; private set; }

        public void BecomeRequester(Requester requester)
        {
            if (this.Requester != null)
            {
                throw new InvalidRequesterException($"User '{this.UserName}' is already an requester.");
            }

            this.Requester = requester;
        }        
    }
}