namespace CarShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using CarShop.Models.Cars;
    using CarShop.Models.Users;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateCar(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model == null || model.Model.Length < CarModelMinLength || model.Model.Length > DefaultMaxLength )
            {
                errors.Add($"Model '{model.Model}' is not valid. It must be between {CarModelMinLength} and {DefaultMaxLength}.");
            }

            if (model.Year < CarYearMinValue || model.Year > CarYearMaxValue)
            {
                errors.Add($"Model '{model.Year}' is not valid. It must be between {CarYearMinValue} and {CarYearMaxValue}.");
            }

            if (model.Image == null || !Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image '{model.Image}' is not valid. It must be a valid url.");
            }

            if (model.PlateNumber == null || !Regex.IsMatch(model.PlateNumber, CarPlateNumberRegularExpression))
            {
                errors.Add($"Plate number '{model.PlateNumber}' is not valid.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (model.Email == null || !Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password == null || model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != null && model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            if (model.UserType != UserTypeClient && model.UserType != UserTypeMechanic)
            {
                errors.Add($"The user can be either a '{UserTypeClient}' or a '{UserTypeMechanic}'.");
            }

            return errors;
        }
    }
}
