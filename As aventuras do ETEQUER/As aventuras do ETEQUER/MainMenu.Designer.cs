namespace As_aventuras_do_ETEQUER
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.NovoJogo_LABEL = new System.Windows.Forms.Label();
            this.Configura_LABEL = new System.Windows.Forms.Label();
            this.Sair_LABEL = new System.Windows.Forms.Label();
            this.Placar_LABEL = new System.Windows.Forms.Label();
            this.novo_select = new System.Windows.Forms.PictureBox();
            this.placar_select = new System.Windows.Forms.PictureBox();
            this.opcoes_select = new System.Windows.Forms.PictureBox();
            this.sair_select = new System.Windows.Forms.PictureBox();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.sair_select2 = new System.Windows.Forms.PictureBox();
            this.opcoes_select2 = new System.Windows.Forms.PictureBox();
            this.placar_select2 = new System.Windows.Forms.PictureBox();
            this.novo_select2 = new System.Windows.Forms.PictureBox();
            this.ThemeMusic = new AxWMPLib.AxWindowsMediaPlayer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.novo_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.placar_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcoes_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sair_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sair_select2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcoes_select2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.placar_select2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.novo_select2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThemeMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(738, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(50, 50);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.TabStop = false;
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExitButton_MouseDown);
            this.ExitButton.MouseHover += new System.EventHandler(this.ExitButton_MouseHover);
            // 
            // NovoJogo_LABEL
            // 
            this.NovoJogo_LABEL.AutoSize = true;
            this.NovoJogo_LABEL.BackColor = System.Drawing.Color.DodgerBlue;
            this.NovoJogo_LABEL.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NovoJogo_LABEL.ForeColor = System.Drawing.Color.Gold;
            this.NovoJogo_LABEL.Location = new System.Drawing.Point(301, 259);
            this.NovoJogo_LABEL.Name = "NovoJogo_LABEL";
            this.NovoJogo_LABEL.Size = new System.Drawing.Size(118, 32);
            this.NovoJogo_LABEL.TabIndex = 3;
            this.NovoJogo_LABEL.Text = "INICIAR";
            // 
            // Configura_LABEL
            // 
            this.Configura_LABEL.AutoSize = true;
            this.Configura_LABEL.BackColor = System.Drawing.Color.DodgerBlue;
            this.Configura_LABEL.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Configura_LABEL.ForeColor = System.Drawing.Color.Gold;
            this.Configura_LABEL.Location = new System.Drawing.Point(299, 400);
            this.Configura_LABEL.Name = "Configura_LABEL";
            this.Configura_LABEL.Size = new System.Drawing.Size(131, 32);
            this.Configura_LABEL.TabIndex = 5;
            this.Configura_LABEL.Text = "OPÇÕES";
            // 
            // Sair_LABEL
            // 
            this.Sair_LABEL.AutoSize = true;
            this.Sair_LABEL.BackColor = System.Drawing.Color.DodgerBlue;
            this.Sair_LABEL.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sair_LABEL.ForeColor = System.Drawing.Color.Gold;
            this.Sair_LABEL.Location = new System.Drawing.Point(323, 466);
            this.Sair_LABEL.Name = "Sair_LABEL";
            this.Sair_LABEL.Size = new System.Drawing.Size(80, 32);
            this.Sair_LABEL.TabIndex = 6;
            this.Sair_LABEL.Text = "SAIR";
            // 
            // Placar_LABEL
            // 
            this.Placar_LABEL.AutoSize = true;
            this.Placar_LABEL.BackColor = System.Drawing.Color.DodgerBlue;
            this.Placar_LABEL.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Placar_LABEL.ForeColor = System.Drawing.Color.Gold;
            this.Placar_LABEL.Location = new System.Drawing.Point(299, 330);
            this.Placar_LABEL.Name = "Placar_LABEL";
            this.Placar_LABEL.Size = new System.Drawing.Size(128, 32);
            this.Placar_LABEL.TabIndex = 7;
            this.Placar_LABEL.Text = "PLACAR";
            // 
            // novo_select
            // 
            this.novo_select.BackColor = System.Drawing.Color.DodgerBlue;
            this.novo_select.Location = new System.Drawing.Point(157, 256);
            this.novo_select.Name = "novo_select";
            this.novo_select.Size = new System.Drawing.Size(35, 35);
            this.novo_select.TabIndex = 8;
            this.novo_select.TabStop = false;
            // 
            // placar_select
            // 
            this.placar_select.BackColor = System.Drawing.Color.DodgerBlue;
            this.placar_select.Location = new System.Drawing.Point(157, 327);
            this.placar_select.Name = "placar_select";
            this.placar_select.Size = new System.Drawing.Size(35, 35);
            this.placar_select.TabIndex = 10;
            this.placar_select.TabStop = false;
            // 
            // opcoes_select
            // 
            this.opcoes_select.BackColor = System.Drawing.Color.DodgerBlue;
            this.opcoes_select.Location = new System.Drawing.Point(157, 397);
            this.opcoes_select.Name = "opcoes_select";
            this.opcoes_select.Size = new System.Drawing.Size(35, 35);
            this.opcoes_select.TabIndex = 11;
            this.opcoes_select.TabStop = false;
            // 
            // sair_select
            // 
            this.sair_select.BackColor = System.Drawing.Color.DodgerBlue;
            this.sair_select.Location = new System.Drawing.Point(157, 463);
            this.sair_select.Name = "sair_select";
            this.sair_select.Size = new System.Drawing.Size(35, 35);
            this.sair_select.TabIndex = 12;
            this.sair_select.TabStop = false;
            // 
            // Updater
            // 
            this.Updater.Interval = 75;
            this.Updater.Tick += new System.EventHandler(this.GameUpdater_Tick);
            // 
            // sair_select2
            // 
            this.sair_select2.BackColor = System.Drawing.Color.DodgerBlue;
            this.sair_select2.Location = new System.Drawing.Point(560, 463);
            this.sair_select2.Name = "sair_select2";
            this.sair_select2.Size = new System.Drawing.Size(35, 35);
            this.sair_select2.TabIndex = 17;
            this.sair_select2.TabStop = false;
            // 
            // opcoes_select2
            // 
            this.opcoes_select2.BackColor = System.Drawing.Color.DodgerBlue;
            this.opcoes_select2.Location = new System.Drawing.Point(560, 397);
            this.opcoes_select2.Name = "opcoes_select2";
            this.opcoes_select2.Size = new System.Drawing.Size(35, 35);
            this.opcoes_select2.TabIndex = 16;
            this.opcoes_select2.TabStop = false;
            // 
            // placar_select2
            // 
            this.placar_select2.BackColor = System.Drawing.Color.DodgerBlue;
            this.placar_select2.Location = new System.Drawing.Point(560, 327);
            this.placar_select2.Name = "placar_select2";
            this.placar_select2.Size = new System.Drawing.Size(35, 35);
            this.placar_select2.TabIndex = 15;
            this.placar_select2.TabStop = false;
            // 
            // novo_select2
            // 
            this.novo_select2.BackColor = System.Drawing.Color.DodgerBlue;
            this.novo_select2.Location = new System.Drawing.Point(560, 256);
            this.novo_select2.Name = "novo_select2";
            this.novo_select2.Size = new System.Drawing.Size(35, 35);
            this.novo_select2.TabIndex = 13;
            this.novo_select2.TabStop = false;
            // 
            // ThemeMusic
            // 
            this.ThemeMusic.Enabled = true;
            this.ThemeMusic.Location = new System.Drawing.Point(695, 12);
            this.ThemeMusic.Name = "ThemeMusic";
            this.ThemeMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ThemeMusic.OcxState")));
            this.ThemeMusic.Size = new System.Drawing.Size(37, 36);
            this.ThemeMusic.TabIndex = 18;
            this.ThemeMusic.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 556);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Acesse para conhecer meu criador:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 572);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(479, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "http://www.orkut.com/Main#Community.aspx?cmm=91309511";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ThemeMusic);
            this.Controls.Add(this.sair_select2);
            this.Controls.Add(this.opcoes_select2);
            this.Controls.Add(this.placar_select2);
            this.Controls.Add(this.novo_select2);
            this.Controls.Add(this.sair_select);
            this.Controls.Add(this.opcoes_select);
            this.Controls.Add(this.placar_select);
            this.Controls.Add(this.novo_select);
            this.Controls.Add(this.Placar_LABEL);
            this.Controls.Add(this.Sair_LABEL);
            this.Controls.Add(this.Configura_LABEL);
            this.Controls.Add(this.NovoJogo_LABEL);
            this.Controls.Add(this.ExitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "As aventuras do ETEQUER";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMenu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.novo_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.placar_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcoes_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sair_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sair_select2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcoes_select2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.placar_select2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.novo_select2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThemeMusic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.Label NovoJogo_LABEL;
        private System.Windows.Forms.Label Configura_LABEL;
        private System.Windows.Forms.Label Sair_LABEL;
        private System.Windows.Forms.Label Placar_LABEL;
        private System.Windows.Forms.PictureBox novo_select;
        private System.Windows.Forms.PictureBox placar_select;
        private System.Windows.Forms.PictureBox opcoes_select;
        private System.Windows.Forms.PictureBox sair_select;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.PictureBox sair_select2;
        private System.Windows.Forms.PictureBox opcoes_select2;
        private System.Windows.Forms.PictureBox placar_select2;
        private System.Windows.Forms.PictureBox novo_select2;
        private AxWMPLib.AxWindowsMediaPlayer ThemeMusic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}