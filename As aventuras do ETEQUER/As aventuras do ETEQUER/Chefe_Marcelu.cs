using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Bibliotecas que eu adicionei
using System.Media;

namespace As_aventuras_do_ETEQUER
{
    public partial class Chefe_Marcelu : Form
    {
        #region variaveis
        //Carregando as imagens das esferas que v�o aparecer nesse chefe
        static public Image BlueBALL, PurpleBALL, RedBALL, OrangeBALL, YellowBALL, LimeBALL, AquaBALL, BlueBALL_light, PurpleBALL_light, RedBALL_light, OrangeBALL_light, YellowBALL_light, LimeBALL_light, AquaBALL_light;

        //Carregando os sons das cores
        static public SoundPlayer BlueSONG, PurpleSONG, RedSONG, OrangeSONG, YellowSONG, LimeSONG, AquaSONG, MadeWrong;

        //Grafico do chefe Marcelu tentando destruir a barreira
        static public Image Marcelu_SPR1, Marcelu_SPR2, Marcelu_SPR3;
        //Essa variavel vai ser usada na anima��o e movimenta��o do chefe marcelo
        int MarceluAnimation = 1;

        //Nessa variavel vai ficar carregado o gr�fico do muro
        static public Image Muro;

        //Avisa o Painel de Controle se a luta contra o chefe jah come�ou ou se o usuario ainda esta lendo as instru��es, caso tenha iniciado os comandos do teclado s�o ativados
        static public bool READ = false;

        //Nessa variavel sera carregado a imagem do pergaminho a ser colocado na LABEL
        static public Image Pergaminho;

        //A imagem do etequer dentro do chefe
        static public Image Etequer;

        //O dano no muro em que marcelo bate ser� randomico, assim o tempo em que o jogador tenta conseguir as sequencias tamb�m fica randomico.
        Random Damage = new Random();
        int DamageValue;

        //Essa variavel vai guardar a quantidade de vida do muro
        int Muro_life = 500;

        //Essa variavel � usada para mostrar se esta tocando as notas musicais ou se j� foi tocado
        static public bool IsDemonstring = false;

        //Essa variavel randomica � usada para saber quantas notas ser�o tocadas
        Random HowManyNotes = new Random();
        //Essa int vai carregar o numero sorteado pela variavel acima
        int NUMBERofNOTES;

        //Essa variavel randomica ser� usada para saber qual nota deve ser tocada
        Random WhoSingNow = new Random();
        //Essa variavel-vetor vai carregar os valores decidiso pela random acima
        int[] Sequencia = new int[9];
        //Mostra o item da sequencia que esta sendo atualmente tocado
        int OneOfTheEight = 0;
        //Ve se j� foi decidido o numero de notas a serem tocadas, para que naum seja redecidido
        bool HowManyISdecided = false;

        //Essa variavel guarda o numero de sequencias j� feitas pelo jogador
        int Completas = 0;

        //Recebe a informa��o de qual tecla foi pressionada e converte ela em uma cor
        static public Color Press_Color;
        //Avisa se o bot�o foi pressionado
        static public bool IsPressedSomeButton = false;
        #endregion
        #region Rotinas
        public Chefe_Marcelu()
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

