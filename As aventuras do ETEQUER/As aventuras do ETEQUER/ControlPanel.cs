using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Bibliotecas que eu adicionei
using WMPLib;
using System.Media;

namespace As_aventuras_do_ETEQUER
{
    public partial class ControlPanel : Form
    {
        #region Variaveis
        static public bool CARREGADO;
        //Avisa se o jogador vai colocar trapaças
        static public bool CHEAT = false;
        //analisa a posição do formulário para saber se estão todos alinhados
        static public int ThisCheckLeft, ThisCheckTop;
        //Verifica se o formulario já esta ativo
        static public bool IAmStarted = false;
        //Vê a posição do mouse dentro do formulario
        static public int MouseLeft, MouseTop;
        //É o valor aumentado na LoadBar depois de carregar cada arquivo
        int Porcent = 1;
        //Essa variavel serve para o Videos avisar o ControlPanel quando o video foi concluido
        static public bool IsFirstVideoFinished = false;
        //Essa variavel mostra o valor da velocidade do personagem
        static public int VELOCIDADE = 10;
        //Essa variavel facilita o carregamento de varias arquivos com nome semelhante, cuja unica diferença seja um numero sequencial, como no caso das animações das caixas.
        int VETOR = 0, FILE = 1;
        //Bloqueia as teclas de comando do jogos e o outro bloqueia todas menos pause
        static public bool TOTALblock = false, PAUSEblock = false;
        //Verifica em qual mestre o jogador esta
        static public int MestreNumber = 0;
        /* 0 = Fora de mestre
         * 1 = Marcelu
         * 2 = Muacir
         * 3 = Agustinho I
         * 4 = Agustinho II
         * 5 = Luis Carlos
         * 6 = TCC*/
        static public Image Pergaminho;

        //Envia o painel de controle para frente caso for pedido
        static public bool GoFront = false;
        //Deixa a tela do jogo invisivel
        static public bool JogoVisibleFALSE = false;

        //Essa variavel faz um random de cores sorteando uma para deixar no fundo da tela de carregando
        Random COR = new Random();
        //Essa variavel recebe o valor do random acima
        int CORselected;

        //Avisa se deseja sair do jogo
        static public bool KILLthat = false;
        #endregion
        #region Rotinas
        public ControlPanel()
        {
            InitializeComponent();
        }
        #endregion

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            #region organizando o gráfico
            this.BringToFront();
            Updater.Enabled = true;

            CORselected = COR.Next(10);
            if (CORselected == 0)
            {
                this.BackColor = Color.DarkGreen;
            }

            else if (CORselected == 1)
            {
                this.BackColor = Color.Indigo;
            }

            else if (CORselected == 2)
            {
                this.BackColor = Color.Black;
            }

            else if (CORselected == 3)
            {
                this.BackColor = Color.Maroon;
            }

            else if (CORselected == 4)
            {
                this.BackColor = Color.DarkSlateGray;
            }

            else if (CORselected == 5)
            {
                this.BackColor = Color.DarkCyan;
            }

            else if (CORselected == 6)
            {
                this.BackColor = Color.MidnightBlue;
            }

            else if (CORselected == 7)
            {
                this.BackColor = Color.DimGray;
            }

            else if (CORselected == 8)
            {
                this.BackColor = Color.SaddleBrown;
            }

            else if (CORselected == 9)
            {
                this.BackColor = Color.OliveDrab;
            }

            else if (CORselected == 10)
            {
                this.BackColor = Color.RoyalBlue;
            }
            #endregion
        }

