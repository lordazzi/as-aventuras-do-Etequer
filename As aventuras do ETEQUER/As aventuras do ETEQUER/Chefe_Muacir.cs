using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace As_aventuras_do_ETEQUER
{
    public partial class Chefe_Muacir : Form
    {
        #region Variaveis
        //Faz as explicações sumirem
        static public bool Explicacao = false;
        //Essas imagens vão importar as animações do trem, incluindo a parte Tail, Head e fumaça...
        static public Image Head1, Head2;
        static public Image Tails;
        static public Image Fuma1, Fuma2, Fuma3, Fuma4, Fuma5, Fuma6, Fuma7, Fuma8, Fuma9;

        //Essas imagens vão importar os inimigos que haverão dentro do chefe Muacir
        static public Image Dengue1, Dengue2;
        static public Image Nave;
        static public Image Morcego1, Morcego2, Morcego3;
        static public Image Nuvem;
        static public Image Satelite;
        static public Image Bird1, Bird2;
        //Nome dos monstros
        int Numero = 0;

        //Carrega o etequer em relação ao chefe muacir
        static public Image ETEQUER_IMG;

        //Posição do jogador dentro do chefe
        static public int PlayerPOS = 0;
        //Posição do trem dentro do chefe
        static public int TremPOS = 0;
        //Essa variavel vai servir para enviar os inimigos contra o jogador aos poucos
        int CONTROL;

        //Essa variavel vai carregar o valor enviado pelo Painel de Controle para que o form interprete
        static public Keys SendingComandos;

        //Linha que recebe as linhas e Linhas possiveis
        int A = 100, AB = 120, B = 140, BC = 160, C = 180, CD = 200, D = 220, DE = 240, E = 260, EF = 280, F = 300, FG = 320, G = 340;
        int Line;

        //Se essa variavel se mantiver falsa é por que o jogador não encostou em nenhm tipo de inimigo
        bool EnemyTouched = false;

        //Mostra a velocidade do trem do muacir
        int VELOCIDADEmuacir;
        #endregion
        #region Rotinas
        public Chefe_Muacir()
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

        //Monstros
        private void Passaro()
        {
            if (PlayerPOS == CONTROL)
            {
                PictureBox Monstro = new PictureBox();
                Monstro.Name = Numero.ToString();
                Numero++;
                Monstro.Size = new System.Drawing.Size(58, 30);
                Monstro.MinimumSize = new System.Drawing.Size(1, 1);
                Monstro.Image = Bird1;
                Monstro.BackColor = Color.Transparent;
                Monstro.Left = 900;
                Monstro.Top = Line;
                Controls.Add(Monstro);
            }
        }

        private void Morcego()
        {
            if (PlayerPOS == CONTROL)
            {
                PictureBox Monstro = new PictureBox();
                Monstro.Name = Numero.ToString();
                Numero++;
                Monstro.Size = new System.Drawing.Size(30, 43);
                Monstro.MinimumSize = new System.Drawing.Size(1, 1);
                Monstro.Image = Morcego1;
                Monstro.BackColor = Color.Transparent;
                Monstro.Left = 900;
                Monstro.Top = Line;
                Controls.Add(Monstro);
            }
        }

        private void Aviao()
        {
            if (PlayerPOS == CONTROL)
            {
                PictureBox Monstro = new PictureBox();
                Monstro.Name = Numero.ToString();
                Numero++;
                Monstro.Size = new System.Drawing.Size(223, 73);
                Monstro.MinimumSize = new System.Drawing.Size(1, 1);
                Monstro.Image = Nave;
                Monstro.BackColor = Color.Transparent;
                Monstro.Left = 900;
                Monstro.Top = Line;
                Controls.Add(Monstro);
            }
        }

        private void Dengue()
        {
            if (PlayerPOS == CONTROL)
            {
                PictureBox Monstro = new PictureBox();
                Monstro.Name = Numero.ToString();
                Numero++;
                Monstro.Size = new System.Drawing.Size(37, 18);
                Monstro.MinimumSize = new System.Drawing.Size(1, 1);
                Monstro.Image = Dengue1;
                Monstro.BackColor = Color.Transparent;
                Monstro.Left = 900;
                Monstro.Top = Line;
                Controls.Add(Monstro);
            }
        }

        private void Satel()
        {
            if (PlayerPOS == CONTROL)
            {
                PictureBox Monstro = new PictureBox();
                Monstro.Name = Numero.ToString();
                Numero++;
                Monstro.Size = new System.Drawing.Size(75, 75);
                Monstro.MinimumSize = new System.Drawing.Size(1, 1);
                Monstro.Image = Satelite;
                Monstro.BackColor = Color.Transparent;
                Monstro.Left = 900;
                Monstro.Top = Line;
                Controls.Add(Monstro);
            }
        }

        private void Nuve()
        {
            if (PlayerPOS == CONTROL)
            {
                PictureBox Monstro = new PictureBox();
                Monstro.Name = Numero.ToString();
                Numero++;
                Monstro.Size = new System.Drawing.Size(222, 53);
                Monstro.MinimumSize = new System.Drawing.Size(1, 1);
                Monstro.Image = Nuvem;
                Monstro.BackColor = Color.Transparent;
                Monstro.Left = 900;
                Monstro.Top = Line;
                Controls.Add(Monstro);
            }
        }

        //COmandos de espaço
        private void LittleSpace()
        {
            //Dengue e morcego
            CONTROL += 50;
        }

        private void MiniMediumSpace()
        {
            //Passaro
            CONTROL += 70;
        }

        private void BigMediumSpace()
        {
            //Satelite
            CONTROL += 90;
        }

        private void LargeSpace()
        {
            //Aeronave e Nuvem
            CONTROL += 240;
        }

        private void FINAL()
        {
            if (PlayerPOS == CONTROL)
            {
                PictureBox Monstro = new PictureBox();
                Monstro.Name = Numero.ToString();
                Numero++;
                Monstro.Size = new System.Drawing.Size(800, 600);
                Monstro.MinimumSize = new Size(1, 1);
                Monstro.MaximumSize = new Size(800, 800);
                Monstro.BackColor = Color.Transparent;
                Monstro.Left = 900;
                Monstro.Top = 0;
                Controls.Add(Monstro);
            }
        }
        #endregion

        private void Chefe_Muacir_Load(object sender, EventArgs e)
        {
            #region Organização do gráfico
            //Colocando as imagens no trem
            Calda1.BackgroundImage = Tails;
            Calda2.BackgroundImage = Tails;
            Calda3.BackgroundImage = Tails;
            Calda4.BackgroundImage = Tails;
            Calda5.BackgroundImage = Tails;
            Cabeca.BackgroundImage = Head1;
            Fumaca.BackgroundImage = Fuma1;

            //Colocando a imagem do Etequer
            ETEQUER.BackgroundImage = ETEQUER_IMG;

            //Colocando a imagem de fundo
            ControlPanel.MestreNumber = 2;

            //Cara do personagem na vida
            LifesFace.Image = Jogo.HeadOfLives;
            #endregion
        }

        private void GameAnimation_Tick(object sender, EventArgs e)
        {
            #region Movimentando os seres dos céus em direção do Etequer
            foreach (object AirEnemyOBJ in this.Controls)
            {
                if (AirEnemyOBJ is PictureBox)
                {
                    PictureBox AirEnemyPIC = AirEnemyOBJ as PictureBox;
                    if (AirEnemyPIC.MinimumSize.Height == 1 && AirEnemyPIC.MinimumSize.Width == 1)
                    {
                        AirEnemyPIC.Left -= ControlPanel.VELOCIDADE;
                    }
                }
            }
            #endregion
            #region Cabeça
            if (Cabeca.BackgroundImage == Head1)
            {
                Cabeca.BackgroundImage = Head2;
            }

            else if (Cabeca.BackgroundImage == Head2)
            {
                Cabeca.BackgroundImage = Head1;
            }
            #endregion
            #region Fumaça
            if (Fumaca.BackgroundImage == Fuma1)
            {
                Fumaca.BackgroundImage = Fuma2;
            }

            else if (Fumaca.BackgroundImage == Fuma2)
            {
                Fumaca.BackgroundImage = Fuma3;
            }

            else if (Fumaca.BackgroundImage == Fuma3)
            {
                Fumaca.BackgroundImage = Fuma4;
            }

            else if (Fumaca.BackgroundImage == Fuma4)
            {
                Fumaca.BackgroundImage = Fuma5;
            }

            else if (Fumaca.BackgroundImage == Fuma5)
            {
                Fumaca.BackgroundImage = Fuma6;
            }

            else if (Fumaca.BackgroundImage == Fuma6)
            {
                Fumaca.BackgroundImage = Fuma7;
            }

            else if (Fumaca.BackgroundImage == Fuma7)
            {
                Fumaca.BackgroundImage = Fuma8;
            }

            else if (Fumaca.BackgroundImage == Fuma8)
            {
                Fumaca.BackgroundImage = Fuma9;
            }

            else if (Fumaca.BackgroundImage == Fuma9)
            {
                Fumaca.BackgroundImage = Fuma1;
            }
            #endregion
            #region Inimigos
            foreach (object OBJinBOSS in this.Controls)
            {
                if (OBJinBOSS is PictureBox)
                {
                    PictureBox GameThing = OBJinBOSS as PictureBox;
                    #region Dengue
                    if (GameThing.Image == Dengue1)
                    {
                        GameThing.Image = Dengue2;
                    }

                    else if (GameThing.Image == Dengue2)
                    {
                        GameThing.Image = Dengue1;
                    }
                    #endregion
                    #region Morcego
                    else if (GameThing.Image == Morcego1)
                    {
                        GameThing.Image = Morcego2;
                    }

                    else if (GameThing.Image == Morcego2)
                    {
                        GameThing.Image = Morcego3;
                    }

                    else if (GameThing.Image == Morcego3)
                    {
                        GameThing.Image = Morcego1;
                    }
                    #endregion
                    #region Passaro
                    else if (GameThing.Image == Bird1)
                    {
                        GameThing.Image = Bird2;
                    }

                    else if (GameThing.Image == Bird2)
                    {
                        GameThing.Image = Bird1;
                    }
                    #endregion
                    GameThing.Update();
                }
            }
            #endregion
            #region Movendo o fundo
            //Movimentando o fundo
            Fundo.MoveBG = true;

            //Aumenta as cordenadas do jogador de acordo com que ele anda
            PlayerPOS += ControlPanel.VELOCIDADE;
            #endregion
            #region Dando os updates
            Calda1.Update();
            Calda2.Update();
            Calda3.Update();
            Calda4.Update();
            Calda5.Update();
            Cabeca.Update();
            Fumaca.Update();
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
            #region Deletando as picturebox inuteis jah usadas para evitar a diminuição da velocidade
            foreach (object OBJinGAME in this.Controls)
            {
                if (OBJinGAME is PictureBox)
                {
                    PictureBox LIXO = OBJinGAME as PictureBox;
                    if (LIXO.Left < -400 && LIXO.MaximumSize.Width == 1 && LIXO.MaximumSize.Height == 1)
                    {
                        Controls.Remove(LIXO);
                    }
                }
            }
            #endregion
            #region Varifica quem ganhou a corrida
            foreach (object OBJ in this.Controls)
            {
                if (OBJ is PictureBox)
                {
                    PictureBox FINAL = OBJ as PictureBox;
                    if (FINAL.MaximumSize.Height == 800 && FINAL.MaximumSize.Width == 800)
                    {
                        //Ve se o Etequer concluiu primeiro
                        if (ETEQUER.Left <= FINAL.Left && FINAL.Left <= (ETEQUER.Left + ETEQUER.Width) || ETEQUER.Left <= (FINAL.Left + FINAL.Width) && (FINAL.Left + FINAL.Width) <= (ETEQUER.Left + ETEQUER.Width) || FINAL.Left < ETEQUER.Left && (ETEQUER.Left + ETEQUER.Width) < (FINAL.Left + FINAL.Width))
                        {
                            if (ETEQUER.Top <= FINAL.Top && FINAL.Top <= (ETEQUER.Top + ETEQUER.Height) || ETEQUER.Top <= (FINAL.Top + FINAL.Height) && (FINAL.Top + FINAL.Height) <= (ETEQUER.Top + ETEQUER.Height) || FINAL.Top < ETEQUER.Top && (ETEQUER.Top + ETEQUER.Height) < (FINAL.Top + FINAL.Height))
                            {
                                ControlPanel.TOTALblock = false;
                                ControlPanel.GoFront = true;
                                ControlPanel.JogoVisibleFALSE = false;
                                ControlPanel.MestreNumber = 0;
                                Jogo.TALK++;
                                this.Close();
                            }
                        }

                        //Ve se o Muacir completou primeiro
                        if (Cabeca.Left <= FINAL.Left && FINAL.Left <= (Cabeca.Left + Cabeca.Width) || Cabeca.Left <= (FINAL.Left + FINAL.Width) && (FINAL.Left + FINAL.Width) <= (Cabeca.Left + Cabeca.Width) || FINAL.Left < Cabeca.Left && (Cabeca.Left + Cabeca.Width) < (FINAL.Left + FINAL.Width))
                        {
                            if (Cabeca.Top <= FINAL.Top && FINAL.Top <= (Cabeca.Top + Cabeca.Height) || Cabeca.Top <= (FINAL.Top + FINAL.Height) && (FINAL.Top + FINAL.Height) <= (Cabeca.Top + Cabeca.Height) || FINAL.Top < Cabeca.Top && (Cabeca.Top + Cabeca.Height) < (FINAL.Top + FINAL.Height))
                            {
                                ControlPanel.TOTALblock = false;
                                ControlPanel.GoFront = true;
                                ControlPanel.JogoVisibleFALSE = false;
                                ControlPanel.MestreNumber = 0;
                                Jogo.TALK++;
                                this.Close();
                                Jogo.DiePig = true;
                            }
                        }
                    }
                }
            }
            #endregion

        }

        private void GameUpdater_Tick(object sender, EventArgs e)
        {
            #region Recebendo as informações dos comandos dados e executando a ação correspondente
            if (SendingComandos == Keys.Right)
            {
                if (ETEQUER.Left <= ControlPanel.VELOCIDADE)
                {
                }

                else
                {
                    ETEQUER.Left += ControlPanel.VELOCIDADE;
                    SendingComandos = Keys.A;
                }
            }

            else if (SendingComandos == Keys.Left)
            {
                if (ETEQUER.Left >= 790)
                {
                }

                else
                {
                    ETEQUER.Left -= ControlPanel.VELOCIDADE;
                    SendingComandos = Keys.A;
                }
            }

            else if (SendingComandos == Keys.Up)
            {
                if (ETEQUER.Top <= 66)
                {
                }

                else
                {
                    ETEQUER.Top -= ControlPanel.VELOCIDADE;
                    SendingComandos = Keys.A;
                }
            }

            else if (SendingComandos == Keys.Down)
            {
                if (ETEQUER.Top + ETEQUER.Height >= 356)
                {
                }
                else
                {
                    ETEQUER.Top += ControlPanel.VELOCIDADE;
                    SendingComandos = Keys.A;
                }
            }

            else if (SendingComandos == Keys.Space)
            {
                Explanation.Visible = false;
                TextPLace.Visible = false;
                MuaVatar.Visible = false;
            }
            #endregion
            #region Declarando o cenário
            CONTROL = 100;
            Line = D;
            Passaro();
            LittleSpace();

            Line = CD;
            Passaro();
            Line = DE;
            Passaro();
            LargeSpace();

            Line = B;
            Nuve();
            Line = F;
            Nuve();
            LargeSpace();

            Line = D;
            Morcego();
            Line = B;
            Dengue();
            LittleSpace();

            Line = F;
            Dengue();
            LittleSpace();

            Line = EF;
            Dengue();
            LittleSpace();

            Line = DE;
            Dengue();
            Line = FG;
            Dengue();
            MiniMediumSpace();

            Line = BC;
            Passaro();
            LittleSpace();

            Line = B;
            Passaro();
            Line = C;
            Passaro();
            LittleSpace();

            Line = AB;
            Passaro();
            Line = BC;
            Passaro();
            Line = CD;
            Passaro();
            LargeSpace();

            LargeSpace();

            Line = A;
            Dengue();
            Line = C;
            Dengue();
            Line = E;
            Dengue();
            BigMediumSpace();

            Line = F;
            Aviao();
            LargeSpace();

            LargeSpace();

            Line = A;
            Satel();
            BigMediumSpace();

            LargeSpace();

            Line = DE;
            Morcego();
            Line = EF;
            Morcego();
            MiniMediumSpace();

            Line = D;
            Morcego();
            Line = E;
            Morcego();
            Line = F;
            Morcego();
            MiniMediumSpace();

            Line = CD;
            Morcego();
            Line = DE;
            Morcego();
            Line = EF;
            Morcego();
            Line = FG;
            Morcego();
            MiniMediumSpace();

            Line = D;
            Morcego();
            Line = E;
            Morcego();
            Line = F;
            Morcego();
            MiniMediumSpace();

            Line = E;
            Morcego();
            Line = A;
            Morcego();
            Line = C;
            Morcego();
            MiniMediumSpace();

            Line = B;
            Morcego();
            Line = D;
            Morcego();
            MiniMediumSpace();

            Line = C;
            Morcego();
            MiniMediumSpace();

            Line = D;
            Passaro();
            LittleSpace();

            Line = C;
            Passaro();
            Line = E;
            Passaro();
            LittleSpace();

            Line = D;
            Morcego();
            Line = B;
            Dengue();
            LittleSpace();

            Line = F;
            Dengue();
            LittleSpace();

            Line = EF;
            Dengue();
            LittleSpace();

            Line = DE;
            Dengue();
            Line = FG;
            Dengue();
            MiniMediumSpace();

            Line = BC;
            Passaro();
            LittleSpace();

            Line = B;
            Passaro();
            Line = C;
            Passaro();
            LittleSpace();

            Line = AB;
            Passaro();
            Line = BC;
            Passaro();
            Line = CD;
            Passaro();
            LargeSpace();

            LargeSpace();

            Line = A;
            Dengue();
            Line = C;
            Dengue();
            Line = E;
            Dengue();
            BigMediumSpace();

            Line = B;
            Passaro();
            Line = D;
            Passaro();
            Line = F;
            Passaro();
            LittleSpace();

            LargeSpace();

            Line = EF;
            Morcego();
            MiniMediumSpace();

            Morcego();
            MiniMediumSpace();

            Line = A;
            Satel();
            Line = C;
            Satel();
            Line = EF;
            Morcego();
            MiniMediumSpace();

            Line = B;
            Nuve();
            Line = F;
            Nuve();
            LargeSpace();

            Line = D;
            Morcego();
            Line = B;
            Dengue();
            LittleSpace();

            Line = F;
            Dengue();
            LittleSpace();

            Line = EF;
            Dengue();
            LittleSpace();

            Line = DE;
            Dengue();
            Line = FG;
            Dengue();
            MiniMediumSpace();

            Line = EF;
            Passaro();
            Line = DE;
            Passaro();
            LittleSpace();

            Line = A;
            Morcego();
            Line = D;
            Morcego();
            LittleSpace();

            Line = E;
            Dengue();
            LittleSpace();

            Line = D;
            Dengue();
            Line = F;
            Dengue();
            LittleSpace();

            Line = A;
            Passaro();
            Line = C;
            Dengue();
            Line = G;
            Dengue();
            Line = DE;
            Dengue();
            LittleSpace();

            Line = E;
            Nuve();
            LargeSpace();

            Line = CD;
            Dengue();
            Line = BC;
            Dengue();
            Line = D;
            Morcego();
            LittleSpace();

            Line = DE;
            Morcego();
            Line = CD;
            Morcego();
            MiniMediumSpace();

            Line = A;
            Aviao();
            LittleSpace();

            Line = CD;
            Nuve();
            MiniMediumSpace();

            Line = G;
            Satel();
            LargeSpace();

            Line = D;
            Aviao();
            Line = A;
            Passaro();
            LargeSpace();

            Line = CD;
            Aviao();
            Line = DE;
            Aviao();
            LargeSpace();

            Line = C;
            Aviao();
            Line = D;
            Aviao();
            Line = E;
            Aviao();
            LargeSpace();

            Line = BC;
            Aviao();
            Line = CD;
            Aviao();
            Line = DE;
            Aviao();
            Line = EF;
            Aviao();
            LargeSpace();

            Line = B;
            Aviao();
            Line = C;
            Aviao();
            Line = D;
            Aviao();
            Line = E;
            Aviao();
            Line = F;
            Aviao();
            LargeSpace();

            Line = AB;
            Aviao();
            Line = BC;
            Aviao();
            Line = CD;
            Aviao();
            Line = DE;
            Aviao();
            Line = EF;
            Aviao();
            Line = FG;
            Aviao();
            LargeSpace();

            Line = A;
            Aviao();
            Line = B;
            Aviao();
            Line = C;
            Aviao();
            Line = D;
            Aviao();
            Line = E;
            Aviao();
            Line = F;
            Aviao();
            Line = G;
            Aviao();
            LargeSpace();

            LargeSpace();

            Line = F;
            Dengue();
            LittleSpace();

            FINAL();

            ETEQUER.BringToFront();
            #endregion
        }

        private void BossMove_Tick(object sender, EventArgs e)
        {
            #region Decidindo a velocidade do trem do Muacir e verificando se o jogador está dentro de algum objeto
            foreach (object OBJinGAME in this.Controls)
            {
                if (OBJinGAME is PictureBox)
                {
                    PictureBox FlierEnemy = OBJinGAME as PictureBox;
                    //Dengue
                    if (FlierEnemy.Image == Dengue1 || FlierEnemy.Image == Dengue2)
                    {
                        if (ETEQUER.Left <= FlierEnemy.Left && FlierEnemy.Left <= (ETEQUER.Left + ETEQUER.Width) || ETEQUER.Left <= (FlierEnemy.Left + FlierEnemy.Width) && (FlierEnemy.Left + FlierEnemy.Width) <= (ETEQUER.Left + ETEQUER.Width) || FlierEnemy.Left < ETEQUER.Left && (ETEQUER.Left + ETEQUER.Width) < (FlierEnemy.Left + FlierEnemy.Width))
                        {
                            if (ETEQUER.Top <= FlierEnemy.Top && FlierEnemy.Top <= (ETEQUER.Top + ETEQUER.Height) || ETEQUER.Top <= (FlierEnemy.Top + FlierEnemy.Height) && (FlierEnemy.Top + FlierEnemy.Height) <= (ETEQUER.Top + ETEQUER.Height) || FlierEnemy.Top < ETEQUER.Top && (ETEQUER.Top + ETEQUER.Height) < (FlierEnemy.Top + FlierEnemy.Height))
                            {
                                VELOCIDADEmuacir = 10;
                                EnemyTouched = true;
                            }
                        }
                    }
                    

                    //Passaro
                    else if (FlierEnemy.Image == Dengue1 || FlierEnemy.Image == Dengue2)
                    {
                        if (ETEQUER.Left <= FlierEnemy.Left && FlierEnemy.Left <= (ETEQUER.Left + ETEQUER.Width) || ETEQUER.Left <= (FlierEnemy.Left + FlierEnemy.Width) && (FlierEnemy.Left + FlierEnemy.Width) <= (ETEQUER.Left + ETEQUER.Width) || FlierEnemy.Left < ETEQUER.Left && (ETEQUER.Left + ETEQUER.Width) < (FlierEnemy.Left + FlierEnemy.Width))
                        {
                            if (ETEQUER.Top <= FlierEnemy.Top && FlierEnemy.Top <= (ETEQUER.Top + ETEQUER.Height) || ETEQUER.Top <= (FlierEnemy.Top + FlierEnemy.Height) && (FlierEnemy.Top + FlierEnemy.Height) <= (ETEQUER.Top + ETEQUER.Height) || FlierEnemy.Top < ETEQUER.Top && (ETEQUER.Top + ETEQUER.Height) < (FlierEnemy.Top + FlierEnemy.Height))
                            {
                                VELOCIDADEmuacir = 15;
                                EnemyTouched = true;
                            }
                        }
                    }

                    //Morcego
                    else if (FlierEnemy.Image == Dengue1 || FlierEnemy.Image == Dengue2)
                    {
                        if (ETEQUER.Left <= FlierEnemy.Left && FlierEnemy.Left <= (ETEQUER.Left + ETEQUER.Width) || ETEQUER.Left <= (FlierEnemy.Left + FlierEnemy.Width) && (FlierEnemy.Left + FlierEnemy.Width) <= (ETEQUER.Left + ETEQUER.Width) || FlierEnemy.Left < ETEQUER.Left && (ETEQUER.Left + ETEQUER.Width) < (FlierEnemy.Left + FlierEnemy.Width))
                        {
                            if (ETEQUER.Top <= FlierEnemy.Top && FlierEnemy.Top <= (ETEQUER.Top + ETEQUER.Height) || ETEQUER.Top <= (FlierEnemy.Top + FlierEnemy.Height) && (FlierEnemy.Top + FlierEnemy.Height) <= (ETEQUER.Top + ETEQUER.Height) || FlierEnemy.Top < ETEQUER.Top && (ETEQUER.Top + ETEQUER.Height) < (FlierEnemy.Top + FlierEnemy.Height))
                            {
                                VELOCIDADEmuacir = 20;
                                EnemyTouched = true;
                            }
                        }
                    }

                    //Satélite
                    else if (FlierEnemy.Image == Dengue1 || FlierEnemy.Image == Dengue2)
                    {
                        if (ETEQUER.Left <= FlierEnemy.Left && FlierEnemy.Left <= (ETEQUER.Left + ETEQUER.Width) || ETEQUER.Left <= (FlierEnemy.Left + FlierEnemy.Width) && (FlierEnemy.Left + FlierEnemy.Width) <= (ETEQUER.Left + ETEQUER.Width) || FlierEnemy.Left < ETEQUER.Left && (ETEQUER.Left + ETEQUER.Width) < (FlierEnemy.Left + FlierEnemy.Width))
                        {
                            if (ETEQUER.Top <= FlierEnemy.Top && FlierEnemy.Top <= (ETEQUER.Top + ETEQUER.Height) || ETEQUER.Top <= (FlierEnemy.Top + FlierEnemy.Height) && (FlierEnemy.Top + FlierEnemy.Height) <= (ETEQUER.Top + ETEQUER.Height) || FlierEnemy.Top < ETEQUER.Top && (ETEQUER.Top + ETEQUER.Height) < (FlierEnemy.Top + FlierEnemy.Height))
                            {
                                VELOCIDADEmuacir = 25;
                                EnemyTouched = true;
                            }
                        }
                    }

                    //Nuvem
                    else if (FlierEnemy.Image == Dengue1 || FlierEnemy.Image == Dengue2)
                    {
                        if (ETEQUER.Left <= FlierEnemy.Left && FlierEnemy.Left <= (ETEQUER.Left + ETEQUER.Width) || ETEQUER.Left <= (FlierEnemy.Left + FlierEnemy.Width) && (FlierEnemy.Left + FlierEnemy.Width) <= (ETEQUER.Left + ETEQUER.Width) || FlierEnemy.Left < ETEQUER.Left && (ETEQUER.Left + ETEQUER.Width) < (FlierEnemy.Left + FlierEnemy.Width))
                        {
                            if (ETEQUER.Top <= FlierEnemy.Top && FlierEnemy.Top <= (ETEQUER.Top + ETEQUER.Height) || ETEQUER.Top <= (FlierEnemy.Top + FlierEnemy.Height) && (FlierEnemy.Top + FlierEnemy.Height) <= (ETEQUER.Top + ETEQUER.Height) || FlierEnemy.Top < ETEQUER.Top && (ETEQUER.Top + ETEQUER.Height) < (FlierEnemy.Top + FlierEnemy.Height))
                            {
                                VELOCIDADEmuacir = 35;
                                EnemyTouched = true;
                            }
                        }
                    }

                    //Avião
                    else if (FlierEnemy.Image == Dengue1 || FlierEnemy.Image == Dengue2)
                    {
                        if (ETEQUER.Left <= FlierEnemy.Left && FlierEnemy.Left <= (ETEQUER.Left + ETEQUER.Width) || ETEQUER.Left <= (FlierEnemy.Left + FlierEnemy.Width) && (FlierEnemy.Left + FlierEnemy.Width) <= (ETEQUER.Left + ETEQUER.Width) || FlierEnemy.Left < ETEQUER.Left && (ETEQUER.Left + ETEQUER.Width) < (FlierEnemy.Left + FlierEnemy.Width))
                        {
                            if (ETEQUER.Top <= FlierEnemy.Top && FlierEnemy.Top <= (ETEQUER.Top + ETEQUER.Height) || ETEQUER.Top <= (FlierEnemy.Top + FlierEnemy.Height) && (FlierEnemy.Top + FlierEnemy.Height) <= (ETEQUER.Top + ETEQUER.Height) || FlierEnemy.Top < ETEQUER.Top && (ETEQUER.Top + ETEQUER.Height) < (FlierEnemy.Top + FlierEnemy.Height))
                            {
                                VELOCIDADEmuacir = 55;
                                EnemyTouched = true;
                            }
                        }
                    }
                }
            }
            if (EnemyTouched == false)
            {
                //velocidade normal do trem
                VELOCIDADEmuacir = -5;
            }
            EnemyTouched = false;
            #endregion
            #region Fazendo o trem do Muacir andar
            Calda1.Left += VELOCIDADEmuacir;
            Calda2.Left += VELOCIDADEmuacir;
            Calda3.Left += VELOCIDADEmuacir;
            Calda4.Left += VELOCIDADEmuacir;
            Calda5.Left += VELOCIDADEmuacir;
            Cabeca.Left += VELOCIDADEmuacir;
            Fumaca.Left += VELOCIDADEmuacir;
            #endregion
        }

        #region Fazendo as explicações sairem
        private void FalaSome_Tick(object sender, EventArgs e)
        {
            if (Explicacao == false)
            {
                Explicacao = true;
            }
            else if (Explicacao == true)
            {
                Explanation.Visible = false;
                TextPLace.Visible = false;
                MuaVatar.Visible = false;
            }
        }
        #endregion
    }
}