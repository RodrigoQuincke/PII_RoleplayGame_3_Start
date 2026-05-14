using System;

namespace Ucu.Poo.RolePlayGame
{
    public interface ICharacter
    {
        string Name { get; }
        int Health { get; }
        int GetTotalAttack();
        int GetTotalDefense();
        void ReceiveAttack(ICharacter attacker);
        void Cure();
    }
}