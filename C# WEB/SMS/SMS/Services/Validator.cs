using SMS.Data;
using SMS.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SMS.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > NamePassMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UsernameMinLength} and {NamePassMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegex))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < PasswordMinLength || model.Password.Length > NamePassMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {NamePassMaxLength} characters long.");
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
    }
}
