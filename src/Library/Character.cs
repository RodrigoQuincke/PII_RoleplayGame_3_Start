using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Character : ICharacter
    {
        public string Name {get; }
        public int AttackValue {get; } 
        protected int DefenseValue {get; }
        protected int InitialHealth {get; }
        public int Health {get; private set; }
        public List<IItem> Equipment { get; private set; }


        protected Character(string name, int attackValue, int defenseValue, int initialHealth)
        {
            this.Name = name;
            this.AttackValue = attackValue;
            this.DefenseValue = defenseValue;
            this.InitialHealth = initialHealth;
            this.Health = initialHealth;
            this.Equipment = new List<IItem>();
        }

        public void ReceiveAttack(ICharacter attacker)
        {
            int actualDamage = attacker.GetTotalAttack() - this.GetTotalDefense();
            if (actualDamage > 0)
            {
                this.Health -= actualDamage;
            }
        }

        public void Cure()
        {
            this.Health = this.InitialHealth;
        }

        public int GetTotalAttack()
        {
            int total = this.AttackValue;
            foreach (IItem item in this.Equipment)
            {
                if (item is IOffensiveItem)
                {
                    IOffensiveItem offensiveItem = (IOffensiveItem)item;
                    total += offensiveItem.AttackValue;
                }
            }
            return total;
        }

        public int GetTotalDefense()
        {
            int total = this.DefenseValue;
            foreach (IItem item in this.Equipment)
            {
                if (item is IDefensiveItem)
                {
                    IDefensiveItem defensiveItem = (IDefensiveItem)item;
                    total += defensiveItem.DefenseValue;
                }
            }
            return total;
        }
    }
}