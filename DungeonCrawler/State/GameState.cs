using DungeonCrawler.Enums;
using DungeonCrawler.GameObjects.Character;
using DungeonCrawler.GameObjects.Character.Enemy;
using DungeonCrawler.GameObjects.Item;
using DungeonCrawler.State.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.State
{
    public class GameState
    {
        private int _score = 0;
        public int[,] FloorState { get; private set; }
        public BasicCharacter Hero { get; private set; }
        public LinkedList<BasicItem> Items { get; private set; }
        public LinkedList<BasicCharacter> Enemies { get; private set; }
        public Queue<string> Messages { get; private set; }

        public GameState(
            BasicCharacter hero,
            LinkedList<BasicItem> items,
            LinkedList<BasicCharacter> enemies
            )
        {
            this.FloorState = new int[20, 20];
            this.Hero = hero;
            this.Items = items;
            this.Enemies = enemies;

            this.Messages = new Queue<string>();
        }

        public Dictionary<string, int> GetHeroStats()
        {
            return new Dictionary<string, int>()
            {
                { "hp", Hero.HP },
                { "damage", Hero.AttackValue },
                { "score", _score }
            };
        }
            
        public void UpdateFloorState()
        {
            FloorState = new int[20, 20];
            FloorState[19, 19] = (int) GameObjectType.Destination;

            foreach (var item in Items)
            {
                int itemType = 
                    item is Potion ?
                    (int)GameObjectType.Potion :
                    (int)GameObjectType.Weapon;

                FloorState[item.Position.Line, item.Position.Column] = itemType;
            }

            foreach (var enemy in Enemies)
            {
                int enemyType = 
                    enemy is Monster ? 
                    (int)GameObjectType.Monster : 
                    (int)GameObjectType.Boss;

                FloorState[enemy.Position.Line, enemy.Position.Column] = enemyType;
            }

            FloorState[Hero.Position.Line, Hero.Position.Column] = (int)GameObjectType.Hero;
        }

        public void ExecutePlayerAction(CharacterAction action)
        {
            if ((int)action == 4)
            {
                LinkedList<BasicCharacter> nearbyEnemies = ListNearbyEnemies();

                foreach (var enemy in nearbyEnemies)
                {
                    Hero.Attack(enemy);
                }
            } else
            {
                Hero.Move(action);
            }
        }

        public bool IsPlayerActionValid(CharacterAction action)
        {
            if ((int) action == 4)
            {
                return PlayerActionValidator.CanAttack(Hero.Position, FloorState);
            }

            return PlayerActionValidator.CanMove(action, Hero.Position, FloorState);
        }

        private LinkedList<BasicCharacter> ListNearbyEnemies()
        {
            LinkedList<BasicCharacter> nearbyEnemies = new LinkedList<BasicCharacter>();

            foreach (var enemy in Enemies)
            {
                if (Hero.Position.Line == enemy.Position.Line 
                    && Math.Abs(Hero.Position.Column - enemy.Position.Column) == 1
                    || Hero.Position.Column == enemy.Position.Column
                    && Math.Abs(Hero.Position.Line - enemy.Position.Line) == 1)
                {
                    nearbyEnemies.AddLast(enemy);
                }
            }

            return nearbyEnemies;
        }
    }
}
