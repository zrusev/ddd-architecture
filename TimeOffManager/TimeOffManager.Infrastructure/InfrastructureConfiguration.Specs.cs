namespace TimeOffManager.Infrastructure
{
    using Application.Vacations.Requests.Queries;
    using AutoMapper;
    using Common.Events;
    using Common.Persistence;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;
    using Vacations;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<TimeOffManagerDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IVacationsDbContext>(provider => provider
                    .GetService<TimeOffManagerDbContext>())
                .AddTransient<IEventDispatcher, EventDispatcher>();

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IRequestQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}