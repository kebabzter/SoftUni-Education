using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
