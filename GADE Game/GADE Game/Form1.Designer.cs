namespace GADE_Game
{
    partial class GADEGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.tbNumUnits = new System.Windows.Forms.TextBox();
            this.tbInfo = new System.Windows.Forms.RichTextBox();
            this.lblRound = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.lblNumUnits = new System.Windows.Forms.Label();
            this.lblNumBuildings = new System.Windows.Forms.Label();
            this.tbNumBuildings = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(317, 269);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // tbNumUnits
            // 
            this.tbNumUnits.Location = new System.Drawing.Point(400, 244);
            this.tbNumUnits.Name = "tbNumUnits";
            this.tbNumUnits.Size = new System.Drawing.Size(73, 20);
            this.tbNumUnits.TabIndex = 2;
            this.tbNumUnits.Text = "0";
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(318, 31);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(156, 186);
            this.tbInfo.TabIndex = 3;
            this.tbInfo.Text = "<Unit Info for this Round>";
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(319, 12);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(52, 13);
            this.lblRound.TabIndex = 4;
            this.lblRound.Text = "Round: X";
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Location = new System.Drawing.Point(400, 269);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(75, 23);
            this.btnPauseResume.TabIndex = 5;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblNumUnits
            // 
            this.lblNumUnits.AutoSize = true;
            this.lblNumUnits.Location = new System.Drawing.Point(314, 246);
            this.lblNumUnits.Name = "lblNumUnits";
            this.lblNumUnits.Size = new System.Drawing.Size(86, 13);
            this.lblNumUnits.TabIndex = 6;
            this.lblNumUnits.Text = "Number of Units:";
            // 
            // lblNumBuildings
            // 
            this.lblNumBuildings.AutoSize = true;
            this.lblNumBuildings.Location = new System.Drawing.Point(314, 227);
            this.lblNumBuildings.Name = "lblNumBuildings";
            this.lblNumBuildings.Size = new System.Drawing.Size(104, 13);
            this.lblNumBuildings.TabIndex = 7;
            this.lblNumBuildings.Text = "Number of Buildings:";
            // 
            // tbNumBuildings
            // 
            this.tbNumBuildings.Location = new System.Drawing.Point(429, 223);
            this.tbNumBuildings.Name = "tbNumBuildings";
            this.tbNumBuildings.Size = new System.Drawing.Size(44, 20);
            this.tbNumBuildings.TabIndex = 8;
            this.tbNumBuildings.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(317, 296);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(400, 296);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // GADEGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 322);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbNumBuildings);
            this.Controls.Add(this.lblNumBuildings);
            this.Controls.Add(this.lblNumUnits);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.tbNumUnits);
            this.Controls.Add(this.btnStart);
            this.Name = "GADEGame";
            this.Text = "GADEGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbNumUnits;
        private System.Windows.Forms.RichTextBox tbInfo;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Label lblNumUnits;
        private System.Windows.Forms.Label lblNumBuildings;
        private System.Windows.Forms.TextBox tbNumBuildings;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}

