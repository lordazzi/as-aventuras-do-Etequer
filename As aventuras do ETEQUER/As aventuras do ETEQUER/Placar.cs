using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Bibliotecas adicionadas por mim
using System.Data.OleDb;

namespace As_aventuras_do_ETEQUER
{
    public partial class Placar : Form
    {
        #region Variaveis
        //Essa variavel carrega a imagem de fundo desse formulario
        static public Image ImagemDeFundo, NOVAimgDefundo;
        //Conexão com o banco de dados e comando
        string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=data.bd;Jet OLEDB:DataBase Password =", Inserir = "SELECT ID, Nome, Pontos FROM Placar WHERE ID=";
        int ID = 1;
        OleDbConnection CONNwithPlacar;
        OleDbCommand InsertValues;
        OleDbDataReader DR_do_placar;
        //Essas strings servem para enviar o valor para a tabela desenhada no placar
        string NOME, PONTOS;
        //senha
        static public int senhaPART4, senhaPART5;
        static public string The_password;
        #endregion

        public Placar()
        {
            InitializeComponent();
        }

        private void ShowRecordist()
        {
            //Facilita para pegar os dados do placar
            InsertValues = new OleDbCommand(Inserir + ID.ToString(), CONNwithPlacar);
            if (CONNwithPlacar.State == ConnectionState.Open)
            {
                DR_do_placar = InsertValues.ExecuteReader();
                if (DR_do_placar.Read())
                {
                    NOME = DR_do_placar["Nome"].ToString();
                    PONTOS = DR_do_placar["Pontos"].ToString();
                }
            }
            ID++;
        }

        private void Placar_Load(object sender, EventArgs e)
        {
            #region Organização do placar
            //Coloca o plano de fundo no placar
            this.BackgroundImage = NOVAimgDefundo;
            //Coloca a imagem do botão na pictureBox 'ExitButton'
            ExitButton.Image = MainMenu.IMG_ExitButton_normal;

            //formulando senha secreta
            senhaPART4 = MainMenu.senhaPART1 * MainMenu.senhaPART1 * MainMenu.senhaPART2;
            senhaPART5 = MainMenu.senhaPART1 - (MainMenu.senhaPART1 / 8);
            The_password = MainMenu.senhaPART3.Substring(0, 1) + senhaPART4.ToString() + MainMenu.senhaPART3.Substring(1, 1) + senhaPART5.ToString() + MainMenu.senhaPART3.Substring(2, 1);
            try
            {
                CONNwithPlacar = new OleDbConnection(ConnStr + The_password + ";");
                CONNwithPlacar.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possivel carregar as pontuações do placar, o banco de dados pode estar corrompidos.\nVocê pode reinstalar o jogo mas isso irá fazer você perder as pontuações marcadas!", "::ERRO::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //Primeiro recordista
            ShowRecordist();
            Primeiro_Nome.Text = NOME;
            Primeiro_Pontos.Text = PONTOS;
            //Segundo recordista
            ShowRecordist();
            Segundo_Nome.Text = NOME;
            Segundo_Pontos.Text = PONTOS;
            //Terceiro recordista
            ShowRecordist();
            Terceiro_Nome.Text = NOME;
            Terceiro_Pontos.Text = PONTOS;
            //Quarto recordista
            ShowRecordist();
            Quarto_Nome.Text = NOME;
            Quarto_Pontos.Text = PONTOS;
            //Quinto recordista
            ShowRecordist();
            Quinto_Nome.Text = NOME;
            Quinto_Pontos.Text = PONTOS;
            //Sexto recordista
            ShowRecordist();
            Sexto_Nome.Text = NOME;
            Sexto_Pontos.Text = PONTOS;
            //Setimo recordista
            ShowRecordist();
            Setimo_Nome.Text = NOME;
            Setimo_Pontos.Text = PONTOS;
            //Oitavo recordista
            ShowRecordist();
            Oitavo_Nome.Text = NOME;
            Oitavo_Pontos.Text = PONTOS;
            //Nono recordista
            ShowRecordist();
            Nono_Nome.Text = NOME;
            Nono_Pontos.Text = PONTOS;
            //Decimo recordista
            ShowRecordist();
            Decimo_Nome.Text = NOME;
            Decimo_Pontos.Text = PONTOS;
            CONNwithPlacar.Close();
            #endregion
        }

        private void Placar_KeyDown(object sender, KeyEventArgs e)
        {
            #region Sai do aplicativo quando Alt + F4 é pressionado
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
            else if (e.Alt && e.KeyCode == Keys.F4)
            {
                Application.Exit();
            }
            #endregion
        }

        #region Ações do botão de saida
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
        #endregion
    }
}