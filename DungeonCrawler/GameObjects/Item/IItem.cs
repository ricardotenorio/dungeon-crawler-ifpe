using DungeonCrawler.GameObjects.Character;
using DungeonCrawler.GameObjects.Character.Playable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Item
{
    interface IItem
    {
        void ApplyEffect(Hero targetCharacter);
    }
}
