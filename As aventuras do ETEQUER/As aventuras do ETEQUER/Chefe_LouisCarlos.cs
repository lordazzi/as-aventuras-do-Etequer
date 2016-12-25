using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Bibliotecas que eue adicionei
using System.Media;

namespace As_aventuras_do_ETEQUER
{
    public partial class Louis_Carlos : Form
    {
        #region Variaveis
        //Mostra qual a opção do menu do chefe que o jogador esta escolhendo
        static public int selected = 1;
        //Recebe a informação de quando o jogador pressionou espaço afirmando que havia selecionado uma determinada opção
        static public bool SpacePressed = false;

        //Essa variavel guarda a imagem do menu do chefe Louis Carlos
        static public Image MENU;

        //Essas variaveis vão guardar os efeitos graficos dos tiros tanto do etequer quando do LC, as de metralhadora são as do LC as de shotgun do Etequer
        static public Image[] ShotGun = new Image[13];
        static public Image Metralha1, Metralha2, Metralha3;

        //Essas variaveis vão guardar os graficos possiveis do Etequer e do Louis Carlos dentro da luta...
        static public Image Eter1, Eter2, Eter3, Eter_W8;
        static public Image LC1, LC2, LC_W8;

        //esses arquivos vão carregar as caixa do cenario
        static public Image BOX1, BOX2;

        //Essa variavel vai carregar o valor selecionado pelo random
        int RandLoad;
        //Diz se o random pode ou não fazer um radomizamento
        bool CanRANDrun = true;
        //Essa variavel vai carregar o tipo de briga que o LC e o Etequer fara, para facilitar minha vida =D
        int LC_FightStyle, Etequer_FightStyle;
        //Essa variavel verifica se a decisão foi tomada
        bool MakeDecision = false;

        //Essa variavel vai servir para animar as decisões
        int LC_WITA = 0, ETE_WITA = 0;
        //O etequer precisa de uma variavel WhereIsTheAnimation a mais
        int LC_WITAhelp = 0;
        //Avisa se a animação já foi concluida
        bool LC_Ended = false, ETE_Ended = false;

        //Essas variaveis vão guardar os valores da vida do Etequer e do Lc
        int LClife = 100, ETEQUERlife = 100;

        //Para de declarar mensagem depois de uma vez
        bool FirstMESSAGE = false;

        //Efeitos sonoros
        static public SoundPlayer RECARREGA_song, SHOT_song;
        #endregion
        #region Rotinas

        private void Mensagem()
        {
            if (TextPlace.Visible == false)
            {
                Text1.Visible = true;
                Text2.Visible = true;
                Text3.Visible = true;
                TextPlace.Visible = true;
                AvatarPlace.Visible = true;
                Text1.BringToFront();
                Text2.BringToFront();
                Text3.BringToFront();
            }
            else if (TextPlace.Visible == true)
            {
                Text1.Visible = false;
                Text2.Visible = false;
                Text3.Visible = false;
                TextPlace.Visible = false;
                AvatarPlace.Visible = false;
            }
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

        public Louis_Carlos()
        {
            InitializeComponent();
        }

        private void TiraMenu()
        {
            OptionMenu.Visible = false;
            opt1.Visible = false;
            opt2.Visible = false;
            opt3.Visible = false;
            SELECTER.Visible = false;
        }

        private void PoeMenu()
        {
            OptionMenu.Visible = true;
            OptionMenu.BringToFront();

            SELECTER.Visible = true;
            SELECTER.BringToFront();

            opt1.Visible = true;
            opt1.BringToFront();

            opt2.Visible = true;
            opt2.BringToFront();

            opt3.Visible = true;
            opt3.BringToFront();
        }
        #endregion

        //Rotinas de fala
        #region Rotinas Wild Ataks
        private void Louis_WildATKI()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  É minha vez de mostrar meu verdadeiro poder!";
            Text3.Text = "";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Sinta do que uma metralhadora é capaz!";
            Text3.Text = "";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKIII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  É hora de esvaziar meu cartucho....";
            Text3.Text = "";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKIV()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Agora fiquei bravo...";
            Text3.Text = "";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKV()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Vamos fazer um assassinato em massa de seus";
            Text3.Text = "  pontos de vida...";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKVI()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Sinda o calor de minhas balas atravessando";
            Text3.Text = "  seu meio!";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKVII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Depois desse golpe eu vou estar na vantagem!";
            Text3.Text = "";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKVIII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Vamos terminar logo com isso...";
            Text3.Text = "";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKIX()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Na próxima eu não terei dó!";
            Text3.Text = "";
            LC_FightStyle = 3;
        }

