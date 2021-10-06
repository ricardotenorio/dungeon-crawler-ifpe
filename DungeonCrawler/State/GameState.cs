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
            if (action == CharacterAction.Attack)
            {
                LinkedList<BasicCharacter> nearbyEnemies = ListNearbyEnemies();

                foreach (var enemy in nearbyEnemies)
                {
                    Hero.Attack(enemy);
                    Messages.Enqueue($"Caused {Hero.AttackValue} Damage to the enemy!");
                }

                RemoveDeadEnemies(nearbyEnemies);
            } 
            else
            {
                Hero.Move(action);
                Messages.Enqueue($"Moved to {Hero.Position}");
                CheckForItems();
            }

            Hero.TakeDamage(1);
        }

        public bool IsPlayerActionValid(CharacterAction action)
        {
            if (action == CharacterAction.Attack)
            {
                return PlayerActionValidator.CanAttack(Hero.Position, FloorState);
            }

            return PlayerActionValidator.CanMove(action, Hero.Position, FloorState);
        }

        public bool IsGameOver()
        {
            if (Hero.HP < 1)
            {
                Messages.Enqueue("You died");

                return true;
            }

            if (Hero.Position == (19, 19))
            {
                _score += Hero.HP;
                Messages.Enqueue("You escaped!");
                Messages.Enqueue($"Your score is {_score}");

                return true;
            }

            return false;
        }

        private void CheckForItems()
        {
            BasicItem? itemToRemove = null;

            foreach (var item in Items)
            {
                if (Hero.Position == item.Position)
                {
                    item.ApplyEffect(Hero as IItemUser);
                    itemToRemove = item;

                    Messages.Enqueue(
                        itemToRemove is Potion 
                        ? "You drank a potion" 
                        : "You grabbed a weapon"
                        );

                    break;
                }
            }

            Items.Remove(itemToRemove);
        }

        private void RemoveDeadEnemies(LinkedList<BasicCharacter> enemiesToCheck)
        {
            foreach (var enemy in enemiesToCheck)
            {
                if (enemy.HP < 1)
                {
                    Enemies.Remove(enemy);

                    if (enemy is Boss)
                    {
                        _score += 15;
                        Messages.Enqueue("You killed a boss");
                    }
                    else
                    {
                        _score += 5;
                        Messages.Enqueue("You killed a monster");
                    }
                }
            }
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
