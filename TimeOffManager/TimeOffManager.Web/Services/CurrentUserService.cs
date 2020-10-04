namespace TimeOffManager.Web.Services
{
    using System;
    using System.Security.Claims;
    using Application.Common.Contracts;
    using Microsoft.AspNetCore.Http;

    public class CurrentUserService : ICurrentUser
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            this.UserEmail = user.FindFirstValue(ClaimTypes.Name); 
        }

        public string UserId { get; }

        public string UserEmail { get; }
    }
}
