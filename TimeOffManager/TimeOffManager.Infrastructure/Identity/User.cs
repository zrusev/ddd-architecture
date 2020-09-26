namespace TimeOffManager.Infrastructure.Identity
{
    using Application.Identity;
    using Microsoft.AspNetCore.Identity;
    using TimeOffManager.Domain.Vacations.Models.Requesters;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public Requester? Requester { get; private set; }

        public void BecomeDealer(Requester requester)
        {
            if (this.Requester != null)
            {
                // throw new InvalidDealerException($"User '{this.UserName}' is already a requester.");
            }

            this.Requester = requester;
        }
    }
}
