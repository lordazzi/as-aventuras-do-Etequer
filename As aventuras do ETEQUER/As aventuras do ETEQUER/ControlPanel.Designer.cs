namespace As_aventuras_do_ETEQUER
{
    partial class ControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.LoadBar = new System.Windows.Forms.ProgressBar();
            this.CARREGANDO_txt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Updater
            // 
            this.Updater.Interval = 1;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // LoadBar
            // 
            this.LoadBar.ForeColor = System.Drawing.Color.Red;
            this.LoadBar.Location = new System.Drawing.Point(34, 523);
            this.LoadBar.Name = "LoadBar";
            this.LoadBar.Size = new System.Drawing.Size(730, 42);
            this.LoadBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.LoadBar.TabIndex = 0;
            // 
            // CARREGANDO_txt
            // 
            this.CARREGANDO_txt.AutoSize = true;
            this.CARREGANDO_txt.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CARREGANDO_txt.ForeColor = System.Drawing.Color.Gold;
            this.CARREGANDO_txt.Location = new System.Drawing.Point(32, 412);
            this.CARREGANDO_txt.Name = "CARREGANDO_txt";
            this.CARREGANDO_txt.Size = new System.Drawing.Size(289, 67);
            this.CARREGANDO_txt.TabIndex = 1;
            this.CARREGANDO_txt.Text = "Carregando";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(307, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 72);
            this.label1.TabIndex = 2;
            this.label1.Text = "    As aventuras do Etequer\r\n               Versão TI\r\n\r\nCriador por Ricardo Azzi" +
                " Silva";
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CARREGANDO_txt);
            this.Controls.Add(this.LoadBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "As aventuras do ETEQUER";
            this.Click += new System.EventHandler(this.ControlPanel_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.ProgressBar LoadBar;
        private System.Windows.Forms.Label CARREGANDO_txt;
        private System.Windows.Forms.Label label1;
    }
}

