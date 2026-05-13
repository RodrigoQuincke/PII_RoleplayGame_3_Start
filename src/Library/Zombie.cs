using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Zombie : Enemies
    {
        public Zombie(string name)
            :base(name, 20, 5, 80, 15)
        {
        }
    }
}