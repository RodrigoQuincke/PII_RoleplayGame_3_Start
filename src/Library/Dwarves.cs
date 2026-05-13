using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Ucu.Poo.RolePlayGame
{
    public class Dwarves : Heroes
    {
        public Axe Axe { get; private set; }
        public Shield Shield { get; private set; }
        public Helmet Helmet { get; private set; }

        public Dwarves(string name)
            : base(name, 70, 50, 400)
        {
            this.Axe = new Axe("Axe", 30);
            this.Helmet = new Helmet("Helmet", 15);
            this.Shield = new Shield("Shield", 20);
            this.Equipment.Add(this.Axe);
            this.Equipment.Add(this.Helmet);
            this.Equipment.Add(this.Shield);
        }
    }
}