using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;

namespace Ucu.Poo.RolePlayGame
{
        
    public class Encounter
    {
        List<Heroes> aliveHeroes = new List<Heroes>();
        List<Enemies> aliveEnemies = new List<Enemies>();
        public void DoEncounter(List<Enemies> enemies, List<Heroes> heroes)
        {
            while (aliveHeroes.Count > 0 && aliveEnemies.Count > 0)
            {
                EnemiesAttack(enemies, heroes);
                foreach (Heroes hero in heroes)
                {
                    if (hero.Health > 0)
                        aliveHeroes.Add(hero);
                }

                if (aliveHeroes.Count == 0)
                {
                    Console.WriteLine("Todos los heroes han sido derrotados.");
                    break;
                }

                HeroesAttack(enemies, heroes);
                foreach (Enemies enemy in enemies)
                {
                    if (enemy.Health > 0)
                        aliveEnemies.Add(enemy);
                }
            }
            if (aliveEnemies.Count == 0)
            {
                Console.WriteLine("Todos los enemigos han sido derrotados.");
                return;
            }
        }
        private List<Heroes> EnemiesAttack(List<Enemies> enemies, List<Heroes> heroes)
        {
            int i = 0;
            foreach (Heroes hero in heroes)
            {
                hero.ReceiveAttack(enemies[i]);
                i++;
                if (i >= enemies.Count)
                    i = 0;
            }

            return heroes;
        }

        private List<Enemies> HeroesAttack(List<Enemies> enemies, List<Heroes> heroes)
        {
            int i = 0;
            foreach (Enemies enemy in enemies)
            {
                foreach (Heroes hero in aliveHeroes)
                {
                    enemy.ReceiveAttack(hero);
                    DefeatEnemy(enemy, hero);
                }
            }
            return enemies;
        }

        private void DefeatEnemy(Enemies enemy, Heroes hero)
        {
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"{enemy.Name} ha sido derrotado por {hero.Name}.");
                hero.AddVictoryPoints(enemy);
                if (hero.AccumulatedVictoryPoints >= 5)
                    hero.Cure();
            }
        }
    }
}