using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();

            string commandName = tokens[0];

            string[] arguments = args.Split().Skip(1).ToArray();

            Type assembly = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}Command");

            ICommand instance = (ICommand)Activator.CreateInstance(assembly);

            return instance.Execute(arguments);
        }
    }
}