        private void Louis_WildATKX()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Não vamos economizar em balas!";
            Text3.Text = "  HAHAHAHAHAHA!";
            LC_FightStyle = 3;
        }
        #endregion
        #region Rotinas Ataks
        private void Louis_ATKI()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Não vamos ser timidos!";
            Text3.Text = "";
            LC_FightStyle = 2;
        }

        private void Louis_ATKII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Pa-pa-pa-pa-pa!";
            Text3.Text = "";
            LC_FightStyle = 2;
        }

        private void Louis_ATKIII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Não vai adiantar se esconder...";
            Text3.Text = "";
            LC_FightStyle = 2;
        }

        private void Louis_ATKIV()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Estou pronto para mais uma metralhada....";
            Text3.Text = "";
            LC_FightStyle = 2;
        }

        private void Louis_ATKV()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Pegue alguns tiros para massagiar-te antes do";
            Text3.Text = "  golpe final...";
            LC_FightStyle = 2;
        }

        private void Louis_ATKVI()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Minhas balas estão no fim... Mas não é nada";
            Text3.Text = "  que uma boa recarregada não faça...";
            LC_FightStyle = 2;
        }

        private void Louis_ATKVII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  As vezes se deve se expor para ganhar...";
            Text3.Text = "  (Porém, não totalmente!)";
            LC_FightStyle = 2;
        }

        private void Louis_ATKVIII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Vamos! Vamos! Estou pronto para jogar mais um";
            Text3.Text = "  vetor de balas...";
            LC_FightStyle = 2;
        }

        private void Louis_ATKIX()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Não importa onde você estiver, eu vou te acertar...";
            Text3.Text = "  ";
            LC_FightStyle = 2;
        }

        private void Louis_ATKX()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Não vou pegar tão pesado com você...";
            Text3.Text = "  ";
            LC_FightStyle = 2;
        }
        #endregion
        #region Rotinas fast atk
        private void Louis_Fast_ATKI()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  É hora de recuar....";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Vamos economizar meus pontos de vida...";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKIII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Tirinho!!";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKIV()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Não preciso de muito para derrotar você....";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKV()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Hora de recarregar...";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKVI()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Me mostre do que você é capaz!";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKVII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Essas caixas servem para se esconder?";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKVIII()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Vamos ver se você consegue me acertar...";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKIX()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Ta-ta-ra!";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }

        private void Louis_Fast_ATKX()
        {
            Mensagem();
            Text1.Text = "Louis Carlos:";
            Text2.Text = "  Esse vai ser um tiro certeiro.";
            Text3.Text = "  ";
            LC_FightStyle = 1;
        }
        #endregion

        //entrada para ataques
        #region Posicionamentos possiveis
        private void Eter_BasicATK()
        {
            Etequer.Image = Eter1;
            Etequer.Left = 128;
            Etequer.Top = 354;
            Etequer.Height = 94;
            Etequer.Width = 77;

            ShotunSHOT.Left = 208;
            ShotunSHOT.Top = 373;
            ShotunSHOT.Height = 25;
            ShotunSHOT.Width = 40;
            ShotunSHOT.Visible = false;
        }

        private void Eter_ATK()
        {
            Etequer.Image = Eter1;
            Etequer.Left = 264;
            Etequer.Top = 354;
            Etequer.Height = 94;
            Etequer.Width = 77;

            ShotunSHOT.Left = 344;
            ShotunSHOT.Top = 373;
            ShotunSHOT.Height = 25;
            ShotunSHOT.Width = 40;
            ShotunSHOT.Visible = false;
        }

        private void Eter_WildATK()
        {
            Etequer.Image = Eter1;
            Etequer.Left = 321;
            Etequer.Top = 358;
            Etequer.Height = 94;
            Etequer.Width = 77;

            ShotunSHOT.Left = 401;
            ShotunSHOT.Top = 377;
            ShotunSHOT.Height = 25;
            ShotunSHOT.Width = 40;
            ShotunSHOT.Visible = false;
        }

        private void LC_BasicATK()
        {
            LCpic.Image = LC1;
            LCpic.Left = 633;
            LCpic.Top = 342;
            LCpic.Height = 95;
            LCpic.Width = 45;

            Metralha.Left = 615;
            Metralha.Top = 384;
            Metralha.Height = 15;
            Metralha.Width = 15;
            Metralha.Visible = false;
        }

        private void LC_ATK()
        {
            LCpic.Image = LC1;
            LCpic.Left = 527;
            LCpic.Top = 363;
            LCpic.Height = 95;
            LCpic.Width = 45;

            Metralha.Left = 509;
            Metralha.Top = 405;
            Metralha.Height = 15;
            Metralha.Width = 15;
            Metralha.Visible = false;
        }

        private void LC_WildATK()
        {
            LCpic.Image = LC1;
            LCpic.Left = 447;
            LCpic.Top = 359;
            LCpic.Height = 95;
            LCpic.Width = 45;

            Metralha.Left = 429;
            Metralha.Top = 401;
            Metralha.Height = 15;
            Metralha.Width = 15;
            Metralha.Visible = false;

        }

        private void Eter_back()
        {
            Etequer.Image = Eter_W8;
            Etequer.Height = 80;
            Etequer.Width = 71;
            Etequer.Left = 128;
            Etequer.Top = 373;
            ShotunSHOT.Visible = false;
        }

        private void LC_back()
        {
            LCpic.Image = LC_W8;
            LCpic.Height = 83;
            LCpic.Width = 54;
            LCpic.Top = 376;
            LCpic.Left = 633;
            Metralha.Visible = false;
        }
        #endregion
        private void Louis_Carlos_Load(object sender, EventArgs e)
        {
            #region Organizando o gráfico dentro do jogo
            //Colocando as caixas
            EtequerBOX.Image = BOX1;
            LouisBox.Image = BOX2;

            //Coloca a imagem que fica do lado dos pontos de vida
            LifesFace.Image = Jogo.HeadOfLives;
            LClifeAVT.Image = Jogo.LCavt;

            //Coloca a imagem já carregada no botão de saida
            ExitButton.Image = MainMenu.IMG_ExitButton_normal;

            //Coloca as imagens na barra de vida
            LifeBAR.BackgroundImage = Jogo.LifeBAR_IMG;
            LifeBar_BAckGround.BackgroundImage = Jogo.LifeBAR_IMG_bg;

            LifeBar_LC.BackgroundImage = Jogo.LifeBAR_IMG;
            BackLifeBAR_LC.BackgroundImage = Jogo.LifeBAR_IMG_bg;

            //Número do chefe
            ControlPanel.MestreNumber = 4;

            //Colocando a imagem carregada do menu dentro do PictureBo do menu
            OptionMenu.Image = MENU;

            //Colocando as imagens dfe pergaminho na picturebox de conversa
            TextPlace.Image = Jogo.Pergaminho;
            Text1.Image = Jogo.textoA;
            Text2.Image = Jogo.textoB;
            Text3.Image = Jogo.textoC;
            AvatarPlace.Image = Jogo.LCavt;

            PoeMenu();

            //Colocando o jogador e o chefe em suas posições iniciais
            Eter_back();
            LC_back();
            #endregion
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
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
            #region Fazendo a decisão quando aperta espaço e voltando a mostrar o menu quando a animação for concluida
            if (SpacePressed == true)
            {
                if (MakeDecision == false)
                {
                    Etequer_FightStyle = selected;
                    OptionMenu.Visible = false;
                    opt1.Visible = false;
                    opt2.Visible = false;
                    opt3.Visible = false;
                    SELECTER.Visible = false;
                    Mensagem();
                    MakeDecision = true;
                }
            }
            else if (SpacePressed == false)
            {
                if (MakeDecision == true)
                {
                    Etequer_FightStyle = selected;
                    OptionMenu.Visible = true;
                    opt1.Visible = true;
                    opt2.Visible = true;
                    opt3.Visible = true;
                    SELECTER.Visible = true;
                    Mensagem();
                    MakeDecision = false;
                }
            }
            #endregion
            #region Mostrando a vida na barra de vida
            if (ETEQUERlife > 1)
            {
                LifeBAR.Width = ETEQUERlife * 5;
            }

            if (LClife > 1)
            {
                LifeBar_LC.Width = LClife * 5;
            }
            #endregion
        }

        private void GameUpdater_Tick(object sender, EventArgs e)
        {
            #region Conclusão
            if (LClife < 0)
            {
                //CONCLUSÃO GERAL
            }

            if (ETEQUERlife < 0)
            {
                this.Close();
                ControlPanel.GoFront = true;
                Videos.WhoPlay = 8;
                Videos Conluido = new Videos();
                Conluido.Show();
            }
            #endregion
            #region Execução dos comandos dados pelo jogador no Control Panel
            if (OptionMenu.Visible == true)
            {
                if (selected == 1)
                {
                    //Colocando a seleção para o usuário ver oq ele escolheu
                    opt1.BackColor = Color.DarkGoldenrod;
                    opt2.BackColor = Color.DarkKhaki;
                    opt3.BackColor = Color.DarkKhaki;
                    SELECTER.Top = 304;
                }

                else if (selected == 2)
                {
                    opt1.BackColor = Color.DarkKhaki;
                    opt2.BackColor = Color.DarkGoldenrod;
                    opt3.BackColor = Color.DarkKhaki;
                    SELECTER.Top = 335;
                }

                else if (selected == 3)
                {
                    opt1.BackColor = Color.DarkKhaki;
                    opt2.BackColor = Color.DarkKhaki;
                    opt3.BackColor = Color.DarkGoldenrod;
                    SELECTER.Top = 366;
                }
            }
            #endregion
            #region Executando o random
            if (CanRANDrun == true)
            {
                Random SELECTing_LCatk = new Random();
                RandLoad = SELECTing_LCatk.Next(29);
                CanRANDrun = false;
            }
            #endregion
            #region Escrevendo a frase do LC
            if (CanRANDrun == false && FirstMESSAGE == false)
            {
                FirstMESSAGE = true;
                //Forte
                if (RandLoad == 0)
                {
                    Louis_WildATKI();
                }

                else if (RandLoad == 1)
                {
                    Louis_WildATKII();
                }

                else if (RandLoad == 2)
                {
                    Louis_WildATKIII();
                }

                else if (RandLoad == 3)
                {
                    Louis_WildATKIV();
                }

                else if (RandLoad == 4)
                {
                    Louis_WildATKV();
                }

                else if (RandLoad == 5)
                {
                    Louis_WildATKVI();
                }

                else if (RandLoad == 6)
                {
                    Louis_WildATKVII();
                }

                else if (RandLoad == 7)
                {
                    Louis_WildATKVIII();
                }

                else if (RandLoad == 8)
                {
                    Louis_WildATKIX();
                }

                else if (RandLoad == 9)
                {
                    Louis_WildATKX();
                }

                //Medio
                else if (RandLoad == 10)
                {
                    Louis_ATKI();
                }

                else if (RandLoad == 11)
                {
                    Louis_ATKII();
                }

                else if (RandLoad == 12)
                {
                    Louis_ATKII();
                }

                else if (RandLoad == 13)
                {
                    Louis_ATKIV();
                }

                else if (RandLoad == 14)
                {
                    Louis_ATKV();
                }

                else if (RandLoad == 15)
                {
                    Louis_ATKVI();
                }

                else if (RandLoad == 16)
                {
                    Louis_ATKVII();
                }

                else if (RandLoad == 17)
                {
                    Louis_ATKVIII();
                }

                else if (RandLoad == 18)
                {
                    Louis_ATKIX();
                }

                else if (RandLoad == 19)
                {
                    Louis_ATKX();
                }

                //Fraco
                else if (RandLoad == 20)
                {
                    Louis_Fast_ATKI();
                }

                else if (RandLoad == 21)
                {
                    Louis_Fast_ATKII();
                }

                else if (RandLoad == 22)
                {
                    Louis_Fast_ATKIII();
                }

                else if (RandLoad == 23)
                {
                    Louis_Fast_ATKIV();
                }

                else if (RandLoad == 24)
                {
                    Louis_Fast_ATKV();
                }

                else if (RandLoad == 25)
                {
                    Louis_Fast_ATKVI();
                }

                else if (RandLoad == 26)
                {
                    Louis_Fast_ATKVII();
                }

                else if (RandLoad == 27)
                {
                    Louis_Fast_ATKVIII();
                }

                else if (RandLoad == 28)
                {
                    Louis_Fast_ATKIX();
                }

                else if (RandLoad == 29)
                {
                    Louis_Fast_ATKX();
                }
            }
            #endregion
        }

        private void Animation_Tick(object sender, EventArgs e)
        {
            //1 = Ataque rapido; 2 = Ataque comum; 3 = Ataque completo
            if (MakeDecision == true)
            {
                #region Animando as decisões e colidindo-as
                GameUpdater.Enabled = false;
                if (ETE_Ended == false)
                {
                    if (ETE_WITA == 0)
                    {
                        if (Etequer_FightStyle == 1)
                        {
                            Eter_BasicATK();
                        }

                        else if (Etequer_FightStyle == 2)
                        {
                            Eter_ATK();
                        }

                        else if (Etequer_FightStyle == 3)
                        {
                            Eter_WildATK();
                        }

                        ShotunSHOT.Visible = true;
                        ShotunSHOT.Image = ShotGun[0];
                        ETE_WITA++;
                        SHOT_song.Play();
                    }

                    else if (ETE_WITA == 1)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 2)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        Etequer.Image = Eter2;
                        RECARREGA_song.Play();
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 3)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 4)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 5)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        Etequer.Image = Eter3;
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 6)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 7)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 8)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        Etequer.Image = Eter2;
                        RECARREGA_song.Play();
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 9)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 10)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 11)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        Etequer.Image = Eter1;
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 12)
                    {
                        ShotunSHOT.Image = ShotGun[ETE_WITA];
                        ETE_WITA++;
                    }

                    else if (ETE_WITA == 13)
                    {
                        ETE_Ended = true;
                    }
                }

                if (LC_Ended == false)
                {
                    if (LC_WITA == 0)
                    {
                        if (LC_FightStyle == 1)
                        {
                            LC_BasicATK();
                        }

                        if (LC_FightStyle == 2)
                        {
                            LC_ATK();
                        }

                        if (LC_FightStyle == 3)
                        {
                            LC_WildATK();
                        }

                        Metralha.Visible = true;
                        Metralha.Image = Metralha1;
                        LC_WITA++;
                    }

                    else if (LC_WITA == 1 && LC_WITAhelp != 5)
                    {
                        Metralha.Image = Metralha2;
                        LCpic.Image = LC2;
                        LC_WITA++;
                        LC_WITAhelp++;
                    }

                    else if (LC_WITA == 2)
                    {
                        Metralha.Image = Metralha3;
                        LCpic.Image = LC1;
                        LC_WITA++;
                    }

                    else if (LC_WITA == 3)
                    {
                        Metralha.Image = Metralha1;
                        LCpic.Image = LC2;
                        LC_WITA++;
                    }

                    else if (LC_WITA == 4)
                    {
                        Metralha.Image = Metralha2;
                        LCpic.Image = LC1;
                        LC_WITA++;
                    }

                    else if (LC_WITA == 5)
                    {
                        Metralha.Image = Metralha3;
                        LCpic.Image = LC2;
                        LC_WITA++;
                    }

                    else if (LC_WITA == 6)
                    {
                        Metralha.Image = Metralha1;
                        LCpic.Image = LC1;
                        LC_WITA = 1;
                    }

                    else if (LC_WITAhelp == 5)
                    {
                        LC_Ended = true;
                        LC_WITA = 0;
                        LC_WITAhelp = 0;
                    }
                }
            #endregion
                #region Dano
                if (ETE_Ended == true && LC_Ended == true)
                {
                    if (Etequer_FightStyle == 1 && LC_FightStyle == 1)
                    {

                    }

                    else if (Etequer_FightStyle == 1 && LC_FightStyle == 2)
                    {
                        ETEQUERlife -= 1;
                    }

                    else if (Etequer_FightStyle == 1 && LC_FightStyle == 3)
                    {
                        LClife -= 5;
                    }

                    else if (Etequer_FightStyle == 2 && LC_FightStyle == 1)
                    {
                        LClife -= 1;
                    }

                    else if (Etequer_FightStyle == 2 && LC_FightStyle == 2)
                    {
                        ETEQUERlife -= 5;
                        LClife -= 5;
                    }

                    else if (Etequer_FightStyle == 2 && LC_FightStyle == 3)
                    {
                        ETEQUERlife -= 10;
                        LClife -= 5;
                    }

                    else if (Etequer_FightStyle == 3 && LC_FightStyle == 1)
                    {
                        ETEQUERlife -= 5;
                    }

                    else if (Etequer_FightStyle == 3 && LC_FightStyle == 2)
                    {
                        LClife -= 10;
                        ETEQUERlife -= 5;
                    }

                    else if (Etequer_FightStyle == 3 && LC_FightStyle == 3)
                    {
                        LClife -= 10;
                        ETEQUERlife -= 10;
                    }

                    ETE_WITA = 0;
                    LC_WITA = 0;
                    LC_WITAhelp = 0;
                    GameUpdater.Enabled = true;
                    SpacePressed = false;
                    MakeDecision = false;
                    CanRANDrun = true;
                    FirstMESSAGE = false;
                    ETE_Ended = false;
                    LC_Ended = false;
                    PoeMenu();
                }
                #endregion
            }
        }
    }
}