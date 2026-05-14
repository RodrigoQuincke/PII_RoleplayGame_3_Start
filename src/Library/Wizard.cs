using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Ucu.Poo.RolePlayGame
{
    public class Wizard : Heroes
    {
        // Atributos:
        public Staff Staff { get; private set; } 
        public SpellsBook SpellsBook { get; private set; } 

        public Wizard(string name)
            : base(name,50, 80,150)  
        {
            this.Staff = new Staff("Staff", 30);
            this.SpellsBook = new SpellsBook("Wizards Book");

            this.Equipment.Add(this.Staff);
            this.Equipment.Add(this.SpellsBook);
        }
    }
}