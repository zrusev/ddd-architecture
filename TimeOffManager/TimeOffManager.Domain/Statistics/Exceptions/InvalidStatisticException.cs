namespace TimeOffManager.Domain.Statistics.Exceptions
{
    using Common;

    public class InvalidStatisticException : BaseDomainException
    {
        public InvalidStatisticException()
        {
        }

        public InvalidStatisticException(string error) => this.Error = error;
    }
}
