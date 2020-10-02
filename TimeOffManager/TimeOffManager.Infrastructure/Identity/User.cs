namespace TimeOffManager.Infrastructure.Identity
{
    using Application.Identity;
    using Domain.Vacations.Models.Requesters;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public Requester? Requester { get; private set; }    
    }
}