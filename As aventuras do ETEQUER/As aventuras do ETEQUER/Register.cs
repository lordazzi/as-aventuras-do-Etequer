using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Bibliotecas que eu adicionei
using System.Data.OleDb;

namespace As_aventuras_do_ETEQUER
{
    public partial class Register : Form
    {
        #region Variaveis
        //Essa variavel faz a animação do "Enviando" rodar
        bool Sending = false;
        //Essa variavel irá receber os pontos do usuário
        string Pontos;

        //Essa matriz vai carregar o placar
        string[,] PLACAR = new string[11, 4];

        //Variaveis que interagem com o banco de dados
        OleDbConnection CONN;
        OleDbCommand CMD;
        OleDbDataReader DR;
        //Senha secreta
        int senhaPART4, senhaPART5;
        string The_password;

        //Verifica se o botão jah foi "clicado"
        bool Clicado = false;

        #endregion
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            #region Organização do gráfico do formulario
            ENVIANDO.Image = MainMenu.SELECT_void;
            //Pegando a pontuação do jogador e colocando ela dentro desse formulario
            Pontos = Jogo.GB_points.ToString();
            //Fechando os formularios que se referem ao jogo
            ControlPanel.KILLthat = true;
            Jogo.thisKILL = true;
            Fundo.KILL = true;
            this.BringToFront();
            //Mostrandoa a pontuação do usuário
            int INDEX = Pontos.IndexOf(".");
            try
            {
                Pontos = Pontos.Substring(0, INDEX + 3);
            }
            catch
            {
            }
            GBpontos.Text = Pontos.Replace(".", ",");
            //Colocando as posições na string
            PLACAR[1, 1] = "1";
            PLACAR[2, 1] = "2";
            PLACAR[3, 1] = "3";
            PLACAR[4, 1] = "4";
            PLACAR[5, 1] = "5";
            PLACAR[6, 1] = "6";
            PLACAR[7, 1] = "7";
            PLACAR[8, 1] = "8";
            PLACAR[9, 1] = "9";
            PLACAR[10, 1] = "10";
            #endregion
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            if (Clicado == false)
            {
                #region Configurações prévias
                //Evitando que o botão seja repressionado
                Clicado = true;

                //Animação
                Sending = true;

                //formulando senha secreta
                senhaPART4 = MainMenu.senhaPART1 * MainMenu.senhaPART1 * MainMenu.senhaPART2;
                senhaPART5 = MainMenu.senhaPART1 - (MainMenu.senhaPART1 / 8);
                The_password = MainMenu.senhaPART3.Substring(0, 1) + senhaPART4.ToString() + MainMenu.senhaPART3.Substring(1, 1) + senhaPART5.ToString() + MainMenu.senhaPART3.Substring(2, 1);

                //Executando os comandos
                DoAction.Enabled = true;
                #endregion
            }

        }

        private void Update_Tick(object sender, EventArgs e)
        {
            #region Dando animação enquanto a pontuação é checada e enviada para o BD
            if (Sending == true)
            {
                if (ENVIANDO.Image == MainMenu.SELECT_void)
                {
                    ENVIANDO.Image = MainMenu.SELECT1;
                    AVISO.Visible = true;
                }

                else if (ENVIANDO.Image == MainMenu.SELECT1)
                {
                    ENVIANDO.Image = MainMenu.SELECT2;
                }

                else if (ENVIANDO.Image == MainMenu.SELECT2)
                {
                    ENVIANDO.Image = MainMenu.SELECT3;
                }

                else if (ENVIANDO.Image == MainMenu.SELECT3)
                {
                    ENVIANDO.Image = MainMenu.SELECT4;
                }

                else if (ENVIANDO.Image == MainMenu.SELECT4)
                {
                    ENVIANDO.Image = MainMenu.SELECT1;
                }
            }

            else
            {
                AVISO.Visible = false;
                ENVIANDO.Image = MainMenu.SELECT_void;
            }
            #endregion
        }

