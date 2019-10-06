using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Game
{
    class ResourceBuilding : Building
    {
        public override int XPos { get => xPos; }

        public override int YPos { get => yPos; }

        public override int Health { get => health; set => health = value; }

        public override int MaxHealth { get => maxHealth; }

        public override string Team { get => team; }

        public override char Sym { get => sym; }

        public override int Speed { get => speed; }

        public override string Name { get => name; }

        string resType;
        int res = 0, resRate=6, resPool=100;

        public ResourceBuilding(int xPos, int yPos, string team) : base(xPos, yPos, 25, 1, team, 'P')
        {
            name = "Resource";
        }

        public override void Die()
        {
            sym = 'W';
        }

        public override string ToString()
        {
                return "Position: " + XPos + ", " + YPos + " | Health: " + Health + "/" + maxHealth + " | Team: " + Team + " | Resources: " + res + "/" + (resPool+res);
        }

        public void genRes()
        {
            if(resRate > resPool)
            {
                res += resPool;
                resPool = 0;
            }
            else
            {
                res += resRate;
                resPool -= resRate;
            }
        }

        public override Unit Work()
        {
            genRes();
            return null;
        }

        public override string Save()
        {
            return xPos + "," + yPos + "," + team + "," + null + "," + health;
        }
    }
}
