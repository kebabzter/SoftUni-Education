using SMS.Models.Users;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        //ICollection<string> ValidateTrip(AddTripFormModel model, bool date);
    }
}
