using DungeonCrawler.Generator;
using DungeonCrawler.State;
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
            //GameGenerator generator = new GameGenerator();
            //GameState state = generator.CreateGame();
            //IUserInterface ui = new TerminalUI();
            //Queue<string> msg = new Queue<string>();

            //Dictionary<string, int> stats = new Dictionary<string, int>();
            //stats.Add("hp", 25);
            //stats.Add("damage", 1);
            //stats.Add("score", 15);

            //msg.Enqueue("this is a test");
            //msg.Enqueue("another test");

            //ui.Draw(state.FloorState, stats, msg);


            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                Console.WriteLine("key pressed: " + key.Key.ToString());
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
