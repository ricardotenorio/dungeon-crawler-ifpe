using DungeonCrawler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Character
{
    public interface ICharacter
    {
        void TakeDamage(int damage);
        void Attack(ICharacter targetCharacter);
        void Move(CharacterAction action);
    }
}