        private void TocandoNotas()
        {
            /* NUMERO DAS NOTAS
             * 0 = Azul
             * 1 = Roxo
             * 2 = Vermelho
             * 3 = Laranja
             * 4 = Amarelo
             * 5 = Verde
             * 6 = Ciano
             */
            if (Sequencia[OneOfTheEight] == 0)
            {
                Caixa_Azul.BackgroundImage = BlueBALL_light;
                Caixa_Roxo.BackgroundImage = PurpleBALL;
                Caixa_Vermelho.BackgroundImage = RedBALL;
                Caixa_Laranja.BackgroundImage = OrangeBALL;
                Caixa_Amarelo.BackgroundImage = YellowBALL;
                Caixa_Verde.BackgroundImage = LimeBALL;
                Caixa_Ciano.BackgroundImage = AquaBALL;

                BlueSONG.Play();
            }

            else if (Sequencia[OneOfTheEight] == 1)
            {
                Caixa_Azul.BackgroundImage = BlueBALL;
                Caixa_Roxo.BackgroundImage = PurpleBALL_light;
                Caixa_Vermelho.BackgroundImage = RedBALL;
                Caixa_Laranja.BackgroundImage = OrangeBALL;
                Caixa_Amarelo.BackgroundImage = YellowBALL;
                Caixa_Verde.BackgroundImage = LimeBALL;
                Caixa_Ciano.BackgroundImage = AquaBALL;

                PurpleSONG.Play();
            }

            else if (Sequencia[OneOfTheEight] == 2)
            {
                Caixa_Azul.BackgroundImage = BlueBALL;
                Caixa_Roxo.BackgroundImage = PurpleBALL;
                Caixa_Vermelho.BackgroundImage = RedBALL_light;
                Caixa_Laranja.BackgroundImage = OrangeBALL;
                Caixa_Amarelo.BackgroundImage = YellowBALL;
                Caixa_Verde.BackgroundImage = LimeBALL;
                Caixa_Ciano.BackgroundImage = AquaBALL;

                RedSONG.Play();
            }

            else if (Sequencia[OneOfTheEight] == 3)
            {
                Caixa_Azul.BackgroundImage = BlueBALL;
                Caixa_Roxo.BackgroundImage = PurpleBALL;
                Caixa_Vermelho.BackgroundImage = RedBALL;
                Caixa_Laranja.BackgroundImage = OrangeBALL_light;
                Caixa_Amarelo.BackgroundImage = YellowBALL;
                Caixa_Verde.BackgroundImage = LimeBALL;
                Caixa_Ciano.BackgroundImage = AquaBALL;

                OrangeSONG.Play();
            }

            else if (Sequencia[OneOfTheEight] == 4)
            {
                Caixa_Azul.BackgroundImage = BlueBALL;
                Caixa_Roxo.BackgroundImage = PurpleBALL;
                Caixa_Vermelho.BackgroundImage = RedBALL;
                Caixa_Laranja.BackgroundImage = OrangeBALL;
                Caixa_Amarelo.BackgroundImage = YellowBALL_light;
                Caixa_Verde.BackgroundImage = LimeBALL;
                Caixa_Ciano.BackgroundImage = AquaBALL;

                YellowSONG.Play();
            }

            else if (Sequencia[OneOfTheEight] == 5)
            {
                Caixa_Azul.BackgroundImage = BlueBALL;
                Caixa_Roxo.BackgroundImage = PurpleBALL;
                Caixa_Vermelho.BackgroundImage = RedBALL;
                Caixa_Laranja.BackgroundImage = OrangeBALL;
                Caixa_Amarelo.BackgroundImage = YellowBALL;
                Caixa_Verde.BackgroundImage = LimeBALL_light;
                Caixa_Ciano.BackgroundImage = AquaBALL;

                LimeSONG.Play();
            }

            else if (Sequencia[OneOfTheEight] == 6)
            {
                Caixa_Azul.BackgroundImage = BlueBALL;
                Caixa_Roxo.BackgroundImage = PurpleBALL;
                Caixa_Vermelho.BackgroundImage = RedBALL;
                Caixa_Laranja.BackgroundImage = OrangeBALL;
                Caixa_Amarelo.BackgroundImage = YellowBALL;
                Caixa_Verde.BackgroundImage = LimeBALL;
                Caixa_Ciano.BackgroundImage = AquaBALL_light;

                AquaSONG.Play();
            }
        }

        private void Zerando()
        {
            Caixa_Azul.BackgroundImage = BlueBALL;
            Caixa_Roxo.BackgroundImage = PurpleBALL;
            Caixa_Vermelho.BackgroundImage = RedBALL;
            Caixa_Laranja.BackgroundImage = OrangeBALL;
            Caixa_Amarelo.BackgroundImage = YellowBALL;
            Caixa_Verde.BackgroundImage = LimeBALL;
            Caixa_Ciano.BackgroundImage = AquaBALL;
        }
        #endregion

