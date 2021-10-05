using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Character.Playable
{
    class Hero : BasicCharacter
    {

        public Hero(int hp, int attackValue, (int, int) position) :
            base(hp, attackValue, position)
        { }

        public void RecoverHP(int recovery)
        {
            this.HP += recovery;
        }

        public void RaiseAttack(int attack)
        {
            this.AttackValue = attack;
        }

    }
}
