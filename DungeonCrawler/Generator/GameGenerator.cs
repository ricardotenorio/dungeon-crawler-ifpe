using DungeonCrawler.AI;
using DungeonCrawler.GameObjects.Character;
using DungeonCrawler.GameObjects.Character.Enemy;
using DungeonCrawler.GameObjects.Character.Playable;
using DungeonCrawler.GameObjects.Item;
using DungeonCrawler.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Generator
{
    public class GameGenerator : IGameGenerator
    {
        private BasicCharacter _hero;
        private LinkedList<BasicItem> _items;
        private LinkedList<BasicCharacter> _enemies;
        private Random _random = new Random();

        public GameGenerator()
        {
            _items = new LinkedList<BasicItem>();
            _enemies = new LinkedList<BasicCharacter>();
        }

        public GameState CreateGame()
        {
            CreateHero();
            CreateItems();
            CreateEnemies();

            return new GameState
                (
                    hero: _hero,
                    items: _items,
                    enemies: _enemies
                );
        }

        private void CreateHero()
        {
            _hero = new Hero(hp: 25, attackValue: 1, position: (0, 0));
        }

        private void CreateItems()
        {
            for (int i = 0; i < 8; i++)
            {
                _items.AddLast
                    (
                    new Potion
                        (
                            effectValue: 6,
                            position: GetRandomPosition(0, 20)
                        )
                    );
            }

            _items.AddLast
                (
                new Weapon
                    (
                        effectValue: 1,
                        position: GetRandomPosition(0, 20)
                    )
                );
        }

        private void CreateEnemies()
        {
            IAI ai = new RandomAI();

            for (int i = 0; i < 6; i++)
            {
                _enemies.AddLast
                    (
                    new Monster
                        (
                        ai: ai,
                        hp: 5,
                        attackValue : 1,
                        position: GetRandomPosition(2, 18)
                        )
                    );
            }

            _enemies.AddLast
                (
                new Boss
                (
                    ai: ai, 
                    hp: 10, 
                    attackValue: 2, 
                    position: GetRandomPosition(2, 18)
                    )
                );
        }

        private (int, int) GetRandomPosition(int lower, int upper)
        {
            (int, int) position;
            int line = 0;
            int column = 0;
            bool isValid = false;

            while (!isValid)
            {
                line = _random.Next(lower, upper);
                column = _random.Next(lower, upper);

                isValid = ValidPosition((line, column));
            }

            position = (line, column);

            return position;
        }

        private bool ValidPosition((int, int) position)
        {
            if (position == (0, 0)
                || position == (19, 19))
            {
                return false;
            }

            foreach (var item in _items)
            {
                if (position == item.Position)
                {
                    return false;
                }
            }

            foreach (var enemy in _enemies)
            {
                if (position == enemy.Position)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
