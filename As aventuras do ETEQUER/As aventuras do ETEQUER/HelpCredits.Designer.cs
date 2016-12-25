namespace As_aventuras_do_ETEQUER
{
    partial class HelpCredits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpCredits));
            this.Ajuda1 = new System.Windows.Forms.Label();
            this.Ajuda2 = new System.Windows.Forms.Label();
            this.Ajuda3 = new System.Windows.Forms.Label();
            this.Ajuda4 = new System.Windows.Forms.Label();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Ajuda1
            // 
            this.Ajuda1.AutoSize = true;
            this.Ajuda1.BackColor = System.Drawing.Color.Transparent;
            this.Ajuda1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ajuda1.Location = new System.Drawing.Point(171, 69);
            this.Ajuda1.Name = "Ajuda1";
            this.Ajuda1.Size = new System.Drawing.Size(384, 208);
            this.Ajuda1.TabIndex = 0;
            this.Ajuda1.Text = resources.GetString("Ajuda1.Text");
            this.Ajuda1.Visible = false;
            // 
            // Ajuda2
            // 
            this.Ajuda2.AutoSize = true;
            this.Ajuda2.BackColor = System.Drawing.Color.Transparent;
            this.Ajuda2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ajuda2.Location = new System.Drawing.Point(154, 69);
            this.Ajuda2.Name = "Ajuda2";
            this.Ajuda2.Size = new System.Drawing.Size(401, 208);
            this.Ajuda2.TabIndex = 1;
            this.Ajuda2.Text = resources.GetString("Ajuda2.Text");
            this.Ajuda2.Visible = false;
            // 
            // Ajuda3
            // 
            this.Ajuda3.AutoSize = true;
            this.Ajuda3.BackColor = System.Drawing.Color.Transparent;
            this.Ajuda3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ajuda3.Location = new System.Drawing.Point(159, 69);
            this.Ajuda3.Name = "Ajuda3";
            this.Ajuda3.Size = new System.Drawing.Size(386, 208);
            this.Ajuda3.TabIndex = 2;
            this.Ajuda3.Text = resources.GetString("Ajuda3.Text");
            this.Ajuda3.Visible = false;
            // 
            // Ajuda4
            // 
            this.Ajuda4.AutoSize = true;
            this.Ajuda4.BackColor = System.Drawing.Color.Transparent;
            this.Ajuda4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ajuda4.Location = new System.Drawing.Point(171, 69);
            this.Ajuda4.Name = "Ajuda4";
            this.Ajuda4.Size = new System.Drawing.Size(374, 144);
            this.Ajuda4.TabIndex = 3;
            this.Ajuda4.Text = resources.GetString("Ajuda4.Text");
            this.Ajuda4.Visible = false;
            // 
            // Updater
            // 
            this.Updater.Enabled = true;
            this.Updater.Interval = 1;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // HelpCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Ajuda4);
            this.Controls.Add(this.Ajuda3);
            this.Controls.Add(this.Ajuda2);
            this.Controls.Add(this.Ajuda1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "HelpCredits";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "As aventuras do Etequer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HelpCredits_KeyDown);
            this.Load += new System.EventHandler(this.HelpCredits_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ajuda1;
        private System.Windows.Forms.Label Ajuda2;
        private System.Windows.Forms.Label Ajuda3;
        private System.Windows.Forms.Label Ajuda4;
        private System.Windows.Forms.Timer Updater;
    }
}