using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Character
{
    public interface IItemUser
    {
        void RecoverHP(int recovery);
        void RaiseAttack(int attack);
    }
}
