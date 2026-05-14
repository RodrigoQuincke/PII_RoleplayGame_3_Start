using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Elves : Heroes
    {
        // Atributos:
        public SpellsBook SpellsBook { get; private set; } 

        public Elves(string name)
            : base(name, 50, 20, 300)
        {
            this.SpellsBook = new SpellsBook("Elves Book");
        }
    }
}