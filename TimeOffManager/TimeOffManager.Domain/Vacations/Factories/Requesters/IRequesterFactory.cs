﻿namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using Common;
    using Models.Requesters;

    public interface IRequesterFactory : IFactory<Requester>
    {
        IRequesterFactory WithFirstName(string firstName);

        IRequesterFactory WithLastName(string lastName);

        IRequesterFactory WithEmployeeId(string employeeId);

        IRequesterFactory WithEmail(string email);

        IRequesterFactory WithImageUrl(string imageUrl);

        IRequesterFactory WithManager(Employee manager);

        IRequesterFactory WithTeam(Team team);
    }
}
