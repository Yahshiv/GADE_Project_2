using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_Game
{
    public partial class GADEGame : Form
    {
        public const int MAPHEIGHT = 20;
        public const int MAPWIDTH = 20;
        const int TILEHEIGHT = 16;
        const int TILEWIDTH = 16;
        const int MAPXOFFSET = 9;
        const int MAPYOFFSET = 12;
        GameEngine engine;
        Timer timer;
        Button[,] btnMap = new Button[MAPWIDTH, MAPHEIGHT];

        public GADEGame()
        {
            InitializeComponent();

            for (int row = 0; row < MAPHEIGHT; row++)//y
            {
                for(int col = 0; col < MAPWIDTH; col++)//x
                {
                    Point p = new Point(TILEWIDTH * col + MAPXOFFSET - col, TILEHEIGHT * row + MAPYOFFSET - row);
                    Button btnTemp = new Button();
                    btnTemp.Location = p;
                    btnTemp.Height = TILEHEIGHT;
                    btnTemp.Width = TILEWIDTH;

                    btnMap[col, row] = btnTemp;
                    Controls.Add(btnMap[col, row]);
                }
            }

            engine = new GameEngine(Convert.ToInt32(tbNumUnits.Text), Convert.ToInt32(tbNumBuildings.Text));

            UpdateUI();

            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 1000;
            timer.Tick += Event;

            tbNumUnits.Text = "1";
        }

        private void Event(object sender, EventArgs e)
        {
            engine.GameRound();
            UpdateUI();

            if(engine.End)
            {
                timer.Stop();
                tbInfo.Text = engine.Winner + " TEAM WON!";
                btnStart.Text = "Start";
            }
        }

        private void UpdateUI()
        {
            for(int row = 0; row < GADEGame.MAPHEIGHT; row++)
            {
                for(int col = 0; col<GADEGame.MAPWIDTH; col++)
                {
                    btnMap[col, row].ForeColor = Color.Black;
                    btnMap[col, row].Text = "" + engine.UnitAtPos(col, row)[1];
                    if (engine.UnitAtPos(col, row)[1] != '~')
                    {
                        if (engine.UnitAtPos(col, row)[0] == 'R')
                        {
                            btnMap[col, row].BackColor = Color.Red;
                            btnMap[col, row].ForeColor = Color.White;
                        }
                        else if (engine.UnitAtPos(col, row)[0] == 'B')
                        {
                            btnMap[col, row].BackColor = Color.Blue;
                            btnMap[col, row].ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        btnMap[col, row].BackColor = Color.Beige;
                    }
                    btnMap[col, row].Font = new Font("Microsoft Sans Serif", 6);
                    btnMap[col, row].Padding = new Padding(0, 0, 0, 0);
                }
            }

            tbInfo = engine.GetInfo(tbInfo);
            lblRound.Text = "Round: " + engine.Round;
        }

        private void btnStartPause_Click(object sender, EventArgs e)//seperate into 2 toggling buttons Start/Stop and Pause/Resume
        {
            if(btnStart.Text == "Stop")
            {
                timer.Stop();
                btnStart.Text = "Start";
            }
            else
            {
                engine.Reset(Convert.ToInt32(tbNumUnits.Text), Convert.ToInt32(tbNumBuildings.Text));
                timer.Start();
                btnStart.Text = "Stop";
            } 
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(btnPauseResume.Text == "Resume")
            {
                timer.Start();
                btnPauseResume.Text = "Pause";
            }
            else
            {
                timer.Stop();
                btnPauseResume.Text = "Resume";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            engine.SaveUnits();
            engine.SaveBuildings();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            timer.Stop();
            btnPauseResume.Text = "Resume";
            engine.LoadUnits();
            engine.LoadBuildings();
            engine.Round = 0;
            UpdateUI();
        }
    }
}
