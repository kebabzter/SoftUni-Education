using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int,BankAccount> accounts = new Dictionary<int, BankAccount>();
           
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                string[] info = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(info[1]);
                switch (info[0])
                {
                    case "Create":
                        if (!accounts.ContainsKey(id))
                        {
                            BankAccount acc = new BankAccount();
                            acc.Id = id;
                            acc.Balance = 0;
                            accounts.Add(id,acc);
                        }
                        else
                        {
                            Console.WriteLine("Account already exists");
                        }
                        break;
                    case "Deposit":
                        if (accounts.ContainsKey(id))
                        {
                            accounts[id].Deposit(decimal.Parse(info[2]));
                        }
                        else
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        break;
                    case "Withdraw":
                        decimal amount = decimal.Parse(info[2]);
                        if (accounts.ContainsKey(id))
                        {
                            if (amount<=accounts[id].Balance)
                            {
                                accounts[id].Withdraw(amount);
                            }
                            else
                            {
                                Console.WriteLine("Insufficient balance");
                            } 
                        }
                        else
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        break;
                    case "Print":
                        if (accounts.ContainsKey(id))
                        {
                            Console.WriteLine(accounts[id].ToString());
                        }
                        else
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        break;
                }

            }
        }
    }
}
