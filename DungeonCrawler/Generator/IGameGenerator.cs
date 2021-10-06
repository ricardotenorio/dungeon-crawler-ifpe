using DungeonCrawler.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Generator
{
    public interface IGameGenerator
    {
        GameState CreateGame();
    }
}
