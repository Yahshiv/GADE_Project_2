using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Game
{
    class MeleeUnit : Unit
    {
        public MeleeUnit(int x, int y, string team) : base(x, y, 16, 1, 5, 1.9, team, 'M')
        {
            name = "Barbarian";
        }

        public override int XPos
        {
            get => xPos;
            set => xPos = value;
        }
        public override int YPos
        {
            get => yPos;
            set => yPos = value;
        }
        public override int Health
        {
            get => health;
            set => health = value;
        }

        public override int MaxHealth { get => maxHealth; }

        public override int Speed { get => speed; }

        public override string Team { get => team; }

        public override char Sym { get => sym; }

        public override bool IsDead { get => isDead; }


        public override void Attack(Unit target)
        {
            isBattling = true;
            target.Health -= atk;

            if (target.Health <= 0)
            {
                target.Die();
            }
        }

        public override void Die()
        {
            isDead = true;
            isBattling = false;
            sym = '~';
        }

        public override bool IsInRange(Unit target)
        {
            if (Math.Sqrt(Math.Pow(XPos - target.XPos, 2) + Math.Pow(YPos - target.YPos, 2)) <= range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Move(Unit target)
        {
            {
                if (Health >= maxHealth * 0.25)
                {
                    if (Math.Pow(XPos - target.XPos, 2) >= Math.Pow(YPos - target.YPos, 2))
                    {
                        if (XPos - target.XPos > 0)
                        {
                            XPos--;                            
                        }
                        else
                        {
                            XPos++;                            
                        }
                    }
                    else
                    {
                        if (YPos - target.YPos > 0)
                        {
                            YPos--;                            
                        }
                        else
                        {
                            YPos++;                            
                        }
                    }
                }
                else
                {
                    if (xPos == 0 && yPos == 0) //top left corner
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            yPos++;
                        }
                    }
                    else if (xPos == 0 && yPos == 19) //bottom left corner
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            yPos--;
                        }
                    }
                    else if (xPos == 19 && yPos == 19) //bottom right corner
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            xPos--;
                        }
                        else
                        {
                            yPos--;
                        }
                    }
                    else if (xPos == 19 && yPos == 0) //top right corner
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            xPos--;
                        }
                        else
                        {
                            yPos++;
                        }
                    }
                    else if (xPos == 0) //left edge
                    {
                        if (rnd.Next(0, 3) == 0)
                        {
                            xPos++;
                        }
                        else if (rnd.Next(0, 2) == 0)
                        {
                            yPos++;
                        }
                        else
                        {
                            yPos--;
                        }
                    }
                    else if (yPos == 0) //top edge
                    {
                        if (rnd.Next(0, 3) == 0)
                        {
                            yPos++; ;
                        }
                        else if (rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            xPos--;
                        }
                    }
                    else if (xPos == 19) //right edge
                    {
                        if (rnd.Next(0, 3) == 0)
                        {
                            xPos--;
                        }
                        else if (rnd.Next(0, 2) == 0)
                        {
                            yPos++;
                        }
                        else
                        {
                            yPos--;
                        }
                    }
                    else if (yPos == 19) //bottom edge
                    {
                        if (rnd.Next(0, 3) == 0)
                        {
                            yPos--;
                        }
                        else if (rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            xPos--;
                        }
                    }
                    else
                    {
                        if ((rnd.Next(0, 4) == 0))
                        {
                            yPos++;
                        }
                        else if (rnd.Next(0, 3) == 0)
                        {
                            yPos--;
                        }
                        else if (rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            xPos--;
                        }
                    }
                }
            }
        }

        public override Unit SeekTarget(Unit[] units)
        {
            double dist = int.MaxValue;
            double temp;
            Unit target = null;

            foreach (Unit u in units)
            {
                if (u == this || u.Team == team || u.IsDead)
                {
                    continue;
                }
                
                temp = Math.Sqrt(Math.Pow(XPos - u.XPos, 2) + Math.Pow(YPos - u.YPos, 2));

                if (temp < dist)
                {
                    dist = temp;
                    target = u;
                }
            }
            return target;
        }

        public override string ToString()
        {
                return "Name: " + name + "\nPosition: " + XPos + ", " + YPos + " | Health: " + Health + "/" + maxHealth + " | Speed: " + speed + " | Attack" + atk + " | Range: " + range + " | Team: " + Team;
        }

        public override string Name { get => name; }

        public override string Save()
        {
            return name[0]+","+xPos+","+yPos+","+health+","+team;
        }
    }
}
