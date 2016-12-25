namespace As_aventuras_do_ETEQUER
{
    partial class Chefe_Agustinho
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer BossMove;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chefe_Agustinho));
            this.Etequer = new System.Windows.Forms.PictureBox();
            this.Agustinho = new System.Windows.Forms.PictureBox();
            this.LifesFace = new System.Windows.Forms.PictureBox();
            this.Unis = new System.Windows.Forms.PictureBox();
            this.Dezes = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.LifeBAR = new System.Windows.Forms.PictureBox();
            this.LifeBar_BAckGround = new System.Windows.Forms.PictureBox();
            this.AgostioLifeBAR = new System.Windows.Forms.PictureBox();
            this.AgostioBG = new System.Windows.Forms.PictureBox();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.BarrerUp = new System.Windows.Forms.PictureBox();
            this.BarrerDown = new System.Windows.Forms.PictureBox();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.GameUpdater = new System.Windows.Forms.Timer(this.components);
            this.MissilMove = new System.Windows.Forms.Timer(this.components);
            this.fala = new System.Windows.Forms.Label();
            BossMove = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Etequer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agustinho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifesFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Unis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dezes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeBAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeBar_BAckGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgostioLifeBAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgostioBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrerUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrerDown)).BeginInit();
            this.SuspendLayout();
            // 
            // BossMove
            // 
            BossMove.Enabled = true;
            BossMove.Interval = 200;
            BossMove.Tick += new System.EventHandler(this.BossMove_Tick);
            // 
            // Etequer
            // 
            this.Etequer.Location = new System.Drawing.Point(12, 243);
            this.Etequer.Name = "Etequer";
            this.Etequer.Size = new System.Drawing.Size(47, 119);
            this.Etequer.TabIndex = 0;
            this.Etequer.TabStop = false;
            // 
            // Agustinho
            // 
            this.Agustinho.Location = new System.Drawing.Point(712, 215);
            this.Agustinho.Name = "Agustinho";
            this.Agustinho.Size = new System.Drawing.Size(76, 188);
            this.Agustinho.TabIndex = 1;
            this.Agustinho.TabStop = false;
            // 
            // LifesFace
            // 
            this.LifesFace.Location = new System.Drawing.Point(12, 12);
            this.LifesFace.Name = "LifesFace";
            this.LifesFace.Size = new System.Drawing.Size(55, 55);
            this.LifesFace.TabIndex = 14;
            this.LifesFace.TabStop = false;
            // 
            // Unis
            // 
            this.Unis.Location = new System.Drawing.Point(111, 17);
            this.Unis.Name = "Unis";
            this.Unis.Size = new System.Drawing.Size(32, 48);
            this.Unis.TabIndex = 13;
            this.Unis.TabStop = false;
            // 
            // Dezes
            // 
            this.Dezes.Location = new System.Drawing.Point(73, 17);
            this.Dezes.Name = "Dezes";
            this.Dezes.Size = new System.Drawing.Size(32, 48);
            this.Dezes.TabIndex = 12;
            this.Dezes.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(738, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(50, 50);
            this.ExitButton.TabIndex = 11;
            this.ExitButton.TabStop = false;
            // 
            // LifeBAR
            // 
            this.LifeBAR.BackColor = System.Drawing.Color.Lime;
            this.LifeBAR.Enabled = false;
            this.LifeBAR.Location = new System.Drawing.Point(163, 29);
            this.LifeBAR.Name = "LifeBAR";
            this.LifeBAR.Size = new System.Drawing.Size(500, 30);
            this.LifeBAR.TabIndex = 18;
            this.LifeBAR.TabStop = false;
            // 
            // LifeBar_BAckGround
            // 
            this.LifeBar_BAckGround.BackColor = System.Drawing.Color.Cyan;
            this.LifeBar_BAckGround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LifeBar_BAckGround.Location = new System.Drawing.Point(163, 29);
            this.LifeBar_BAckGround.Name = "LifeBar_BAckGround";
            this.LifeBar_BAckGround.Size = new System.Drawing.Size(500, 30);
            this.LifeBar_BAckGround.TabIndex = 17;
            this.LifeBar_BAckGround.TabStop = false;
            // 
            // AgostioLifeBAR
            // 
            this.AgostioLifeBAR.BackColor = System.Drawing.Color.Lime;
            this.AgostioLifeBAR.Enabled = false;
            this.AgostioLifeBAR.Location = new System.Drawing.Point(163, 539);
            this.AgostioLifeBAR.Name = "AgostioLifeBAR";
            this.AgostioLifeBAR.Size = new System.Drawing.Size(500, 30);
            this.AgostioLifeBAR.TabIndex = 20;
            this.AgostioLifeBAR.TabStop = false;
            // 
            // AgostioBG
            // 
            this.AgostioBG.BackColor = System.Drawing.Color.Cyan;
            this.AgostioBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AgostioBG.Location = new System.Drawing.Point(163, 539);
            this.AgostioBG.Name = "AgostioBG";
            this.AgostioBG.Size = new System.Drawing.Size(500, 30);
            this.AgostioBG.TabIndex = 19;
            this.AgostioBG.TabStop = false;
            // 
            // Avatar
            // 
            this.Avatar.Location = new System.Drawing.Point(12, 513);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(75, 75);
            this.Avatar.TabIndex = 21;
            this.Avatar.TabStop = false;
            // 
            // BarrerUp
            // 
            this.BarrerUp.BackColor = System.Drawing.Color.Black;
            this.BarrerUp.Enabled = false;
            this.BarrerUp.Location = new System.Drawing.Point(0, 75);
            this.BarrerUp.Name = "BarrerUp";
            this.BarrerUp.Size = new System.Drawing.Size(800, 5);
            this.BarrerUp.TabIndex = 22;
            this.BarrerUp.TabStop = false;
            // 
            // BarrerDown
            // 
            this.BarrerDown.BackColor = System.Drawing.Color.Black;
            this.BarrerDown.Enabled = false;
            this.BarrerDown.Location = new System.Drawing.Point(0, 495);
            this.BarrerDown.Name = "BarrerDown";
            this.BarrerDown.Size = new System.Drawing.Size(800, 5);
            this.BarrerDown.TabIndex = 23;
            this.BarrerDown.TabStop = false;
            // 
            // Updater
            // 
            this.Updater.Enabled = true;
            this.Updater.Interval = 1;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // GameUpdater
            // 
            this.GameUpdater.Enabled = true;
            this.GameUpdater.Interval = 1;
            this.GameUpdater.Tick += new System.EventHandler(this.GameUpdater_Tick);
            // 
            // MissilMove
            // 
            this.MissilMove.Enabled = true;
            this.MissilMove.Tick += new System.EventHandler(this.MissilMove_Tick);
            // 
            // fala
            // 
            this.fala.AutoSize = true;
            this.fala.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fala.Location = new System.Drawing.Point(159, 513);
            this.fala.Name = "fala";
            this.fala.Size = new System.Drawing.Size(290, 19);
            this.fala.TabIndex = 24;
            this.fala.Text = "Meu robo realmente tinha OverClock!";
            this.fala.Visible = false;
            // 
            // Chefe_Agustinho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.fala);
            this.Controls.Add(this.BarrerDown);
            this.Controls.Add(this.BarrerUp);
            this.Controls.Add(this.Avatar);
            this.Controls.Add(this.AgostioLifeBAR);
            this.Controls.Add(this.AgostioBG);
            this.Controls.Add(this.LifeBAR);
            this.Controls.Add(this.LifeBar_BAckGround);
            this.Controls.Add(this.LifesFace);
            this.Controls.Add(this.Unis);
            this.Controls.Add(this.Dezes);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Agustinho);
            this.Controls.Add(this.Etequer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Chefe_Agustinho";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "As aventuras do Etequer";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Chefe_Agustinho_IMC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Etequer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agustinho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifesFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Unis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dezes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeBAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeBar_BAckGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgostioLifeBAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgostioBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrerUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrerDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Etequer;
        private System.Windows.Forms.PictureBox Agustinho;
        private System.Windows.Forms.PictureBox LifesFace;
        private System.Windows.Forms.PictureBox Unis;
        private System.Windows.Forms.PictureBox Dezes;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.PictureBox LifeBAR;
        private System.Windows.Forms.PictureBox LifeBar_BAckGround;
        private System.Windows.Forms.PictureBox AgostioLifeBAR;
        private System.Windows.Forms.PictureBox AgostioBG;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.PictureBox BarrerUp;
        private System.Windows.Forms.PictureBox BarrerDown;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.Timer GameUpdater;
        private System.Windows.Forms.Timer MissilMove;
        private System.Windows.Forms.Label fala;
    }
}