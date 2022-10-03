using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    this.health = 0;
                }
                else if (value > this.BaseHealth)
                {
                    this.health = BaseHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => this.armor;
            set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag;

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            this.Armor -= hitPoints;
            double pointsForReduce = hitPoints - Armor;

            if (pointsForReduce > 0)
            {
                Health -= pointsForReduce;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }


        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}