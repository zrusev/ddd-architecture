namespace TimeOffManager.Domain.Vacations.Factories.Requests
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using FluentAssertions;
    using Models.Requests;
    using Xunit;

    public class RequestFactorySpecs
    {
        [Fact]
        public void BuildShouldCreateRequestWithoutApprover()
        {
            // Assert
            var requestFactory = new RequestFactory();

            // Act
            requestFactory
                .WithPeriod(new DateTime(2020, 10, 1), new DateTime(2020, 10, 3))
                .WithDays(new DateTime(2020, 10, 1), new DateTime(2020, 10, 3))
                .WithRequesterComment(string.Empty)
                .WithRequestDates(
                    new RequestType("WFH", "Work from home"),
                    new TimeSpan(8, 0, 0),
                    true,
                    true,
                    new List<DateTime>())
                .WithOptions(
                    false,
                    false,
                    true,
                    true)
                .WithApprover(null)
                .Build();

            // Assert
            requestFactory.Should().NotBeNull();
        }

        [Fact]
        public void BuildShouldThrowExceptionWithLaterStartDate()
        {
            // Assert
            var requestFactory = new RequestFactory();

            // Act
            Action act = () => requestFactory
                .WithPeriod(new DateTime(2020, 10, 1), new DateTime(2020, 9, 30))
                .WithDays(new DateTime(2020, 10, 1), new DateTime(2020, 10, 3))
                .WithRequesterComment(string.Empty)
                .WithRequestDates(
                    new RequestType("WFH", "Work from home"),
                    new TimeSpan(8, 0, 0),
                    true,
                    true,
                    new List<DateTime>())
                .WithOptions(
                    false,
                    false,
                    true,
                    true)
                .WithApprover(null)
                .Build();

            // Assert
            act.Should().Throw<InvalidDateTimeException>();
        }

        [Fact]
        public void BuildShouldCreateRequestWithoutOptions()
        {
            // Assert
            var requestFactory = new RequestFactory();

            // Act
            requestFactory
                .WithPeriod(new DateTime(2020, 11, 1), new DateTime(2020, 11, 2))
                .WithDays(new DateTime(2020, 10, 1), new DateTime(2020, 10, 3))
                .WithRequesterComment(string.Empty)
                .WithRequestDates(
                    new RequestType("WFH", "Work from home"),
                    new TimeSpan(8, 0, 0),
                    true,
                    true,
                    new List<DateTime>())
                .WithApprover(null)
                .Build();

            // Assert
            requestFactory.Should().NotBeNull();
        }
    }
}