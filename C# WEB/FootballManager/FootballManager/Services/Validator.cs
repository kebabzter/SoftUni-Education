namespace FootballManager.Services
{
    using FootballManager.ViewModels.Players;
    using FootballManager.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidatePlayer(AddPlayerFormModel player)
        {
            var errors = new List<string>();

            if (player.FullName == null || player.FullName.Length < PlayerFullNameMinLength || player.FullName.Length > PlayerFullNameMaxLength)
            {
                errors.Add($"Username '{player.FullName}' is not valid. It must be between {PlayerFullNameMinLength} and {PlayerFullNameMaxLength} characters long.");
            }

            if (string.IsNullOrWhiteSpace(player.ImageUrl) || !Regex.IsMatch(player.ImageUrl, UrlRegularExpression))
            {
                errors.Add($"Invalid image path.");
            }

            if (player.Position.Length > PlayerPositionMaxLength || player.Position.Length < PlayerPositionMinLength || player.Position == null)
            {
                errors.Add($"Position '{player.Position}' is not valid. It must be between {PlayerPositionMinLength} and {PlayerPositionMaxLength} characters long.");
            }

            if (player.Endurance > PlayerEnduranceAndSpeedMax || player.Endurance < PlayerEnduranceAndSpeedMin)
            {
                errors.Add($"Endurance '{player.Endurance}' is not valid. It must be between {PlayerEnduranceAndSpeedMin} and {PlayerEnduranceAndSpeedMax}.");
            }

            if (player.Speed > PlayerEnduranceAndSpeedMax || player.Speed < PlayerEnduranceAndSpeedMin)
            {
                errors.Add($"Speed '{player.Endurance}' is not valid. It must be between {PlayerEnduranceAndSpeedMin} and {PlayerEnduranceAndSpeedMax}.");
            }

            if (player.Description.Length > PlayerDescriptionMaxLength)
            {
                errors.Add($"Description is not valid. It must be between 0 and {PlayerDescriptionMaxLength}.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UserMinUsername || user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Email == null || user.Email.Length < UserEmailMinLength || user.Email.Length > UserEmailMaxLength)
            {
                errors.Add($"Username '{user.Email}' is not valid. It must be between {UserEmailMinLength} and {UserEmailMaxLength} characters long.");
            }

            if (user.Password == null || user.Password.Length < UserMinPassword || user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }


            return errors;
        }
    }
}
