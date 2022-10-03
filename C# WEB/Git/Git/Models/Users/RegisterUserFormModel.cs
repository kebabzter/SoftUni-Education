﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models.Users
{
    public class RegisterUserFormModel
    {
        public string Username { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public string ConfirmPassword { get; init; }
    }
}
