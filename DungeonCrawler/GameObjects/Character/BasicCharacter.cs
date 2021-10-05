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

        public virtual (int, int) Move()
        {
            throw new NotImplementedException();
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
