using DungeonCrawler.GameObjects.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Item
{
    class Potion : BasicItem
    {

        public Potion(int effectValue, (int, int) position): base (effectValue, position)
        { }

        public override void ApplyEffect(IItemUser targetCharacter)
        {
            targetCharacter.RecoverHP(EffectValue);
        }
    }
}
