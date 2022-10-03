using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.Users
{
    public class UserViewModel
    {
        public string Username { get; init; }

        public IEnumerable<Product> Products { get; set; }
    }
}
