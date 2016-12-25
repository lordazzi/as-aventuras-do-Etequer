namespace As_aventuras_do_ETEQUER
{
    partial class Load_Inicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Load_Inicial));
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.WhatIsLoading = new System.Windows.Forms.Label();
            this.Open = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Updater
            // 
            this.Updater.Interval = 1;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // WhatIsLoading
            // 
            this.WhatIsLoading.AutoSize = true;
            this.WhatIsLoading.BackColor = System.Drawing.Color.Transparent;
            this.WhatIsLoading.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhatIsLoading.ForeColor = System.Drawing.Color.Black;
            this.WhatIsLoading.Location = new System.Drawing.Point(12, 432);
            this.WhatIsLoading.Name = "WhatIsLoading";
            this.WhatIsLoading.Size = new System.Drawing.Size(15, 19);
            this.WhatIsLoading.TabIndex = 2;
            this.WhatIsLoading.Text = " ";
            // 
            // Open
            // 
            this.Open.Interval = 1250;
            this.Open.Tick += new System.EventHandler(this.Open_Tick);
            // 
            // Load_Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 460);
            this.Controls.Add(this.WhatIsLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(640, 460);
            this.MinimumSize = new System.Drawing.Size(640, 460);
            this.Name = "Load_Inicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "As aventuras do ETEQUER";
            this.Load += new System.EventHandler(this.Load_Inicial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.Label WhatIsLoading;
        private System.Windows.Forms.Timer Open;
    }
}