        private void DoAction_Tick(object sender, EventArgs e)
        {
            #region Conexão com o banco de dados
            //Tentativa de conexão
            try
            {
                CONN = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=data.bd;Jet OLEDB:DataBase Password =" + The_password + ";");
                CONN.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possivel carregar as pontuações do placar, o banco de dados pode estar corrompidos.\nVocê pode reinstalar o jogo mas isso irá fazer você perder as pontuações marcadas!", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sending = false;
            }
            #endregion
            #region Puchando as informações para uma matriz
            for (int INTfor = 1; INTfor < 11; INTfor++)
            {
                CMD = new OleDbCommand("SELECT ID, Nome, Pontos FROM Placar WHERE ID=" + INTfor, CONN);
                if (CONN.State == ConnectionState.Open)
                {
                    DR = CMD.ExecuteReader();
                    if (DR.Read())
                    {
                        PLACAR[INTfor, 2] = DR["Nome"].ToString();
                        PLACAR[INTfor, 3] = DR["Pontos"].ToString();
                    }
                }
            }
            #endregion
            #region Primeiro lugar
            if (double.Parse(PLACAR[1, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = PLACAR[8, 2];
                PLACAR[9, 3] = PLACAR[8, 3];

                PLACAR[8, 2] = PLACAR[7, 2];
                PLACAR[8, 3] = PLACAR[7, 3];

                PLACAR[7, 2] = PLACAR[6, 2];
                PLACAR[7, 3] = PLACAR[6, 3];

                PLACAR[6, 2] = PLACAR[5, 2];
                PLACAR[6, 3] = PLACAR[5, 3];

                PLACAR[5, 2] = PLACAR[4, 2];
                PLACAR[5, 3] = PLACAR[4, 3];

                PLACAR[4, 2] = PLACAR[3, 2];
                PLACAR[4, 3] = PLACAR[3, 3];

                PLACAR[3, 2] = PLACAR[2, 2];
                PLACAR[3, 3] = PLACAR[2, 3];

                PLACAR[2, 2] = PLACAR[1, 2];
                PLACAR[2, 3] = PLACAR[1, 3];

                PLACAR[1, 2] = Nome.Text;
                PLACAR[1, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Segundo lugar
            else if (double.Parse(PLACAR[2, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = PLACAR[8, 2];
                PLACAR[9, 3] = PLACAR[8, 3];

                PLACAR[8, 2] = PLACAR[7, 2];
                PLACAR[8, 3] = PLACAR[7, 3];

                PLACAR[7, 2] = PLACAR[6, 2];
                PLACAR[7, 3] = PLACAR[6, 3];

                PLACAR[6, 2] = PLACAR[5, 2];
                PLACAR[6, 3] = PLACAR[5, 3];

                PLACAR[5, 2] = PLACAR[4, 2];
                PLACAR[5, 3] = PLACAR[4, 3];

                PLACAR[4, 2] = PLACAR[3, 2];
                PLACAR[4, 3] = PLACAR[3, 3];

                PLACAR[3, 2] = PLACAR[2, 2];
                PLACAR[3, 3] = PLACAR[2, 3];

                PLACAR[2, 2] = Nome.Text;
                PLACAR[2, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Terceiro lugar
            else if (double.Parse(PLACAR[3, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = PLACAR[8, 2];
                PLACAR[9, 3] = PLACAR[8, 3];

                PLACAR[8, 2] = PLACAR[7, 2];
                PLACAR[8, 3] = PLACAR[7, 3];

                PLACAR[7, 2] = PLACAR[6, 2];
                PLACAR[7, 3] = PLACAR[6, 3];

                PLACAR[6, 2] = PLACAR[5, 2];
                PLACAR[6, 3] = PLACAR[5, 3];

                PLACAR[5, 2] = PLACAR[4, 2];
                PLACAR[5, 3] = PLACAR[4, 3];

                PLACAR[4, 2] = PLACAR[3, 2];
                PLACAR[4, 3] = PLACAR[3, 3];

                PLACAR[3, 2] = Nome.Text;
                PLACAR[3, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Quarto lugar
            else if (double.Parse(PLACAR[4, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = PLACAR[8, 2];
                PLACAR[9, 3] = PLACAR[8, 3];

                PLACAR[8, 2] = PLACAR[7, 2];
                PLACAR[8, 3] = PLACAR[7, 3];

                PLACAR[7, 2] = PLACAR[6, 2];
                PLACAR[7, 3] = PLACAR[6, 3];

                PLACAR[6, 2] = PLACAR[5, 2];
                PLACAR[6, 3] = PLACAR[5, 3];

                PLACAR[5, 2] = PLACAR[4, 2];
                PLACAR[5, 3] = PLACAR[4, 3];

                PLACAR[4, 2] = Nome.Text;
                PLACAR[4, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Quinto lugar
            else if (double.Parse(PLACAR[5, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = PLACAR[8, 2];
                PLACAR[9, 3] = PLACAR[8, 3];

                PLACAR[8, 2] = PLACAR[7, 2];
                PLACAR[8, 3] = PLACAR[7, 3];

                PLACAR[7, 2] = PLACAR[6, 2];
                PLACAR[7, 3] = PLACAR[6, 3];

                PLACAR[6, 2] = PLACAR[5, 2];
                PLACAR[6, 3] = PLACAR[5, 3];

                PLACAR[5, 2] = Nome.Text;
                PLACAR[5, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Sexto lugar
            else if (double.Parse(PLACAR[6, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = PLACAR[8, 2];
                PLACAR[9, 3] = PLACAR[8, 3];

                PLACAR[8, 2] = PLACAR[7, 2];
                PLACAR[8, 3] = PLACAR[7, 3];

                PLACAR[7, 2] = PLACAR[6, 2];
                PLACAR[7, 3] = PLACAR[6, 3];

                PLACAR[6, 2] = Nome.Text;
                PLACAR[6, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Setimo lugar
            else if (double.Parse(PLACAR[7, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = PLACAR[8, 2];
                PLACAR[9, 3] = PLACAR[8, 3];

                PLACAR[8, 2] = PLACAR[7, 2];
                PLACAR[8, 3] = PLACAR[7, 3];

                PLACAR[7, 2] = Nome.Text;
                PLACAR[7, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Oitavo lugar
            else if (double.Parse(PLACAR[8, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = PLACAR[8, 2];
                PLACAR[9, 3] = PLACAR[8, 3];

                PLACAR[8, 2] = Nome.Text;
                PLACAR[8, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Nono lugar
            else if (double.Parse(PLACAR[9, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = PLACAR[9, 2];
                PLACAR[10, 3] = PLACAR[9, 3];

                PLACAR[9, 2] = Nome.Text;
                PLACAR[9, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region Decimo lugar
            else if (double.Parse(PLACAR[10, 3]) < double.Parse(Pontos))
            {
                PLACAR[10, 2] = Nome.Text;
                PLACAR[10, 3] = Pontos.Replace(".", ",");
            }
            #endregion
            #region fora do placar
            else
            {
            }
            #endregion
            #region Inserindo a matriz no banco de dados
            for (int INTfor = 1; INTfor < 11; INTfor++)
            {
                CMD = new OleDbCommand("UPDATE Placar SET Nome='" + PLACAR[INTfor, 2] + "' WHERE Id=" + PLACAR[INTfor, 1] + ";", CONN);
                CMD.ExecuteNonQuery();
                CMD = new OleDbCommand("UPDATE Placar SET Pontos='" + PLACAR[INTfor, 3] + "' WHERE Id=" + PLACAR[INTfor, 1] + ";", CONN);
                CMD.ExecuteNonQuery();
            }
            #endregion
            #region Abrindo o placar
            DoAction.Enabled = false;
            Sending = false;
            this.Close();
            Placar OpenPlacar = new Placar();
            OpenPlacar.Show();
            #endregion
        }

        private void Register_KeyDown(object sender, KeyEventArgs e)
        {
            #region Encerrando a aplicação
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                Application.Exit();
            }
            #endregion
        }
    }
}