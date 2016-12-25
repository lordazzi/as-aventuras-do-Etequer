using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace As_aventuras_do_ETEQUER
{
    public partial class Configura_InputBox : Form
    {
        #region Variaveis
        //O valor dessa variavel é enviada para as configurações
        static public Keys CHAVE;
        //Muda a cor de fundo de acordo com o numero da variavel
        int WhatColorNow = 0;
        #endregion

        public Configura_InputBox()
        {
            InitializeComponent();
        }

        private void Configura_InputBox_KeyDown(object sender, KeyEventArgs e)
        {
                CHAVE = e.KeyCode;
                this.Close();
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            #region Muda a cor de fundo do formulario para chamar atenção
            if (WhatColorNow == 0)
            {
                this.BackColor = Color.Blue;
                WhatColorNow++;
            }
            else if (WhatColorNow == 1)
            {
                this.BackColor = Color.Purple;
                WhatColorNow++;
            }
            else if (WhatColorNow == 2)
            {
                this.BackColor = Color.Red;
                WhatColorNow++;
            }
            else if (WhatColorNow == 3)
            {
                this.BackColor = Color.Orange;
                WhatColorNow++;
            }
            else if (WhatColorNow == 4)
            {
                this.BackColor = Color.Yellow;
                WhatColorNow++;
            }
            else if (WhatColorNow == 5)
            {
                this.BackColor = Color.Lime;
                WhatColorNow++;
            }
            else if (WhatColorNow == 6)
            {
                this.BackColor = Color.Aqua;
                WhatColorNow = 0;
            }
            #endregion
        }
    }
}