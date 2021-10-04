using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawler.Enums;

namespace DungeonCrawler.UI.Terminal
{
    class TerminalUI : IUserInterface
    {
        protected readonly string _border = "==============================================";
        
        protected readonly Dictionary<int, char> _tilesByState = new Dictionary<int, char>()
            {
                { (int) GameObjectType.Empty, '0' },
                { (int) GameObjectType.Hero, 'H' },
                { (int) GameObjectType.Monster, 'M' },
                { (int) GameObjectType.Boss, 'B' },
                { (int) GameObjectType.Potion, 'P' },
                { (int) GameObjectType.Weapon, 'W' },
                { (int) GameObjectType.Destination, 'D' },
            };

        protected readonly Dictionary<char, ConsoleColor> _colorsByTile = new Dictionary<char, ConsoleColor>()
            {
                { 'H', ConsoleColor.Cyan },
                { 'M', ConsoleColor.Red },
                { 'B', ConsoleColor.DarkRed },
                { 'P', ConsoleColor.Green },
                { 'W', ConsoleColor.Yellow },
                { 'D', ConsoleColor.Blue },
                { '0', ConsoleColor.Gray }
            };
        

        public void Draw(int[,] floorState, Dictionary<string, int> heroStats, Queue<string> messages)
        {
            Console.Clear();
            DrawStats(heroStats);
            DrawFloor(floorState);
            DrawCommandHints();
            DrawMessages(messages);
        }

        protected virtual void DrawStats(Dictionary<string, int> heroStats)
        {
            Console.WriteLine(_border);
            Console.Write($"Hero HP: {heroStats["hp"]} ");
            Console.Write($"Hero Damage: {heroStats["damage"]} ");
            Console.WriteLine($"Hero Score: {heroStats["score"]}");
            Console.WriteLine(_border);
        }

        protected virtual void DrawFloor(int[,] floorState)
        {
            char tile;

            for(int i = 0; i < floorState.GetLength(0); i++)
            {
                Console.Write("  ");
                for (int j = 0; j < floorState.GetLength(1); j++)
                {
                    tile = _tilesByState[floorState[i, j]];
                    Console.ForegroundColor = _colorsByTile[tile];

                    Console.Write(tile + " ");
                }

                Console.WriteLine();
            }
                
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        protected virtual void DrawCommandHints()
        {
            Console.WriteLine(_border);

            Console.Write($"[A] to move left.   ");
            Console.WriteLine($"[D] to move right.");

            Console.Write($"[W] to move up.     ");
            Console.WriteLine($"[S] to move down.");

            Console.Write($"[Space] to attack.  ");
            Console.WriteLine($"[Esc] to exit.");
            
            Console.WriteLine(_border);
        }

        protected virtual void DrawMessages(Queue<string> messages)
        {
            while (messages.Any())
            {
                Console.WriteLine(messages.Dequeue());
            }

            Console.WriteLine(_border);
        }
    }
}
