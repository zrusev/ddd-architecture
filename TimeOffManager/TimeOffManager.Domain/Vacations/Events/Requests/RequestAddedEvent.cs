﻿namespace TimeOffManager.Domain.Vacations.Events.Requests
{
    using Common;

    public class RequestAddedEvent : IDomainEvent
    {
        public RequestAddedEvent(int requestId, int currentBalance, int revisedBalance)
        {
            this.RequestId = requestId;
            this.CurrentBalance = currentBalance;
            this.RevisedBalance = revisedBalance;
        }

        public int RequestId { get; private set; }

        public int CurrentBalance { get; private set; }

        public int RevisedBalance { get; private set; }
    }
}