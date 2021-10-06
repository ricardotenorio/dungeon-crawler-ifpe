using DungeonCrawler.Manager;
using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            manager.StartGame();
        }
    }
}
