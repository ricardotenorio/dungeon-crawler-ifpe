using DungeonCrawler.GameObjects.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Item
{
    class Weapon : IItem
    {
        public int EffectValue { get; private set; }

        public Weapon(int effectValue)
        {
            this.EffectValue = effectValue;
        }

        public void ApplyEffect(IItemUser targetCharacter)
        {
            targetCharacter.RaiseAttack(EffectValue);
        }
    }
}
