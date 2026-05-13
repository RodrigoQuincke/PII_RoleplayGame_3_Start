namespace Ucu.Poo.RolePlayGame
{
    public abstract class Enemies : Character, IEnemies
    {
        public int VictoryPoints { get; private set; }

        protected Enemies(string name, int attackValue, int defenseValue, int initialHealth, int victoryPoints)
            : base(name, attackValue, defenseValue, initialHealth)
        {
            VictoryPoints = victoryPoints;
        }
    }
}