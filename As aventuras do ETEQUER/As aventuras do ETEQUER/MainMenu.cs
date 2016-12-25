using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Bibliotecas adicionadas por mim
using System.Media;
using WMPLib;
using System.Diagnostics;

namespace As_aventuras_do_ETEQUER
{
    public partial class MainMenu : Form
    {
        #region variaveis
        //BackGround do menu e de opções
        static public Image BGcheff;
        //Ve se é necessario que parem a musica
        static public bool STOPmusic = false;
        //Nessas variaveis serão carregados os gráficos do botão de saida.
        static public Image IMG_ExitButton_normal, IMG_ExitButton_hover, IMG_ExitButton_press;
        //Número da opção
        int option_selected = 1;
        //Carrega as imagens usadas para a seleção de um dos itens do menu
        static public Image SELECT_void, SELECT1, SELECT2, SELECT3, SELECT4;
        //Variaveis usadas para animar as imagens do menu, SELECTshow mostra a imagem e SELECTwho mostra qual deve ser mostrada.
        Image SELECTshow; int SELECTwho = 1;
        //Som de efeito
        static public SoundPlayer ChangeMenuOption, WhenSelectOption;
        //Declaração das teclas usadas pelo usuário para controlar o personagem no ogo
        static public Keys Pula = Keys.Space, Direita = Keys.Right, Esquerda = Keys.Left, Pause = Keys.P, Estabil = Keys.Up, SelfKill = Keys.D;
        //Senha do banco de dados
        static public int senhaPART1 = 8, senhaPART2 = 100;
        static public string senhaPART3 = "ras";

        //Musicas do windows media player
        IWMPMedia Theme;

        static public bool CARREGADO = false;
        #endregion
        #region Rotinas
        public MainMenu()
        {
            InitializeComponent();
        }

        private void RunAnimation()
        {
            //A animação do item selecionado no menu
            if (SELECTwho == 1)
            {
                SELECTshow = SELECT1;
                SELECTwho = 2;
            }
            else if (SELECTwho == 2)
            {
                SELECTshow = SELECT2;
                SELECTwho = 3;
            }
            else if (SELECTwho == 3)
            {
                SELECTshow = SELECT3;
                SELECTwho = 4;
            }
            else if (SELECTwho == 4)
            {
                SELECTshow = SELECT4;
                SELECTwho = 1;
            }
        }
        #endregion

        private void MainMenu_Load(object sender, EventArgs e)
        {
            #region Posicionando gráfico carregado
            try
            {
                //Colocando a musica de fundo
                    Theme = ThemeMusic.newMedia("Programa\\MMT.wav");
                    ThemeMusic.currentPlaylist.appendItem(Theme);
                    ThemeMusic.Ctlcontrols.play();
                    ThemeMusic.settings.setMode("Loop", true);
                    ThemeMusic.settings.volume = 100;


                //Imagem de fundo do menu
                this.BackgroundImage = BGcheff;

                //Imagem do botão de saida
                ExitButton.Image = IMG_ExitButton_normal;

                //Coloca as imagens ao lado das opções do menu
                novo_select.Image = SELECT_void;
                placar_select.Image = SELECT_void;
                opcoes_select.Image = SELECT_void;
                sair_select.Image = SELECT_void;

                //Inicia o atualizar do jogo
                Updater.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error ao organizar o gráfico", "::ERROR::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            #endregion
        }

        #region botão de saida
        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            ExitButton.Image = IMG_ExitButton_hover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = IMG_ExitButton_normal;
        }

        private void ExitButton_MouseDown(object sender, MouseEventArgs e)
        {
            ExitButton.Image = IMG_ExitButton_press;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
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
            #region Qual item do menu está selecionado?
            //A variavel option_selected mostra qual item do menu esta selecionado.
            if (e.KeyCode == Keys.Down)
            {
                if (option_selected == 4)
                {
                    option_selected = 1;
                }
                else
                {
                    option_selected++;
                }

                ChangeMenuOption.Play();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (option_selected == 1)
                {
                    option_selected = 4;
                }
                else
                {
                    option_selected--;
                }

                ChangeMenuOption.Play();
            }
            #endregion
            #region Ação da opção selecionada
            if (e.KeyCode == Keys.Space)
            {
                //Faz o somzinho de quando você escolhe uma das opções
                WhenSelectOption.Play();

                if (option_selected == 1)
                {
                    //Novo jogo
                    ControlPanel IniciarJogo = new ControlPanel();
                    IniciarJogo.Show();
                    Jogo.GB_points = 0;
                    STOPmusic = true;

                    //Faz com que o jogador nunca tenha conversado ou lutado com nenhum professor
                    Jogo.RozaTalk = false;
                    Jogo.MarceluTalk = false;
                    Jogo.MarceluFight = false;
                    Jogo.MuacirFight = false;
                    Jogo.RenatuTalk = false;
                    Jogo.AgustinhoFight = false;
                    Jogo.CleitoTalk = false;
                    Jogo.LCFight = false;
                }
                else if (option_selected == 2)
                {
                    //Ver o placar
                    Placar AbrirPlacar = new Placar();
                    AbrirPlacar.Show();
                }
                else if (option_selected == 3)
                {
                    //Opções
                    Opcoes VCpode = new Opcoes();
                    VCpode.Show();
                }
                else if (option_selected == 4)
                {
                    //Sair
                    Application.Exit();
                }
            }
            #endregion
        }

