using DungeonCrawler.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Character.Enemy
{
    public class Monster : BasicCharacter
    {
        public IAI AI { get; private set; }

        public Monster(IAI ai, int hp, int attackValue, (int, int) position): 
            base(hp, attackValue, position)
        {
            this.AI = ai;
        }

    }
}
