using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Archer : Heroes
    {
        public Bow Bow { get; private set; }
        public Armor Armor { get; private set; }

        public Archer(string name)
            : base(name, 90, 30, 100)
        {
            this.Bow = new Bow("Bow", 40);
            this.Armor = new Armor("Armor", 50);
            this.Equipment.Add(this.Bow);
            this.Equipment.Add(this.Armor);
        }

    }
}