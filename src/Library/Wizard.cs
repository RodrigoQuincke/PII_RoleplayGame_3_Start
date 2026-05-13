using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Ucu.Poo.RolePlayGame
{
    public class Wizard : Heroes
    {
        public Staff Staff { get; private set; }
        public SpellsBook SpellsBook { get; private set; }

        public Wizard(string name)
            : base(name,50, 80,150)  
        {
            this.Staff = new Staff("Staff", 30);
            this.SpellsBook = new SpellsBook("Wizards Book");
            this.Equipment.Add(this.Staff);
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
            total += this.SpellsBook.GetTotalAttack();
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
            total += this.SpellsBook.GetTotalDefense();
            return total;
        }
    }
}