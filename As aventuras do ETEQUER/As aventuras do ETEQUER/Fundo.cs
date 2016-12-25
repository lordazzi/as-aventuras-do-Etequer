using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace As_aventuras_do_ETEQUER
{
    public partial class Fundo : Form
    {
        #region Variaveis
        //analisa a posição do formulário para saber se estão todos alinhados
        static public int ThisCheckLeft, ThisCheckTop;
        //Verifica se o formulario já esta ativo
        static public bool IAmStarted = false;
        //Imagem de fundo
        static public Image InGameBG, MarceluBG, MuacirBG, Agustinhobg, LCbg;
        //Avisa quando o jogador pressionou o botão para a movimentaçãp da imagem de fundo.
        static public bool MoveBG = false;
        //encerra esse formulario se for pedido
        static public bool KILL = false;
        #endregion
        #region rotinas
        public Fundo()
        {
            InitializeComponent();
        }
        #endregion
        private void Fundo_Load(object sender, EventArgs e)
        {
            Updater.Enabled = true;
        }

        private void Fundo_KeyDown(object sender, KeyEventArgs e)
        {
            #region encerra toda aplicação no arpertar de Alt + F4
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                Application.Exit();
            }
            #endregion
        }

        private void GameUpdater_Tick(object sender, EventArgs e)
        {
            #region Análise de erros
            //Verifica se os formularios estão alinhados
            IAmStarted = true;
            ThisCheckLeft = this.Left;
            ThisCheckTop = this.Top;

            if (Jogo.IAmStarted == true && Fundo.IAmStarted == true && ControlPanel.IAmStarted == true)
            {
                if (Jogo.ThisCheckLeft == Fundo.ThisCheckLeft && ControlPanel.ThisCheckLeft == Fundo.ThisCheckLeft)
                {
                }
                else
                {
                    Application.Exit();
                }

                if (Jogo.ThisCheckTop == Fundo.ThisCheckTop && ControlPanel.ThisCheckTop == Fundo.ThisCheckTop)
                {
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
            }
            #endregion
            #region Coloca o gráfico no lugar quando for carregado
            if (ControlPanel.CARREGADO == true)
            {
                Imagem_Tema.Image = MarceluBG;
            }
            #endregion
            #region Troca de cenario no caso de passar de modulo e no caso de seu um chefe
            if (ControlPanel.MestreNumber == 0)
            {
                if (Imagem_Tema.Image != InGameBG)
                {
                    Imagem_Tema.Visible = true;
                    Imagem_Tema.Image = InGameBG;
                }
            }

            else if (ControlPanel.MestreNumber == 1)
            {
                if (this.BackgroundImage != MarceluBG)
                {
                    Imagem_Tema.Visible = false;
                    this.BackgroundImage = MarceluBG;
                }
            }

            else if (ControlPanel.MestreNumber == 2)
            {
                if (Imagem_Tema.Image != MuacirBG)
                {
                    Imagem_Tema.Visible = true;
                    Imagem_Tema.Image = MuacirBG;
                }
            }

            else if (ControlPanel.MestreNumber == 3)
            {
                if (this.BackgroundImage != Agustinhobg)
                {
                    Imagem_Tema.Visible = false;
                    this.BackgroundImage = Agustinhobg;
                }
            }

            else if (ControlPanel.MestreNumber == 4)
            {
                if (this.BackgroundImage != LCbg)
                {
                    Imagem_Tema.Visible = false;
                    this.BackgroundImage = LCbg;
                }
            }
            #endregion
        }

        private void GameUpdater_Tick_1(object sender, EventArgs e)
        {
            #region Explicação deste Timer
            /* A diferença de um GameUpdater
             * para um Updater normal é que
             * ele transfere as informações
             * das teclas pressionadas para
             * controle do personagem, se
             * houver muitos comandos a serem
             * executados no mesmo Timer o
             * simples movimento do personagem
             * pode se tornar lento, por isso
             * é criado um novo Timer usado
             * unicamente para tranferir
             * informações de comandos do
             * jogo.*/
            #endregion
            #region Movimentação do plano de fundo
            if (MoveBG == true)
            {
                if (Jogo.UltimaTecla == MainMenu.Direita)
                {
                    if (Imagem_Tema.Left <= -1600)
                    {
                        Imagem_Tema.Left = -800;
                    }
                    else
                    {
                        Imagem_Tema.Left = Imagem_Tema.Left - ControlPanel.VELOCIDADE;
                    }
                    MoveBG = false;
                }
                else if (Jogo.UltimaTecla == MainMenu.Esquerda)
                {
                    if (Imagem_Tema.Left >= 0)
                    {
                        Imagem_Tema.Left = -800;
                    }
                    else
                    {
                        Imagem_Tema.Left = Imagem_Tema.Left + ControlPanel.VELOCIDADE;
                    }
                    MoveBG = false;
                }
            }
            #endregion
            #region Fecha esse formulario se for pedido
            if (KILL == true)
            {
                this.Close();
            }
            #endregion
        }
    }
}