        private void ControlPanel_KeyDown(object sender, KeyEventArgs e)
        {
            #region Fechando com o apertar de ESC
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            #endregion
            #region Fecha todo aplicativo caso aperte Alt + F4
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                Application.Exit();
            }
            #endregion
            #region Apertar Enter para sair do video
            if (Videos.SomethingPlayingInMe == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Videos.WannaExit = true;
                }
            }
            #endregion
            #region COMANDOS
            #region Comandos usados nas fases
            //Bloqueia todas as teclas menos a de pausa
            if (PAUSEblock == false)
            {
                //Bloqueia todas as teclas que envolvem o jogo
                if (Jogo.TALKing == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (Jogo.DontMOVE == true)
                        {
                        }
                        else
                        {
                            Jogo.TALK++;
                        }
                    }
                }

                else if (TOTALblock == false)
                {
                    if (e.KeyCode == MainMenu.Direita)
                    {
                        //Cancela o movimento da posição oposta
                        Jogo.CanTryMoveAllforESQ = false;
                        //Analisa se há caixas impedindo a movimentação do personagem, caso contrario ordena a execução de todos comandos de movimentação
                        Jogo.CanTryMoveAllforDIR = true;
                    }

                    else if (e.KeyCode == MainMenu.Esquerda)
                    {
                        //Cancela o movimento da posição oposta
                        Jogo.CanTryMoveAllforDIR = false;
                        //Analisa se há caixas impedindo a movimentação do personagem, caso contrario ordena a execução de todos comandos de movimentação
                        Jogo.CanTryMoveAllforESQ = true;
                    }

                    else if (e.KeyCode == MainMenu.Estabil)
                    {
                        //Cancela o movimento da posição oposta
                        Jogo.CanTryMoveAllforDIR = false;
                        //Analisa se há caixas impedindo a movimentação do personagem, caso contrario ordena a execução de todos comandos de movimentação
                        Jogo.CanTryMoveAllforESQ = false;
                    }

                    else if (e.KeyCode == MainMenu.Pula)
                    {
                        //Avisa que o jogador esta "no ar", ele ficará assim até que caia, impedindo-o de dar dois pulos entre outras ações.
                        if (Jogo.IAmStarted == true)
                        {
                            Jogo.Subindo_PULO = true;
                        }
                    }

                    else if (e.KeyCode == MainMenu.SelfKill)
                    {
                        Jogo.DiePig = true;
                    }

                    else if (e.KeyCode == MainMenu.Pause)
                    {
                        TOTALblock = true;
                        PAUSEblock = true;
                    }
                }
            }

            else if (e.KeyCode == MainMenu.Pause || e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                TOTALblock = false;
                PAUSEblock = false;
            }

            else if (e.KeyCode == Keys.Q)
            {
                //FECHA O JOGO
            }

            else if (e.KeyCode == Keys.NumPad0)
            {
                CHEAT = true;
            }


            

            #endregion
            #region Comando do Marcelu
            if (MestreNumber == 1)
            {
                //Analisa se o jogador já leu as regras sobre como jogar com o chefe
                if (Chefe_Marcelu.READ == true)
                {
                    //Analisa se o jogador esta vendo como deve ser tocado.
                    if (Chefe_Marcelu.IsDemonstring == false)
                    {
                        if (e.KeyCode == Keys.NumPad7)
                        {
                            //Envia uma cor para essa variavel de acordo com a tecla pressionada
                            Chefe_Marcelu.Press_Color = Color.Blue;
                            //Avisa que uma tecla foi pressionada
                            Chefe_Marcelu.IsPressedSomeButton = true;
                        }
                        else if (e.KeyCode == Keys.NumPad8)
                        {
                            Chefe_Marcelu.Press_Color = Color.Purple;
                            Chefe_Marcelu.IsPressedSomeButton = true;
                        }
                        else if (e.KeyCode == Keys.NumPad9)
                        {
                            Chefe_Marcelu.Press_Color = Color.Red;
                            Chefe_Marcelu.IsPressedSomeButton = true;
                        }
                        else if (e.KeyCode == Keys.NumPad5)
                        {
                            Chefe_Marcelu.Press_Color = Color.Orange;
                            Chefe_Marcelu.IsPressedSomeButton = true;
                        }
                        else if (e.KeyCode == Keys.NumPad1)
                        {
                            Chefe_Marcelu.Press_Color = Color.Yellow;
                            Chefe_Marcelu.IsPressedSomeButton = true;
                        }
                        else if (e.KeyCode == Keys.NumPad2)
                        {
                            Chefe_Marcelu.Press_Color = Color.Green;
                            Chefe_Marcelu.IsPressedSomeButton = true;
                        }
                        else if (e.KeyCode == Keys.NumPad3)
                        {
                            Chefe_Marcelu.Press_Color = Color.Aqua;
                            Chefe_Marcelu.IsPressedSomeButton = true;
                        }
                    }
                }
                else if (Chefe_Marcelu.READ == false)
                {
                    if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                    {
                        Chefe_Marcelu.READ = true;
                        Chefe_Marcelu.IsDemonstring = true;
                    }
                }
            }
            #endregion
            #region Comando do Muacir
            if (MestreNumber == 2)
            {
                if (e.KeyCode == Keys.Right)
                {
                    Chefe_Muacir.SendingComandos = Keys.Right;
                }

                else if (e.KeyCode == Keys.Left)
                {
                    Chefe_Muacir.SendingComandos = Keys.Left;
                }

                else if (e.KeyCode == Keys.Up)
                {
                    Chefe_Muacir.SendingComandos = Keys.Up;
                }

                else if (e.KeyCode == Keys.Down)
                {
                    Chefe_Muacir.SendingComandos = Keys.Down;
                }

                else if (e.KeyCode == Keys.Space)
                {
                    Chefe_Muacir.SendingComandos = Keys.Space;
                }
            }
            #endregion
            #region Comando do Agustinho
            if (MestreNumber == 3)
            {
                if (e.KeyCode == Keys.Up)
                {
                    Chefe_Agustinho.Way = 1;
                }

                else if (e.KeyCode == Keys.Down)
                {
                    Chefe_Agustinho.Way = 2;
                }
            }
