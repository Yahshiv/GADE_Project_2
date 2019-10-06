using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Game
{
    abstract class Unit
    {
        protected int xPos, yPos, health, maxHealth, speed, atk;
        protected string team;
        protected double range;
        protected char sym;
        protected bool isBattling, isDead;
        public static Random rnd = new Random();

        protected string name;

        public Unit(int xPos, int yPos, int health, int speed, int atk, double range, string team, char sym)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.maxHealth = health;
            this.speed = speed;
            this.atk = atk;
            this.range = range;
            this.team = team;
            this.sym = sym;
        }

        public abstract void Move(Unit target);
        public abstract void Attack(Unit targetUnit);
        public abstract bool IsInRange(Unit targetUnit);
        public abstract Unit SeekTarget(Unit[] units);
        public abstract void Die();
        public abstract override string ToString();

        public abstract int XPos { get; set; }
        public abstract int YPos { get; set; }
        public abstract int Health { get; set; }
        public abstract int MaxHealth { get; }
        public abstract int Speed { get; }
        public abstract string Team { get; }
        public abstract char Sym { get; }
        public abstract bool IsDead { get; }

        public abstract string Name { get; }

        public abstract string Save();
    }
}
