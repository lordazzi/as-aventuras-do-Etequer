using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Bibliotecas que eu adicionei
using WMPLib;

namespace As_aventuras_do_ETEQUER
{
    public partial class Videos : Form
    {
        #region Variaveis
        //Essa variavel vai carregar o video
        IWMPMedia Video;
        //Essa variavel mostra qual video deve ser rodado
        static public int WhoPlay;
        //Essa variavel serve para transportar informação do momento que o jogador clica em skip
        static public bool WannaExit = false;
        //Evita reanalizes
        bool IsAnalized = false;
        //Avisa para o painel de controle se um video esta rodando
        static public bool SomethingPlayingInMe = false;
        #endregion
        #region Rotinas
        public Videos()
        {
            InitializeComponent();
        }
        private void Primeiro()
        {
            //O video um é o video inicial ondeo etequer faz a prova e passa
            if (WhoPlay == 1)
            {
                //Avisa que não há um video rodando
                SomethingPlayingInMe = false;
                //Abre o jogo
                ControlPanel.IsFirstVideoFinished = true;
                //Avisa que o jogador não conversou com a primeira rozinha
                Jogo.RozaTalk = false;
                //Fecha a tela do video
                this.Close();
            }
        }
        private void Segundo()
        {
            //O video dois é o video do primeiro chefe, o video do marcelu da torre
            if (WhoPlay == 2)
            {
                ControlPanel.JogoVisibleFALSE = true;
                SomethingPlayingInMe = false;
                ControlPanel.MestreNumber = 1;
                this.Close();
                Chefe_Marcelu FirstBOSS = new Chefe_Marcelu();
                FirstBOSS.Show();
                ControlPanel.GoFront = true;
            }
        }
        private void Terceiro()
        {
            //O terceiro video é o video do segundo chefe, o muacir...
            if (WhoPlay == 3)
            {
                ControlPanel.JogoVisibleFALSE = true;
                SomethingPlayingInMe = false;
                ControlPanel.MestreNumber = 2;
                this.Close();
                Chefe_Muacir SecondBOSS = new Chefe_Muacir();
                SecondBOSS.Show();
                ControlPanel.GoFront = true;
            }
        }
        private void Quarto()
        {
            //O quarto é o video do terceiro chefe, o Agunstinho...
            if (WhoPlay == 4)
            {
                ControlPanel.TOTALblock = false;
                ControlPanel.JogoVisibleFALSE = false;
                SomethingPlayingInMe = false;
                ControlPanel.MestreNumber = 0;
                this.Close();
                Jogo.TALK = 0;
                ControlPanel.GoFront = true;
            }
        }
        private void Quinto()
        {
            //O quinto video é o video do ultimo chefe, o Louis Carlos....
            if (WhoPlay == 5)
            {
                ControlPanel.JogoVisibleFALSE = false;
                SomethingPlayingInMe = false;
                this.Close();
                ControlPanel.GoFront = true;
                Jogo.TALK++;
            }
        }
        private void Sexto()
        {
            //São os creditos
            if (WhoPlay == 6)
            {
                this.Close();
                SomethingPlayingInMe = false;
                MainMenu.STOPmusic = false;
            }
        }
        private void Setimo()
        {
            // O video sete é o de Game Over
            if (WhoPlay == 7)
            {
                Application.Exit();
                MainMenu.STOPmusic = false;
                SomethingPlayingInMe = false;
            }
        }
        private void Oitavo()
        {
            if (WhoPlay == 8)
            {
                this.Close();
                Register BD_Access = new Register();
                BD_Access.BringToFront();
                BD_Access.Show();
            }
        }
        #endregion

