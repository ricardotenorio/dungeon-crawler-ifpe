using DungeonCrawler.Enums;
using DungeonCrawler.Generator;
using DungeonCrawler.State;
using DungeonCrawler.UI;
using DungeonCrawler.UI.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Manager
{
    class GameManager
    {
        private bool _continue = true;
        private GameState _state;
        private IUserInterface _ui;
        private Dictionary<ConsoleKey, CharacterAction> _actionsByInput = new Dictionary<ConsoleKey, CharacterAction>()
            {
                { ConsoleKey.A, CharacterAction.MoveLeft},
                { ConsoleKey.W, CharacterAction.MoveUp},
                { ConsoleKey.D, CharacterAction.MoveRight},
                { ConsoleKey.S, CharacterAction.MoveDown},
                { ConsoleKey.Spacebar, CharacterAction.Attack},
            };

        public void StartGame()
        {
            GameGenerator generator = new GameGenerator();
            _state = generator.CreateGame();
            _ui = new TerminalUI();

            while (_continue)
            {
                NextTurn();
            }
        }

        private void NextTurn()
        {
            bool validInput = false;
            _state.UpdateFloorState();
            _ui.Draw(_state.FloorState, _state.GetHeroStats(), _state.Messages);
            ConsoleKey key;

            do
            {
                key = PlayerInput();

                if (key == ConsoleKey.Escape)
                {
                    System.Environment.Exit(0);
                }

                validInput = _state.IsPlayerActionValid(_actionsByInput[key]);
            } while (!validInput);

            _state.ExecutePlayerAction(_actionsByInput[key]);            
        }

        private ConsoleKey PlayerInput()
        {
            return Console.ReadKey(true).Key;
        }
    }
}
