using Git.Models.Repositories;
using Git.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Git.Services
{
    using static Git.Data.DataConstants;
    public class Validator : IValidator
    {
        public ICollection<string> ValidateRepository(RepositoryCreateFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length > RepositoryMaxLength || model.Name.Length < RepositoryMinLength)
            {
                errors.Add($"Name '{model.Name}' is not valid. It must be between {RepositoryMinLength} and {RepositoryMaxLength} characters long.");
            }

            if (model.RepositoryType != "Public" && model.RepositoryType != "Private")
            {
                errors.Add($"Repository type '{model.RepositoryType}' is not valid. The repository type must be either 'Public' or 'Private'");
            }

            return errors;
        }

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
    }
}
