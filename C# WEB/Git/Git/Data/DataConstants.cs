﻿namespace Git.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int DefaultMaxLength = 20;

        public const int UserMinUsername = 5;
        public const int UserMinPassword = 5;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int RepositoryMinLength = 3;
        public const int RepositoryMaxLength = 10;

        public const int DescriptionMinLength = 5;

        //public const int MaxSeats = 6;
        //public const int MinSeats = 2;
        //public const int DescriptionMaxLength = 80;

        //public const string DateTimeFormat = "dd.MM.yyyy HH:mm";

        //public const string UrlRegularExpression = @"^(http[s]?:\/\/(www\.)?|ftp:\/\/(www\.)?|www\.){1}([0-9A-Za-z-\.@:%_\+~#=]+)+((\.[a-zA-Z]{2,3})+)(\/(.)*)?(\?(.)*)?";
    }
}
