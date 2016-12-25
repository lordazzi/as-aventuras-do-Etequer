namespace As_aventuras_do_ETEQUER
{
    partial class Videos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Videos));
            this.VideoPlace = new AxWMPLib.AxWindowsMediaPlayer();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.MSG = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlace)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoPlace
            // 
            this.VideoPlace.Enabled = true;
            this.VideoPlace.Location = new System.Drawing.Point(0, 0);
            this.VideoPlace.Name = "VideoPlace";
            this.VideoPlace.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VideoPlace.OcxState")));
            this.VideoPlace.Size = new System.Drawing.Size(800, 667);
            this.VideoPlace.TabIndex = 0;
            // 
            // Updater
            // 
            this.Updater.Enabled = true;
            this.Updater.Interval = 1;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // MSG
            // 
            this.MSG.AutoSize = true;
            this.MSG.BackColor = System.Drawing.Color.Black;
            this.MSG.ForeColor = System.Drawing.Color.Gold;
            this.MSG.Location = new System.Drawing.Point(12, 9);
            this.MSG.Name = "MSG";
            this.MSG.Size = new System.Drawing.Size(100, 13);
            this.MSG.TabIndex = 1;
            this.MSG.Text = "Carregando o video";
            // 
            // Videos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.MSG);
            this.Controls.Add(this.VideoPlace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Videos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "As aventuras do Etequer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Videos_KeyDown);
            this.Load += new System.EventHandler(this.Videos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer VideoPlace;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.Label MSG;
    }
}