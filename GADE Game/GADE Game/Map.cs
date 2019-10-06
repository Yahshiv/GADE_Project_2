using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_Game
{
    class Map
    {
        static string[,] map = new string[GADEGame.MAPWIDTH, GADEGame.MAPHEIGHT];
        public static Unit[] units;
        static Building[] buildings;
        int numUnits, numBuildings;
        string[] teams = { "RED", "BLUE" };

        public Map(int numUnits, int numBuildings)
        {
            this.numUnits = numUnits;
            this.numBuildings = numBuildings;
            map = new string[GADEGame.MAPWIDTH, GADEGame.MAPHEIGHT];
            units = new Unit[numUnits];
            buildings = new Building[numBuildings];
            Randomize();
            UpdateMap();
        }

        public Unit[] Units
        {
            get { return units; }
        }

        public Building[] Buildings
        {
            get { return buildings; }
        }

        public void Randomize()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    map[x, y] = "~~";
                }
            }

            units = new Unit[numUnits];

            for (int i = 0; i < numUnits; i++)
            {
                int x = Unit.rnd.Next(0, GADEGame.MAPWIDTH);
                int y = Unit.rnd.Next(0, GADEGame.MAPHEIGHT);
                int teamID = Unit.rnd.Next(0, 2);
                int unitType = Unit.rnd.Next(0, 2);

                if (unitType == 0)
                {
                    do
                    {
                        x = Unit.rnd.Next(0, GADEGame.MAPWIDTH);
                        y = Unit.rnd.Next(0, GADEGame.MAPHEIGHT);
                    } while (map[x, y] != "~~");
                    units[i] = new MeleeUnit(x, y, teams[teamID]);

                    map[x, y] = "" + units[i].Team[0] + units[i].Sym;

                }
                else
                {                
                    do
                    {
                        x = Unit.rnd.Next(0, GADEGame.MAPWIDTH);
                        y = Unit.rnd.Next(0, GADEGame.MAPHEIGHT);
                    } while (map[x, y] != "~~");
                    units[i] = new RangedUnit(x, y, teams[teamID]);

                    map[x, y] = "" + units[i].Team[0] + units[i].Sym;
                }
            }

            for (int j = 0; j < numBuildings; j++)
            {
                int x = Unit.rnd.Next(0, GADEGame.MAPWIDTH);
                int y = Unit.rnd.Next(0, GADEGame.MAPHEIGHT);
                int teamID = Unit.rnd.Next(0, 2);
                int buildingType = Unit.rnd.Next(0, 2);

                if (buildingType == 0)
                {
                    string unitType;
                    int type = Unit.rnd.Next(0, 2);
                    if (type == 0)
                    {
                        unitType = "RangedUnit";
                    }
                    else
                    {
                        unitType = "MeleeUnit";
                    }

                    do
                    {
                        x = Unit.rnd.Next(0, GADEGame.MAPWIDTH);
                        y = Unit.rnd.Next(0, GADEGame.MAPHEIGHT);
                    } while (map[x, y] != "~~");
                    buildings[j] = new FactoryBuilding(x, y, teams[teamID], unitType);

                    map[x, y] = "" + buildings[j].Team[0] + buildings[j].Sym;
                }
                else
                {
                    do
                    {
                        x = Unit.rnd.Next(0, GADEGame.MAPWIDTH);
                        y = Unit.rnd.Next(0, GADEGame.MAPHEIGHT);
                    } while (map[x, y] != "~~");
                    buildings[j] = new ResourceBuilding(x, y, teams[teamID]);

                    map[x, y] = "" + buildings[j].Team[0] + buildings[j].Sym;
                }
            }
        }

        public string GetMapStr()
        {
            string mapStr = "";
            for(int row = 0; row < GADEGame.MAPHEIGHT; row++)
            {
                for(int col = 0; col < GADEGame.MAPWIDTH; col++)
                {
                    mapStr += map[col, row];
                }
                mapStr += "\n";
            }
            return mapStr;
        }

        public string UnitAtPos(int col, int row)
        {
            return map[col, row];
        }

        public void UpdateMap()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    map[x, y] = "~~";
                }
            }

            foreach (Unit u in units)
            {
                if (!u.IsDead)
                {
                    map[u.XPos, u.YPos] = "" + u.Team[0] + u.Sym;
                }
            }

            foreach (Building b in buildings)
            {
                map[b.XPos, b.YPos] = "" + b.Team[0] + b.Sym;
            }
        }

        public RichTextBox GetUnitInfo(RichTextBox tb)
        {
            tb.Text = "";
            foreach (Unit u in units)
            {
                if(!u.IsDead)
                {
                    tb.Text += u.ToString() + "\n";
                }             
            }
            return tb;
        }

        public RichTextBox GetBuildingInfo(RichTextBox tb)
        {
            tb.Text = "";
            foreach (Building b in buildings)
            {
                    tb.Text += b.ToString() + "\n";   
            }
            return tb;
        }

        public void SaveUnits()
        {
            FileStream input = new FileStream("SavedUnits.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(input);
            foreach(Unit u in units)
            {
                sw.WriteLine(u.Save());
            }
            sw.Close();
            input.Close();
        }

        public void SaveBuildings()
        {
            FileStream input = new FileStream("SavedBuildings.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(input);
            foreach (Building b in buildings)
            {
                sw.WriteLine(b.Save());
            }
            sw.Close();
            input.Close();
        }

        public void LoadUnits()
        {
            FileStream input = new FileStream("SavedUnits.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(input);
            string line = sr.ReadLine();
            string[] lines;

            units = new Unit[0];
            while(line != null)
            {
                lines = line.Split(',');
                string type = lines[0];
                int xPos = Convert.ToInt32(lines[1]);
                int yPos = Convert.ToInt32(lines[2]);
                int health = Convert.ToInt32(lines[3]);
                string team = lines[4];

                Array.Resize(ref units, units.Length + 1);

                if(type == "R")
                {
                    units[units.Length - 1] = new RangedUnit(xPos, yPos, team);
                }
                else
                {
                    units[units.Length - 1] = new MeleeUnit(xPos, yPos, team);
                }

                units[units.Length - 1].Health = health;

                line = sr.ReadLine();
            }
            UpdateMap();
        }

        public void LoadBuildings()
        {
            FileStream input = new FileStream("SavedBuildings.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(input);
            string line = sr.ReadLine();
            string[] lines;

            buildings = new Building[0];
            while (line != null)
            {
                lines = line.Split(',');
                int xPos = Convert.ToInt32(lines[0]);
                int yPos = Convert.ToInt32(lines[1]);
                string team = lines[2];
                int health = Convert.ToInt32(lines[4]);

                Array.Resize(ref buildings, buildings.Length + 1);

                if(lines[3] == null)//resource
                {
                    buildings[buildings.Length - 1] = new ResourceBuilding(xPos, yPos, team);
                }
                else//factory
                {
                    buildings[buildings.Length - 1] = new FactoryBuilding(xPos, yPos, team, lines[3]);
                }
                buildings[buildings.Length - 1].Health = health;
                line = sr.ReadLine();
            }
            UpdateMap();
        }
    }
}
