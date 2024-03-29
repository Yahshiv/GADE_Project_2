﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Game
{
    class ResourceBuilding : Building
    {
        //overridden fields
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
        
        public ResourceBuilding(int xPos, int yPos, string team) : base(xPos, yPos, 25, 1, team, 'P')//constructor
        {
            name = "Resource";
        }
        //overridden methods
        public override void Die()
        {
            sym = 'W';
        }

        public override string ToString()//neatly formatted output
        {
                return "Position: " + XPos + ", " + YPos + " | Health: " + Health + "/" + maxHealth + " | Team: " + Team + " | Resources: " + res + "/" + (resPool+res);
        }

        public void genRes()//generates resources (not inherited)
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

        public override Unit Work()//common method for buildings
        {
            genRes();
            return null;
        }

        public override string Save()//returns formatted building info to save
        {
            return xPos + "," + yPos + "," + team + "," + null + "," + health;
        }
    }
}
