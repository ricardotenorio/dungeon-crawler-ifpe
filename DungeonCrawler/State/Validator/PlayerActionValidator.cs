using DungeonCrawler.Enums;
using DungeonCrawler.GameObjects.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.State.Validator
{
    class PlayerActionValidator
    {
        public static bool CanMove(CharacterAction action, (int line, int column) characterPosition, int[,] floorState)
        {
            switch (action)
            {
                case CharacterAction.MoveLeft:
                    characterPosition.column -= 1;
                    break;
                case CharacterAction.MoveRight:
                    characterPosition.column += 1;
                    break;
                case CharacterAction.MoveUp:
                    characterPosition.line -= 1;
                    break;
                case CharacterAction.MoveDown:
                    characterPosition.line += 1;
                    break;
            }

            if (characterPosition.line < 0
                || characterPosition.line > 19
                || characterPosition.column < 0
                || characterPosition.column > 19)
            {
                return false;
            }

            if (floorState[characterPosition.line, characterPosition.column] == (int)GameObjectType.Monster
                || floorState[characterPosition.line, characterPosition.column] == (int)GameObjectType.Boss)
            {
                return false;
            }

            return true;
        }

        public static bool CanAttack((int line, int column) characterPosition, int[,] floorState)
        {

            if (
                characterPosition.line -1 >= 0 
                && (
                    floorState[characterPosition.line - 1, characterPosition.column] == (int)GameObjectType.Monster
                    || floorState[characterPosition.line - 1, characterPosition.column] == (int)GameObjectType.Boss
                   )
               )
            {
                return true;
            } 
            
            if (
                characterPosition.line + 1 <= 19
                && (
                    floorState[characterPosition.line + 1, characterPosition.column] == (int)GameObjectType.Monster
                    || floorState[characterPosition.line + 1, characterPosition.column] == (int)GameObjectType.Boss
                   )
               )
            {
                return true;
            }

            if (
                characterPosition.column - 1 >= 0
                && (
                    floorState[characterPosition.line, characterPosition.column - 1] == (int)GameObjectType.Monster
                    || floorState[characterPosition.line, characterPosition.column - 1] == (int)GameObjectType.Boss
                   )
               )
            {
                return true;
            }

            if (
                characterPosition.column + 1 <= 19
                && (
                    floorState[characterPosition.line, characterPosition.column + 1] == (int)GameObjectType.Monster
                    || floorState[characterPosition.line, characterPosition.column + 1] == (int)GameObjectType.Boss
                   )
               )
            {
                return true;
            }

            return false;
        }
    }
}
