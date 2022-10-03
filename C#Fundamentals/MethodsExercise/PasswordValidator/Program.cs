using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (!LengthPassword(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!ConsistLettersDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!HaveDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (LengthPassword(password) && ConsistLettersDigits(password)&&HaveDigits(password))
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool LengthPassword(string password)
        {
            if (password.Length>=6 &&password.Length<=10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ConsistLettersDigits(string password)
        {
            for (int i = 0; i <password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static bool HaveDigits(string password)
        {
            int countDigits = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    countDigits++;
                    if (countDigits==2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
