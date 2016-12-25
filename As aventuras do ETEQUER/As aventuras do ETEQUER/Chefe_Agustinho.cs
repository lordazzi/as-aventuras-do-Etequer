using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace As_aventuras_do_ETEQUER
{
    public partial class Chefe_Agustinho : Form
    {
        #region Variaveis
        //Essas variaveis vão receber a imagens do missil que sera jogado do chefe para o jogador
        static public Image M_Left, M_Right, M_Up, M_Down, M_Left_Up, M_Left_Down, M_Right_Up, M_Right_Down;
        //Essa variavel vai carregar a imagem do etequer em relação ao chefe agustinho
        static public Image Etequer_IMG;
        //Essa variavel vai carregar o chefe agustinho
        static public Image Agustinho_IMG;
        //Essa variavel vai servir para controlar o jogador
        static public int Way = 0;

        //Essas variaveis vão marcar a quantidade de vida do chefe e do jogador
        static public int AgustinhoLIFE = 100, EtequerLIFE = 100;

        //Essa variavel será usada para contar o numero de misseis lançados pelo chefe
        static public int MissilsNumber = 0;

        //Essa variavel vai guarda o valor de para qual lado o Agustinho deve seguir
        static public Keys BOSSdir = Keys.Space;
        #endregion
        #region Rotinas
        public Chefe_Agustinho()
        {
            InitializeComponent();
        }

        private void ConvertToIMG()
        {
            if (Jogo.intTOstring == "0")
            {
                Jogo.stringTOimg = Jogo.Zero;
            }
            else if (Jogo.intTOstring == "1")
            {
                Jogo.stringTOimg = Jogo.Um;
            }
            else if (Jogo.intTOstring == "2")
            {
                Jogo.stringTOimg = Jogo.Dois;
            }
            else if (Jogo.intTOstring == "3")
            {
                Jogo.stringTOimg = Jogo.Tres;
            }
            else if (Jogo.intTOstring == "4")
            {
                Jogo.stringTOimg = Jogo.Quatro;
            }
            else if (Jogo.intTOstring == "5")
            {
                Jogo.stringTOimg = Jogo.Cinco;
            }
            else if (Jogo.intTOstring == "6")
            {
                Jogo.stringTOimg = Jogo.Seis;
            }
            else if (Jogo.intTOstring == "7")
            {
                Jogo.stringTOimg = Jogo.Sete;
            }
            else if (Jogo.intTOstring == "8")
            {
                Jogo.stringTOimg = Jogo.Oito;
            }
            else if (Jogo.intTOstring == "9")
            {
                Jogo.stringTOimg = Jogo.Nove;
            }
        }

        private void CreateMissil()
        {
            PictureBox TIRO = new PictureBox();
            TIRO.AccessibleName = "2";
            TIRO.Image = M_Left;
            TIRO.Width = 114;
            TIRO.Height = 20;
            TIRO.MinimumSize = new System.Drawing.Size(1, 1);
            TIRO.Left = 600;
            TIRO.Top += Agustinho.Top + 53;
            TIRO.BackColor = Color.Transparent;
            Controls.Add(TIRO);
        }
        #endregion

        private void Chefe_Agustinho_IMC_Load(object sender, EventArgs e)
        {
            #region Organização do gráfico
            //Coloca a cabeça do jogador do lado do número de vidas
            LifesFace.Image = Jogo.HeadOfLives;
            //Coloca a avatar do Agustinho ao lado da vida dele
            Avatar.Image = Jogo.AGUSTINHOavt;

            //Coloca a imagem já carregada no botão de saida
            ExitButton.Image = MainMenu.IMG_ExitButton_normal;

            //Coloca as imagens na barra de vida do jogador
            LifeBAR.BackgroundImage = Jogo.LifeBAR_IMG;
            LifeBar_BAckGround.BackgroundImage = Jogo.LifeBAR_IMG_bg;

            //Coloca a imagem na barra de vida do chefe
            AgostioLifeBAR.BackgroundImage = Jogo.LifeBAR_IMG;
            AgostioBG.BackgroundImage = Jogo.LifeBAR_IMG_bg;

            //Colocando a imagem inicial no jogador e no chefe
            Etequer.Image = Etequer_IMG;
            Agustinho.Image = Agustinho_IMG;

            //Número do chefe
            ControlPanel.MestreNumber = 3;
            #endregion
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            #region verifica se o mouse está em cima do botão de saida
            //verifica se o mouse esta em cima do botão de saida para poder dizer qual é a imagem que deve ser usada.
            if (ControlPanel.MouseLeft >= (Jogo.ExitButton_left) && ControlPanel.MouseLeft <= (Jogo.ExitButton_left + Jogo.ExitButton_width) && ControlPanel.MouseTop >= (Jogo.ExitButton_top) && ControlPanel.MouseTop <= (Jogo.ExitButton_top + Jogo.ExitButton_height))
            {
                ExitButton.Image = MainMenu.IMG_ExitButton_hover;
            }
            else
            {
                ExitButton.Image = MainMenu.IMG_ExitButton_normal;
            }
            #endregion
            #region Mostra o numero de vidas
            if (Jogo.Vidas <= 9)
            {
                Jogo.SubVida1 = "0";
                Jogo.SubVida2 = Jogo.Vidas.ToString();
            }
            else
            {
                Jogo.SubVida1 = Jogo.Vidas.ToString().Substring(0, 1);
                Jogo.SubVida2 = Jogo.Vidas.ToString().Substring(1, 1);
            }
            //Dezenas são mostradas
            Jogo.intTOstring = Jogo.SubVida1;
            ConvertToIMG();
            Dezes.Image = Jogo.stringTOimg;
            Dezes.Update();

            //Unidades são mostradas
            Jogo.intTOstring = Jogo.SubVida2;
            ConvertToIMG();
            Unis.Image = Jogo.stringTOimg;
            Unis.Update();

            #endregion
            #region Mostra nas Barras de vida a quantidade de vida atual
            if (EtequerLIFE != 0)
            {
                LifeBAR.Width = EtequerLIFE * 5;
            }
            else
            {
                LifeBAR.Width = 1;
            }

            if (AgustinhoLIFE != 0)
            {
                AgostioLifeBAR.Width = AgustinhoLIFE * 5;
            }
            else
            {
                AgostioLifeBAR.Width = 1;
            }
            #endregion
        }

        private void GameUpdater_Tick(object sender, EventArgs e)
        {
            #region Recebe o comando e executa a ação
            if (Way == 1)
            {
                //para cima
                if (Etequer.Top <= 69)
                {
                    Way = 0;
                }
                else
                {
                    Etequer.Top -= ControlPanel.VELOCIDADE;
                    Way = 0;
                }
            }

            else if (Way == 2)
            {
                //para baixo
                if (Etequer.Top >= 383)
                {
                    Way = 0;
                }
                else
                {
                    Etequer.Top += ControlPanel.VELOCIDADE;
                    Way = 0;
                }
            }
            #endregion
            #region Verificando se deve ou não lançar mais um missil
            //Nessa foreach ele conta quantos misseis estão no cenario
            foreach (object OBJinBOSS in this.Controls)
            {
                if (OBJinBOSS is PictureBox)
                {
                    PictureBox BossMissil = OBJinBOSS as PictureBox;
                    if (BossMissil.MinimumSize.Height == 1 || BossMissil.MinimumSize.Width == 1)
                    {
                        MissilsNumber++;
                    }
                }
            }

            if (MissilsNumber == 0)
            {
                CreateMissil();
            }

            MissilsNumber = 0;
            //Esse foreach compara o numero de misseis em campo com os que devem estar em campo, caso falte algum ele preenche a "vaga"
           /* foreach (object OBJinBOSS in this.Controls)
            {
                if (OBJinBOSS is PictureBox)
                {
                    PictureBox BossMissil = OBJinBOSS as PictureBox;
                    if (BossMissil.MinimumSize.Height == 1 || BossMissil.MinimumSize.Width == 1)
                    {
                        if (AgustinhoLIFE <= 100 && AgustinhoLIFE > 70 && MissilsNumber == 1)
                        {
                            CreateMissil();
                        }

                        else if (AgustinhoLIFE <= 70 && AgustinhoLIFE > 40 && MissilsNumber <= 2)
                        {
                            if (BossMissil.Left < 600)
                            {
                                CreateMissil();
                            }
                        }

                        else if (AgustinhoLIFE <= 40 && AgustinhoLIFE > 10 && MissilsNumber <= 3)
                        {
                            if (BossMissil.Left < 600)
                            {
                                CreateMissil();
                            }
                        }

                        else if (AgustinhoLIFE <= 10 && MissilsNumber <= 4)
                        {
                            if (BossMissil.Left < 600)
                            {
                                CreateMissil();
                            }
                        }
                    }
                }
            }*/
            #endregion
            #region Colisão do missil com alguém
            foreach (object OBJ in this.Controls)
            {
                if (OBJ is PictureBox)
                {
                    PictureBox MISSIL = OBJ as PictureBox;
                    //Com o  Etequer
                    if ((MISSIL.Left <= Etequer.Left + Etequer.Width) && (MISSIL.Left > Etequer.Left))
                    {
                        if (MISSIL.AccessibleName == "1" || MISSIL.AccessibleName == "2" || MISSIL.AccessibleName == "3")
                        {
                            if ((MISSIL.Top + MISSIL.Height <= Etequer.Top) && (MISSIL.Top >= Etequer.Top) || (Etequer.Top < MISSIL.Top) && (Etequer.Top + Etequer.Height > MISSIL.Top + MISSIL.Height))
                            {
                                fala.Visible = true;
                                MISSIL.AccessibleName = "5";
                            }

                            /*else if ((MISSIL.Top + MISSIL.Height >= Etequer.Top) && (MISSIL.Top <= Etequer.Top) || (Etequer.Top < MISSIL.Top) && (Etequer.Top + 43 > MISSIL.Top + MISSIL.Height) || (MISSIL.Top < Etequer.Top + 43) && (MISSIL.Top + MISSIL.Height < Etequer.Top + 43))
                            {
                                fala.Visible = true;
                                MISSIL.AccessibleName = "6";
                            }

                            else if ((MISSIL.Top + MISSIL.Height >= Etequer.Top + 87) && (MISSIL.Top <= Etequer.Top + 87) || (Etequer.Top + 87 < MISSIL.Top) && (Etequer.Top + Etequer.Height > MISSIL.Top + MISSIL.Height) || (MISSIL.Top < Etequer.Top + Etequer.Height) && (MISSIL.Top + MISSIL.Height < Etequer.Top + Etequer.Height))
                            {
                                fala.Visible = true;
                                MISSIL.AccessibleName = "4";
                            }*/
                        }
                    }

                    //Com o Agustinho
                    if ((MISSIL.Left >= Agustinho.Left) && (MISSIL.Left < Agustinho.Left + Agustinho.Width))
                    {

                        if (MISSIL.AccessibleName == "4" || MISSIL.AccessibleName == "5" || MISSIL.AccessibleName == "6")
                        {
                            if ((MISSIL.Top + MISSIL.Height >= Agustinho.Top + 64) && (MISSIL.Top <= Agustinho.Top + 64) || (Agustinho.Top + 64 < MISSIL.Top) && (Agustinho.Top + 125 > MISSIL.Top + MISSIL.Height) || (MISSIL.Top < Agustinho.Top + 125) && (MISSIL.Top + MISSIL.Height < Agustinho.Top + 125))
                            {
                              //  MISSIL.AccessibleName = "2";
                                AgustinhoLIFE = 0;
                                this.Controls.Remove(MISSIL);
                            }

                            else if ((MISSIL.Top + MISSIL.Height >= Agustinho.Top) && (MISSIL.Top <= Agustinho.Top) || (Agustinho.Top < MISSIL.Top) && (Agustinho.Top + 63 > MISSIL.Top + MISSIL.Height) || (MISSIL.Top < Agustinho.Top + 63) && (MISSIL.Top + MISSIL.Height < Agustinho.Top + 63))
                            {
                             //   MISSIL.AccessibleName = "1";
                                AgustinhoLIFE = 0;
                                this.Controls.Remove(MISSIL);
                            }

                            else if ((MISSIL.Top + MISSIL.Height >= Agustinho.Top + 126) && (MISSIL.Top <= Agustinho.Top + 126) || (Agustinho.Top + 126 < MISSIL.Top) && (Agustinho.Top + Agustinho.Height > MISSIL.Top + MISSIL.Height) || (MISSIL.Top < Agustinho.Top + Agustinho.Height) && (MISSIL.Top + MISSIL.Height < Agustinho.Top + Agustinho.Height))
                            {
                               // MISSIL.AccessibleName = "3";
                                AgustinhoLIFE = 0;
                                this.Controls.Remove(MISSIL);
                            }
                        }
                    }
                }
            }
            #endregion
            #region Avisa para qual direção o Agustinho deve ir
            foreach (object OBJinGAME in this.Controls)
            {
                if (OBJinGAME is PictureBox)
                {
                    PictureBox Missil = OBJinGAME as PictureBox;
                    if (Missil.Top > (Agustinho.Top + 52))
                    {
                        BOSSdir = Keys.Down;
                    }

                    else if (Missil.Top < (Agustinho.Top + 68))
                    {
                        BOSSdir = Keys.Up;
                    }

                    else
                    {
                        BOSSdir = Keys.Space;
                    }
                }
            }
            #endregion
            #region Destroi misseis fujões
            foreach (object OBJ in this.Controls)
            {
                if (OBJ is PictureBox)
                {
                    PictureBox Missil = OBJ as PictureBox;
                    if (Missil.MaximumSize.Height == 1 && Missil.MinimumSize.Width == 1 && Missil.Left < -200)
                    {
                        this.Controls.Remove(Missil);
                    }
                }
            }
            #endregion
        }

        private void MissilMove_Tick(object sender, EventArgs e)
        {
            #region Orienta a movimentação do missil
            foreach (object OBJinGAME in this.Controls)
            {
                if (OBJinGAME is PictureBox)
                {
                    PictureBox Missil = OBJinGAME as PictureBox;
                    if (Missil.MinimumSize.Height == 1 || Missil.MinimumSize.Width == 1)
                    {
                        //Agustinho (All left)
                        if (Missil.AccessibleName == "1")
                        {
                            if (Missil.Top < 80)
                            {
                                Missil.AccessibleName = "3";
                                Missil.Image = M_Left_Down;
                                Missil.Left -= ControlPanel.VELOCIDADE;
                                Missil.Top += ControlPanel.VELOCIDADE;
                            }
                            else
                            {
                                Missil.Image = M_Left_Up;
                                Missil.Left -= ControlPanel.VELOCIDADE;
                                Missil.Top -= ControlPanel.VELOCIDADE;
                            }
                        }

                        else if (Missil.AccessibleName == "2")
                        {
                            Missil.Image = M_Left;
                            Missil.Left -= ControlPanel.VELOCIDADE;
                        }

                        else if (Missil.AccessibleName == "3")
                        {
                            if (Missil.Top > 495)
                            {
                                AccessibleName = "1";
                                Missil.Image = M_Left_Up;
                                Missil.Left -= ControlPanel.VELOCIDADE;
                                Missil.Top -= ControlPanel.VELOCIDADE;
                            }
                            else
                            {
                                Missil.Image = M_Left_Down;
                                Missil.Left -= ControlPanel.VELOCIDADE;
                                Missil.Top += ControlPanel.VELOCIDADE;
                            }
                        }


                            //Etequer (All right <-- Sako a piada?)
                        else if (Missil.AccessibleName == "4")
                        {
                            if (Missil.Top < 80)
                            {
                                AccessibleName = "6";
                                Missil.Image = M_Right_Down;
                                Missil.Left += ControlPanel.VELOCIDADE;
                                Missil.Top += ControlPanel.VELOCIDADE;
                            }

                            else
                            {
                                Missil.Image = M_Right_Up;
                                Missil.Left += (ControlPanel.VELOCIDADE / 5);
                                Missil.Top -= (ControlPanel.VELOCIDADE / 5);
                            }
                        }

                        else if (Missil.AccessibleName == "5")
                        {
                            Missil.Image = M_Right;
                            Missil.Left += ControlPanel.VELOCIDADE;
                        }

                        else if (Missil.AccessibleName == "6")
                        {
                            if (Missil.Top > 495)
                            {
                                AccessibleName = "4";
                                Missil.Image = M_Right_Up;
                                Missil.Left += (ControlPanel.VELOCIDADE / 5);
                                Missil.Top -= (ControlPanel.VELOCIDADE / 5);
                            }

                            else
                            {
                                Missil.Image = M_Right_Down;
                                Missil.Left += ControlPanel.VELOCIDADE;
                                Missil.Top += ControlPanel.VELOCIDADE;
                            }
                        }
                    }
                }
            }
            #endregion
            #region Arrumando a imagem do missil
            foreach (object OBJ in this.Controls)
            {
                if (OBJ is PictureBox)
                {
                    PictureBox MISSIL = OBJ as PictureBox;
                    if (MISSIL.Image == M_Left_Down || MISSIL.Image == M_Left_Up || MISSIL.Image == M_Right_Down || MISSIL.Image == M_Right_Up)
                    {
                        MISSIL.Height = 83;
                        MISSIL.Width = 83;
                    }

                    else if (MISSIL.Image == M_Down || MISSIL.Image == M_Up)
                    {
                        MISSIL.Width = 20;
                        MISSIL.Height = 114;
                    }

                    else if (MISSIL.Image == M_Right || MISSIL.Image == M_Left)
                    {
                        MISSIL.Width = 114;
                        MISSIL.Height = 20;
                    }
                }
            }
            #endregion
            #region TIrando pontos de vida caso o MISSIL ultrapasse determinado ponto
            foreach (object OBJ in this.Controls)
            {
                if (OBJ is PictureBox)
                {
                    PictureBox MISSIL = OBJ as PictureBox;
                    if (MISSIL.Left < -100)
                    {
                        Controls.Remove(MISSIL);
                        EtequerLIFE -= 5;
                    }

                    if (MISSIL.Left > 900)
                    {
                        Controls.Remove(MISSIL);
                        AgustinhoLIFE -= 5;
                    }
                }
            }
            #endregion
            #region Encerrando o jogo de algum jeito (Agustinho perde ou Etequer perde)
            if (AgustinhoLIFE <= 0)
            {
                this.Close();
                Videos.WhoPlay = 4;
                Videos AGO = new Videos();
                ControlPanel.MestreNumber = 0;
                ControlPanel.GoFront = true;
                AGO.Show();
            }

            if (EtequerLIFE <= 0)
            {
                MessageBox.Show("ERRO!" + Environment.NewLine + "Não é possivel o Agustinho vencer...", "::ERROR::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            #endregion
        }

        private void BossMove_Tick(object sender, EventArgs e)
        {
            #region Faz com que o Agustinho siga o missil
            if (BOSSdir == Keys.Space)
            {
            }

            else if (BOSSdir == Keys.Down)
            {
                Agustinho.Top += ControlPanel.VELOCIDADE / 2;
            }

            else if (BOSSdir == Keys.Up)
            {
                Agustinho.Top -= ControlPanel.VELOCIDADE / 2;
            }
            #endregion
        }
    }
}