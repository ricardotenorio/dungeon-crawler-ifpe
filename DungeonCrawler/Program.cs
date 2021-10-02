using DungeonCrawler.UI;
using DungeonCrawler.UI.Terminal;
using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterface ui = new TerminalUI();
            int[,] state = new int[20, 20];
            Queue<string> msg = new Queue<string>();

            state[0, 0] = 1;
            state[1, 10] = 5;
            state[10, 1] = 4;
            state[15, 15] = 3;
            state[17, 11] = 2;
            state[19, 19] = 6;

            Dictionary<string, int> stats = new Dictionary<string, int>();
            stats.Add("hp", 25);
            stats.Add("damage", 1);
            stats.Add("score", 15);

            msg.Enqueue("this is a test");
            msg.Enqueue("another test");

            ui.Draw(state, stats, msg);

            Console.WriteLine(msg.Count);
        }
    }
}
