using DungeonCrawler.GameObjects.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Item
{
    class Potion : IItem
    {
        public int EffectValue { get; private set; }

        public Potion(int effectValue)
        {
            this.EffectValue = effectValue;
        }

        public void ApplyEffect(IItemUser targetCharacter)
        {
            targetCharacter.RecoverHP(EffectValue);
        }
    }
}
