namespace As_aventuras_do_ETEQUER
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.GBpontos = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.TextBox();
            this.Enviar = new System.Windows.Forms.Button();
            this.ENVIANDO = new System.Windows.Forms.PictureBox();
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.AVISO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DoAction = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ENVIANDO)).BeginInit();
            this.SuspendLayout();
            // 
            // GBpontos
            // 
            this.GBpontos.AutoSize = true;
            this.GBpontos.BackColor = System.Drawing.Color.Transparent;
            this.GBpontos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBpontos.ForeColor = System.Drawing.Color.GhostWhite;
            this.GBpontos.Location = new System.Drawing.Point(152, 495);
            this.GBpontos.Name = "GBpontos";
            this.GBpontos.Size = new System.Drawing.Size(15, 16);
            this.GBpontos.TabIndex = 2;
            this.GBpontos.Text = "0";
            // 
            // Nome
            // 
            this.Nome.Location = new System.Drawing.Point(153, 523);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(124, 20);
            this.Nome.TabIndex = 3;
            // 
            // Enviar
            // 
            this.Enviar.BackColor = System.Drawing.Color.White;
            this.Enviar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enviar.Location = new System.Drawing.Point(22, 552);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(145, 28);
            this.Enviar.TabIndex = 4;
            this.Enviar.Text = "ENVIAR PONTOS";
            this.Enviar.UseVisualStyleBackColor = false;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // ENVIANDO
            // 
            this.ENVIANDO.BackColor = System.Drawing.Color.Transparent;
            this.ENVIANDO.Location = new System.Drawing.Point(173, 549);
            this.ENVIANDO.Name = "ENVIANDO";
            this.ENVIANDO.Size = new System.Drawing.Size(35, 35);
            this.ENVIANDO.TabIndex = 14;
            this.ENVIANDO.TabStop = false;
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Interval = 75;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // AVISO
            // 
            this.AVISO.AutoSize = true;
            this.AVISO.BackColor = System.Drawing.Color.Transparent;
            this.AVISO.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AVISO.ForeColor = System.Drawing.Color.GhostWhite;
            this.AVISO.Location = new System.Drawing.Point(214, 567);
            this.AVISO.Name = "AVISO";
            this.AVISO.Size = new System.Drawing.Size(79, 16);
            this.AVISO.TabIndex = 15;
            this.AVISO.Text = "Enviando...";
            this.AVISO.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(322, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 51);
            this.label1.TabIndex = 16;
            this.label1.Text = "As aventuras do Etequer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(547, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "criado por Ricardo Azzi Silva";
            // 
            // DoAction
            // 
            this.DoAction.Interval = 500;
            this.DoAction.Tick += new System.EventHandler(this.DoAction_Tick);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AVISO);
            this.Controls.Add(this.ENVIANDO);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.GBpontos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Register_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ENVIANDO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GBpontos;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.PictureBox ENVIANDO;
        private System.Windows.Forms.Timer Update;
        private System.Windows.Forms.Label AVISO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer DoAction;
    }
}