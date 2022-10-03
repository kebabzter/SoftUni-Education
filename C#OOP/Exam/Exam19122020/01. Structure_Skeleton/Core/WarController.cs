using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly List<Character> charParty;
		private readonly Stack<Item> itemPool;
		public WarController()
		{
			charParty = new List<Character>();
			itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
            switch (args[0])
            {
				case "Warrior":
					charParty.Add(new Warrior(args[1]));
					break;
                case "Priest":
					charParty.Add(new Priest(args[1]));
					break;
				default:
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType,args[0]));
				
            }
            return string.Format(SuccessMessages.JoinParty,args[1]);
		}

		public string AddItemToPool(string[] args)
		{
			switch (args[0])
			{
				case "HealthPotion":
					itemPool.Push(new HealthPotion());
					break;
				case "FirePotion":
					itemPool.Push(new FirePotion());
					break;
				default:
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, args[0]));

			}
			return string.Format(SuccessMessages.AddItemToPool, args[0]);
		
		}

		public string PickUpItem(string[] args)
		{
			Character character = charParty.FirstOrDefault(x=>x.Name==args[0]);
            if (character==null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty,args[0]));
            }
            if (itemPool.Count==0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item item = itemPool.Pop();
			character.Bag.AddItem(item);
			return string.Format(SuccessMessages.PickUpItem, character.Name,item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			Character character = charParty.FirstOrDefault(x => x.Name == args[0]);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			}
			Item item = character.Bag.GetItem(args[1]);
			
			item.AffectCharacter(character);
			return string.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			var character = charParty.OrderByDescending(x => x.IsAlive)
				.ThenByDescending(x=>x.Health);
            foreach (var item in character)
            {
				sb.AppendLine(string.Format(SuccessMessages.CharacterStats,item.Name,item.Health,item.BaseHealth,item.Armor,item.BaseArmor,item.IsAlive?"Alive":"Dead"));
            }
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			Character attacker = charParty.FirstOrDefault(x=>x.Name==args[0]);
			Character receiver = charParty.FirstOrDefault(x=>x.Name==args[1]);

            if (attacker==null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty,args[0]));
            }
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}

			Warrior warrior = attacker as Warrior;
			if (warrior==null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, args[0]));
			}
			warrior.Attack(receiver);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{args[0]} attacks {args[1]} for {attacker.AbilityPoints} hit points! {args[1]} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

			if (!receiver.IsAlive)
			{
				sb.AppendLine($"{receiver.Name} is dead!");
			}

			return sb.ToString().TrimEnd();

			//string output= string.Format(SuccessMessages.AttackCharacter,warrior.Name,receiver.Name,warrior.AbilityPoints,receiver.Name,receiver.Health,receiver.BaseHealth,receiver.Armor,receiver.BaseArmor);
   //         if (receiver.Health==0)
   //         {
			//	string temp = string.Format(SuccessMessages.AttackKillsCharacter,receiver.Name);
			//	output = $"{output}\n{temp}";
   //         }
			//return output;
		}

		public string Heal(string[] args)
		{
				Character healer = charParty.FirstOrDefault(x => x.Name == args[0]);
				Character receiver = charParty.FirstOrDefault(x => x.Name == args[1]);

				if (healer == null)
				{
					throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
				}
				if (receiver == null)
				{
					throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
				}

				Priest priest = healer as Priest;
				if (priest == null)
				{
					throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, args[0]));
				}

				return string.Format(SuccessMessages.HealCharacter, priest.Name, receiver.Name, priest.AbilityPoints, receiver.Name, receiver.Health);
		}
	}
}
