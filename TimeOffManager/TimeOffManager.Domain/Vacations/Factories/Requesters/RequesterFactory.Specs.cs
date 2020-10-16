namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using FluentAssertions;
    using Models.Requests;
    using Xunit;

    public class RequesterFactorySpecs
    {
        [Fact]
        public void BuildShouldCreateRequesterWithoutManager()
        {
            // Assert
            var requesterFactory = new RequesterFactory();

            requesterFactory
                .WithFirstName("FirstName")
                .WithLastName("LastName")
                .WithEmployeeId("EID")
                .WithEmail("test@user.com")
                .WithImageUrl("https://photo.com")
                .WithPTOBalance(20, 20)
                .WithManager(null)
                .FromUser(Guid.NewGuid().ToString())
                .Build();

            // Assert
            requesterFactory.Should().NotBeNull();
        }

        [Fact]
        public void BuildShouldThrowExceptionWithoutTeam()
        {
            // Assert
            var requesterFactory = new RequesterFactory();

            Action act = () => requesterFactory
                .WithFirstName("FirstName")
                .WithLastName("LastName")
                .WithEmployeeId("EID")
                .WithEmail("test@user.com")
                .WithImageUrl("https://photo.com")
                .WithManager(null)
                .WithTeam(string.Empty)
                .FromUser(Guid.NewGuid().ToString())
                .Build();

            // Assert
            act.Should().Throw<InvalidTeamException>();
        }

        [Fact]
        public void BuildShouldCreateRequesterWithoutPTOBalance()
        {
            // Assert
            var requesterFactory = new RequesterFactory();

            requesterFactory
                .WithFirstName("FirstName")
                .WithLastName("LastName")
                .WithEmployeeId("EID")
                .WithEmail("test@user.com")
                .WithImageUrl("https://photo.com")
                .WithTeam("MyTeam")
                .WithPTOBalance(null, null)
                .WithManager(null)
                .FromUser(Guid.NewGuid().ToString())
                .Build();

            // Assert
            requesterFactory.Should().NotBeNull();
        }
    }
}
