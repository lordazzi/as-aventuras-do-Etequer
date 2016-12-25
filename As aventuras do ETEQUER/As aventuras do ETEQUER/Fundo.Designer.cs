namespace As_aventuras_do_ETEQUER
{
    partial class Fundo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fundo));
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.Imagem_Tema = new System.Windows.Forms.PictureBox();
            this.GameUpdater = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Imagem_Tema)).BeginInit();
            this.SuspendLayout();
            // 
            // Updater
            // 
            this.Updater.Interval = 1;
            this.Updater.Tick += new System.EventHandler(this.GameUpdater_Tick);
            // 
            // Imagem_Tema
            // 
            this.Imagem_Tema.Location = new System.Drawing.Point(-800, 0);
            this.Imagem_Tema.Name = "Imagem_Tema";
            this.Imagem_Tema.Size = new System.Drawing.Size(2400, 600);
            this.Imagem_Tema.TabIndex = 0;
            this.Imagem_Tema.TabStop = false;
            // 
            // GameUpdater
            // 
            this.GameUpdater.Enabled = true;
            this.GameUpdater.Interval = 1;
            this.GameUpdater.Tick += new System.EventHandler(this.GameUpdater_Tick_1);
            // 
            // Fundo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Imagem_Tema);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Fundo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "As aventuras do Etequer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Fundo_KeyDown);
            this.Load += new System.EventHandler(this.Fundo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Imagem_Tema)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.PictureBox Imagem_Tema;
        private System.Windows.Forms.Timer GameUpdater;
    }
}