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
            _state.UpdateFloorState();
            _ui.Draw(_state.FloorState, _state.GetHeroStats(), _state.Messages);
            
            
        }

        private ConsoleKey PlayerInput()
        {
            return Console.ReadKey(true).Key;
        }
    }
}
