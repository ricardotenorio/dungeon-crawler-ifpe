using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.UI
{
    interface IUserInterface
    {
        void Draw(int[,] floorState, Dictionary<string, int> heroStats, Queue<string> messages); 
    }
}
