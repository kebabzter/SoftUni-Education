namespace SMS.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;        
        public const int NamePassMaxLength = 20;
        public const int UsernameMinLength = 5;        
        
        public const int PasswordMinLength = 6;
        public const string UserEmailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //public const string DateTimeFormat = "dd.MM.yyyy HH:mm";

        //public const int MinSeats = 2;
        //public const int MaxSeats = 6;
        //public const string UrlRegex = @"^(http[s]?:\/\/(www\.)?|ftp:\/\/(www\.)?|www\.){1}([0-9A-Za-z-\.@:%_\+~#=]+)+((\.[a-zA-Z]{2,3})+)(\/(.)*)?(\?(.)*)?";
    }
}
