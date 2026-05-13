using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Goblin : Enemies
    {
        public Goblin(string name)
            :base(name, 30, 10, 50, 10)
        {
        }
    }
}