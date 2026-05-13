using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Knight : Heroes
    {
        public Sword Sword { get; private set; }
        public Shield Shield { get; private set; }
        public Armor Armor { get; private set; }

        public Knight(string name)
            : base(name, 150, 100, 300)
        {
            this.Sword = new Sword("Sword", 50);
            this.Shield = new Shield("Shield", 20);
            this.Armor = new Armor("Armor", 50);
            this.Equipment.Add(this.Sword);
            this.Equipment.Add(this.Shield);
            this.Equipment.Add(this.Armor);
        }
    }
}