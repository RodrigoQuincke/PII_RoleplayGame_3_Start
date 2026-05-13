using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Elves : Heroes
    {
        public SpellsBook SpellsBook { get; private set; }

        public Elves(string name)
            : base(name, 50, 20, 300)
        {
            this.SpellsBook = new SpellsBook("Elves Book");
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