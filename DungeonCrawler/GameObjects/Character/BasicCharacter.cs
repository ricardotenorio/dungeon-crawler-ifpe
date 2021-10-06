using DungeonCrawler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameObjects.Character
{
    public abstract class BasicCharacter : ICharacter
    {
        public int HP { get; protected set; }
        public int AttackValue { get; protected set; }
        public (int Line, int Column) Position { get; protected set; }

        public BasicCharacter(int hp, int attackValue, (int, int) position)
        {
            this.HP = hp;
            this.AttackValue = attackValue;
            this.Position = position;
        }

        public virtual void Move(CharacterAction action)
        {
            switch (action)
            {
                case CharacterAction.MoveLeft:
                    Position = (Position.Line, Position.Column - 1);
                    break;
                case CharacterAction.MoveUp:
                    Position = (Position.Line - 1, Position.Column);
                    break;
                case CharacterAction.MoveRight:
                    Position = (Position.Line, Position.Column + 1);
                    break;
                case CharacterAction.MoveDown:
                    Position = (Position.Line + 1, Position.Column);
                    break;
            }
        }

        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
        }

        public virtual void Attack(ICharacter targetCharacter)
        {
            targetCharacter.TakeDamage(AttackValue);
        }
    }
}
