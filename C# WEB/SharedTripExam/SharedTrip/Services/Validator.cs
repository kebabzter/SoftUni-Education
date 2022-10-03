namespace SharedTrip.Services
{
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using static SharedTrip.Data.DataConstants;
    public class Validator : IValidator
    {

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }
        public ICollection<string> ValidateTrip(AddTripFormModel model, bool IsDateValid)
        {
            var errors = new List<string>();

            if (model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description is not valid. It must be between 0 and {DescriptionMaxLength} characters long.");
            }

            if (model.Seats > MaxSeats || model.Seats < MinSeats)
            {
                errors.Add($"Number of seats is not valid. It must be between {MinSeats} and {MaxSeats}.");
            }

            if (!IsDateValid)
            {
                errors.Add($"Date must be in the following format: {DateTimeFormat}.");
            }

            if (string.IsNullOrWhiteSpace(model.ImagePath) || !Regex.IsMatch(model.ImagePath, UrlRegularExpression))
            {
                errors.Add($"Invalid image path.");
            }

            return errors;
        }
    }
}
