namespace TimeOffManager.Infrastructure.Vacations
{
    using Common.Persistence;
    using Domain.Vacations.Models.Requesters;
    using Domain.Vacations.Models.Requests;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    internal interface IVacationsDbContext : IDbContext
    {
        DbSet<Request> Requests { get; }

        DbSet<RequestType> RequestTypes { get; }

        DbSet<Requester> Requesters { get; }

        DbSet<Team> Teams { get; }

        DbSet<User> Users { get; } // TODO: Temporary workaround
    }
}