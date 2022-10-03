using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }

                string[] line = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = line[0];
                string pokemonName = line[1];
                string pokemonElement = line[2];
                int pokemonHealth = int.Parse(line[3]);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }
                trainers.Find(x => x.Name == trainerName).Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (command == "Fire" || command == "Water" || command == "Electricity")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        var trainer = trainers[i];

                        if (!trainer.Pokemons.Any(x => x.Element == command))
                        {
                            foreach (var item in trainer.Pokemons)
                            {
                                item.Health -= 10;
                            }
                        }
                        else
                        {
                            trainer.Badges++;
                        }
                    }
                    foreach (var trainer in trainers)
                    {
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }
            foreach (var item in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{item.Name} {item.Badges} {item.Pokemons.Count}");
            }
        }

    }
}

