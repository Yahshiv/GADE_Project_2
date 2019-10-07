using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_Game
{
    class GameEngine
    {
        Map map;
        bool end = false;
        string winner = "";
        int round = 0;

        public GameEngine(int numUnits, int numBuildings)
        {
            map = new Map(numUnits, numBuildings);
        }

        public bool End
        {
            get { return end; }
        }

        public string Winner
        {
            get { return winner; }
        }

        public int Round
        {
            get { return round; }
            set { round = value; }
        }

        public string GetMapStr
        {
            get { return map.GetMapStr(); }
        }

        public void Reset(int numUnits, int numBuildings)
        {
            map = new Map(numUnits, numBuildings);
            end = false;
            round = 0;
        }

        public void GameRound()//game loop
        {
            foreach(Unit u in map.Units)//unit turns
            {
                if(u.IsDead || round%u.Speed != 0)//skips turn if dead or not a valid turn based on speed
                {
                    continue;
                }
                
                Unit target = u.SeekTarget(map.Units);//finds closest unit

                if (target == null)//ends game if no target
                {
                    end = true;
                    winner = u.Team;
                    map.UpdateMap();
                    return;
                }

                if(u.Health > u.MaxHealth/4 && u.IsInRange(target))//if over 25% HP and in range, attack
                {
                    u.Attack(target);
                }
                else //otherwise, move to the target or run away
                {
                    u.Move(target);
                }
            }

            foreach(Building b in map.Buildings)//building turns
            {
                if(round%b.Speed != 0)//if its its turn
                {
                    continue;
                }

                Unit temp = b.Work();//do function
                if(temp != null)//if a unit was returned, resize the array and add that unit.
                {
                    Array.Resize(ref Map.units, map.Units.Length + 1);
                    Map.units[map.Units.Length - 1] = temp;
                }
            }

            map.UpdateMap();
            round++;
        }

        public RichTextBox GetInfo(RichTextBox tb)//returns unit and building info strings
        {
            tb.Text = map.GetUnitInfo(tb).Text + map.GetBuildingInfo(tb).Text;
            return tb;
        }

        public string UnitAtPos(int col, int row)//returns string info at position
        {
            return map.UnitAtPos(col, row);
        }

        public void SaveBuildings()//saves buildings
        {
            map.SaveBuildings();
        }

        public void SaveUnits()//saves units
        {
            map.SaveUnits();
        }

        public void LoadUnits()//loads units
        {
            map.LoadUnits();
        }

        public void LoadBuildings()//loads buildings
        {
            map.LoadBuildings();
        }
    }
}
