using DungeonCrawler.GameObjects.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Item
{
    public abstract class BasicItem : IItem
    {
        public int EffectValue { get; private set; }
        public (int Line, int Column) Position { get; protected set; }

        public BasicItem(int effectValue, (int, int) position)
        {
            this.EffectValue = effectValue;
            this.Position = position;
        }

        public abstract void ApplyEffect(IItemUser targetCharacter);
    }
}
