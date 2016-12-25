using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace As_aventuras_do_ETEQUER
{
    public partial class Configura : Form
    {
        #region variaveis
        //Essas variaveis vão carregar as imagens dos botões
        static public Image IMG_ChangeValueButton_normal, IMG_ChangeValueButton_hover, IMG_ChangeValueButton_press;
        //Essa variavel serve para mostrar qual o botão que foi pressionado
        int QuemFoi = 0;
        //Verifica se o formulario que pede  nova tecla esta aberto
        bool CIB_isOpen = false;
        //Imagem de fundo das configurações
        static public Image ImagemDeFundo;
        #endregion

        public Configura()
        {
            InitializeComponent();
        }

        private void Configura_Load(object sender, EventArgs e)
        {
            #region Organização do gráfico carregado na execução do programa
            //Coloca a imagem carregada no inicio no fundo
            this.BackgroundImage = ImagemDeFundo;
            //Coloca a imagem carregada no inicio no botão de saida
            ExitButton.Image = MainMenu.IMG_ExitButton_normal;
            //Coloca os valores atuais das teclas de ação
            Pular.Text = " " + MainMenu.Pula.ToString() + " ";
            Direita.Text = " " + MainMenu.Direita.ToString() + " ";
            Esquerda.Text = " " + MainMenu.Esquerda.ToString() + " ";
            Pausa.Text = " " + MainMenu.Pause.ToString() + " ";
            Estabilizar.Text = " " + MainMenu.Estabil.ToString() + " ";
            Morrer.Text = " " + MainMenu.SelfKill.ToString() + " ";
            //Coloca a imagem nos botões
            BTN_pausa.Image = IMG_ChangeValueButton_normal;
            BTN_pular.Image = IMG_ChangeValueButton_normal;
            BTN_direita.Image = IMG_ChangeValueButton_normal;
            BTN_esquerda.Image = IMG_ChangeValueButton_normal;
            BTN_para.Image = IMG_ChangeValueButton_normal;
            BTN_DIE.Image = IMG_ChangeValueButton_normal;
            #endregion
        }

        #region Ações do botão de saida
        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = MainMenu.IMG_ExitButton_normal;
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            ExitButton.Image = MainMenu.IMG_ExitButton_hover;
        }

        private void ExitButton_MouseDown(object sender, MouseEventArgs e)
        {
            ExitButton.Image = MainMenu.IMG_ExitButton_press;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Ações básicas dos botões 'trocar'
        private void BTN_pular_MouseHover(object sender, EventArgs e)
        {
            BTN_pular.Image = IMG_ChangeValueButton_hover;
        }

        private void BTN_pular_MouseLeave(object sender, EventArgs e)
        {
            BTN_pular.Image = IMG_ChangeValueButton_normal;
        }

        private void BTN_pular_MouseDown(object sender, MouseEventArgs e)
        {
            BTN_pular.Image = IMG_ChangeValueButton_press;
        }

        private void BTN_direita_MouseHover(object sender, EventArgs e)
        {
            BTN_direita.Image = IMG_ChangeValueButton_hover;
        }

        private void BTN_direita_MouseLeave(object sender, EventArgs e)
        {
            BTN_direita.Image = IMG_ChangeValueButton_normal;
        }

        private void BTN_direita_MouseDown(object sender, MouseEventArgs e)
        {
            BTN_direita.Image = IMG_ChangeValueButton_press;
        }

        private void BTN_esquerda_MouseHover(object sender, EventArgs e)
        {
            BTN_esquerda.Image = IMG_ChangeValueButton_hover;
        }

        private void BTN_esquerda_MouseLeave(object sender, EventArgs e)
        {
            BTN_esquerda.Image = IMG_ChangeValueButton_normal;
        }

        private void BTN_esquerda_MouseDown(object sender, MouseEventArgs e)
        {
            BTN_esquerda.Image = IMG_ChangeValueButton_press;
        }

        private void BTN_pausa_MouseLeave(object sender, EventArgs e)
        {
            BTN_pausa.Image = IMG_ChangeValueButton_normal;
        }

        private void BTN_pausa_MouseHover(object sender, EventArgs e)
        {
            BTN_pausa.Image = IMG_ChangeValueButton_hover;
        }

        private void BTN_pausa_MouseDown(object sender, MouseEventArgs e)
        {
            BTN_pausa.Image = IMG_ChangeValueButton_press;
        }

        private void BTN_para_MouseDown(object sender, MouseEventArgs e)
        {
            BTN_para.Image = IMG_ChangeValueButton_press;
        }

        private void BTN_para_MouseHover(object sender, EventArgs e)
        {
            BTN_para.Image = IMG_ChangeValueButton_hover;
        }

        private void BTN_para_MouseLeave(object sender, EventArgs e)
        {
            BTN_para.Image = IMG_ChangeValueButton_normal;
        }

        private void BTN_DIE_MouseDown(object sender, MouseEventArgs e)
        {
            BTN_DIE.Image = IMG_ChangeValueButton_press;
        }

        private void BTN_DIE_MouseHover(object sender, EventArgs e)
        {
            BTN_DIE.Image = IMG_ChangeValueButton_hover;
        }

        private void BTN_DIE_MouseLeave(object sender, EventArgs e)
        {
            BTN_DIE.Image = IMG_ChangeValueButton_normal;
        }
        #endregion
        #region Ações avançadas dos botões 'trocar'
        private void BTN_pular_Click(object sender, EventArgs e)
        {
            QuemFoi = 1;
            Configura_InputBox TrocarValor = new Configura_InputBox();
            TrocarValor.Show();
            Updater.Enabled = true;
        }

        private void BTN_direita_Click(object sender, EventArgs e)
        {
            QuemFoi = 2;
            Configura_InputBox TrocarValor = new Configura_InputBox();
            TrocarValor.Show();
            Updater.Enabled = true;
        }

        private void BTN_esquerda_Click(object sender, EventArgs e)
        {
            QuemFoi = 3;
            Configura_InputBox TrocarValor = new Configura_InputBox();
            TrocarValor.Show();
            Updater.Enabled = true;
        }

        private void BTN_pausa_Click(object sender, EventArgs e)
        {
            QuemFoi = 4;
            Configura_InputBox TrocarValor = new Configura_InputBox();
            TrocarValor.Show();
            Updater.Enabled = true;
        }

        private void BTN_para_Click(object sender, EventArgs e)
        {
            QuemFoi = 5;
            Configura_InputBox TrocarValor = new Configura_InputBox();
            TrocarValor.Show();
            Updater.Enabled = true;
        }

        private void BTN_DIE_Click(object sender, EventArgs e)
        {
            QuemFoi = 6;
            Configura_InputBox TrocarValor = new Configura_InputBox();
            TrocarValor.Show();
            Updater.Enabled = true;
        }
        #endregion

        private void Updater_Tick(object sender, EventArgs e)
        {
            #region Coloca a nova chave para o comando
            //Verifica se o formulario que pede a nova chave esta aberto
            foreach (Form InputBox in Application.OpenForms)
            {
                if (InputBox is Configura_InputBox)
                {
                    CIB_isOpen = true;
                }
                else
                {
                    CIB_isOpen = false;
                }
            }
            //Se o formulario que pede a nova chave estiver fechado essa ação é executada e depois encerra o timer
            if (CIB_isOpen == false)
            {
                if (QuemFoi == 1)
                {
                    MainMenu.Pula = Configura_InputBox.CHAVE;
                    Pular.Text = " " + MainMenu.Pula.ToString() + " ";
                    Pular.Update();
                    Updater.Enabled = false;
                }
                else if (QuemFoi == 2)
                {
                    MainMenu.Direita = Configura_InputBox.CHAVE;
                    Direita.Text = " " + MainMenu.Direita.ToString() + " ";
                    Direita.Update();
                    Updater.Enabled = false;
                }
                else if (QuemFoi == 3)
                {
                    MainMenu.Esquerda = Configura_InputBox.CHAVE;
                    Esquerda.Text = " " + MainMenu.Esquerda.ToString() + " ";
                    Esquerda.Update();
                    Updater.Enabled = false;
                }
                else if (QuemFoi == 4)
                {
                    MainMenu.Pause = Configura_InputBox.CHAVE;
                    Pausa.Text = " " + MainMenu.Pause.ToString() + " ";
                    Pausa.Update();
                    Updater.Enabled = false;
                }
                else if (QuemFoi == 5)
                {
                    MainMenu.Estabil = Configura_InputBox.CHAVE;
                    Estabilizar.Text = " " + MainMenu.Estabil.ToString() + " ";
                    Estabilizar.Update();
                    Updater.Enabled = false;
                }
                else if (QuemFoi == 6)
                {
                    MainMenu.Estabil = Configura_InputBox.CHAVE;
                    Morrer.Text = " " + MainMenu.Estabil.ToString() + " ";
                    Morrer.Update();
                    Updater.Enabled = false;
                }
            }
            #endregion
        }

        private void Configura_KeyDown(object sender, KeyEventArgs e)
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
            #region Volta para o menu principal quando apertar espaço
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
            #endregion
        }
    }
}