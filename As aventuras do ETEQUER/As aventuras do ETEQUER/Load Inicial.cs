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

namespace As_aventuras_do_ETEQUER
{
    public partial class Load_Inicial : Form
    {
        public Load_Inicial()
        {
            InitializeComponent();
        }

        private void Load_Inicial_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackgroundImage = Image.FromFile("programa\\initialload.bg");
                Updater.Enabled = true;
            }
            catch
            {
                MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            //Carrega os arquivos que serão usados no MainMenu, são sons e imagens
            #region Carregando gráfico e audio do programa

            try
            {
                //Novo plano de fundo do placar, para evitar o carregamento de muitas pictureBox (1)
                WhatIsLoading.Text = "Carregando programa\\newPLC.bg";
                WhatIsLoading.Update();
                Placar.NOVAimgDefundo = Image.FromFile("programa\\newPLC.bg");

                //Imagens dos botões das configurações (2)
                WhatIsLoading.Text = "Carregando programa\\cbn.btn";
                WhatIsLoading.Update();
                Configura.IMG_ChangeValueButton_normal = Image.FromFile("Programa\\CBN.btn");

                //(3)
                WhatIsLoading.Text = "Carregando programa\\cbh.btn";
                WhatIsLoading.Update();
                Configura.IMG_ChangeValueButton_hover = Image.FromFile("Programa\\cBh.btn");

                //(4)
                WhatIsLoading.Text = "Carregando programa\\cbp.btn";
                WhatIsLoading.Update();
                Configura.IMG_ChangeValueButton_press = Image.FromFile("Programa\\cBp.btn");

                //Imagens do botão de saida (5)
                WhatIsLoading.Text = "Carregando programa\\ebn.btn";
                WhatIsLoading.Update();
                MainMenu.IMG_ExitButton_normal = Image.FromFile("Programa\\ebn.btn");

                //(6)
                WhatIsLoading.Text = "Carregando programa\\ebh.img";
                WhatIsLoading.Update();
                MainMenu.IMG_ExitButton_hover = Image.FromFile("Programa\\ebh.btn");

                //(7)
                WhatIsLoading.Text = "Carregando programa\\ebp.btn";
                WhatIsLoading.Update();
                MainMenu.IMG_ExitButton_press = Image.FromFile("Programa\\ebp.btn");

                //Imagem de fundo do menu e das opções (8)
                WhatIsLoading.Text = "Carregando programa\\MM.bg";
                WhatIsLoading.Update();
                MainMenu.BGcheff = Image.FromFile("programa\\MM.bg");

                //Imagens da animação que mostram ao usuário qual item está selecionado (9)
                WhatIsLoading.Text = "Carregando programa\\select0.opt";
                WhatIsLoading.Update();
                MainMenu.SELECT_void = Image.FromFile("Programa\\select0.opt");

                //(10)
                WhatIsLoading.Text = "Carregando programa\\select1.opt";
                WhatIsLoading.Update();
                MainMenu.SELECT1 = Image.FromFile("programa\\select1.opt");

                //(11)
                WhatIsLoading.Text = "Carregando programa\\select2.opt";
                WhatIsLoading.Update();
                MainMenu.SELECT2 = Image.FromFile("Programa\\select2.opt");

                //(12)
                WhatIsLoading.Text = "Carregando programa\\select3.opt";
                WhatIsLoading.Update();
                MainMenu.SELECT3 = Image.FromFile("Programa\\select3.opt");

                //(13)
                WhatIsLoading.Text = "Carregando programa\\select4.opt";
                WhatIsLoading.Update();
                MainMenu.SELECT4 = Image.FromFile("Programa\\select4.opt");

                //Som que ocorre na troca de item das opções do menu (14)
                WhatIsLoading.Text = "Carregando programa\\effect1.eff";
                WhatIsLoading.Update();
                MainMenu.ChangeMenuOption = new SoundPlayer("Programa\\effect1.eff");

                //Som que ocorre ao pressionar barra de espaço (15)
                WhatIsLoading.Text = "Carregando programa\\effect2.eff";
                WhatIsLoading.Update();
                MainMenu.WhenSelectOption = new SoundPlayer("Programa\\effect2.eff");

                //Carregando o plano de fundo do placar e das configurações (16)
                WhatIsLoading.Text = "Carregando programa\\CONF.bg";
                WhatIsLoading.Update();
                Configura.ImagemDeFundo = Image.FromFile("Programa\\CONF.bg");

                //Carregando plano de fundo do menu de Ajuda e do Menu de Créditos
                WhatIsLoading.Text = "Grafico\\help.bg";
                WhatIsLoading.Update();
                HelpCredits.Plano_de_fundo = Image.FromFile("Grafico\\help.bg");

                WhatIsLoading.Text = "Todos arquivos necessarios foram carregados com sucesso!";
            }
            catch
            {
                MessageBox.Show("::ERRO::\nNão é possivel concluir o carregamento.\n - Talvéz você tenha movido, deletado ou renomeado o arquivo.\n - A instalação pode não ter sido concluida com sucesso.", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Open.Enabled = true;
            Updater.Enabled = false;
            #endregion
        }

        private void Open_Tick(object sender, EventArgs e)
        {
                MainMenu INICIAR = new MainMenu();
                INICIAR.Show();
                this.Visible = false;
                Updater.Enabled = false;
                Open.Enabled = false;
        }
    }
}