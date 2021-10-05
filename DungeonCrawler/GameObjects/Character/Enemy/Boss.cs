
using DungeonCrawler.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Character.Enemy
{
    class Boss : BasicCharacter
    {
        public IAI AI { get; private set; }

        public Boss(IAI ai, int hp, int attackValue, (int, int) position) :
            base(hp, attackValue, position)
        {
            this.AI = ai;
        }

    }
}
