namespace TimeOffManager.Application.Statistics.Hanlers
{
    using Common;
    using Domain.Vacations.Events.Requests;
    using Domain.Statistics.Repositories;
    using System.Threading.Tasks;

    public class RequestAddedEventHandler : IEventHandler<RequestAddedEvent>
    {
        private const string StatisticName = "BalanceRecords";

        private readonly IStatisticsDomainRepository statistics;

        public RequestAddedEventHandler(IStatisticsDomainRepository statistics)
            => this.statistics = statistics;

        public Task Handle(RequestAddedEvent domainEvent)
            => this.statistics.AddRecord(
                StatisticName,
                domainEvent.RequestId, 
                domainEvent.CurrentBalance, 
                domainEvent.RevisedBalance);
    }
}