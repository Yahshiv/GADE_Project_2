using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Game
{
    abstract class Building
    {
        protected int xPos, yPos, health, maxHealth, speed;
        protected string team, name;
        protected char sym;

        public abstract void Die();
        public abstract override string ToString();

        public Building(int xPos, int yPos, int health, int speed, string team, char sym)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.maxHealth = health;
            this.speed = speed;
            this.team = team;
            this.sym = sym;
        }

        public abstract Unit Work();

        public abstract int XPos { get; }
        public abstract int YPos { get; }
        public abstract int Health { get; set; }
        public abstract int MaxHealth { get; }
        public abstract string Team { get; }
        public abstract char Sym { get; }
        public abstract int Speed { get; }

        public abstract string Name { get; }

        public abstract string Save();
    }
}
