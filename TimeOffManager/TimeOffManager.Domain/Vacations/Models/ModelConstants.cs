namespace TimeOffManager.Domain.Vacations.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int EIDLength = 6;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
            public const int MaxDescriptionLength = 1000;
        }

        public class RequestType
        {
            public const int MaxNameLength = 50;
            public const int MaxDescriptionLength = 2000;
        }

        public class Request
        {
            public const int MaxCommentLength = 2000;
        }
    }
}
