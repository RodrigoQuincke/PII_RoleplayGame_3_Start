using System;
using System.Collections.Generic;

namespace Ucu.Poo.RolePlayGame
{
    public class Encounter
    {
        public void DoEncounter(List<Enemies> enemies, List<Heroes> heroes)
        {
            List<Heroes> aliveHeroes = new List<Heroes>(heroes);
            List<Enemies> aliveEnemies = new List<Enemies>(enemies);

            while (aliveHeroes.Count > 0 && aliveEnemies.Count > 0)
            {
                for (int i = 0; i < aliveEnemies.Count; i++)
                {
                    Heroes target = aliveHeroes[i % aliveHeroes.Count];
                    target.ReceiveAttack(aliveEnemies[i]);
                }

                aliveHeroes = aliveHeroes.FindAll(h => h.Health > 0);

                if (aliveHeroes.Count == 0)
                {
                    Console.WriteLine("Todos los heroes han sido derrotados.");
                    break;
                }

                foreach (Heroes hero in aliveHeroes)
                {
                    foreach (Enemies enemy in aliveEnemies)
                    {
                        if (enemy.Health > 0)
                        {
                            int healthBefore = enemy.Health;
                            enemy.ReceiveAttack(hero);
                            if (healthBefore > 0 && enemy.Health <= 0)
                            {
                                Console.WriteLine($"{enemy.Name} ha sido derrotado por {hero.Name}.");
                                hero.AddVictoryPoints(enemy);
                                if (hero.AccumulatedVictoryPoints >= 5)
                                    hero.Cure();
                            }
                        }
                    }
                }

                aliveEnemies = aliveEnemies.FindAll(e => e.Health > 0);
            }

            if (aliveEnemies.Count == 0)
                Console.WriteLine("Todos los enemigos han sido derrotados.");
        }
    }
}