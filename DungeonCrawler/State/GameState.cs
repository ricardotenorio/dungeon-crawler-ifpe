using DungeonCrawler.Enums;
using DungeonCrawler.GameObjects.Character;
using DungeonCrawler.GameObjects.Character.Enemy;
using DungeonCrawler.GameObjects.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.State
{
    public class GameState
    {
        public int[,] FloorState { get; private set; }
        public BasicCharacter Hero { get; private set; }
        public LinkedList<BasicItem> Items { get; private set; }
        public LinkedList<BasicCharacter> Enemies { get; private set; }

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

            UpdateFloorState();
        }
        
        public void UpdateFloorState()
        {
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
    }
}
