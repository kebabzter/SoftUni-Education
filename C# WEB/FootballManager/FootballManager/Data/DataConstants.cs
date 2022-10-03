namespace FootballManager.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int DefaultMaxLength = 20;

        public const int UserMinUsername = 5;
        public const int UserMinPassword = 5;
        public const int UserEmailMaxLength = 60;
        public const int UserEmailMinLength = 10;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int PlayerFullNameMinLength = 5;
        public const int PlayerFullNameMaxLength = 80;
        public const int PlayerDescriptionMaxLength = 200;
        public const int PlayerPositionMinLength = 5;
        public const int PlayerPositionMaxLength = 20;
        public const int PlayerEnduranceAndSpeedMax = 10;
        public const int PlayerEnduranceAndSpeedMin = 0;


        public const string UrlRegularExpression = @"^(http[s]?:\/\/(www\.)?|ftp:\/\/(www\.)?|www\.){1}([0-9A-Za-z-\.@:%_\+~#=]+)+((\.[a-zA-Z]{2,3})+)(\/(.)*)?(\?(.)*)?";
    }
}