        private void Chefe_Marcelo_Load(object sender, EventArgs e)
        {
            #region Organizando o gr�fico
            //Colocando as bolas coloridas nas picturesbox
            Zerando();

            //Colocando a imagem do muro no muro
            WALL.Image = Muro;

            //Colocando a imagem do professor na picturebox
            Marcelu.Image = Marcelu_SPR2;

            //Colocando as imagens do pergaminho
            TextPlace.Image = ControlPanel.Pergaminho;
            INFOtext.Image = Pergaminho;

            //Barra de vida e seu back
            LifeBar.BackgroundImage = Jogo.LifeBAR_IMG;
            BackLifeBar.BackgroundImage = Jogo.LifeBAR_IMG_bg;

            //Cara do personagem na vida
            LifesFace.Image = Jogo.HeadOfLives;

            //COlocando a imagem do etequer
            ETEQUER.Image = Etequer;
            #endregion
        }

        private void GameUpdater_Tick(object sender, EventArgs e)
        {
            #region verifica se o mouse est� em cima do bot�o de saida
            //verifica se o mouse esta em cima do bot�o de saida para poder dizer qual � a imagem que deve ser usada.
            if (ControlPanel.MouseLeft >= (Jogo.ExitButton_left) && ControlPanel.MouseLeft <= (Jogo.ExitButton_left + Jogo.ExitButton_width) && ControlPanel.MouseTop >= (Jogo.ExitButton_top) && ControlPanel.MouseTop <= (Jogo.ExitButton_top + Jogo.ExitButton_height))
            {
                ExitButton.Image = MainMenu.IMG_ExitButton_hover;
            }
            else
            {
                ExitButton.Image = MainMenu.IMG_ExitButton_normal;
            }
            #endregion
            #region Verifica se o jogador j� leu as regras do jogo
            if (READ == true)
            {
                TextPlace.Visible = false;
                INFOtext.Visible = false;
            }
            #endregion
            #region Atualiza a vida do muro
            if (Muro_life >= 0)
            {
                LifeBar.Width = Muro_life;
            }
            else
            {
                LifeBar.Width = 1;
                //O Etequer morre

                ControlPanel.TOTALblock = false;
                ControlPanel.GoFront = true;
                ControlPanel.JogoVisibleFALSE = false;
                ControlPanel.MestreNumber = 0;
                this.Close();
                Jogo.DiePig = true;
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
            //Dezenas s�o mostradas
            Jogo.intTOstring = Jogo.SubVida1;
            ConvertToIMG();
            Dezes.Image = Jogo.stringTOimg;
            Dezes.Update();

            //Unidades s�o mostradas
            Jogo.intTOstring = Jogo.SubVida2;
            ConvertToIMG();
            Unis.Image = Jogo.stringTOimg;
            Unis.Update();

            #endregion
            #region Recebe a informa��o de qual tecla foi pressionada
            if (IsPressedSomeButton == true)
            {
                if (NUMBERofNOTES != (OneOfTheEight + 1))
                {
                    //Se essa variavel naum ficar falsa ser� considerado como se o jogador tivesse apertado uma nova vez o bot�o toda hora que o timer rodasse
                    IsPressedSomeButton = false;
                    if (Press_Color == Color.Blue)
                    {
                        if (Sequencia[OneOfTheEight] == 0)
                        {
                            //Toca o som azul comemorando o acertar da tecla
                            BlueSONG.Play();

                            //Caso haja alguma esfera com luz, a luz � tirada e colocada na selecionada
                            Zerando();
                            Caixa_Azul.BackgroundImage = BlueBALL_light;
                        }
                        else
                        {
                            //Caso o jogador erre a tecla
                            MadeWrong.Play();
                            //Reinicia
                            OneOfTheEight = -1;
                            Zerando();
                        }
                    }

                    else if (Press_Color == Color.Purple)
                    {
                        if (Sequencia[OneOfTheEight] == 1)
                        {
                            PurpleSONG.Play();

                            Zerando();
                            Caixa_Roxo.BackgroundImage = PurpleBALL_light;
                        }
                        else
                        {
                            MadeWrong.Play();
                            OneOfTheEight = -1;
                            Zerando();
                        }
                    }

                    else if (Press_Color == Color.Red)
                    {
                        if (Sequencia[OneOfTheEight] == 2)
                        {
                            RedSONG.Play();

                            Zerando();
                            Caixa_Vermelho.BackgroundImage = RedBALL_light;
                        }
                        else
                        {
                            MadeWrong.Play();
                            OneOfTheEight = -1;
                            Zerando();
                        }
                    }

                    else if (Press_Color == Color.Orange)
                    {
                        if (Sequencia[OneOfTheEight] == 3)
                        {
                            OrangeSONG.Play();

                            Zerando();
                            Caixa_Laranja.BackgroundImage = OrangeBALL_light;
                        }
                        else
                        {
                            MadeWrong.Play();
                            OneOfTheEight = -1;
                            Zerando();
                        }
                    }

                    else if (Press_Color == Color.Yellow)
                    {
                        if (Sequencia[OneOfTheEight] == 4)
                        {
                            YellowSONG.Play();

                            Zerando();
                            Caixa_Amarelo.BackgroundImage = YellowBALL_light;
                        }
                        else
                        {
                            MadeWrong.Play();
                            OneOfTheEight = -1;
                            Zerando();
                        }
                    }

                    else if (Press_Color == Color.Green)
                    {
                        if (Sequencia[OneOfTheEight] == 5)
                        {
                            LimeSONG.Play();

                            Zerando();
                            Caixa_Verde.BackgroundImage = LimeBALL_light;
                        }
                        else
                        {
                            MadeWrong.Play();
                            OneOfTheEight = -1;
                            Zerando();
                        }
                    }

                    else if (Press_Color == Color.Aqua)
                    {
                        if (Sequencia[OneOfTheEight] == 6)
                        {
                            AquaSONG.Play();

                            Zerando();
                            Caixa_Ciano.BackgroundImage = AquaBALL_light;
                        }
                        else
                        {
                            MadeWrong.Play();
                            OneOfTheEight = -1;
                            Zerando();
                        }
                    }
                    OneOfTheEight++;
                }
                else
                {
                    Completas++;
                    Zerando();
                    IsPressedSomeButton = false;
                    OneOfTheEight = 0;
                    HowManyISdecided = false;
                    IsDemonstring = true;
                }
            }
            #endregion
            #region Mostrando o n�mero de sequencias completadas pelo jogador
            COMP.Text = Completas.ToString();
            #endregion
        }

        private void MediumAnimation_Tick(object sender, EventArgs e)
        {
            #region Fazendo anima��o do chefe marcelo atr�s da parede
            if (MarceluAnimation == 1)
            {
                Marcelu.Image = Marcelu_SPR1;
                MarceluAnimation++;
            }

            else if (MarceluAnimation == 2)
            {
                Marcelu.Image = Marcelu_SPR2;
                MarceluAnimation++;
            }

            else if (MarceluAnimation == 3)
            {

                Marcelu.Image = Marcelu_SPR3;
                MarceluAnimation++;
                if (READ == true)
                {
                    //Essa imagem � a imagem de marcelu batendo na parede, automaticamente � nela que se deve conter o dano. O dano � o c�digo a seguir
                    DamageValue = Damage.Next(5);
                    Muro_life -= DamageValue;
                }
            }

            else if (MarceluAnimation == 4)
            {
                Marcelu.Image = Marcelu_SPR2;
                MarceluAnimation = 1;
            }
            #endregion
        }

        private void Demonstration_Tick(object sender, EventArgs e)
        {
            //Esse timer � usado para fazer a demonstra��o das notas que forem tocadas.
            #region Tocando os sons do chefe para que o jogador reproduza-os
            if (Completas != 8)
            {
                if (IsDemonstring == true)
                {
                    //V� quantas notas ser�o tocadas
                    if (HowManyISdecided == false)
                    {
                        NUMBERofNOTES = HowManyNotes.Next(5, 8);
                        HowManyISdecided = true;
                    }
                    //Toca as notas
                    if (NUMBERofNOTES != (OneOfTheEight + 1))
                    {
                        Sequencia[OneOfTheEight] = WhoSingNow.Next(6);
                        TocandoNotas();
                        OneOfTheEight++;
                    }
                    else
                    {
                        //Deixa todas esferas apagadas
                        Zerando();
                        IsDemonstring = false;
                        OneOfTheEight = 0;
                    }
                }
            }
            else
            {
                // 
                //Nesse else vai ficar oq ocorre quando se conclui o chefe, vencendo
                //
                ControlPanel.TOTALblock = false;
                ControlPanel.GoFront = true;
                ControlPanel.JogoVisibleFALSE = false;
                ControlPanel.MestreNumber = 0;
                Jogo.MarceluFight = true;
                this.Close();
                Jogo.TALK++;
            }
            #endregion
        }
    }
}