#endregion
            #region Comando Louis Carlos
            if (MestreNumber == 4)
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (Louis_Carlos.selected == 3)
                    {
                        Louis_Carlos.selected = 1;
                    }
                    else
                    {
                        Louis_Carlos.selected++;
                    }
                }

                else if (e.KeyCode == Keys.Up)
                {
                    if (Louis_Carlos.selected == 1)
                    {
                        Louis_Carlos.selected = 3;
                    }
                    else
                    {
                        Louis_Carlos.selected--;
                    }
                }

                else if (e.KeyCode == Keys.Space)
                {
                    Louis_Carlos.SpacePressed = true;
                }
            }
            #endregion
            #endregion
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            #region Deixa o painel de controle na frente quando for pedido
            if (GoFront == true)
            {
                this.BringToFront();
                GoFront = false;
            }
            #endregion
            #region Análise de erros
            IAmStarted = true;
            ThisCheckLeft = this.Left;
            ThisCheckTop = this.Top;

            //verifica se os formularios estão iniciados
            if (Jogo.IAmStarted == true && Fundo.IAmStarted == true && ControlPanel.IAmStarted == true)
            {
                //Verifica se os formularios estão alinhados
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
            #region Carregando arquivos
            if (CARREGADO == false)
            {
                #region 0% para 25%
                //Carregando a imagem no fundo
                Fundo.InGameBG = Image.FromFile("Grafico//modone.bg"); //1
                LoadBar.Value = LoadBar.Value + Porcent;
                //Carregando a fonte dos números
                Jogo.Zero = Image.FromFile("Fonte//fontzero.numb"); //2
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Um = Image.FromFile("Fonte//fontone.numb"); //3
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Dois = Image.FromFile("Fonte//fonttwo.numb"); //4
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Tres = Image.FromFile("Fonte//fontthree.numb"); //5
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Quatro = Image.FromFile("Fonte//fontfour.numb"); //6
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Cinco = Image.FromFile("Fonte//fontfive.numb"); //7
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Seis = Image.FromFile("Fonte//fontsix.numb"); //8
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Sete = Image.FromFile("Fonte//fontseven.numb"); //9
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Oito = Image.FromFile("Fonte//fonteight.numb"); //10
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Nove = Image.FromFile("Fonte//fontnine.numb"); //11
                LoadBar.Value = LoadBar.Value + Porcent;
                //Carregando a carinha das vidas
                Jogo.HeadOfLives = Image.FromFile("Programa//Lifes.grf"); //12
                LoadBar.Value = LoadBar.Value + Porcent;
                //Carregando do grafico geral do personagem
                Jogo.Etequer1_DIR = Image.FromFile("Grafico//eter1_DIR.grf"); //13
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Etequer2_DIR = Image.FromFile("Grafico//eter2_DIR.grf"); //14
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Etequer3_DIR = Image.FromFile("Grafico//eter3_DIR.grf"); //15
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FW_Etequer1_DIR = Image.FromFile("Grafico//FW_eter1_DIR.grf"); //16
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FW_Etequer2_DIR = Image.FromFile("Grafico//FW_eter2_DIR.grf"); //17
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FW_Etequer3_DIR = Image.FromFile("Grafico//FW_eter3_DIR.grf"); //18
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Etequer1_ESQ = Image.FromFile("Grafico//eter1_ESQ.grf"); //19
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Etequer2_ESQ = Image.FromFile("Grafico//eter2_ESQ.grf"); //20
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.Etequer3_ESQ = Image.FromFile("Grafico//eter3_ESQ.grf"); //21
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FW_Etequer1_ESQ = Image.FromFile("Grafico//FW_eter1_ESQ.grf"); //22
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FW_Etequer2_ESQ = Image.FromFile("Grafico//FW_eter2_ESQ.grf"); //23
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FW_Etequer3_ESQ = Image.FromFile("Grafico//FW_eter3_ESQ.grf"); //24
                LoadBar.Value = LoadBar.Value + Porcent;
                #endregion
                #region 25%
                //Carregando as imagens do chefe agustinho
                Jogo.Agustinho_01 = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\agustinho_01.grf");
                Jogo.Agustinho_02 = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\agustinho_02.grf");
                Jogo.Agustinho_03 = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\agustinho_03.grf");

                //Carregando as imagens dos misseis do chefe agustinho
                Chefe_Agustinho.M_Down = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Missil\\Missiel_down.grf");
                Chefe_Agustinho.M_Up = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Missil\\Missiel_up.grf");
                Chefe_Agustinho.M_Right = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Missil\\Missiel_right.grf");
                Chefe_Agustinho.M_Left = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Missil\\Missiel_left.grf");

                Chefe_Agustinho.M_Left_Down = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Missil\\Missiel_DownLeft.grf");
                Chefe_Agustinho.M_Right_Down = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Missil\\Missiel_DownRight.grf");
                Chefe_Agustinho.M_Right_Up = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Missil\\Missiel_UpRight.grf");
                Chefe_Agustinho.M_Left_Up = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Missil\\Missiel_UpLeft.grf");

                //Carregando a imagem do agustinho como InBoss
                Chefe_Agustinho.Agustinho_IMG = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Agustinho.grf");
                //Carregando a imagem do etequer em relação ao chefe Agustinho
                Chefe_Agustinho.Etequer_IMG = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Etequer.grf");

                //Carregando a imagem de fundo do chefe
                Fundo.Agustinhobg = Image.FromFile("Grafico\\Inimigos\\Augustinho IMC\\Fundo.grf");

                //Louis Carlos
                //Carregando imagem do menu do chefe Louis Carlos
                Louis_Carlos.MENU = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Menu.grf");

                //Carregando os efeitos graficos
                Louis_Carlos.ShotGun[0] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0001.grf");
                Louis_Carlos.ShotGun[1] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0002.grf");
                Louis_Carlos.ShotGun[2] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0003.grf");
                Louis_Carlos.ShotGun[3] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0004.grf");
                Louis_Carlos.ShotGun[4] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0005.grf");
                Louis_Carlos.ShotGun[5] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0006.grf");
                Louis_Carlos.ShotGun[6] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0007.grf");
                Louis_Carlos.ShotGun[7] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0008.grf");
                Louis_Carlos.ShotGun[8] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0009.grf");
                Louis_Carlos.ShotGun[9] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0010.grf");
                Louis_Carlos.ShotGun[10] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0011.grf");
                Louis_Carlos.ShotGun[11] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0012.grf");
                Louis_Carlos.ShotGun[12] = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\toshoot0013.grf");

                Louis_Carlos.Metralha1 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\metralha - 1.grf");
                Louis_Carlos.Metralha2 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\metralha - 2.grf");
                Louis_Carlos.Metralha3 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Efeitos graficos\\metralha - 3.grf");

                //Carregando o cenario
                Louis_Carlos.BOX1 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\CaixaI.grf");
                Louis_Carlos.BOX2 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\CaixaII.grf");
                Fundo.LCbg = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\fundo.grf");

                //Carregando os arquivos dos graficos do jogador e do chefe
                Louis_Carlos.LC1 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\LC_ATK - 1.grf");
                Louis_Carlos.LC2 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\LC_ATK - 2.grf");
                Louis_Carlos.LC_W8 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\LC_W8.grf");

                Louis_Carlos.Eter1 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Etequer_ATK - 1.grf");
                Louis_Carlos.Eter2 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Etequer_ATK - 2.grf");
                Louis_Carlos.Eter3 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Etequer_ATK - 3.grf");
                Louis_Carlos.Eter_W8 = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\Etequer_W8.grf");

                //Carregando a imagem do Louis Carlos pacato, usada no encontro do formulario "jogo" entre os dois
                Jogo.LouisCarlosIMG = Image.FromFile("Grafico\\Inimigos\\Louis Carlos\\LC.grf");

                #endregion
                #region 25% para 50%
                //Outros graficos
                Jogo.LifeBAR_IMG_bg = Image.FromFile("Grafico//transparent.bg"); //25
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.LifeBAR_IMG = Image.FromFile("Grafico//lifebar.bg"); //26
                LoadBar.Value = LoadBar.Value + Porcent;
                //Piso da primeira fase
                Jogo.YellowTile = Image.FromFile("Grafico//Tiles//MOD1.TIL"); //27
                LoadBar.Value = LoadBar.Value + Porcent;
                //Arquivos "Eu sou um" (I'm a)
                Jogo.IMA_Tile = Image.FromFile("Reconhece//tile.IMA"); //28
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_CdBox = Image.FromFile("Reconhece//CdBox.IMA"); //29
                LoadBar.Value = LoadBar.Value + Porcent;
                //Pisos das outras fases
                Jogo.GrayTile = Image.FromFile("Grafico//Tiles//MOD2.TIL"); //30
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.GreenTile = Image.FromFile("Grafico//Tiles//MOD3.TIL"); //31
                LoadBar.Value = LoadBar.Value + Porcent;
                //Carregando caixas e items
                Jogo.CDbox = Image.FromFile("Grafico//Tiles//CD.BOX"); //32
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.CDitem = Image.FromFile("Grafico//Tiles//CD.ITM"); //33
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.DVDbox = Image.FromFile("Grafico//Tiles//DVD.BOX"); //34
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.DVDitem = Image.FromFile("Grafico//Tiles//DVD.ITM"); //35
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.PENbox = Image.FromFile("Grafico//Tiles//PEN.BOX"); //36
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.PENitem = Image.FromFile("Grafico//Tiles//PEN.ITM"); //37
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FWbox = Image.FromFile("Grafico//Tiles//FW.BOX"); //38
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FWitem_SPR1 = Image.FromFile("Grafico//Tiles//FW1.ITM"); //39
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.FWitem_SPR2 = Image.FromFile("Grafico//Tiles//FW2.ITM"); //40
                LoadBar.Value = LoadBar.Value + Porcent;
                //Arquivos "Eu sou um"
                Jogo.IMA_StarItem = Image.FromFile("Reconhece//StarItem.IMA"); //41
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_CdItem = Image.FromFile("Reconhece//CdItem.IMA"); //42
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_DvdBox = Image.FromFile("Reconhece//DvdBox.IMA"); //43
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_DvdItem = Image.FromFile("Reconhece//DvdItem.IMA"); //44
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_FwBox = Image.FromFile("Reconhece//FwBox.IMA"); //45
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_FwItem = Image.FromFile("Reconhece//FwItem.IMA"); //46
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_PenBox = Image.FromFile("Reconhece//PenBox.IMA"); //47
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_PenItem = Image.FromFile("Reconhece//PenItem.IMA"); //48
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_LifeBox = Image.FromFile("Reconhece//LifeBox.IMA"); //49
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.IMA_LifeItem = Image.FromFile("Reconhece//LifeItem.IMA"); //50
                LoadBar.Value = LoadBar.Value + Porcent;
                #endregion
                #region 50%
                //Arquivos para animação da quebra de caixa
                VETOR = 0; FILE = 1;
                for (VETOR = 0; VETOR <= 15; VETOR++)
                {
                    Jogo.LIFEani[VETOR] = Image.FromFile("Grafico//Tiles//Animation//LIFEBOXs//LIFEbox_" + FILE.ToString() + ".ani");
                    FILE++;
                }

                VETOR = 0; FILE = 1;
                for (VETOR = 0; VETOR <= 15; VETOR++)
                {
                    Jogo.PENani[VETOR] = Image.FromFile("Grafico//Tiles//Animation//PENBOXs//PENbox_" + FILE.ToString() + ".ani");
                    FILE++;
                }

                VETOR = 0; FILE = 1;
                for (VETOR = 0; VETOR <= 15; VETOR++)
                {
                    Jogo.STARani[VETOR] = Image.FromFile("Grafico//Tiles//Animation//STARBOXs//STARbox_" + FILE.ToString() + ".ani");
                    FILE++;
                }

                //Arquivos IMA para chefes e amigos
                Jogo.IMA_Roza = Image.FromFile("Reconhece/Roza.ima");
                Jogo.IMA_Marcelu_Friend = Image.FromFile("Reconhece/MarceluBom.ima");
                Jogo.IMA_Marcelu_Boss = Image.FromFile("Reconhece/MarceluMal.ima");
                Jogo.IMA_Muacir = Image.FromFile("Reconhece/Muacir.ima");
                Jogo.IMA_Renatu = Image.FromFile("Reconhece/Renatu.IMA");
                Jogo.IMA_Agustinho = Image.FromFile("Reconhece/Agustinho.ima");
                Jogo.IMA_Cleito = Image.FromFile("Reconhece/Cleito.IMA");
                Jogo.IMA_LouisCarlos = Image.FromFile("Reconhece/LouisCarlos.IMA");

                //Pergaminho usado nos chefes para explicação de como enfrenta-los
                Pergaminho = Image.FromFile("Grafico\\BossInfo.grf");
                //Arquivos usados na conversação dos personagens
                Jogo.Pergaminho = Image.FromFile("Grafico//pergaminho.grf");
                Jogo.textoA = Image.FromFile("Grafico//text1.grf");
                Jogo.textoB = Image.FromFile("Grafico//text2.grf");
                Jogo.textoC = Image.FromFile("Grafico//text3.grf");

                //Arquivos de efeito sonoro ao pegar um item
                Jogo.FWeff = new SoundPlayer("Grafico//FW.eff");
                Jogo.LIFEeff = new SoundPlayer("Grafico//LIFE.eff");
                Jogo.STAReff = new SoundPlayer("Grafico//STAR.eff");
                Jogo.ITEMSeff = new SoundPlayer("Grafico//ITEMS.eff");

                //Arquivos I'm a (Eu sou um...), esses servem para reconhecer os Boots
                Jogo.IMA_BadGuy = Image.FromFile("Reconhece//BadGuy.IMA");
                Jogo.IMA_Daivison = Image.FromFile("Reconhece//Daivison.IMA");
                Jogo.IMA_Erwin = Image.FromFile("Reconhece//Erwin.IMA");

                //Carregando imagens dos monstros boots
                //Etequers do mal
                Jogo.BadGuy_DIR1 = Image.FromFile("Grafico//Inimigos//BadGuy//BadGuy1_DIR.grf");
                Jogo.BadGuy_DIR2 = Image.FromFile("Grafico//Inimigos//BadGuy//BadGuy2_DIR.grf");
                Jogo.BadGuy_DIR3 = Image.FromFile("Grafico//Inimigos//BadGuy//BadGuy3_DIR.grf");

                Jogo.BadGuy_ESQ1 = Image.FromFile("Grafico//Inimigos//BadGuy//BadGuy1_ESQ.grf");
                Jogo.BadGuy_ESQ2 = Image.FromFile("Grafico//Inimigos//BadGuy//BadGuy2_ESQ.grf");
                Jogo.BadGuy_ESQ3 = Image.FromFile("Grafico//Inimigos//BadGuy//BadGuy3_ESQ.grf");

                //Davison
                Jogo.Daivison1 = Image.FromFile("Grafico//Inimigos//Daivison//DAIVISON1.grf");
                Jogo.Daivison2 = Image.FromFile("Grafico//Inimigos//Daivison//DAIVISON2.grf");

                //ALIADOS
                //Roza
                Jogo.Roza1 = Image.FromFile("Grafico//Aliados//Roza//Roza_SPR1.grf");
                Jogo.Roza2 = Image.FromFile("Grafico//Aliados//Roza//Roza_SPR2.grf");
                Jogo.Roza2x2 = Image.FromFile("Grafico//Aliados//Roza//Roza_SPR2.grf");
                Jogo.Roza3 = Image.FromFile("Grafico//Aliados//Roza//Roza_SPR3.grf");

                Jogo.RozaEXIT1 = Image.FromFile("Grafico//Aliados//Roza//Roza_EXITing1.grf");
                Jogo.RozaEXIT2 = Image.FromFile("Grafico//Aliados//Roza//Roza_EXITing2.grf");
                Jogo.RozaEXIT3 = Image.FromFile("Grafico//Aliados//Roza//Roza_EXITing3.grf");
                Jogo.RozaEXIT4 = Image.FromFile("Grafico//Aliados//Roza//Roza_EXITing4.grf");

                //Marcelu
                Jogo.MarceluOE = Image.FromFile("Grafico//Aliados//Marcelu//MARCELU_SPR1.grf");
                Jogo.MarceluCE = Image.FromFile("Grafico//Aliados//Marcelu//MARCELU_SPR2.grf");

                //CHEFES
                //Marcelu
                //Pergaminho de explicação para marcelo, colocado na LABEL
                Chefe_Marcelu.Pergaminho = Image.FromFile("Grafico\\Inimigos\\Marcelu\\MarceluInfo.grf");

                //Carregando o gráfico do Etequer durante a luta Marcelo vs Etequer
                Chefe_Marcelu.Etequer = Image.FromFile("Grafico\\Inimigos\\Marcelu\\Etequer.grf");

                //Carregando as esferas coloridas
                Chefe_Marcelu.BlueBALL = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Azul.grf");
                Chefe_Marcelu.PurpleBALL = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Roxo.grf");
                Chefe_Marcelu.RedBALL = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Vermelho.grf");
                Chefe_Marcelu.OrangeBALL = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Laranja.grf");
                Chefe_Marcelu.YellowBALL = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Amarelo.grf");
                Chefe_Marcelu.LimeBALL = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Verde.grf");
                Chefe_Marcelu.AquaBALL = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Ciano.grf");

                Chefe_Marcelu.BlueBALL_light = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Azul_brilho.grf");
                Chefe_Marcelu.PurpleBALL_light = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Roxo_brilho.grf");
                Chefe_Marcelu.RedBALL_light = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Vermelho_brilho.grf");
                Chefe_Marcelu.OrangeBALL_light = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Laranja_brilho.grf");
                Chefe_Marcelu.YellowBALL_light = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Amarelo_brilho.grf");
                Chefe_Marcelu.LimeBALL_light = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Verde_brilho.grf");
                Chefe_Marcelu.AquaBALL_light = Image.FromFile("Grafico//Inimigos//Marcelu//Esferas//Ciano_brilho.grf");

                //Carregando o plano de fundo do chefe
                Fundo.MarceluBG = Image.FromFile("Grafico\\Inimigos\\Marcelu\\fundo.bg");

                //Imagem do muro que bloqueia o marcelo
                Chefe_Marcelu.Muro = Image.FromFile("Grafico\\Inimigos\\Marcelu\\Muro.grf");

                //Carregando os sons
                Chefe_Marcelu.BlueSONG = new SoundPlayer("Grafico//Inimigos//Marcelu//Efeitos//Azul.eff");
                Chefe_Marcelu.PurpleSONG = new SoundPlayer("Grafico//Inimigos//Marcelu//Efeitos//Roxo.eff");
                Chefe_Marcelu.RedSONG = new SoundPlayer("Grafico//Inimigos//Marcelu//Efeitos//Vermelho.eff");
                Chefe_Marcelu.OrangeSONG = new SoundPlayer("Grafico//Inimigos//Marcelu//Efeitos//Laranja.eff");
                Chefe_Marcelu.YellowSONG = new SoundPlayer("Grafico//Inimigos//Marcelu//Efeitos//Amarelo.eff");
                Chefe_Marcelu.LimeSONG = new SoundPlayer("Grafico//Inimigos//Marcelu//Efeitos//Verde.eff");
                Chefe_Marcelu.AquaSONG = new SoundPlayer("Grafico//Inimigos//Marcelu//Efeitos//Ciano.eff");
                //Som de "errado"
                Chefe_Marcelu.MadeWrong = new SoundPlayer("Grafico//Inimigos//Marcelu//Efeitos//Errado.eff");

                //O chefe se movimentando
                Chefe_Marcelu.Marcelu_SPR1 = Image.FromFile("Grafico//Inimigos//Marcelu//Chefe//Marcelu_ATC_1.grf");
                Chefe_Marcelu.Marcelu_SPR2 = Image.FromFile("Grafico//Inimigos//Marcelu//Chefe//Marcelu_ATC_2.grf");
                Chefe_Marcelu.Marcelu_SPR3 = Image.FromFile("Grafico//Inimigos//Marcelu//Chefe//Marcelu_ATC_3.grf");


                //MUACIR
                //Carregando as imagens do trem -- Frente
                Chefe_Muacir.Head1 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Head01.grf");
                Chefe_Muacir.Head2 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Head02.grf");
                // -- Traseira
                Chefe_Muacir.Tails = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Tail.grf");
                // -- Fumaça
                Chefe_Muacir.Fuma1 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke1.grf");
                Chefe_Muacir.Fuma2 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke2.grf");
                Chefe_Muacir.Fuma3 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke3.grf");
                Chefe_Muacir.Fuma4 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke4.grf");
                Chefe_Muacir.Fuma5 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke5.grf");
                Chefe_Muacir.Fuma6 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke6.grf");
                Chefe_Muacir.Fuma7 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke7.grf");
                Chefe_Muacir.Fuma8 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke8.grf");
                Chefe_Muacir.Fuma9 = Image.FromFile("Grafico\\Inimigos\\Muacir\\Trem\\Smoke9.grf");

                //Inimigos de dentro do chefe
                Chefe_Muacir.Dengue1 = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\dengue01.grf");
                Chefe_Muacir.Dengue2 = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\dengue02.grf");

                Chefe_Muacir.Nave = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\avião.grf");

                Chefe_Muacir.Bird1 = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\bird1.grf");
                Chefe_Muacir.Bird2 = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\bird2.grf");

                Chefe_Muacir.Nuvem = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\nuvem.grf");

                Chefe_Muacir.Morcego1 = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\morcego1.grf");
                Chefe_Muacir.Morcego2 = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\morcego2.grf");
                Chefe_Muacir.Morcego3 = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\morcego3.grf");

                Chefe_Muacir.Satelite = Image.FromFile("Grafico\\Inimigos\\Muacir\\AirEnemys\\satelite.grf");

                //Etequer dentro do chefe muacir
                Chefe_Muacir.ETEQUER_IMG = Image.FromFile("Grafico\\Inimigos\\Muacir\\Etequer.grf");

                //Carregando as imagens do Muacir antes de enfrete-lo como chefe
                Jogo.Muacir1 = Image.FromFile("Grafico\\Inimigos\\Muacir\\MUACIR_SPR1.grf");
                Jogo.Muacir2_1 = Image.FromFile("Grafico\\Inimigos\\Muacir\\MUACIR_SPR2.grf");
                Jogo.Muacir2_2 = Image.FromFile("Grafico\\Inimigos\\Muacir\\MUACIR_SPR2-1.grf");
                Jogo.Muacir3 = Image.FromFile("Grafico\\Inimigos\\Muacir\\MUACIR_SPR3.grf");
                Jogo.Muacir4 = Image.FromFile("Grafico\\Inimigos\\Muacir\\MUACIR_SPR4.grf");

                //Carrega o plano de fundo do chefe Muacir
                Fundo.MuacirBG = Image.FromFile("Grafico\\Inimigos\\Muacir\\fundo.grf");
                #endregion
                #region 50% para 79%
                Jogo.IMA_StarBox = Image.FromFile("Reconhece//StarBox.IMA"); //51
                LoadBar.Value = LoadBar.Value + Porcent;
                //Arquivos Theme, ou seja, musicas de tema
                Jogo.Broke = new SoundPlayer("Grafico//Broken.eff"); //52
                //Outros arquivos de caixas e items 
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.STARbox = Image.FromFile("Grafico//Tiles//STAR.BOX"); //55
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.STARitem_SPR1 = Image.FromFile("Grafico//Tiles//STAR1.ITM"); //56
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.STARitem_SPR2 = Image.FromFile("Grafico//Tiles//STAR2.ITM"); //57
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.LIFEbox = Image.FromFile("Grafico//Tiles//LIFE.BOX"); //58
                LoadBar.Value = LoadBar.Value + Porcent;
                Jogo.LIFEitem = Image.FromFile("Grafico//Tiles//LIFE.ITM"); //59
                LoadBar.Value = LoadBar.Value + Porcent;
                //Arquivos de Boot, "I do (...)"
                Jogo.BOOT = Image.FromFile("Reconhece//Boot.ido"); //60
                LoadBar.Value = LoadBar.Value + Porcent;
                LoadBar.Value = LoadBar.Value + Porcent;
                LoadBar.Value = LoadBar.Value + Porcent;
                //Arquivos de animação
                VETOR = 0; FILE = 1;
                for (VETOR = 0; VETOR <= 15; VETOR++) //64 ao 79
                {
                    LoadBar.Value = LoadBar.Value + Porcent;
                    Jogo.CDani[VETOR] = Image.FromFile("Grafico//Tiles//Animation//CDBOXs//CDbox_" + FILE.ToString() + ".ani");
                    FILE++;
                }
                #endregion
                #region 79%
                //Outros

                //Carregando o Wevin
                Jogo.Ervin1 = Image.FromFile("Grafico\\Inimigos\\Ervin\\ERVIN1.grf");
                Jogo.Ervin2 = Image.FromFile("Grafico\\Inimigos\\Ervin\\ERVIN2.grf");
                Jogo.Ervin3 = Image.FromFile("Grafico\\Inimigos\\Ervin\\ERVIN3.grf");

                //Carregando as avatares
                Jogo.ETEQUERavt = Image.FromFile("Avatar//etequer.avt");
                Jogo.ROZAavt = Image.FromFile("Avatar//Roza.avt");
                Jogo.MARCELUavt = Image.FromFile("Avatar//Marcelu.avt");
                Jogo.MUACIRavt = Image.FromFile("Avatar//Muacir.avt");
                Jogo.RENATUavt = Image.FromFile("Avatar//Renatu.avt");
                Jogo.AGUSTINHOavt = Image.FromFile("Avatar//Agustinho.avt");
                Jogo.CLEITOavt = Image.FromFile("Avatar//Cleito.avt");
                Jogo.LCavt = Image.FromFile("Avatar//Louis.avt");

                //Morte do Etequer
                Jogo.ETECdie_1 = Image.FromFile("Grafico\\eterdie_1.grf");
                Jogo.ETECdie_2 = Image.FromFile("Grafico\\eterdie_2.grf");
                Jogo.ETECdie_3 = Image.FromFile("Grafico\\eterdie_3.grf");
                Jogo.ETECdie_4 = Image.FromFile("Grafico\\eterdie_4.grf");
                Jogo.ETECdie_5 = Image.FromFile("Grafico\\eterdie_5.grf");
                Jogo.ETECdie_6 = Image.FromFile("Grafico\\eterdie_6.grf");
                //Som da morte do etequer
                Jogo.GuiLL = new SoundPlayer("Grafico\\Morreu.eff");

                //Banco de itens
                Jogo.BI = Image.FromFile("Grafico\\BI.grf");
                Jogo.BIused = Image.FromFile("Grafico\\used BI.grf");
                //Carregando a imagem do professor Renatu
                Jogo.RenatuIMG = Image.FromFile("Grafico\\Aliados\\Renatu\\Renatu.grf");
                //Carregando a imagem do professor Cleito
                Jogo.CleitoIMG = Image.FromFile("Grafico\\Aliados\\Cleito\\Cleito.grf");

                Louis_Carlos.RECARREGA_song = new SoundPlayer("Grafico\\Inimigos\\Louis Carlos\\Efeitos sonoros\\reload.eff");
                Louis_Carlos.SHOT_song = new SoundPlayer("Grafico\\Inimigos\\Louis Carlos\\Efeitos sonoros\\Tiro.eff");

                #endregion
                #region 79% para 100%
                VETOR = 0; FILE = 1;
                for (VETOR = 0; VETOR <= 15; VETOR++) // 80 ao 96
                {
                    LoadBar.Value = LoadBar.Value + Porcent;
                    Jogo.DVDani[VETOR] = Image.FromFile("Grafico//Tiles//Animation//DVDBOXs//DVDbox_" + FILE.ToString() + ".ani");
                    FILE++;
                }

                VETOR = 0; FILE = 1;
                for (VETOR = 0; VETOR <= 15; VETOR++) // 97 a acima de 100
                {
                    Jogo.FWani[VETOR] = Image.FromFile("Grafico//Tiles//Animation//FWBOXs//FWbox_" + FILE.ToString() + ".ani");
                    FILE++;
                }

                LoadBar.Value = 100;
                CARREGADO = true;

                //Abre o video depois que carregar, fazendo com que rode o video de numero 1
                Jogo.RozaTalk = false;
                Videos.WhoPlay = 1;
                //verifica se o ultimo arquivo já foi carregado
                Videos.SomethingPlayingInMe = false;
                //Avisa que o jogador não conversou com a primeira rozinha
                Videos partC = new Videos();
                partC.Show();

                this.BringToFront();
            #endregion
                
            }
            else
            {
                LoadBar.Visible = false;
                CARREGANDO_txt.Visible = false;
                this.Opacity = 0.01;
            }
            #endregion
            #region Verifica a posição do mouse dentro do jogo
            //Isso serve para saber se o mouse esta dentro do botão de saida ou se ele o pressionou
            MouseLeft = Cursor.Position.X - this.Left;
            MouseTop = Cursor.Position.Y - this.Top;
            #endregion
            #region Inicia o jogo quando o video é concluido ou forçado a concluir
            if (IsFirstVideoFinished == true)
            {
                //Abre o jogo
                Fundo partA = new Fundo();
                Jogo partB = new Jogo();
                partA.Show();
                partB.Show();
                IsFirstVideoFinished = false;
                this.BringToFront();
            }
            #endregion
            #region Sai do jogo se for pedido
            if (KILLthat == true)
            {
                this.Close();
            }
            #endregion
        }

        #region Ação do botão de saida
        private void ControlPanel_Click(object sender, EventArgs e)
        {
            if (MouseLeft >= (Jogo.ExitButton_left) && MouseLeft <= (Jogo.ExitButton_left + Jogo.ExitButton_width) && MouseTop >= (Jogo.ExitButton_top) && MouseTop <= (Jogo.ExitButton_top + Jogo.ExitButton_height))
            {
                Application.Exit();
            }
        }
        #endregion
    }
}