        private void Videos_Load(object sender, EventArgs e)
        {
            #region posicionamento do gráfico
            //Roda o video um se for ele o pedido
            if (WhoPlay == 1)
            {
                try
                {
                    Video = VideoPlace.newMedia("Movies\\entermovie.wmv");
                    VideoPlace.currentPlaylist.appendItem(Video);
                    VideoPlace.settings.volume = 100;
                    VideoPlace.Ctlcontrols.play();
                    SomethingPlayingInMe = true;
                }
                catch
                {
                    MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

            else if (WhoPlay == 2)
            {
                try
                {
                    Video = VideoPlace.newMedia("Movies\\Marcelu.wmv");
                    VideoPlace.currentPlaylist.appendItem(Video);
                    VideoPlace.settings.volume = 100;
                    VideoPlace.Ctlcontrols.play();
                    SomethingPlayingInMe = true;
                }
                catch
                {
                    MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Segundo();
                }
            }

            else if (WhoPlay == 3)
            {
                try
                {
                    Video = VideoPlace.newMedia("Movies\\Muacir.wmv");
                    VideoPlace.currentPlaylist.appendItem(Video);
                    VideoPlace.settings.volume = 100;
                    VideoPlace.Ctlcontrols.play();
                    SomethingPlayingInMe = true;
                }
                catch
                {
                    MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Terceiro();
                }
            }

            else if (WhoPlay == 4)
            {
                try
                {
                    Video = VideoPlace.newMedia("Movies\\Agustinho.wmv");
                    VideoPlace.currentPlaylist.appendItem(Video);
                    VideoPlace.settings.volume = 100;
                    VideoPlace.Ctlcontrols.play();
                    SomethingPlayingInMe = true;
                }
                catch
                {
                    MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Quarto();
                }
            }

            else if (WhoPlay == 5)
            {
                try
                {
                    Video = VideoPlace.newMedia("Movies\\Louis Carlos.wmv");
                    VideoPlace.currentPlaylist.appendItem(Video);
                    VideoPlace.settings.volume = 100;
                    VideoPlace.Ctlcontrols.play();
                    SomethingPlayingInMe = true;
                }
                catch
                {
                    MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Quinto();
                }
            }

            else if (WhoPlay == 6)
            {
                try
                {
                    MainMenu.STOPmusic = true;
                    Video = VideoPlace.newMedia("Movies\\creditos.wmv");
                    VideoPlace.currentPlaylist.appendItem(Video);
                    VideoPlace.settings.volume = 100;
                    VideoPlace.Ctlcontrols.play();
                    SomethingPlayingInMe = true;
                }
                catch
                {
                    MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Sexto();
                }
            }

            else if (WhoPlay == 7)
            {
                try
                {
                    Video = VideoPlace.newMedia("Movies\\Game_Over.wmv");
                    VideoPlace.currentPlaylist.appendItem(Video);
                    VideoPlace.settings.volume = 100;
                    VideoPlace.Ctlcontrols.play();
                    SomethingPlayingInMe = true;
                }
                catch
                {
                    MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Setimo();
                }
            }

            else if (WhoPlay == 8)
            {
                try
                {
                    Video = VideoPlace.newMedia("Movies\\FIM.wmv");
                    VideoPlace.currentPlaylist.appendItem(Video);
                    VideoPlace.settings.volume = 100;
                    VideoPlace.Ctlcontrols.play();
                    SomethingPlayingInMe = true;
                }
                catch
                {
                    MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Oitavo();
                }
            }
            #endregion
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            #region Ações feitas no finalizar dos videos
                if (VideoPlace.playState == WMPPlayState.wmppsStopped)
                {
                    Primeiro();
                    Segundo();
                    Terceiro();
                    Quarto();
                    Quinto();
                    Sexto();
                    Setimo();
                    Oitavo();
                }
            #endregion
            #region percebe se o jogador quer sair do video
            if (WannaExit == true)
            {
                Primeiro();
                Segundo();
                Terceiro();
                Quarto();
                Quinto();
                Sexto();
                Setimo();
                Oitavo();
                WannaExit = false;
            }
            #endregion
            #region Troca de mensagem quando o video é carregado
            try
            {
                if (IsAnalized == false)
                {
                    if (VideoPlace.playState == WMPPlayState.wmppsPlaying)
                    {
                        MSG.Text = "Pressione enter para sair do video";
                        IsAnalized = true;
                    }
                }
            }
            catch
            {
                Primeiro();
                Segundo();
                Terceiro();
                Quarto();
                Quinto();
                Sexto();
                Setimo();
                Oitavo();
            }
            #endregion
        }

        #region Outros recursos
        private void Videos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
                MainMenu.STOPmusic = false;
            }
        }
        #endregion
    }
}