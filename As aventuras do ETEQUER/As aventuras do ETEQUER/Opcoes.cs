using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Bibliotecas que eu adicionei
using System.Media;
using WMPLib;

namespace As_aventuras_do_ETEQUER
{
    public partial class Opcoes : Form
    {
        #region Variaveis
        //Variaveis usadas para animar as imagens do menu, SELECTshow mostra a imagem e SELECTwho mostra qual deve ser mostrada.
        Image SELECTshow;
        int SELECTwho = 1;
        //Usada para trocar a opção do menu selecionada
        int option_selected = 1;
        #endregion
        #region Rotinas
        public Opcoes()
        {
            InitializeComponent();
        }

        private void RunAnimation()
        {
            //A animação do item selecionado no menu
            if (SELECTwho == 1)
            {
                SELECTshow = MainMenu.SELECT1;
                SELECTwho = 2;
            }
            else if (SELECTwho == 2)
            {
                SELECTshow = MainMenu.SELECT2;
                SELECTwho = 3;
            }
            else if (SELECTwho == 3)
            {
                SELECTshow = MainMenu.SELECT3;
                SELECTwho = 4;
            }
            else if (SELECTwho == 4)
            {
                SELECTshow = MainMenu.SELECT4;
                SELECTwho = 1;
            }
        }
        #endregion

        private void Opcoes_Load(object sender, EventArgs e)
        {
            #region Organização dos graficos
            //Coloca a imagem de fundo
            this.BackgroundImage = MainMenu.BGcheff;

            //Coloca a imagem no botão de saida
            ExitButton.Image = MainMenu.IMG_ExitButton_normal;

            //Coloca as imagens de seleção em suas posições
            config_select.Image = MainMenu.SELECT_void;
            config_select2.Image = MainMenu.SELECT_void;
            ajuda_select.Image = MainMenu.SELECT_void;
            ajuda_select2.Image = MainMenu.SELECT_void;
            creditos_select.Image = MainMenu.SELECT_void;
            creditos_select2.Image = MainMenu.SELECT_void;
            voltar_select.Image = MainMenu.SELECT_void;
            voltar_select2.Image = MainMenu.SELECT_void;
            #endregion
        }

        private void Opcoes_KeyDown(object sender, KeyEventArgs e)
        {
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

                MainMenu.ChangeMenuOption.Play();
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

                MainMenu.ChangeMenuOption.Play();
            }
            #endregion
            #region Ação da opção selecionada
            if (e.KeyCode == Keys.Space)
            {
                MainMenu.WhenSelectOption.Play();

                if (option_selected == 1)
                {
                    Configura ChageConfig = new Configura();
                    ChageConfig.Show();
                }
                else if (option_selected == 2)
                {
                    HelpCredits.WhatTheHell = 0;
                    HelpCredits Ajuda = new HelpCredits();
                    Ajuda.Show();
                }
                else if (option_selected == 3)
                {
                    Videos.WhoPlay = 6;
                    Videos CREDTS = new Videos();
                    CREDTS.Show();
                }
                else if (option_selected == 4)
                {
                    this.Close();
                }
            }
            #endregion
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            //Esse Updater é 75 vezes mais lento que os normais do InGame
            #region Animação do menu
            //Executa a animação da opção selecionada
            if (option_selected == 1)
            {
                //Novo jogo selecionado
                //Muda a cor do texto
                Config_LABEL.ForeColor = Color.Red;
                Ajuda_LABEL.ForeColor = Color.Gold;
                Creditos_LABEL.ForeColor = Color.Gold;
                Voltar_LABEL.ForeColor = Color.Gold;

                //Anula as imagens de animação e a animação dos itens não-selecionados
               ajuda_select.Image = MainMenu.SELECT_void;
               creditos_select.Image = MainMenu.SELECT_void;
               voltar_select.Image = MainMenu.SELECT_void;

               ajuda_select2.Image = MainMenu.SELECT_void;
               creditos_select2.Image = MainMenu.SELECT_void;
               voltar_select2.Image = MainMenu.SELECT_void;

                //Roda a animação no item selecionado
                config_select.Image = SELECTshow;
                config_select2.Image = SELECTshow;
            }

            else if (option_selected == 2)
            {
                //Novo jogo selecionado
                //Muda a cor do texto
                Config_LABEL.ForeColor = Color.Gold;
                Ajuda_LABEL.ForeColor = Color.Red;
                Creditos_LABEL.ForeColor = Color.Gold;
                Voltar_LABEL.ForeColor = Color.Gold;

                //Anula as imagens de animação e a animação dos itens não-selecionados
                config_select.Image = MainMenu.SELECT_void;
                creditos_select.Image = MainMenu.SELECT_void;
                voltar_select.Image = MainMenu.SELECT_void;

                config_select2.Image = MainMenu.SELECT_void;
                creditos_select2.Image = MainMenu.SELECT_void;
                voltar_select2.Image = MainMenu.SELECT_void;

                //Roda a animação no item selecionado
                ajuda_select.Image = SELECTshow;
                ajuda_select2.Image = SELECTshow;
            }

            else if (option_selected == 3)
            {
                //Novo jogo selecionado
                //Muda a cor do texto
                Config_LABEL.ForeColor = Color.Gold;
                Ajuda_LABEL.ForeColor = Color.Gold;
                Creditos_LABEL.ForeColor = Color.Red;
                Voltar_LABEL.ForeColor = Color.Gold;

                //Anula as imagens de animação e a animação dos itens não-selecionados
                config_select.Image = MainMenu.SELECT_void;
                ajuda_select.Image = MainMenu.SELECT_void;
                voltar_select.Image = MainMenu.SELECT_void;

                config_select2.Image = MainMenu.SELECT_void;
                ajuda_select2.Image = MainMenu.SELECT_void;
                voltar_select2.Image = MainMenu.SELECT_void;

                //Roda a animação no item selecionado
                creditos_select.Image = SELECTshow;
                creditos_select2.Image = SELECTshow;
            }

            else if (option_selected == 4)
            {
                //Novo jogo selecionado
                //Muda a cor do texto
                Config_LABEL.ForeColor = Color.Gold;
                Ajuda_LABEL.ForeColor = Color.Gold;
                Creditos_LABEL.ForeColor = Color.Gold;
                Voltar_LABEL.ForeColor = Color.Red;

                //Anula as imagens de animação e a animação dos itens não-selecionados
                config_select.Image = MainMenu.SELECT_void;
                ajuda_select.Image = MainMenu.SELECT_void;
                creditos_select.Image = MainMenu.SELECT_void;

                config_select2.Image = MainMenu.SELECT_void;
                ajuda_select2.Image = MainMenu.SELECT_void;
                creditos_select2.Image = MainMenu.SELECT_void;

                //Roda a animação no item selecionado
                voltar_select.Image = SELECTshow;
                voltar_select2.Image = SELECTshow;
            }
            //Atualiza as picturebox
            config_select.Update();
            config_select2.Update();
            ajuda_select.Update();
            ajuda_select2.Update();
            creditos_select.Update();
            creditos_select2.Update();
            voltar_select.Update();
            voltar_select2.Update();

            //Atualiza a animação
            RunAnimation();
            #endregion
        }

        #region Botão de saida
        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            ExitButton.Image = MainMenu.IMG_ExitButton_hover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = MainMenu.IMG_ExitButton_normal;
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
    }
}