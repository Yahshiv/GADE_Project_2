using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Game
{
    class FactoryBuilding : Building
    {
        public override int XPos { get => xPos; }

        public override int YPos { get => yPos; }

        public override int Health { get => health; set => health = value; }

        public override int MaxHealth { get => maxHealth; }

        public override string Team { get => team; }

        public override char Sym { get => sym; }

        public override int Speed { get => speed; }

        public override string Name { get => name; }

        string unitType;
        int ySpawn;

        public FactoryBuilding(int xPos, int yPos, string team, string type) : base(xPos, yPos, 40, 4, team, 'B')
        {
            unitType = type;
            name = "Factory";
            if (YPos == GADEGame.MAPHEIGHT-1)
            {
                ySpawn = YPos - 1;
            }
            else
            {
                ySpawn = YPos + 1;
            }
        }

        public override void Die()
        {
            sym = 'W';
        }

        public override string ToString()
        {
                return "Position: " + XPos + ", " + YPos + " | Health: " + Health + "/" + maxHealth + " | Team: " + Team;
        }

        public Unit Spawn()
        {
            Unit u;

            if(unitType == "RangedUnit")
            {
                u = new RangedUnit(xPos, ySpawn, team);
            }
            else
            {
                u = new MeleeUnit(xPos, ySpawn, team);
            }

            return u;
        }

        public override Unit Work()
        {
            return Spawn();
        }

        public override string Save()
        {
            return xPos + "," + yPos + "," + team + "," + unitType + "," + health;
        }
    }
}