        private void GameUpdater_Tick(object sender, EventArgs e)
        {
            #region Animação do menu
            //Executa a animação da opção selecionada
            if (option_selected == 1)
            {
                //Novo jogo selecionado
                //Muda a cor do texto
                NovoJogo_LABEL.ForeColor = Color.Red;
                Placar_LABEL.ForeColor = Color.Gold;
                Configura_LABEL.ForeColor = Color.Gold;
                Sair_LABEL.ForeColor = Color.Gold;

                //Anula as imagens de animação e a animação dos itens não-selecionados
                placar_select.Image = SELECT_void;
                opcoes_select.Image = SELECT_void;
                sair_select.Image = SELECT_void;

                placar_select2.Image = SELECT_void;
                opcoes_select2.Image = SELECT_void;
                sair_select2.Image = SELECT_void;

                //Roda a animação no item selecionado
                novo_select.Image = SELECTshow;
                novo_select2.Image = SELECTshow;
            }

            else if (option_selected == 2)
            {
                //Placar selecionado
                //Muda a cor do texto
                NovoJogo_LABEL.ForeColor = Color.Gold;
                Placar_LABEL.ForeColor = Color.Red;
                Configura_LABEL.ForeColor = Color.Gold;
                Sair_LABEL.ForeColor = Color.Gold;

                //Anula as imagens de animação e a animação dos itens não-selecionados
                novo_select.Image = SELECT_void;
                opcoes_select.Image = SELECT_void;
                sair_select.Image = SELECT_void;

                novo_select2.Image = SELECT_void;
                opcoes_select2.Image = SELECT_void;
                sair_select2.Image = SELECT_void;

                //Roda a animação no item selecionado
                placar_select.Image = SELECTshow;
                placar_select2.Image = SELECTshow;
            }

            else if (option_selected == 3)
            {
                //Configurações selecionado
                //Muda a cor do texto
                NovoJogo_LABEL.ForeColor = Color.Gold;
                Placar_LABEL.ForeColor = Color.Gold;
                Configura_LABEL.ForeColor = Color.Red;
                Sair_LABEL.ForeColor = Color.Gold;

                //Anula as imagens de animação e a animação dos itens não-selecionados
                novo_select.Image = SELECT_void;
                placar_select.Image = SELECT_void;
                sair_select.Image = SELECT_void;

                novo_select2.Image = SELECT_void;
                placar_select2.Image = SELECT_void;
                sair_select2.Image = SELECT_void;

                //Roda a animação no item selecionado
                opcoes_select.Image = SELECTshow;
                opcoes_select2.Image = SELECTshow;
            }

            else if (option_selected == 4)
            {
                //Sair selecionado
                //Muda a cor do texto
                NovoJogo_LABEL.ForeColor = Color.Gold;
                Placar_LABEL.ForeColor = Color.Gold;
                Configura_LABEL.ForeColor = Color.Gold;
                Sair_LABEL.ForeColor = Color.Red;

                //Anula as imagens de animação e a animação dos itens não-selecionados
                novo_select.Image = SELECT_void;
                placar_select.Image = SELECT_void;
                opcoes_select.Image = SELECT_void;

                novo_select2.Image = SELECT_void;
                placar_select2.Image = SELECT_void;
                opcoes_select2.Image = SELECT_void;

                //Roda a animação no item selecionado
                sair_select.Image = SELECTshow;
                sair_select2.Image = SELECTshow;
            }

            //Atualiza os PictureBox
            novo_select.Update();
            placar_select.Update();
            opcoes_select.Update();
            novo_select2.Update();
            placar_select2.Update();
            opcoes_select2.Update();
            sair_select.Update();
            sair_select2.Update();
            //Atualiza a animação
            RunAnimation();
            #endregion
            #region Para a musica se for pedido para que o faça
            if (STOPmusic == true && ThemeMusic.playState == WMPPlayState.wmppsPlaying)
            {
                ThemeMusic.Ctlcontrols.stop();
                this.Visible = false;
            }

            else if (STOPmusic == false && ThemeMusic.playState == WMPPlayState.wmppsStopped)
            {
                ThemeMusic.Ctlcontrols.play();
                this.Visible = true;
            }
            #endregion
        }

        #region Encerra o aplicativo caso fechem o MainMenu
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region LINK
        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.orkut.com/Main#Community.aspx?cmm=91309511");
        }
#endregion
    }
}