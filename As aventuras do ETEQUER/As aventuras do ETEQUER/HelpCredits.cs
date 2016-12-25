using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace As_aventuras_do_ETEQUER
{
    public partial class HelpCredits : Form
    {
        #region Variaveis
        //Essa variavel carregará a imagem que será colocada no fundo
        static public Image Plano_de_fundo;

        //Essa variavel verifica se o jogador esta abrindo esse formulario com o objetivo de ver os créditos ou ver tópicos de ajuda
        static public int WhatTheHell;// 0 = Ajuda, 1 = créditos.

        //Vê qual a parte dos créditos/ajuda o jogador está...
        int AjudaCredito = 0;
        #endregion
        #region Rotinas
        public HelpCredits()
        {
            InitializeComponent();
        }
        #endregion

        private void HelpCredits_Load(object sender, EventArgs e)
        {
            #region Organização do formulario
            this.BackgroundImage = Plano_de_fundo;
            #endregion
        }

        private void HelpCredits_KeyDown(object sender, KeyEventArgs e)
        {
            #region Recebendo os comandos do usuário
            if (e.KeyCode == Keys.Add)
            {
                if (WhatTheHell == 0)
                {
                    if (AjudaCredito < 3)
                    {
                        AjudaCredito++;
                        Updater.Enabled = true;
                    }
                }
            }

            else if (e.KeyCode == Keys.Subtract)
            {
                if (AjudaCredito == 0)
                {
                }

                else if (AjudaCredito != 0)
                {
                    AjudaCredito--;
                    Updater.Enabled = true;
                }
            }

            else if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
            #endregion
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            #region Executando os comandos recebidos pelo usuário
            if (WhatTheHell == 0)
            {
                foreach (object TEXTOobj in this.Controls)
                {
                    if (TEXTOobj is Label)
                    {
                        Label TEXTO_lbl = TEXTOobj as Label;
                        TEXTO_lbl.Visible = false;
                    }
                }
                if (AjudaCredito == 0)
                {
                    Ajuda1.Visible = true;
                }

                else if (AjudaCredito == 1)
                {
                    Ajuda2.Visible = true;
                }

                else if (AjudaCredito == 2)
                {
                    Ajuda3.Visible = true;
                }

                else if (AjudaCredito == 3)
                {
                    Ajuda4.Visible = true;
                }
                Updater.Enabled = false;
            }

            else if (WhatTheHell == 1)
            {
                foreach (object TEXTOobj in this.Controls)
                {
                    if (TEXTOobj is Label)
                    {
                        Label TEXTO_lbl = TEXTOobj as Label;
                        TEXTO_lbl.Visible = false;
                    }
                }

                //Organização dos créditos
            }
            #endregion
        }
    }
}