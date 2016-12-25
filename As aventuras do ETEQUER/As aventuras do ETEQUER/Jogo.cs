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
    public partial class Jogo : Form
    {
        #region Variaveis
        //Pulo do jogador 
        int Hpulo = 13;

        //Evita que rodem videos e musica ao mesmo tempo
        bool VideoOPEN = false;

        //analisa a posição do formulário para saber se estão todos alinhados
        static public int ThisCheckLeft, ThisCheckTop;
        //Verifica se o formulario já esta ativo
        static public bool IAmStarted = false;
        //Informações do botão de saida para o Painel de controle saiba onde deve ser clicado para sair
        static public int ExitButton_height, ExitButton_width, ExitButton_top, ExitButton_left;

        //Essas imagens carregam o gráfico da fonte do número de vidas
        static public Image Zero, Um, Dois, Tres, Quatro, Cinco, Seis, Sete, Oito, Nove;
        //numero de vidas
        static public int Vidas = 5;
        //Porcentagem da vida (vida relacionada a barra)
        static public int Porcent_of_Life = 100;

        //Essa variavel é usada na conversão da vida, de int para imagem.
        static public string intTOstring;
        //Essa variavel vai receber o valor da imagem correspondente ao número
        static public Image stringTOimg;
        //Essas variaveis recebem os dois algarismos da vida do jogador
        static public string SubVida1, SubVida2;

        //Essa variavel de imagem guarda a cabeça do jogador localizada ao lado dos pontos de vida
        static public Image HeadOfLives;

        //Carrega o grafico do personagem
        static public Image Etequer1_DIR, Etequer2_DIR, Etequer3_DIR, Etequer1_ESQ, Etequer2_ESQ, Etequer3_ESQ;

        //Carrega o grafico do personagem com FIrewall ativa
        static public Image FW_Etequer1_DIR, FW_Etequer2_DIR, FW_Etequer3_DIR, FW_Etequer1_ESQ, FW_Etequer2_ESQ, FW_Etequer3_ESQ;

        //Variaveis usadas para fazer a animação da locomoção do jogador
        //Essa variavel volta com o valor da imagem da animação
        Image IMG_AnimationValue;
        //Essa variavel marca qual a animação deve ser colocada
        int COD_AnimationValue = 2;
        //Verifica para qual o lado que o jogador esta andando o jogador
        static public int WhereAreYouGoing = 0;
        /* 0 = Não anda
         * 1 = Direita
         * 2 = Esquerda*/

        //Verifica se o personagem esta ou não usando Firewall
        bool IsFW = false;
        //Tempo de FW
        int FWtime = 1200;
        //Para mostrar a FW serão necessarias as seguintes variaveis
        //Recebe o valor da divisão do FWtime/50
        double Dividido;
        //Tira a virgula do double
        string ORIGINALvalue; int INDEXER;

        //Verifica a ultima tecla que o jogador pressionou (Direita ou Esquersa)
        static public Keys UltimaTecla = MainMenu.Direita;

        //Essas duas variaveis guardam o valor da imagem de barra de vida, tando a imagem de fundo assim como a imagem que marca a porcentagem de vida do jogador
        static public Image LifeBAR_IMG_bg, LifeBAR_IMG;

        //Variavel que mostra o valor da posição do jogador para poder tirar e colocar o chão
        static public int PLAYERpos = 0;

        //Essa variavel guarda os pontos do personagem, ela deverá entrar no banco de dados do SAVE
        static public double GB_points;

        //Move o chão, inimigo, itens quando é pressionado a tecla de locomoção
        static public bool IsMoved = false;

        //Carrega as imagens dos chãos, caixas e items
        static public Image YellowTile, GrayTile, GreenTile, CDbox, CDitem, DVDbox, DVDitem, PENbox, PENitem, FWbox, FWitem_SPR1, FWitem_SPR2, LIFEbox, LIFEitem, STARbox, STARitem_SPR1, STARitem_SPR2;

        //Essas variaveis de imagem servem para reconhecer se o objeto é um Piso, Item, Caixa, Inimigo etc.
        static public Image IMA_Tile, IMA_CdBox, IMA_CdItem, IMA_DvdBox, IMA_DvdItem, IMA_PenBox, IMA_PenItem, IMA_FwBox, IMA_FwItem, IMA_LifeItem, IMA_LifeBox, IMA_StarBox, IMA_StarItem;
        //Reconhecendo os quatro boots BadGuy, Renato, Erwin e Daivison
        static public Image IMA_BadGuy, IMA_Daivison, IMA_Erwin;

        //Essas variaveis de imagem server para o inimigo fazer a determinada ação, cada variavel contem informações do que o Enemy NPC deve fazer
        static public Image BOOT;

        //Essa variavel coloca cada chão no seu lugar, dependendo de seu valor, um novo chão aparece ou desaparece
        int TileControl;

        //Verifica se já foi adicionado '10' para a localização do jogador dentro do foreach de pesquisa de chão no formulário
        static public bool LocationCorrection = false;

        //Essas variaveis contem a variaveção de posições que as picturebox podem ter.
        int F = 469, E = 409, D = 349, C = 289, B = 229, A = 169;

        //Tocando a musica de fundo
        static public IWMPMedia GAME_music, ROZA_music, MARCELU_music, MUACIR_music, RENATU_music, AGUSTINHO_music, CLEITO_music, LC_music;

        //Guarda os itens que foram pegos e os que não foram
        static public int[] SituacaoDOSitems = new int[9999];
        //Essa variavel avalia se o item foi pego ou não
        int Fui_pego = 0;

        //Essa variavel foi criada para quando o jogo é iniciado, quando é iniciada uma nova fase ou quando o usuário 'LoadIza' o jogo.
        static public bool FirstDeclaration = false;

        //Avisa se o jogador esta pulando
        static public bool Subindo_PULO = false;
        //Esse número marca em que posição no ar ele se encontra
        int Air_pos;

        //Essa variavel mostra que todos os objetos do formulario jah foram pesquisados e que se você estiver sem nenhum por baixo de você, você cai
        bool HaveOneUnderMe = true;

        //Analisa se direita e esquerda estão livres para a movimentação
        static public bool DIR_livre = true, ESQ_livre = true;
        //Essa variavel é muito importante, ela verifica se há impedimento para o jogador e caso contrario ela movimenta tudo
        static public bool CanTryMoveAllforESQ = false, CanTryMoveAllforDIR = false;

        //Essas variaveis vão guardar as animações ocorrida quando as caixas são quebradas
        static public Image[] CDani = new Image[16], DVDani = new Image[16], FWani = new Image[16], LIFEani = new Image[16], PENani = new Image[16], STARani = new Image[16];
        //Essas variaveis vão servir para a animação da caixa
        Image CDanimage, DVDanimage, FWanimage, LIFEanimage, PENanimage, STARanimage; //Transporta a imagem para uma picturebox.
        int CDcount = 0, DVDcount = 0, FWcount = 0, LIFEcount = 0, PENcount = 0, STARcount = 0; //Avisa qual imagem deve ser mostrada agora.
        static public SoundPlayer Broke; //Som de quebra de caixa
        //Sons de efeitos quando se pega um item
        static public SoundPlayer FWeff, LIFEeff, STAReff, ITEMSeff;

        //Nessa variavel vai ficar guardada as imagens das conversas entre o jogador e os NPCs
        static public Image Pergaminho, textoA, textoB, textoC;

        //Inteiro e Randomica usados no random da pontuação do pendrive
        int PENrand;
        Random PENpoints = new Random();

        //Randomizando a direção para qual o Boot vai se direcionar
        Random BOOTdirect = new Random();

        //Essas variaveis vão guardar as imagens animativas dos boots
        //Etequer do mal
        static public Image BadGuy_DIR1, BadGuy_DIR2, BadGuy_DIR3, BadGuy_ESQ1, BadGuy_ESQ2, BadGuy_ESQ3;
        static public Image Daivison1, Daivison2;
        static public Image Ervin1, Ervin2, Ervin3;
        //Declarar Renatos aqui

        //Ve se o jogador ja conversou com os diversos professores do jogo
        static public bool RozaTalk, MarceluTalk, MarceluFight, MuacirFight, RenatuTalk, AgustinhoFight, CleitoTalk, LCFight;

        //Imagens da rozinha
        static public Image Roza1, Roza2, Roza2x2, Roza3;
        static public Image RozaEXIT1, RozaEXIT2, RozaEXIT3, RozaEXIT4;

        //imagens do Alido e chefe marcelu -- Marcelu Opened Eyes, Marcelu Closed Eyes
        static public Image MarceluOE, MarceluCE;

        //Imagens do inimigo Muacir
        static public Image Muacir1, Muacir2_1, Muacir2_2, Muacir3, Muacir4;
        //Verifica se a imagem do muacir jah piscou
        static public bool PiscouMua = false;

        //Carrega a imagem do professor Renatu
        static public Image RenatuIMG;

        //Carrega a imagem do professor Cleito
        static public Image CleitoIMG;

        //Imagens de animação in game do chefe Agustinho
        static public Image Agustinho_01, Agustinho_02, Agustinho_03;

        //Carrega a imagem do cordenador Louis Carlos
        static public Image LouisCarlosIMG;

        //Reconhecedor de chefes e amigos, arquivos IMA
        static public Image IMA_Roza, IMA_Marcelu_Friend, IMA_Marcelu_Boss, IMA_Muacir, IMA_Renatu, IMA_Agustinho, IMA_Cleito, IMA_LouisCarlos;

        //Essas variaveis vão ficar guardando as avatares dos personagens
        static public Image ETEQUERavt, ROZAavt, MARCELUavt, MUACIRavt, RENATUavt, AGUSTINHOavt, CLEITOavt, LCavt;

        //Essa variavel vai fazer com que o programa saiba em qual parte da conversa o joagador esta (em relação jogador/aliado(ou inimigo)
        static public int TALK = 0;
        //Avisa se o jogador esta conversando
        static public bool TALKing = false;

        //Faz o jogo todo parar, estou usando isso para o talk
        static public bool DontMOVE = false;

        //Essas variaveis de imagem irão carregar as imagens de animação da morte do Etequer
        static public Image ETECdie_1, ETECdie_2, ETECdie_3, ETECdie_4, ETECdie_5, ETECdie_6;
        //Som que o Etequer faz quando morre
        static public SoundPlayer GuiLL;
        //Se essa variavel ficar verdadeira, o Etequer morre (Esse comentario fico parecendo ameça com refem =D)
        static public bool DiePig = false;
        //Variavel int que mostra onde se localiza a animação da morte do jogador
        int KillANIM = 0;

        //Essas variaveis de imagem vão carregar a imagem do Banco de Itens vazio e com a ShotGun
        static public Image BI, BIused;

        //Essa variavel vai guarda o local em que o jogador deve voltar quando ele morrer
        int CheckPoint = 100;
        //Essa variavel impede que a fase seja reconstruida parcialmente pelo sistema de CheckPoint
        bool C_POINTED = true;

        //Essas variaveis vão marcar quais o checkpoints que o jogador já pegou
        bool CP_roza = false;
        bool CP_Marcelu_Talk = false;
        bool CP_Marcelu_Boss = false;
        bool CP_Muacir = false;
        bool CP_Renatu = false;
        bool CP_Agustinho = false;
        bool CP_Cleito = false;
        bool CP_LouisCarlos = false;

        //Avisa a musica de quem esta tocando
        bool Music_Game = false;
        bool Music_roza = false;
        bool Music_Marcelu = false;
        bool Music_Muacir = false;
        bool Music_Renatu = false;
        bool Music_Agustinho = false;
        bool Music_Cleito = false;
        bool Music_LouisCarlos = false;

        //Fecha o formulario jogo se for pedido para que o faça
        static public bool thisKILL = false;
        #endregion
        #region pisos do jogo
        //pisos
        private void YellowT(int Line)
        {
            //Se o controle de chãos do lado direito tiver um determinado valor e a ultima tecla a ter sido pressionada for a Direita, um chão será colocado.
            if (PLAYERpos == (TileControl) && UltimaTecla == MainMenu.Esquerda)
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = YellowTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = -100;
                NewTile.MinimumSize = new Size(2, 0);
                this.Controls.Add(NewTile);
            }
            //Se o controle de chãos do lado esquerdo tiver um determinado valor e a ultima tecla a ter sido pressionada for a Esquerda, um chão será colocado.
            else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = YellowTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = 900;
                NewTile.MinimumSize = new Size(2, 0);
                this.Controls.Add(NewTile);
            }
            //Verifica se a primeira declaração para a fase foi feita, para caso de load, nova fase ou inicio do game

            else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = YellowTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = -100 + TileControl;
                NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                this.Controls.Add(NewTile);
            }
        }
        private void GrayT(int Line)
        {
            //Se o controle de chãos do lado direito tiver um determinado valor e a ultima tecla a ter sido pressionada for a Direita, um chão será colocado.
            if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = GrayTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = -100;
                NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                this.Controls.Add(NewTile);
            }
            //Se o controle de chãos do lado esquerdo tiver um determinado valor e a ultima tecla a ter sido pressionada for a Esquerda, um chão será colocado.
            else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = GrayTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = 900;
                NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                this.Controls.Add(NewTile);
            }

            else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = GrayTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = -100 + TileControl;
                NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                this.Controls.Add(NewTile);
            }
        }
        private void GreenT(int Line)
        {
            //Se o controle de chãos do lado direito tiver um determinado valor e a ultima tecla a ter sido pressionada for a Direita, um chão será colocado.
            if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = GreenTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = -100;
                NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                this.Controls.Add(NewTile);
            }
            //Se o controle de chãos do lado esquerdo tiver um determinado valor e a ultima tecla a ter sido pressionada for a Esquerda, um chão será colocado.
            else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = GreenTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = 900;
                NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                this.Controls.Add(NewTile);
            }

            else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
            {
                PictureBox NewTile = new PictureBox();
                NewTile.InitialImage = IMA_Tile;
                NewTile.BackColor = Color.Orange;
                NewTile.Image = GreenTile;
                NewTile.Height = 60;
                NewTile.Width = 60;
                NewTile.Top = Line;
                NewTile.Left = -100 + TileControl;
                NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                this.Controls.Add(NewTile);
            }
        }

        //Nova coluna eburacos
        private void NovaColuna()
        {
            /*Essa rotina foi criada em maior parte por uma questão de estética da declaração da fase;
             * Ela é usada para saber quando o programador acabou de fazer a coluna e quer partir para outra;
             * Duas vezes seguidas esse comando é criado um buraco, três vezes, dois buracos e assim em diante*/
            TileControl = TileControl + 60;
        }
        #endregion
        #region Caixas e items do jogo
        //Adiciona 0,7 pontos
        private void CD(int Line)
        {
            //Se SituacaoDOSitems[Fui_pego] for igual a zero, será criada uma caixa com um item dentro, pois o usuário ainda não a quebrou
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                //Se o controle de chãos do lado direito tiver um determinado valor e a ultima tecla a ter sido pressionada for a Direita, um chão será colocado.
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_CdBox;
                    NewTile.BackColor = Color.Lime;
                    NewTile.Image = CDbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
                //Se o controle de chãos do lado esquerdo tiver um determinado valor e a ultima tecla a ter sido pressionada for a Esquerda, um chão será colocado.
                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_CdBox;
                    NewTile.BackColor = Color.Lime;
                    NewTile.Image = CDbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_CdBox;
                    NewTile.BackColor = Color.Lime;
                    NewTile.Image = CDbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            //Se SituacaoDOSitems[Fui_pego] for igual a um, um cd é criado, pois o usuário quebrou a caixa
            else if (SituacaoDOSitems[Fui_pego] == 1)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_CdItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = CDitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
                //Se o controle de chãos do lado esquerdo tiver um determinado valor e a ultima tecla a ter sido pressionada for a Esquerda, um chão será colocado.
                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_CdItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = CDitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_CdItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = CDitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            Fui_pego++;
        }

        //Adiciona 4,7 pontos
        private void DVD(int Line)
        {
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                if (PLAYERpos == (TileControl) && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_DvdBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = DVDbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_DvdBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = DVDbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_DvdBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = DVDbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            else if (SituacaoDOSitems[Fui_pego] == 1)
            {

                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_DvdItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = DVDitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_DvdItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = DVDitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_DvdItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = DVDitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            Fui_pego++;
        }

        //Adiciona pontos que podem variar de 1, 2, 4 ou 8.
        private void PEN(int Line)
        {
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            else if (SituacaoDOSitems[Fui_pego] == 1)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            Fui_pego++;
        }

        //Protege o jogador de qualquer inimigo com exceção de chefes e buracos
        private void FW(int Line)
        {
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_FwBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = FWbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_FwBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = FWbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_FwBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = FWbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }

            else if (SituacaoDOSitems[Fui_pego] == 1)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_FwItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = FWitem_SPR1;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_FwItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = FWitem_SPR2;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_FwItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = FWitem_SPR2;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            Fui_pego++;
        }

        //Adiciona uma vida
        private void LIFE(int Line)
        {
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_LifeBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = LIFEbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_LifeBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = LIFEbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_LifeBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = LIFEbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            else if (SituacaoDOSitems[Fui_pego] == 1)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_LifeItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = LIFEitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    this.Controls.Add(NewTile);

                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_LifeItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = LIFEitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_LifeItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = LIFEitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            else if (SituacaoDOSitems[Fui_pego] == 2)
            {
            }
            //Se já tiver pego a caixa de vida e morrer depois disso, ao reiniciar as caixas, ela volta como uma caixa de pendrive
            else if (SituacaoDOSitems[Fui_pego] == 3)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }

            else if (SituacaoDOSitems[Fui_pego] == 4)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_PenItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = PENitem;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            Fui_pego++;
        }

        //Reenche a vida
        private void STAR(int Line)
        {
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_StarBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = STARbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_StarBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = STARbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_StarBox;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = STARbox;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            else if (SituacaoDOSitems[Fui_pego] == 1)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_StarItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = STARitem_SPR1;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_StarItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = STARitem_SPR1;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);

                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = IMA_StarItem;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Image = STARitem_SPR1;
                    NewTile.Height = 60;
                    NewTile.Width = 60;
                    NewTile.Top = Line;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
            Fui_pego++;
        }

        #endregion
        #region Inimigos
        private void BadGuy(int Line)
        {
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 74;
                    NewTile.Width = 46;
                    NewTile.Top = Line - 14;
                    NewTile.Enabled = false; // Vai analisar se a direção que o monstro deve seguir já foi selecionada
                    NewTile.WaitOnLoad = true; // Verifica se o monstro esta caindo ou não
                    NewTile.Image = BadGuy_ESQ1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_BadGuy;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new Size(2, 0);
                    NewTile.MaximumSize = new Size(990, 990);
                    this.Controls.Add(NewTile);
                }
                //Se o controle de chãos do lado esquerdo tiver um determinado valor e a ultima tecla a ter sido pressionada for a Esquerda, um chão será colocado.
                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 74;
                    NewTile.Width = 46;
                    NewTile.Top = Line - 14;
                    NewTile.Enabled = false;
                    NewTile.WaitOnLoad = true;
                    NewTile.Image = BadGuy_ESQ1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_BadGuy;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new Size(2, 0);
                    NewTile.MaximumSize = new Size(990, 990);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 74;
                    NewTile.Width = 46;
                    NewTile.Top = Line - 14;
                    NewTile.Enabled = false;
                    NewTile.WaitOnLoad = true;
                    NewTile.Image = BadGuy_ESQ1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_BadGuy;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new Size(2, 0);
                    NewTile.MaximumSize = new Size(990, 990);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void Daivison(int Line)
        {
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 90;
                    NewTile.Width = 49;
                    NewTile.Top = Line - 30;
                    NewTile.Enabled = false;
                    NewTile.WaitOnLoad = true;
                    NewTile.Image = Daivison1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_Daivison;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new Size(2, 0);
                    this.Controls.Add(NewTile);
                }
                //Se o controle de chãos do lado esquerdo tiver um determinado valor e a ultima tecla a ter sido pressionada for a Esquerda, um chão será colocado.
                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 90;
                    NewTile.Width = 49;
                    NewTile.Top = Line - 30;
                    NewTile.Enabled = false;
                    NewTile.WaitOnLoad = true;
                    NewTile.Image = Daivison1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_Daivison;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 90;
                    NewTile.Width = 49;
                    NewTile.Top = Line - 30;
                    NewTile.Enabled = false;
                    NewTile.WaitOnLoad = true;
                    NewTile.Image = Daivison1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_Daivison;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void Erwin(int Line)
        {
            if (SituacaoDOSitems[Fui_pego] == 0)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 90;
                    NewTile.Width = 49;
                    NewTile.Top = Line - 30;
                    NewTile.Enabled = false;
                    NewTile.WaitOnLoad = true;
                    NewTile.Image = Ervin1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_Erwin;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new Size(2, 0);
                    NewTile.MaximumSize = new Size(990, 990);
                    this.Controls.Add(NewTile);
                }
                //Se o controle de chãos do lado esquerdo tiver um determinado valor e a ultima tecla a ter sido pressionada for a Esquerda, um chão será colocado.
                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 90;
                    NewTile.Width = 49;
                    NewTile.Top = Line - 30;
                    NewTile.Enabled = false;
                    NewTile.WaitOnLoad = true;
                    NewTile.Image = Ervin1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_Erwin;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new Size(2, 0);
                    NewTile.MaximumSize = new Size(990, 990);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.Name = Fui_pego.ToString();
                    NewTile.InitialImage = BOOT;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.Height = 90;
                    NewTile.Width = 49;
                    NewTile.Top = Line - 30;
                    NewTile.Enabled = false;
                    NewTile.WaitOnLoad = true;
                    NewTile.Image = Ervin1;
                    NewTile.AccessibleDescription = "ESQUERDA";
                    NewTile.ErrorImage = IMA_Erwin;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new Size(2, 0);
                    NewTile.MaximumSize = new Size(990, 990);
                    this.Controls.Add(NewTile);
                }
            }
        }
        #endregion
        #region Amigos e Chefes
        //Modulo 1
        private void Roza(int Line)
        {
            if (RozaTalk == false)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Roza;
                    NewTile.BackgroundImageLayout = ImageLayout.Center;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Roza1;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 81;
                    NewTile.Width = 33;
                    NewTile.Top = Line - 21;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Roza;
                    NewTile.BackgroundImageLayout = ImageLayout.Center;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Roza1;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 81;
                    NewTile.Width = 33;
                    NewTile.Top = Line - 21;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Roza;
                    NewTile.BackgroundImageLayout = ImageLayout.Center;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Roza1;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 81;
                    NewTile.Width = 33;
                    NewTile.Top = Line - 21;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void MarceluI(int Line)
        {
            if (MarceluTalk == false)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Marcelu_Friend;
                    NewTile.AccessibleName = "0";
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = MarceluOE;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 116;
                    NewTile.Width = 30;
                    NewTile.Top = Line - 56;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Marcelu_Friend;
                    NewTile.AccessibleName = "0";
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = MarceluOE;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 116;
                    NewTile.Width = 30;
                    NewTile.Top = Line - 56;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Marcelu_Friend;
                    NewTile.AccessibleName = "0";
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = MarceluOE;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 116;
                    NewTile.Width = 30;
                    NewTile.Top = Line - 56;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void MarceluII(int Line)
        {
            if (MarceluFight == false)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Marcelu_Boss;
                    NewTile.AccessibleName = "0";
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = MarceluOE;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 116;
                    NewTile.Width = 30;
                    NewTile.Top = Line - 56;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Marcelu_Boss;
                    NewTile.AccessibleName = "0";
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = MarceluOE;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 116;
                    NewTile.Width = 30;
                    NewTile.Top = Line - 56;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Marcelu_Boss;
                    NewTile.AccessibleName = "0";
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = MarceluOE;
                    NewTile.BackgroundImageLayout = ImageLayout.Stretch;
                    NewTile.Height = 116;
                    NewTile.Width = 30;
                    NewTile.Top = Line - 56;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void Muacir(int Line)
        {
            if (MuacirFight == false)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Muacir;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Muacir1;
                    NewTile.Height = 169;
                    NewTile.Width = 79;
                    NewTile.Top = Line - 109;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Muacir;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Muacir1;
                    NewTile.Height = 169;
                    NewTile.Width = 79;
                    NewTile.Top = Line - 109;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Muacir;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Muacir1;
                    NewTile.Height = 169;
                    NewTile.Width = 79;
                    NewTile.Top = Line - 109;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void Renatu(int Line)
        {
            if (RenatuTalk == false)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Renatu;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = RenatuIMG;
                    NewTile.Height = 128;
                    NewTile.Width = 37;
                    NewTile.Top = Line - 68;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Renatu;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = RenatuIMG;
                    NewTile.Height = 128;
                    NewTile.Width = 37;
                    NewTile.Top = Line - 68;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Renatu;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = RenatuIMG;
                    NewTile.Height = 128;
                    NewTile.Width = 37;
                    NewTile.Top = Line - 68;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void Agustinho(int Line)
        {
            if (AgustinhoFight == false)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.AccessibleName = "0";
                    NewTile.InitialImage = IMA_Agustinho;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Agustinho_01;
                    NewTile.Height = 374;
                    NewTile.Width = 215;
                    NewTile.Top = Line - 310;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.AccessibleName = "0";
                    NewTile.InitialImage = IMA_Agustinho;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Agustinho_01;
                    NewTile.Height = 374;
                    NewTile.Width = 215;
                    NewTile.Top = Line - 310;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.AccessibleName = "0";
                    NewTile.InitialImage = IMA_Agustinho;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = Agustinho_01;
                    NewTile.Height = 374;
                    NewTile.Width = 215;
                    NewTile.Top = Line - 310;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void Cleito(int Line)
        {
            if (CleitoTalk == false)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Cleito;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = CleitoIMG;
                    NewTile.Height = 146;
                    NewTile.Width = 44;
                    NewTile.Top = Line - 86;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Cleito;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = CleitoIMG;
                    NewTile.Height = 146;
                    NewTile.Width = 44;
                    NewTile.Top = Line - 86;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_Cleito;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = CleitoIMG;
                    NewTile.Height = 146;
                    NewTile.Width = 44;
                    NewTile.Top = Line - 86;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }

        private void LouisCarlos(int Line)
        {
            if (CleitoTalk == false)
            {
                if (PLAYERpos == TileControl && UltimaTecla == MainMenu.Esquerda)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_LouisCarlos;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = LouisCarlosIMG;
                    NewTile.Height = 99;
                    NewTile.Width = 29;
                    NewTile.Top = Line - 39;
                    NewTile.Left = -100;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (PLAYERpos == (TileControl - 1000) && UltimaTecla == MainMenu.Direita)
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_LouisCarlos;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = LouisCarlosIMG;
                    NewTile.Height = 99;
                    NewTile.Width = 29;
                    NewTile.Top = Line - 39;
                    NewTile.Left = 900;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }

                else if (FirstDeclaration == false && PLAYERpos < TileControl && PLAYERpos > (TileControl - 1000))
                {
                    PictureBox NewTile = new PictureBox();
                    NewTile.InitialImage = IMA_LouisCarlos;
                    NewTile.BackColor = Color.Transparent;
                    NewTile.BackgroundImage = LouisCarlosIMG;
                    NewTile.Height = 99;
                    NewTile.Width = 29;
                    NewTile.Top = Line - 39;
                    NewTile.Left = -100 + TileControl;
                    NewTile.MinimumSize = new System.Drawing.Size(2, 0);
                    this.Controls.Add(NewTile);
                }
            }
        }
        #endregion
        #region Rotinas de animações
        private void Animation()
        {
            if (UltimaTecla == MainMenu.Direita)
            {
                if (IsFW == false)
                {
                    if (COD_AnimationValue == 1)
                    {
                        IMG_AnimationValue = Etequer1_DIR;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 2)
                    {
                        IMG_AnimationValue = Etequer2_DIR;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 3)
                    {
                        IMG_AnimationValue = Etequer3_DIR;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 4)
                    {
                        IMG_AnimationValue = Etequer2_DIR;
                        COD_AnimationValue = 1;
                    }
                }

                else if (IsFW == true)
                {
                    if (COD_AnimationValue == 1)
                    {
                        IMG_AnimationValue = FW_Etequer1_DIR;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 2)
                    {
                        IMG_AnimationValue = FW_Etequer2_DIR;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 3)
                    {
                        IMG_AnimationValue = FW_Etequer3_DIR;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 4)
                    {
                        IMG_AnimationValue = FW_Etequer2_DIR;
                        COD_AnimationValue = 1;
                    }
                }
            }

            else if (UltimaTecla == MainMenu.Esquerda)
            {
                if (IsFW == false)
                {
                    if (COD_AnimationValue == 1)
                    {
                        IMG_AnimationValue = Etequer1_ESQ;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 2)
                    {
                        IMG_AnimationValue = Etequer2_ESQ;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 3)
                    {
                        IMG_AnimationValue = Etequer3_ESQ;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 4)
                    {
                        IMG_AnimationValue = Etequer2_ESQ;
                        COD_AnimationValue = 1;
                    }
                }

                else if (IsFW == true)
                {
                    if (COD_AnimationValue == 1)
                    {
                        IMG_AnimationValue = FW_Etequer1_ESQ;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 2)
                    {
                        IMG_AnimationValue = FW_Etequer2_ESQ;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 3)
                    {
                        IMG_AnimationValue = FW_Etequer3_ESQ;
                        COD_AnimationValue++;
                    }
                    else if (COD_AnimationValue == 4)
                    {
                        IMG_AnimationValue = FW_Etequer2_ESQ;
                        COD_AnimationValue = 1;
                    }
                }
            }
        }

        private void OpenBOXanimation_CD()
        {
            if (CDcount == 0)
            {
                Broke.Play();

                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 1)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 2)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 3)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 4)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 5)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 6)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 7)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 8)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 9)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 10)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 11)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 12)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 13)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 14)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }

            else if (CDcount == 15)
            {
                CDanimage = CDani[CDcount];
                CDcount++;
            }
        }

        private void OpenBOXanimation_DVD()
        {
            if (DVDcount == 0)
            {
                Broke.Play();

                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 1)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 2)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 3)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 4)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 5)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 6)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 7)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 8)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 9)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 10)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 11)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 12)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 13)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 14)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }

            else if (DVDcount == 15)
            {
                DVDanimage = DVDani[DVDcount];
                DVDcount++;
            }
        }

        private void OpenBOXanimation_FW()
        {
            if (FWcount == 0)
            {
                Broke.Play();

                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 1)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 2)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 3)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 4)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 5)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 6)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 7)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 8)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 9)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 10)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 11)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 12)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 13)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 14)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }

            else if (FWcount == 15)
            {
                FWanimage = FWani[FWcount];
                FWcount++;
            }
        }

        private void OpenBOXanimation_LIFE()
        {
            if (LIFEcount == 0)
            {
                Broke.Play();

                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 1)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 2)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 3)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 4)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 5)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 6)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 7)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 8)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 9)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 10)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 11)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 12)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 13)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 14)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }

            else if (LIFEcount == 15)
            {
                LIFEanimage = LIFEani[LIFEcount];
                LIFEcount++;
            }
        }

        private void OpenBOXanimation_PEN()
        {
            if (PENcount == 0)
            {
                Broke.Play();

                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 1)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 2)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 3)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 4)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 5)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 6)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 7)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 8)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 9)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 10)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 11)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 12)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 13)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 14)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }

            else if (PENcount == 15)
            {
                PENanimage = PENani[PENcount];
                PENcount++;
            }
        }

        private void OpenBOXanimation_STAR()
        {
            if (STARcount == 0)
            {
                Broke.Play();

                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 1)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 2)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 3)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 4)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 5)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 6)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 7)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 8)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 9)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 10)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 11)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 12)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 13)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 14)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }

            else if (STARcount == 15)
            {
                STARanimage = STARani[STARcount];
                STARcount++;
            }
        }
        #endregion
        #region Outras rotinas
        public Jogo()
        {
            InitializeComponent();
        }

        private void ConvertToIMG()
        {
            if (intTOstring == "0")
            {
                stringTOimg = Zero;
            }
            else if (intTOstring == "1")
            {
                stringTOimg = Um;
            }
            else if (intTOstring == "2")
            {
                stringTOimg = Dois;
            }
            else if (intTOstring == "3")
            {
                stringTOimg = Tres;
            }
            else if (intTOstring == "4")
            {
                stringTOimg = Quatro;
            }
            else if (intTOstring == "5")
            {
                stringTOimg = Cinco;
            }
            else if (intTOstring == "6")
            {
                stringTOimg = Seis;
            }
            else if (intTOstring == "7")
            {
                stringTOimg = Sete;
            }
            else if (intTOstring == "8")
            {
                stringTOimg = Oito;
            }
            else if (intTOstring == "9")
            {
                stringTOimg = Nove;
            }
        }

        private void Caindo()
        {
            //Essa rotina esta sempre ativa, com excessão de quando o personagem esta pulando
            if (Subindo_PULO == false)
            {
                foreach (object OBJ in this.Controls)
                {
                    if (OBJ is PictureBox)
                    {
                        PictureBox GameThing = OBJ as PictureBox;
                        if (GameThing.MinimumSize.Width == 2)
                        {
                            if ((ETEQUER.Top + ETEQUER.Height) <= (GameThing.Top) && (ETEQUER.Top + ETEQUER.Height) >= (GameThing.Top - ControlPanel.VELOCIDADE) && (ETEQUER.Left >= GameThing.Left && ETEQUER.Left <= (GameThing.Left + GameThing.Width)) || (ETEQUER.Top + ETEQUER.Height) <= (GameThing.Top) && (ETEQUER.Top + ETEQUER.Height) >= (GameThing.Top - ControlPanel.VELOCIDADE) && ETEQUER.Left <= GameThing.Left && (ETEQUER.Left + ETEQUER.Width) >= GameThing.Left)
                            {
                                ETEQUER.Top = GameThing.Top - ETEQUER.Height;
                               ETEQUER.Update();
                                if (GameThing.InitialImage == IMA_Tile)
                                {
                                    //Se o item em que o jogador cair for um chão ele simplesmente para.
                                }

                                else if (GameThing.InitialImage == IMA_CdBox)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 1;
                                    GameThing.MaximumSize = new System.Drawing.Size(998, 998);
                                    GameThing.InitialImage = IMA_CdItem;
                                    GameThing.Image = null;
                                    if (IsFW == false)
                                    {
                                        Subindo_PULO = true;
                                    }

                                    else if (IsFW == true)
                                    {
                                    }
                                }

                                else if (GameThing.InitialImage == IMA_DvdBox)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 1;
                                    GameThing.MaximumSize = new Size(998, 998);
                                    GameThing.InitialImage = IMA_DvdItem;
                                    GameThing.Image = null;
                                    if (IsFW == false)
                                    {
                                        Subindo_PULO = true;
                                    }

                                    else if (IsFW == true)
                                    {
                                    }
                                }

                                else if (GameThing.InitialImage == IMA_FwBox)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 1;
                                    GameThing.MaximumSize = new Size(998, 998);
                                    GameThing.InitialImage = IMA_FwItem;
                                    GameThing.Image = null;

                                    if (IsFW == false)
                                    {
                                        Subindo_PULO = true;
                                    }

                                    else if (IsFW == true)
                                    {
                                    }
                                }

                                else if (GameThing.InitialImage == IMA_LifeBox)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 1;
                                    GameThing.MaximumSize = new Size(998, 998);
                                    GameThing.InitialImage = IMA_LifeItem;
                                    GameThing.Image = null;

                                    if (IsFW == false)
                                    {
                                        Subindo_PULO = true;
                                    }

                                    else if (IsFW == true)
                                    {
                                    }
                                }

                                else if (GameThing.InitialImage == IMA_PenBox)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 1;
                                    GameThing.MaximumSize = new Size(998, 998);
                                    GameThing.InitialImage = IMA_PenItem;
                                    GameThing.Image = null;
                                    if (IsFW == false)
                                    {
                                        Subindo_PULO = true;
                                    }

                                    else if (IsFW == true)
                                    {
                                    }
                                }

                                else if (GameThing.InitialImage == IMA_StarBox)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 1;
                                    GameThing.MaximumSize = new System.Drawing.Size(998, 998);
                                    GameThing.InitialImage = IMA_StarItem;
                                    GameThing.Image = null;
                                    if (IsFW == false)
                                    {
                                        Subindo_PULO = true;
                                    }

                                    else if (IsFW == true)
                                    {
                                    }
                                }

                                else if (GameThing.InitialImage == BOOT)
                                {
                                    Controls.Remove(GameThing);
                                    BOOTs(GameThing.ErrorImage, true);
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 1;
                                    
                                }

                                else if (GameThing.InitialImage == IMA_CdItem || GameThing.InitialImage == IMA_DvdItem || GameThing.InitialImage == IMA_FwItem || GameThing.InitialImage == IMA_LifeItem || GameThing.InitialImage == IMA_PenItem || GameThing.InitialImage == IMA_StarItem)
                                {
                                    ETEQUER.Top += ControlPanel.VELOCIDADE;
                                    ETEQUER.Update();
                                }
                                HaveOneUnderMe = true;
                                Air_pos = 0;
                            }
                        }
                    }
                }

                if (HaveOneUnderMe == false)
                {
                    ETEQUER.Top += ControlPanel.VELOCIDADE;
                    ETEQUER.Update();
                }
                else
                {
                    HaveOneUnderMe = false;
                }
            }
        }

        private void Caindo_Enemy()
        {
            #region CAINDO
            /*ATRIBUTOS USADOS
              * Nome        ||      Tipo        ||      Como
              * WaitOnLoad  ||      Boolean     ||  Verifica se há algo embaixo dele
 */

            foreach (object OBJ1 in this.Controls)
            {
                if (OBJ1 is PictureBox)
                {
                    PictureBox FALLER = OBJ1 as PictureBox;
                    if (FALLER.WaitOnLoad == true)
                    {
                        foreach (object OBJ2 in this.Controls)
                        {
                            if (OBJ1 is PictureBox && OBJ2 is PictureBox)
                            {
                                PictureBox GameThing = OBJ2 as PictureBox;
                                if (GameThing.MinimumSize.Width == 2 && FALLER.InitialImage == BOOT) // Verifica se encontrou no foreach um "caidor" e um "chão"
                                {
                                    if (FALLER.Left <= GameThing.Left && GameThing.Left <= (FALLER.Left + FALLER.Width) || FALLER.Left <= (GameThing.Left + GameThing.Width) && (GameThing.Left + GameThing.Width) <= (FALLER.Left + FALLER.Width) || GameThing.Left < FALLER.Left && (FALLER.Left + FALLER.Width) < (GameThing.Left + GameThing.Width))
                                    {
                                        if (FALLER.Top + FALLER.Height < GameThing.Top && FALLER.Top + FALLER.Height + ControlPanel.VELOCIDADE >= GameThing.Top || FALLER.Top == GameThing.Top - FALLER.Height)
                                        {
                                            FALLER.Top = GameThing.Top - FALLER.Height;
                                            FALLER.WaitOnLoad = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (object OBJ in this.Controls)
            {
                if (OBJ is PictureBox)
                {
                    PictureBox FALLER = OBJ as PictureBox;
                    if (FALLER.InitialImage == BOOT)
                    {
                        if (FALLER.WaitOnLoad == true)
                        {
                            FALLER.Top += ControlPanel.VELOCIDADE;
                        }
                        else
                        {
                            FALLER.WaitOnLoad = true;
                        }
                    }
                }
            }
            #endregion
        }

        private void Pulando()
        {
            Air_pos++;
            if (Air_pos < Hpulo)
            {
                ETEQUER.Top -= ControlPanel.VELOCIDADE;
                ETEQUER.Update();
            }
            else if (Air_pos >= Hpulo)
            {
                Subindo_PULO = false;
                Caindo();
            }
        }

        private void Mensagem()
        {
            if (AVISO.Visible == false)
            {
                AvatarPlace.Left = 2;
                AvatarPlace.Top = 84;
                TextPlace.Left = 83;
                TextPlace.Top = 77;
                AVISO.Visible = true;
                Text1.Visible = true;
                Text2.Visible = true;
                Text3.Visible = true;
                TextPlace.Visible = true;
                AvatarPlace.Visible = true;
                Text1.BringToFront();
                Text2.BringToFront();
                Text3.BringToFront();
            }
            else if (AVISO.Visible == true)
            {
                AvatarPlace.Top = -1084;
                TextPlace.Top = -1077;
                AVISO.Visible = false;
                Text1.Visible = false;
                Text2.Visible = false;
                Text3.Visible = false;
                TextPlace.Visible = false;
                AvatarPlace.Visible = false;
            }
        }

        private void MusicFALSE()
        {
            Music_Game = false;
            Music_roza = false;
            Music_Marcelu = false;
            Music_Muacir = false;
            Music_Renatu = false;
            Music_Agustinho = false;
            Music_Cleito = false;
            Music_LouisCarlos = false;
        }

        private void NOmusic()
        {
            ThemePlayer.Ctlcontrols.stop();
            ThemePlayer_ROZA.Ctlcontrols.stop();
            ThemePlayer_MARCELU.Ctlcontrols.stop();
            ThemePlayer_MUACIR.Ctlcontrols.stop();
            ThemePlayer_RENATU.Ctlcontrols.stop();
            ThemePlayer_AGUSTINHO.Ctlcontrols.stop();
            ThemePlayer_CLEITO.Ctlcontrols.stop();
            ThemePlayer_LC.Ctlcontrols.stop();
        }

        private void BOOTs(Image ERRORimg, bool KILLit)
        {
            if (KILLit == false)
            {
                if (ERRORimg == IMA_BadGuy)
                {
                    Porcent_of_Life -= 3;
                }

                else if (ERRORimg == IMA_Daivison)
                {
                    Porcent_of_Life -= 6;
                }

                else if (ERRORimg == IMA_Erwin)
                {
                    Porcent_of_Life -= 9;
                }
            }
            else if (KILLit == true)
            {
                if (ERRORimg == IMA_BadGuy)
                {
                    Pulando();
                    //Favorecimento ao jogador
                    GB_points = GB_points + 0.1;

                    //Animando o ganho
                    Label POINTS = new Label();
                    POINTS.Enabled = false;
                    POINTS.TabIndex = 0;
                    POINTS.Text = "+ 0.1 GB!";
                    POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    POINTS.Left = 175;
                    POINTS.Top = ETEQUER.Top - 5;
                    POINTS.SendToBack();
                    this.Controls.Add(POINTS);
                }

                else if (ERRORimg == IMA_Daivison)
                {
                    Pulando();

                    GB_points = GB_points + 0.3;

                    Label POINTS = new Label();
                    POINTS.Enabled = false;
                    POINTS.TabIndex = 0;
                    POINTS.Text = "+ 0.3 GB!";
                    POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    POINTS.Left = 175;
                    POINTS.Top = ETEQUER.Top - 5;
                    POINTS.SendToBack();
                    this.Controls.Add(POINTS);
                }

                else if (ERRORimg == IMA_Erwin)
                {
                    Pulando();

                    GB_points = GB_points + 0.5;

                    Label POINTS = new Label();
                    POINTS.Enabled = false;
                    POINTS.TabIndex = 0;
                    POINTS.Text = "+ 0.5 GB!";
                    POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    POINTS.Left = 175;
                    POINTS.Top = ETEQUER.Top - 5;
                    POINTS.SendToBack();
                    this.Controls.Add(POINTS);
                }
            }
        }

        private void Morreu()
        {
            Vidas -= 1;
        }

        private void SOMETUDO()
        {
            foreach (object TODOSobj in this.Controls)
            {
                if (TODOSobj is PictureBox)
                {
                    PictureBox TODASpic = TODOSobj as PictureBox;
                    if (TODASpic.MinimumSize.Width == 2)
                    {
                        Controls.Remove(TODASpic);
                    }
                }
            }

            foreach (object TODOSobj in this.Controls)
            {
                if (TODOSobj is PictureBox)
                {
                    PictureBox TODASpic = TODOSobj as PictureBox;
                    if (TODASpic.MinimumSize.Width == 2)
                    {
                        Controls.Remove(TODASpic);
                    }
                }
            }

            foreach (object TODOSobj in this.Controls)
            {
                if (TODOSobj is PictureBox)
                {
                    PictureBox TODASpic = TODOSobj as PictureBox;
                    if (TODASpic.MinimumSize.Width == 2)
                    {
                        Controls.Remove(TODASpic);
                    }
                }
            }

            foreach (object TODOSobj in this.Controls)
            {
                if (TODOSobj is PictureBox)
                {
                    PictureBox TODASpic = TODOSobj as PictureBox;
                    if (TODASpic.MinimumSize.Width == 2)
                    {
                        Controls.Remove(TODASpic);
                    }
                }
            }

            foreach (object TODOSobj in this.Controls)
            {
                if (TODOSobj is PictureBox)
                {
                    PictureBox TODASpic = TODOSobj as PictureBox;
                    if (TODASpic.MinimumSize.Width == 2)
                    {
                        Controls.Remove(TODASpic);
                    }
                }
            }

            foreach (object TODOSobj in this.Controls)
            {
                if (TODOSobj is PictureBox)
                {
                    PictureBox TODASpic = TODOSobj as PictureBox;
                    if (TODASpic.MinimumSize.Width == 2)
                    {
                        Controls.Remove(TODASpic);
                    }
                }
            }
        }
        #endregion

        private void Jogo_Load(object sender, EventArgs e)
        {
            #region Organização geral
            //Tira a musica do MainMenu
            MainMenu.STOPmusic = true;

            //Avisando que o jogador não fez nada, não falou com ninguém nem lutou com ninguém
            RozaTalk = false;
            MarceluTalk = false;
            MarceluFight = false;
            MuacirFight = false;
            RenatuTalk = false;
            AgustinhoFight = false;
            CleitoTalk = false;
            LCFight = false;

            //Pega alguns atributos do botão de sida para enviar para o Painel de controle, isso serve para o Painel de controle saber onde deve ser clicado para sair do jogo
            ExitButton_height = ExitButton.Height;
            ExitButton_width = ExitButton.Width;
            ExitButton_left = ExitButton.Left;
            ExitButton_top = ExitButton.Top;

            //Coloca a imagem que fica do lado dos pontos de vida
            LifesFace.Image = HeadOfLives;

            //Coloca a imagem já carregada no botão de saida
            ExitButton.Image = MainMenu.IMG_ExitButton_normal;

            //Coloca as imagens na barra de vida
            LifeBAR.BackgroundImage = LifeBAR_IMG;
            LifeBar_BAckGround.BackgroundImage = LifeBAR_IMG_bg;

            //Coloca o grafico no personagem
            ETEQUER.BackgroundImage = Etequer2_DIR;

            //Colocando as imagens dfe pergaminho na picturebox de conversa
            TextPlace.Image = Pergaminho;
            Text1.Image = textoA;
            Text2.Image = textoB;
            Text3.Image = textoC;

            //Ativa o updater
            Updater.Enabled = true;

            //Carrega musica
            GAME_music = ThemePlayer.newMedia("Grafico\\Themes\\Game_Theme.mp3");
            ThemePlayer.currentPlaylist.appendItem(GAME_music);

            ROZA_music = ThemePlayer_ROZA.newMedia("Grafico\\Themes\\Roza_thm.mp3");
            ThemePlayer_ROZA.currentPlaylist.appendItem(ROZA_music);

            MARCELU_music = ThemePlayer_MARCELU.newMedia("Grafico\\Themes\\Marcelu_thm.mp3");
            ThemePlayer_MARCELU.currentPlaylist.appendItem(MARCELU_music);

            MUACIR_music = ThemePlayer_MUACIR.newMedia("Grafico\\Themes\\Muacir_thm.mp3");
            ThemePlayer_MUACIR.currentPlaylist.appendItem(MUACIR_music);

            RENATU_music = ThemePlayer_RENATU.newMedia("Grafico\\Themes\\Renatu_thm.mp3");
            ThemePlayer_RENATU.currentPlaylist.appendItem(RENATU_music);

            AGUSTINHO_music = ThemePlayer_AGUSTINHO.newMedia("Grafico\\Themes\\Agustinho_thm.mp3");
            ThemePlayer_AGUSTINHO.currentPlaylist.appendItem(AGUSTINHO_music);

            CLEITO_music = ThemePlayer_CLEITO.newMedia("Grafico\\Themes\\Cleito_thm.mp3");
            ThemePlayer_CLEITO.currentPlaylist.appendItem(CLEITO_music);

            LC_music = ThemePlayer_LC.newMedia("Grafico\\Themes\\Louis Carlos_thm.mp3");
            ThemePlayer_LC.currentPlaylist.appendItem(LC_music);
            #endregion
        }

        private void Jogo_KeyDown(object sender, KeyEventArgs e)
        {
            #region encerra toda aplicação no apertar de Alt + F4
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                Application.Exit();
            }
            #endregion
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            #region Análise de erros do aplicativo
            //Verifica se os formularios estão alinhados
            IAmStarted = true;
            ThisCheckLeft = this.Left;
            ThisCheckTop = this.Top;

            if (Jogo.IAmStarted == true && Fundo.IAmStarted == true && ControlPanel.IAmStarted == true)
            {
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
            #region verifica se o mouse está em cima do botão de saida
            //verifica se o mouse esta em cima do botão de saida para poder dizer qual é a imagem que deve ser usada.
            if (ControlPanel.MouseLeft >= (ExitButton_left) && ControlPanel.MouseLeft <= (ExitButton_left + ExitButton_width) && ControlPanel.MouseTop >= (ExitButton_top) && ControlPanel.MouseTop <= (ExitButton_top + ExitButton_height))
            {
                ExitButton.Image = MainMenu.IMG_ExitButton_hover;
            }
            else
            {
                ExitButton.Image = MainMenu.IMG_ExitButton_normal;
            }
            #endregion
            #region Mostra o numero de vidas
            if (Vidas <= 9)
            {
                SubVida1 = "0";
                SubVida2 = Vidas.ToString();
            }
            else
            {
                SubVida1 = Vidas.ToString().Substring(0, 1);
                SubVida2 = Vidas.ToString().Substring(1, 1);
            }
            //Dezenas são mostradas
            intTOstring = SubVida1;
            ConvertToIMG();
            Dezes.Image = stringTOimg;
            Dezes.Update();

            //Unidades são mostradas
            intTOstring = SubVida2;
            ConvertToIMG();
            Unis.Image = stringTOimg;
            Unis.Update();

            #endregion
            #region Atualizando os pontos
            GIGA_PONTOS.Text = GB_points.ToString() + " GB";
            #endregion
            #region Atualizando a barra de vida
            if (LifeBAR.Enabled == false)
            {
                LifeBAR.Width = Porcent_of_Life * 5;
            }
            #endregion
            #region Fica invisivel quando é avisado para fazer isso
            if (this.Visible == true)
            {
                if (ControlPanel.JogoVisibleFALSE == true)
                {
                    this.Visible = false;
                }
            }
            if (this.Visible == false)
            {
                if (ControlPanel.JogoVisibleFALSE == false)
                {
                    this.Visible = true;
                }
            }
            #endregion
            #region Faz a musica do jogo tocar
            VideoOPEN = false;
            foreach (Form VideoPlayer in Application.OpenForms)
            {
                if (VideoPlayer is Videos)
                {
                    VideoOPEN = true;
                    NOmusic();
                }
            }

            if (VideoOPEN == false)
            {
                bool NoMusic = true;
                foreach (object OBJ in this.Controls)
                {
                    if (OBJ is PictureBox)
                    {
                        PictureBox PROF = OBJ as PictureBox;
                        if (PROF.InitialImage == IMA_Marcelu_Friend || PROF.InitialImage == IMA_Marcelu_Boss || PROF.InitialImage == IMA_Renatu || PROF.InitialImage == IMA_Agustinho || PROF.InitialImage == IMA_Roza || PROF.InitialImage == IMA_LouisCarlos || PROF.InitialImage == IMA_Cleito || PROF.InitialImage == IMA_Muacir)
                        {
                            NoMusic = false;
                        }
                    }
                }

                if (NoMusic == true)
                {
                    if (Music_Game == false)
                    {
                        NOmusic();
                        MusicFALSE();
                        Music_Game = true;
                        ThemePlayer.Ctlcontrols.play();
                        ThemePlayer.settings.setMode("Loop", true);
                        ThemePlayer.settings.volume = 100;
                    }
                }

                foreach (object OBJ in this.Controls)
                {
                    if (OBJ is PictureBox)
                    {
                        PictureBox PROF = OBJ as PictureBox;
                        if (PROF.InitialImage == IMA_Roza)
                        {
                            if (Music_roza == false)
                            {
                                if (ThemePlayer_ROZA.playState == WMPPlayState.wmppsPlaying)
                                {
                                }

                                else
                                {
                                    NOmusic();
                                    MusicFALSE();
                                    ThemePlayer_ROZA.Ctlcontrols.play();
                                    ThemePlayer_ROZA.settings.setMode("Loop", true);
                                    ThemePlayer_ROZA.settings.volume = 100;
                                }
                            }
                        }

                        else if (PROF.InitialImage == IMA_Marcelu_Friend || PROF.InitialImage == IMA_Marcelu_Boss)
                        {

                            if (Music_Marcelu == false)
                            {
                                if (ThemePlayer_MARCELU.playState == WMPPlayState.wmppsPlaying)
                                {
                                }

                                else
                                {
                                    NOmusic();
                                    MusicFALSE();
                                    ThemePlayer_MARCELU.Ctlcontrols.play();
                                    ThemePlayer_MARCELU.settings.setMode("Loop", true);
                                    ThemePlayer_MARCELU.settings.volume = 100;
                                }
                            }
                        }

                        else if (PROF.InitialImage == IMA_Muacir)
                        {

                            if (Music_Muacir == false)
                            {
                                if (ThemePlayer_MUACIR.playState == WMPPlayState.wmppsPlaying)
                                {
                                }

                                else
                                {
                                    NOmusic();
                                    MusicFALSE();
                                    ThemePlayer_MUACIR.Ctlcontrols.play();
                                    ThemePlayer_MUACIR.settings.setMode("Loop", true);
                                    ThemePlayer_MUACIR.settings.volume = 100;
                                }
                            }
                        }

                        else if (PROF.InitialImage == IMA_Renatu)
                        {

                            if (Music_Renatu == false)
                            {
                                if (ThemePlayer_RENATU.playState == WMPPlayState.wmppsPlaying)
                                {
                                }

                                else
                                {
                                    NOmusic();
                                    MusicFALSE();
                                    ThemePlayer_RENATU.Ctlcontrols.play();
                                    ThemePlayer_RENATU.settings.setMode("Loop", true);
                                    ThemePlayer_RENATU.settings.volume = 100;
                                }
                            }
                        }

                        else if (PROF.InitialImage == IMA_Agustinho)
                        {

                            if (Music_Agustinho == false)
                            {
                                if (ThemePlayer_AGUSTINHO.playState == WMPPlayState.wmppsPlaying)
                                {
                                }

                                else
                                {
                                    NOmusic();
                                    MusicFALSE();
                                    ThemePlayer_AGUSTINHO.Ctlcontrols.play();
                                    ThemePlayer_AGUSTINHO.settings.setMode("Loop", true);
                                    ThemePlayer_AGUSTINHO.settings.volume = 100;
                                }
                            }
                        }

                        else if (PROF.InitialImage == IMA_Cleito)
                        {

                            if (Music_Cleito == false)
                            {
                                if (ThemePlayer_CLEITO.playState == WMPPlayState.wmppsPlaying)
                                {
                                }

                                else
                                {
                                    NOmusic();
                                    MusicFALSE();
                                    ThemePlayer_CLEITO.Ctlcontrols.play();
                                    ThemePlayer_CLEITO.settings.setMode("Loop", true);
                                    ThemePlayer_CLEITO.settings.volume = 100;
                                }
                            }
                        }

                        else if (PROF.InitialImage == IMA_LouisCarlos)
                        {

                            if (Music_LouisCarlos == false)
                            {
                                if (ThemePlayer_LC.playState == WMPPlayState.wmppsPlaying)
                                {
                                }

                                else
                                {
                                    NOmusic();
                                    MusicFALSE();
                                    ThemePlayer_LC.Ctlcontrols.play();
                                    ThemePlayer_LC.settings.setMode("Loop", true);
                                    ThemePlayer_LC.settings.volume = 100;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Encerra este formulario se for pedido
            if (thisKILL == true)
            {
                this.Close();
            }
            #endregion
            #region Abrindo o Menu Pausa
            if (ControlPanel.CHEAT == true)
            {
                PauseMENU.Visible = true;
                PauseINFO.Visible = true;
                Punlock.Visible = false;
                Qunlock.Visible = false;
                Oo.Visible = true;
                cheat.Visible = true;
                this.BringToFront();
            }
            else if (ControlPanel.PAUSEblock == true)
            {
                PauseMENU.Visible = true;
                Punlock.Visible = true;
                PauseINFO.Visible = true;
                Qunlock.Visible = true;
            }
            else if (ControlPanel.PAUSEblock == false)
            {
                PauseMENU.Visible = false;
                Punlock.Visible = false;
                PauseINFO.Visible = false;
                Qunlock.Visible = false;
                Oo.Visible = false;
                cheat.Visible = false;
            }
            #endregion
            #region Atualizando a barra FW em todos os sentidos
            if (IsFW == true)
            {
                FWbar_BG.Top = ETEQUER.Top - 17;
                FWbar_BG.Left = 192;
                FWbar_BG.Visible = true;

                FWbar.Top = ETEQUER.Top - 17;
                FWbar.Left = 192;
                FWbar.Visible = true;

                Dividido = double.Parse(FWtime.ToString());
                Dividido = Dividido / 10;
                INDEXER = Dividido.ToString().IndexOf(",");
                if (INDEXER >= 0)
                {
                    ORIGINALvalue = Dividido.ToString().Substring(0, INDEXER);
                }
                else
                {
                    ORIGINALvalue = Dividido.ToString();
                }
                FWbar.Height = int.Parse(ORIGINALvalue);
            }
            else if (IsFW == false)
            {
                FWbar_BG.Top = 0;
                FWbar_BG.Left = 0;
                FWbar_BG.Visible = false;

                FWbar.Top = 0;
                FWbar.Left = 0;
                FWbar.Visible = false;
            }
            #endregion
        }

        private void GameUpdater_Tick(object sender, EventArgs e)
        {
            if (ControlPanel.TOTALblock == false)
            {
                #region Execução continua do Caindo, para evitar que o jogador passe por cima dos buracos
                if (Subindo_PULO == false)
                {
                    Caindo();
                    Caindo_Enemy();
                }
                #endregion
                #region Analisando para saber se o jogador bateu a cabeça em algum lugar
                //Essa região analisa se o jogador bateu a cabeça em alguma coisa, dependendo da 'coisa' em que o jogador cabeçeou uma determinada ação ocorrera que pode variar de perda de vida no caso de monstro até a básica finalização do pulo pelo impedimento.
                foreach (object OBJinGAME in this.Controls)
                {
                    if (OBJinGAME is PictureBox)
                    {
                        PictureBox GameThing = OBJinGAME as PictureBox;
                        if (Subindo_PULO == true)
                        {
                            if ((ETEQUER.Left + ETEQUER.Width) > GameThing.Left && (ETEQUER.Left + ETEQUER.Width) < (GameThing.Left + GameThing.Width) || ETEQUER.Left > GameThing.Left && ETEQUER.Left < (GameThing.Left + GameThing.Width))
                            {
                                if ((GameThing.Top + GameThing.Height) < ETEQUER.Top && (GameThing.Top + GameThing.Height + ControlPanel.VELOCIDADE) > ETEQUER.Top)
                                {
                                    if (GameThing.InitialImage == IMA_CdBox || GameThing.InitialImage == IMA_DvdBox || GameThing.InitialImage == IMA_FwBox || GameThing.InitialImage == IMA_LifeBox || GameThing.InitialImage == IMA_StarBox || GameThing.InitialImage == IMA_Tile)
                                    {
                                        if (IsFW == false)
                                        {
                                            Subindo_PULO = false;
                                            Caindo();
                                        }
                                        else if (IsFW == true)
                                        {
                                            GameThing.MaximumSize = new Size(998, 998);
                                        }
                                    }
                                    else if (GameThing.InitialImage == BOOT)
                                    {
                                        BOOTs(GameThing.ErrorImage, IsFW);
                                    }

                                    else if (GameThing.InitialImage == IMA_CdItem || GameThing.InitialImage == IMA_DvdItem || GameThing.InitialImage == IMA_FwItem || GameThing.InitialImage == IMA_LifeItem || GameThing.InitialImage == IMA_PenItem || GameThing.InitialImage == IMA_StarItem)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Movimentação do personagem
                //Nenhum lado
                if (WhereAreYouGoing == 0)
                {
                }
                //Direita
                else if (WhereAreYouGoing == 1)
                {
                    //Animação do personagem
                    Animation();
                    ETEQUER.BackgroundImage = IMG_AnimationValue;
                    //Anula o valor recebido para ele ser reenviado
                    WhereAreYouGoing = 0;
                }
                //Esquerda
                else if (WhereAreYouGoing == 2)
                {
                    //Animação do personagem
                    Animation();
                    ETEQUER.BackgroundImage = IMG_AnimationValue;
                    //Anula o valor recebido para ele ser reenviado
                    WhereAreYouGoing = 0;
                }

                if (Subindo_PULO == true)
                {
                    Pulando();
                }
                #endregion
                #region Movendo o chão
                if (IsMoved == true)
                {
                    foreach (object TUDO_obj in this.Controls)
                    {
                        if (TUDO_obj is PictureBox)
                        {
                            PictureBox GameThing = TUDO_obj as PictureBox;
                            //Se o arquivo for um chão
                            if (GameThing.MinimumSize.Width == 2)
                            {
                                if (UltimaTecla == MainMenu.Direita)
                                {
                                    GameThing.Left = GameThing.Left - ControlPanel.VELOCIDADE;
                                    //Apesar de parecer que o jogador esta parado para você, para o computador ele está se movendo e essa variavel mostra o valor da sua localização
                                    if (LocationCorrection == false) //Esse IF evita duplas adições
                                    {
                                        PLAYERpos = PLAYERpos + ControlPanel.VELOCIDADE;
                                        LocationCorrection = true;
                                    }
                                }
                                else if (UltimaTecla == MainMenu.Esquerda)
                                {
                                    GameThing.Left = GameThing.Left + ControlPanel.VELOCIDADE;
                                    //Apesar de parecer que o jogador esta parado para você, para o computador ele está se movendo e essa variavel mostra o valor da sua localização
                                    if (LocationCorrection == false) //Esse IF evita duplas adições
                                    {
                                        PLAYERpos = PLAYERpos - ControlPanel.VELOCIDADE;
                                        LocationCorrection = true;
                                    }
                                }
                            }
                        }
                    }
                    IsMoved = false;
                }
                #endregion
                #region Declaração do cenário
                //Esse IF impede que o checkpoint seja criado pela metade
                if (C_POINTED == true)
                {
                    #region MODULO1
                    Fui_pego = 0;
                    if (FirstDeclaration == false)
                    {
                        PLAYERpos = CheckPoint;
                    }
                    TileControl = CheckPoint;

                    DVD(E);
                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    Roza(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    BadGuy(E);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    CD(F);
                    NovaColuna();

                    CD(E);
                    NovaColuna();

                    CD(D);
                    YellowT(F);
                    NovaColuna();

                    LIFE(C);
                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(F);
                    CD(E);
                    NovaColuna();

                    YellowT(D);
                    YellowT(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(C);
                    YellowT(D);
                    YellowT(E);
                    NovaColuna();

                    NovaColuna();

                    YellowT(B);
                    YellowT(C);
                    YellowT(D);
                    YellowT(E);
                    NovaColuna();

                    YellowT(F);
                    CD(E);
                    PEN(D);
                    NovaColuna();

                    YellowT(F);
                    DVD(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    Daivison(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(D);
                    Erwin(C);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(D);
                    Daivison(C);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(D);
                    BadGuy(C);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(C);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    MarceluI(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    Erwin(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    Daivison(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    BadGuy(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    Erwin(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    Daivison(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(E);
                    BadGuy(D);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(C);
                    NovaColuna();

                    YellowT(B);
                    YellowT(D);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(E);
                    Daivison(D);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(E);
                    Erwin(D);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    NovaColuna();

                    YellowT(C);
                    NovaColuna();

                    YellowT(C);
                    CD(B);
                    NovaColuna();

                    YellowT(C);
                    NovaColuna();

                    YellowT(C);
                    PEN(B);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    MarceluII(E);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    STAR(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(E);
                    CD(D);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    YellowT(D);
                    DVD(C);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    NovaColuna();

                    YellowT(C);
                    NovaColuna();

                    YellowT(C);
                    PEN(B);
                    NovaColuna();

                    YellowT(C);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();
                    NovaColuna();
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    CD(E);
                    NovaColuna();

                    YellowT(F);
                    CD(D);
                    DVD(E);
                    NovaColuna();

                    YellowT(F);
                    CD(C);
                    DVD(D);
                    PEN(E);
                    NovaColuna();

                    YellowT(F);
                    CD(D);
                    DVD(E);
                    NovaColuna();

                    YellowT(F);
                    CD(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    Erwin(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(E);
                    LIFE(D);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(E);
                    Daivison(D);
                    NovaColuna();

                    YellowT(E);
                    NovaColuna();

                    YellowT(D);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();

                    YellowT(F);
                    Muacir(E);
                    NovaColuna();

                    YellowT(F);
                    NovaColuna();
                    #endregion
                    #region MODULO2
                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    GrayT(E);
                    Erwin(D);
                    NovaColuna();

                    GrayT(D);
                    NovaColuna();

                    GrayT(D);
                    BadGuy(C);
                    NovaColuna();

                    GrayT(C);
                    NovaColuna();

                    GrayT(C);
                    Daivison(B);
                    NovaColuna();

                    GrayT(B);
                    NovaColuna();

                    NovaColuna();

                    GrayT(D);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    Daivison(E);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    CD(D);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    CD(D);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    CD(D);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    Renatu(E);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    CD(F);
                    CD(E);
                    NovaColuna();

                    CD(F);
                    CD(E);
                    NovaColuna();

                    CD(E);
                    GrayT(F);
                    NovaColuna();

                    CD(E);
                    GrayT(F);
                    Erwin(D);
                    NovaColuna();

                    PEN(E);
                    GrayT(F);
                    NovaColuna();

                    CD(D);
                    GrayT(E);
                    NovaColuna();

                    DVD(C);
                    GrayT(D);
                    NovaColuna();

                    CD(B);
                    GrayT(C);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    DVD(E);
                    CD(D);
                    DVD(C);
                    NovaColuna();

                    GrayT(F);
                    CD(E);
                    PEN(D);
                    CD(C);
                    NovaColuna();

                    GrayT(F);
                    DVD(E);
                    CD(D);
                    DVD(C);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    Erwin(E);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    NovaColuna();

                    GrayT(D);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    GrayT(E);
                    Daivison(D);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    GrayT(D);
                    NovaColuna();

                    NovaColuna();

                    GrayT(C);
                    NovaColuna();

                    GrayT(D);
                    NovaColuna();

                    GrayT(D);
                    BadGuy(C);
                    NovaColuna();

                    GrayT(D);
                    NovaColuna();

                    GrayT(C);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    CD(E);
                    CD(D);
                    CD(C);
                    CD(B);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    Erwin(E);
                    NovaColuna();

                    GrayT(F);
                    DVD(E);
                    DVD(D);
                    DVD(C);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    GrayT(E);
                    CD(D);
                    NovaColuna();

                    GrayT(E);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();

                    GrayT(F);
                    Agustinho(E);
                    NovaColuna();

                    GrayT(F);
                    NovaColuna();
                    #endregion
                    #region MODULO3
                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    LIFE(E);
                    NovaColuna();

                    GreenT(F);
                    FW(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    NovaColuna();

                    GreenT(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    Erwin(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    Daivison(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    BadGuy(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(E);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    GreenT(E);
                    NovaColuna();

                    GreenT(E);
                    CD(D);
                    CD(C);
                    NovaColuna();

                    GreenT(E);
                    CD(D);
                    CD(C);
                    NovaColuna();

                    GreenT(E);
                    NovaColuna();

                    GreenT(D);
                    NovaColuna();

                    GreenT(E);
                    NovaColuna();

                    GreenT(F);
                    CD(E);
                    Daivison(D);
                    NovaColuna();

                    GreenT(F);
                    CD(E);
                    NovaColuna();

                    GreenT(F);
                    PEN(E);
                    CD(D);
                    NovaColuna();

                    GreenT(F);
                    PEN(E);
                    CD(D);
                    NovaColuna();

                    GreenT(C);
                    NovaColuna();

                    GreenT(C);
                    NovaColuna();

                    GreenT(C);
                    NovaColuna();

                    GreenT(C);
                    NovaColuna();

                    DVD(D);
                    NovaColuna();

                    DVD(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    CD(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    Cleito(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(E);
                    NovaColuna();

                    NovaColuna();

                    GreenT(E);
                    FW(D);
                    NovaColuna();

                    GreenT(F);
                    DVD(E);
                    CD(D);
                    NovaColuna();

                    GreenT(F);
                    DVD(E);
                    CD(D);
                    NovaColuna();

                    GreenT(F);
                    DVD(E);
                    PEN(D);
                    CD(C);
                    NovaColuna();

                    GreenT(E);
                    DVD(D);
                    CD(C);
                    NovaColuna();

                    GreenT(D);
                    DVD(C);
                    CD(B);
                    NovaColuna();

                    GreenT(C);
                    DVD(B);
                    CD(A);
                    NovaColuna();

                    GreenT(B);
                    DVD(A);
                    NovaColuna();

                    GreenT(C);
                    NovaColuna();

                    GreenT(D);
                    CD(C);
                    Erwin(B);
                    NovaColuna();

                    GreenT(E);
                    PEN(D);
                    CD(C);
                    NovaColuna();

                    GreenT(E);
                    PEN(D);
                    CD(C);
                    NovaColuna();

                    GreenT(E);
                    PEN(D);
                    CD(C);
                    BadGuy(B);
                    NovaColuna();

                    GreenT(D);
                    CD(C);
                    NovaColuna();

                    GreenT(C);
                    NovaColuna();

                    GreenT(C);
                    NovaColuna();

                    GreenT(C);
                    Daivison(B);
                    NovaColuna();

                    GreenT(D);
                    PEN(C);
                    NovaColuna();

                    GreenT(E);
                    PEN(C);
                    PEN(D);
                    NovaColuna();

                    GreenT(F);
                    PEN(E);
                    PEN(D);
                    CD(C);
                    DVD(B);
                    NovaColuna();

                    GreenT(F);
                    PEN(E);
                    CD(D);
                    NovaColuna();

                    GreenT(F);
                    PEN(E);
                    CD(D);
                    Daivison(C);
                    NovaColuna();

                    GreenT(F);
                    PEN(E);
                    CD(D);
                    NovaColuna();

                    DVD(C);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    STAR(E);
                    NovaColuna();

                    GreenT(F);
                    LIFE(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(E);
                    NovaColuna();

                    NovaColuna();
                    NovaColuna();
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();

                    GreenT(F);
                    LouisCarlos(E);
                    NovaColuna();

                    GreenT(F);
                    NovaColuna();
                    #endregion
                }
                #endregion
                #region Deletamento dos picturebox inuteis
                //Deletando o chão quando ele ultrapassa os limites
                foreach (object ALL_obj in this.Controls)
                {
                    if (ALL_obj is PictureBox)
                    {
                        PictureBox GameThing = ALL_obj as PictureBox;
                        if (GameThing.Left == -110 && UltimaTecla == MainMenu.Direita && GameThing.MinimumSize.Width == 2 && GameThing.MinimumSize.Height == 0)
                        {
                            Controls.Remove(GameThing);

                        }
                        else if (GameThing.Left == 910 && UltimaTecla == MainMenu.Esquerda && GameThing.MinimumSize.Width == 2 && GameThing.MinimumSize.Height == 0)
                        {
                            Controls.Remove(GameThing);

                        }
                    }
                }
                #endregion
                #region configuração da movimentação dos BOOTs
                foreach (object OBJ in this.Controls)
                {
                    if (OBJ is PictureBox)
                    {
                        PictureBox GameMonster = OBJ as PictureBox;
                        if (GameMonster.InitialImage == BOOT)
                        {
                            foreach (object OBJ_II in this.Controls)
                            {
                                if (OBJ_II is PictureBox)
                                {
                                    PictureBox GameThing = OBJ_II as PictureBox;
                                    #region Batendo nas coisas
                                    if (GameThing.MinimumSize.Width == 2 && GameThing.MinimumSize.Height == 0)
                                    {
                                        if (GameMonster.AccessibleDescription == "DIREITA")
                                        {
                                            if (GameThing.Top >= GameMonster.Top && GameThing.Top < GameMonster.Top + GameMonster.Height || GameMonster.Top > GameThing.Top && GameMonster.Top < GameThing.Top + GameThing.Height)
                                            {
                                                if ((GameMonster.Left + GameMonster.Width) > (GameThing.Left - ControlPanel.VELOCIDADE * 2.5) && (GameMonster.Left + GameMonster.Width) < GameThing.Left)
                                                {
                                                    GameMonster.AccessibleDescription = "ESQUERDA";
                                                }
                                            }
                                        }

                                        else if (GameMonster.AccessibleDescription == "ESQUERDA")
                                        {
                                            if (GameThing.Top >= GameMonster.Top && GameThing.Top < GameMonster.Top + GameMonster.Height || GameMonster.Top > GameThing.Top && GameMonster.Top < GameThing.Top + GameThing.Height)
                                            {
                                                if ((GameThing.Left + GameThing.Width + ControlPanel.VELOCIDADE * 2.5) > GameMonster.Left && (GameThing.Left + GameThing.Width) < GameMonster.Left)
                                                {
                                                    GameMonster.AccessibleDescription = "DIREITA";
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                }
                                #endregion
                #region Movimentando os inimigos
                foreach (object OBJ in this.Controls)
                {
                    if (OBJ is PictureBox)
                    {
                        PictureBox GameMonster = OBJ as PictureBox;
                        if (GameMonster.InitialImage == BOOT && GameMonster.AccessibleDescription == "DIREITA")
                        {
                            GameMonster.Left += ControlPanel.VELOCIDADE / 2;
                        }

                        else if (GameMonster.InitialImage == BOOT && GameMonster.AccessibleDescription == "ESQUERDA")
                        {
                            GameMonster.Left -= ControlPanel.VELOCIDADE / 2;
                        }
                    }
                }
                #endregion
                #region Animação da moviemntação dos boots
                foreach (object OBJinGAME in this.Controls)
                {
                    if (OBJinGAME is PictureBox)
                    {
                        PictureBox GameMonster = OBJinGAME as PictureBox;
                        if (GameMonster.ErrorImage == IMA_BadGuy)
                        {
                            if (GameMonster.MaximumSize.Height == 990)
                            {
                                if (GameMonster.AccessibleDescription == "DIREITA")
                                {
                                    GameMonster.Image = BadGuy_DIR1;
                                }

                                else if (GameMonster.AccessibleDescription == "ESQUERDA")
                                {
                                    GameMonster.Image = BadGuy_ESQ1;
                                }
                                GameMonster.MaximumSize = new Size(991, 991);
                            }

                            else if (GameMonster.MaximumSize.Height == 991)
                            {
                                if (GameMonster.AccessibleDescription == "DIREITA")
                                {
                                    GameMonster.Image = BadGuy_DIR2;
                                }

                                else if (GameMonster.AccessibleDescription == "ESQUERDA")
                                {
                                    GameMonster.Image = BadGuy_ESQ2;
                                }
                                GameMonster.MaximumSize = new Size(992, 992);
                            }

                            else if (GameMonster.MaximumSize.Height == 992)
                            {
                                if (GameMonster.AccessibleDescription == "DIREITA")
                                {
                                    GameMonster.Image = BadGuy_DIR3;
                                }

                                else if (GameMonster.AccessibleDescription == "ESQUERDA")
                                {
                                    GameMonster.Image = BadGuy_ESQ3;
                                }
                                GameMonster.MaximumSize = new Size(993, 993);
                            }

                            else if (GameMonster.MaximumSize.Height == 993)
                            {
                                if (GameMonster.AccessibleDescription == "DIREITA")
                                {
                                    GameMonster.Image = BadGuy_DIR2;
                                }

                                else if (GameMonster.AccessibleDescription == "ESQUERDA")
                                {
                                    GameMonster.Image = BadGuy_ESQ2;
                                }
                                GameMonster.MaximumSize = new Size(990, 990);
                            }
                        }

                        else if (GameMonster.ErrorImage == IMA_Daivison)
                        {
                            //Imagem animativa
                            if (GameMonster.Image == Daivison1)
                            {
                                GameMonster.Image = Daivison2;
                            }

                            else if (GameMonster.Image == Daivison2)
                            {
                                GameMonster.Image = Daivison1;
                            }
                        }

                        else if (GameMonster.ErrorImage == IMA_Erwin)
                        {
                            if (GameMonster.MaximumSize.Height == 990)
                            {
                                GameMonster.Image = Ervin1;
                                GameMonster.MaximumSize = new Size(991, 991);
                            }

                            else if (GameMonster.MaximumSize.Height == 991)
                            {
                                GameMonster.Image = Ervin2;
                                GameMonster.MaximumSize = new Size(992, 992);
                            }

                            else if (GameMonster.MaximumSize.Height == 992)
                            {
                                GameMonster.Image = Ervin3;
                                GameMonster.MaximumSize = new Size(990, 990);
                            }
                        }
                    }
                }
                                #endregion
                //Avisando que a primeira declaração do cenário foi feita, isso é usado para casos como inicio do jogo, load do game ou passar de fase.
                C_POINTED = true;
                FirstDeclaration = true;
            }
        }

        private void ReationUpdater_Tick_1(object sender, EventArgs e)
        {
            if (ControlPanel.TOTALblock == false)
            {
                //Timer criado para dar a reação que o jogador tem ao encostar nos objetos
                #region Enconstar de direita e esquerda em qualquer caixa, chão etc
                //Analisa se existe impedimento procurando a posição de cada picturebox no jogo, se não houver impedimento ele da a ordem para tudo se mover
                if (CanTryMoveAllforESQ == true)
                {
                    ESQ_livre = true;
                    foreach (object OBJinGAME in this.Controls)
                    {
                        if (OBJinGAME is PictureBox)
                        {
                            PictureBox GameThing = OBJinGAME as PictureBox;
                            if (GameThing.MinimumSize.Width == 2 && GameThing.MinimumSize.Height == 0)
                            {
                                if (GameThing.Top > ETEQUER.Top && GameThing.Top < ETEQUER.Top + ETEQUER.Height || ETEQUER.Top > GameThing.Top && ETEQUER.Top < GameThing.Top + GameThing.Height)
                                {
                                    if ((GameThing.Left + GameThing.Width + (ControlPanel.VELOCIDADE * 2 - ControlPanel.VELOCIDADE / 10 * 3)) > ETEQUER.Left && (GameThing.Left + GameThing.Width) < ETEQUER.Left)
                                    {
                                        if (GameThing.InitialImage == IMA_CdItem || GameThing.InitialImage == IMA_DvdItem || GameThing.InitialImage == IMA_LifeItem || GameThing.InitialImage == IMA_FwItem || GameThing.InitialImage == IMA_PenItem || GameThing.InitialImage == IMA_StarItem)
                                        {
                                            ESQ_livre = true;
                                        }

                                        else if (GameThing.InitialImage == IMA_CdBox || GameThing.InitialImage == IMA_DvdBox || GameThing.InitialImage == IMA_LifeBox || GameThing.InitialImage == IMA_FwBox || GameThing.InitialImage == IMA_PenBox || GameThing.InitialImage == IMA_StarBox)
                                        {
                                            if (IsFW == true)
                                            {
                                                ESQ_livre = true;
                                                GameThing.MaximumSize = new Size(998, 998);
                                            }
                                            else
                                            {
                                                ESQ_livre = false;
                                            }
                                        }

                                        else
                                        {
                                            ESQ_livre = false;
                                        }
                                    }
                                }

                                if (Subindo_PULO == true)
                                {
                                    if (GameThing.Top >= ETEQUER.Top && GameThing.Top <= ETEQUER.Top + ETEQUER.Height || ETEQUER.Top >= GameThing.Top && ETEQUER.Top <= GameThing.Top + GameThing.Height)
                                    {
                                        if ((GameThing.Left + GameThing.Width) >= ETEQUER.Left && (GameThing.Left + GameThing.Width) <= ETEQUER.Left)
                                        {
                                            if (GameThing.InitialImage == IMA_CdItem || GameThing.InitialImage == IMA_DvdItem || GameThing.InitialImage == IMA_LifeItem || GameThing.InitialImage == IMA_FwItem || GameThing.InitialImage == IMA_PenItem || GameThing.InitialImage == IMA_StarItem)
                                            {
                                                ESQ_livre = true;
                                            }

                                            else if (GameThing.InitialImage == IMA_CdBox || GameThing.InitialImage == IMA_DvdBox || GameThing.InitialImage == IMA_LifeBox || GameThing.InitialImage == IMA_FwBox || GameThing.InitialImage == IMA_PenBox || GameThing.InitialImage == IMA_StarBox)
                                            {
                                                if (IsFW == true)
                                                {
                                                    ESQ_livre = true;
                                                    GameThing.MaximumSize = new Size(998, 998);
                                                }
                                                else
                                                {
                                                    ESQ_livre = false;
                                                }
                                            }

                                            else
                                            {

                                                ESQ_livre = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (ESQ_livre == true)
                    {
                        //Avisa que a ultima tecla a ser apertada é a Esquerda
                        Jogo.UltimaTecla = MainMenu.Esquerda;

                        //Envia o valor do que deve ser feito
                        Jogo.WhereAreYouGoing = 2;

                        //Faz o fundo mover
                        Fundo.MoveBG = true;

                        //Faz mover os itens, chão, paredes e inimigos
                        Jogo.IsMoved = true;

                        //Retira 10 na localização do personagem
                        Jogo.LocationCorrection = false;
                    }
                }

                if (CanTryMoveAllforDIR == true)
                {
                    DIR_livre = true;
                    foreach (object OBJinGAME in this.Controls)
                    {
                        if (OBJinGAME is PictureBox)
                        {
                            PictureBox GameThing = OBJinGAME as PictureBox;
                            if (GameThing.MinimumSize.Width == 2 && GameThing.MinimumSize.Height == 0)
                            {
                                if (GameThing.Top > ETEQUER.Top && GameThing.Top < ETEQUER.Top + ETEQUER.Height || ETEQUER.Top > GameThing.Top && ETEQUER.Top < GameThing.Top + GameThing.Height)
                                {
                                    if (ETEQUER.Left + ETEQUER.Width > GameThing.Left - (ControlPanel.VELOCIDADE * 2 - ControlPanel.VELOCIDADE / 10 * 3) && ETEQUER.Left + ETEQUER.Width < GameThing.Left)
                                    {
                                        if (GameThing.InitialImage == IMA_CdItem || GameThing.InitialImage == IMA_DvdItem || GameThing.InitialImage == IMA_LifeItem || GameThing.InitialImage == IMA_FwItem || GameThing.InitialImage == IMA_PenItem || GameThing.InitialImage == IMA_StarItem)
                                        {
                                            DIR_livre = true;
                                        }

                                        else if (GameThing.InitialImage == IMA_CdBox || GameThing.InitialImage == IMA_DvdBox || GameThing.InitialImage == IMA_LifeBox || GameThing.InitialImage == IMA_FwBox || GameThing.InitialImage == IMA_PenBox || GameThing.InitialImage == IMA_StarBox)
                                        {
                                            if (IsFW == true)
                                            {
                                                DIR_livre = true;
                                                GameThing.MaximumSize = new Size(998, 998);
                                            }
                                            else
                                            {
                                                DIR_livre = false;
                                            }
                                        }

                                        else
                                        {
                                            DIR_livre = false;
                                        }
                                    }
                                }
                                //Para pulos na extrema-diagonal
                                if (Subindo_PULO == true)
                                {
                                    if (GameThing.Top >= ETEQUER.Top && GameThing.Top <= ETEQUER.Top + ETEQUER.Height || ETEQUER.Top >= GameThing.Top && ETEQUER.Top <= GameThing.Top + GameThing.Height)
                                    {
                                        if (ETEQUER.Left + ETEQUER.Width > GameThing.Left && ETEQUER.Left + ETEQUER.Width <= GameThing.Left)
                                        {
                                            if (GameThing.InitialImage == IMA_CdItem || GameThing.InitialImage == IMA_DvdItem || GameThing.InitialImage == IMA_LifeItem || GameThing.InitialImage == IMA_FwItem || GameThing.InitialImage == IMA_PenItem || GameThing.InitialImage == IMA_StarItem)
                                            {
                                                DIR_livre = true;
                                            }

                                            else if (GameThing.InitialImage == IMA_CdBox || GameThing.InitialImage == IMA_DvdBox || GameThing.InitialImage == IMA_LifeBox || GameThing.InitialImage == IMA_FwBox || GameThing.InitialImage == IMA_PenBox || GameThing.InitialImage == IMA_StarBox)
                                            {
                                                if (IsFW == true)
                                                {
                                                    DIR_livre = true;
                                                    GameThing.MaximumSize = new Size(998, 998);
                                                }
                                                else
                                                {
                                                    DIR_livre = false;
                                                }
                                            }

                                            else
                                            {
                                                DIR_livre = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (DIR_livre == true)
                    {
                        //Avisa que a ultima tecla a ser apertada é a Direita
                        Jogo.UltimaTecla = MainMenu.Direita;

                        //Envia o valor do que deve ser feito
                        Jogo.WhereAreYouGoing = 1;

                        //Faz o fundo mover
                        Fundo.MoveBG = true;

                        //Faz mover os itens, chão, paredes e inimigos
                        Jogo.IsMoved = true;

                        //Adiciona 10 na localização do personagem
                        Jogo.LocationCorrection = false;
                    }
                }
                #endregion
                #region Evitando entrada do jogador numa picturebox-item
                foreach (object OBJinGAME in this.Controls)
                {
                    if (OBJinGAME is PictureBox)
                    {
                        PictureBox GameThing = OBJinGAME as PictureBox;
                        //Verificando o left
                        if (ETEQUER.Left < GameThing.Left && ETEQUER.Left + ETEQUER.Width > GameThing.Left || ETEQUER.Left < GameThing.Left && ETEQUER.Left + ETEQUER.Width > GameThing.Left || GameThing.Left < ETEQUER.Left && ETEQUER.Left + ETEQUER.Width < GameThing.Left + GameThing.Width)
                        {
                            if (GameThing.InitialImage == IMA_CdItem || GameThing.InitialImage == IMA_DvdItem || GameThing.InitialImage == IMA_FwItem || GameThing.InitialImage == IMA_LifeItem || GameThing.InitialImage == IMA_PenItem || GameThing.InitialImage == IMA_StarItem)
                            {
                            }
                            else
                            {
                                //verificando o top, se estiver entrando por cima ele sobe
                                if (GameThing.Top <= ETEQUER.Top && (GameThing.Top + GameThing.Height) >= ETEQUER.Top)
                                {
                                    ETEQUER.Top = GameThing.Height + GameThing.Top;
                                    Subindo_PULO = false;
                                    Caindo();
                                    if (GameThing.InitialImage == BOOT)
                                    {
                                        BOOTs(GameThing.ErrorImage, IsFW);
                                    }
                                }

                                //Se estiver entrando na picturebox por baixo, ele desce...
                                if (ETEQUER.Top < GameThing.Top && (ETEQUER.Top + ETEQUER.Height) > GameThing.Top)
                                {
                                    ETEQUER.Top = GameThing.Top - ETEQUER.Height - ControlPanel.VELOCIDADE;
                                    if (GameThing.InitialImage == BOOT)
                                    {
                                        BOOTs(GameThing.ErrorImage, IsFW);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Contato com amigos e inimigos (chefes)
                foreach (object OBJinGAME in this.Controls)
                {
                    if (OBJinGAME is PictureBox)
                    {
                        PictureBox GameTeacher = OBJinGAME as PictureBox;
                        #region Conversa com Roza
                        if (GameTeacher.InitialImage == IMA_Roza)
                        {
                            if (GameTeacher.Left - 120 < (ETEQUER.Left + ETEQUER.Width) && CP_roza == false)
                            {
                                CheckPoint = PLAYERpos;
                                CP_roza = true;
                            }

                            if (GameTeacher.Left - 90 < (ETEQUER.Left + ETEQUER.Width))
                            {
                                if (TALK == 0)
                                {
                                    TALKing = true;
                                    CanTryMoveAllforDIR = false;
                                    CanTryMoveAllforESQ = false;
                                    AvatarPlace.Image = ROZAavt;
                                    Mensagem();
                                    Text1.Text = "Roza:";
                                    Text2.Text = "Vejo que bebeu da água de um dos super bebedouros";
                                    Text3.Text = "da Etec";
                                    TALK++;
                                }
                                else if (TALK == 2)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Errr... Olá... Eu... Eu sou o Etequer...";
                                    Text3.Text = "";
                                    TALK++;
                                }
                                else if (TALK == 4)
                                {
                                    AvatarPlace.Image = ROZAavt;
                                    Text1.Text = "Roza";
                                    Text2.Text = ":)";
                                    Text3.Text = "Eu sou Roza, te darei uma noção básico do jogo, eu sou uma aliada,";
                                    TALK++;
                                }

                                else if (TALK == 6)
                                {
                                    AvatarPlace.Image = ROZAavt;
                                    Text1.Text = "Roza";
                                    Text2.Text = "no decorrer do curso você encontrará professores inimigos, aliados e ";
                                    Text3.Text = "chefes, os inimigos são mais simples de se dar, pule em cima deles e ";
                                    TALK++;
                                }


                                else if (TALK == 8)
                                {
                                    AvatarPlace.Image = ROZAavt;
                                    Text1.Text = "Roza";
                                    Text2.Text = "ganhará uma pontuação, para concluir o curso você deverá derrotar os ";
                                    Text3.Text = "chefes, os aliados te ajudarão a passar... Os inimigos são quatro tipos ";
                                    TALK++;
                                }

                                else if (TALK == 10)
                                {
                                    AvatarPlace.Image = ROZAavt;
                                    Text1.Text = "Roza";
                                    Text2.Text = "diferentes, os chefes são três e os aliados quatro. Se você precisar de mais";
                                    Text3.Text = "ajuda sobre o programa ou comandos entre no tópico \"ajuda\" do Menu Inicial.";
                                    TALK++;
                                }

                                else if (TALK == 12)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "O... Ok....";
                                    Text3.Text = "";
                                    TALK++;
                                }


                                else if (TALK == 14)
                                {
                                    Mensagem();
                                    DontMOVE = true;
                                    TALK++;
                                    ReationUpdater.Interval = 100;
                                }

                                else if (TALK == 15)
                                {
                                    GameTeacher.BackgroundImage = RozaEXIT1;
                                    TALK++;
                                }

                                else if (TALK == 16)
                                {
                                    GameTeacher.BackgroundImage = RozaEXIT2;
                                    TALK++;
                                }

                                else if (TALK == 17)
                                {
                                    GameTeacher.Top -= ControlPanel.VELOCIDADE * 6;
                                    GameTeacher.BackgroundImage = RozaEXIT3;
                                    TALK++;
                                }

                                else if (TALK == 18)
                                {
                                    if (GameTeacher.Width > 5)
                                    {
                                        GameTeacher.Left += 15;
                                    }
                                    GameTeacher.Width = 5;
                                    GameTeacher.BackgroundImage = RozaEXIT4;
                                    GameTeacher.Top -= ControlPanel.VELOCIDADE * 6;
                                    if (GameTeacher.Top < -100)
                                    {
                                        Controls.Remove(GameTeacher);
                                        TALKing = false;
                                        RozaTalk = true;
                                        ReationUpdater.Interval = 1;
                                        TALK = 0;
                                        DontMOVE = false;
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Conversa com Marcelu
                        else if (GameTeacher.InitialImage == IMA_Marcelu_Friend)
                        {
                            if (GameTeacher.Left - 120 < (ETEQUER.Left + ETEQUER.Width) && CP_Marcelu_Talk == false)
                            {
                                CheckPoint = PLAYERpos;
                                CP_Marcelu_Talk = true;
                            }

                            if (GameTeacher.Left - 90 < (ETEQUER.Left + ETEQUER.Width))
                            {
                                if (TALK == 0)
                                {
                                    TALKing = true;
                                    CanTryMoveAllforDIR = false;
                                    CanTryMoveAllforESQ = false;
                                    AvatarPlace.Image = ETEQUERavt;
                                    Mensagem();
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Hum... Que homem estranho, o cabelo dele... Tem formato de... de...";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 2)
                                {
                                    AvatarPlace.Image = MARCELUavt;
                                    Text1.Text = "Marcelu:";
                                    Text2.Text = "Torre! Marcelu da Torre é meu nome, estou aqui para te ajudar...";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 4)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Ahh... Éh? Ajudar? Como?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 6)
                                {
                                    AvatarPlace.Image = MARCELUavt;
                                    Text1.Text = "Marcelu:";
                                    Text2.Text = "Bom, só por você ter me encontrado você altera seu \"Check Point\" para";
                                    Text3.Text = "cá, além de receber um item....";
                                    TALK++;
                                }

                                else if (TALK == 8)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Check Point?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 10)
                                {
                                    AvatarPlace.Image = MARCELUavt;
                                    Text1.Text = "Marcelu:";
                                    Text2.Text = "Sim, sim, apartir de agora, quando você perder uma vida, esse será o local";
                                    Text3.Text = "para onde você voltará";
                                    TALK++;
                                }

                                else if (TALK == 12)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "E meu item?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 14)
                                {
                                    AvatarPlace.Image = MARCELUavt;
                                    Text1.Text = "Marcelu:";
                                    Text2.Text = "Errr... Hum... Item... Eu vou te dar... te dar... A \"Fire Wall\"!";
                                    Text3.Text = "Esse item vai te deixar bem mais forte, pegue-o.";
                                    TALK++;
                                }

                                else if (TALK == 16)
                                {
                                    AvatarPlace.Image = MARCELUavt;
                                    Text1.Text = "Marcelu:";
                                    Text2.Text = "Agora tenho que ir dar uma aula...";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 18)
                                {
                                    Controls.Remove(GameTeacher);
                                    Mensagem();
                                    MarceluTalk = true;
                                    TALKing = false;
                                    TALK = 0;
                                    IsFW = true;
                                    FWtime = 1200;
                                }
                            }
                        }
                        #endregion
                        #region Luta com Marcelu
                        else if (GameTeacher.InitialImage == IMA_Marcelu_Boss)
                        {
                            if (GameTeacher.Left - 120 < (ETEQUER.Left + ETEQUER.Width) && CP_Marcelu_Boss == false)
                            {
                                CheckPoint = PLAYERpos;
                                CP_Marcelu_Boss = true;
                            }

                            if (GameTeacher.Left - 90 < (ETEQUER.Left + ETEQUER.Width))
                            {
                                if (TALK == 0)
                                {
                                    ControlPanel.JogoVisibleFALSE = true;
                                    CanTryMoveAllforDIR = false;
                                    CanTryMoveAllforESQ = false;
                                    Videos.WhoPlay = 2;
                                    Videos PlayMarcelu = new Videos();
                                    PlayMarcelu.Show();
                                    ControlPanel.TOTALblock = true;
                                    ControlPanel.GoFront = true;
                                    TALK++;
                                }
                                else if (TALK == 2)
                                {
                                    ControlPanel.JogoVisibleFALSE = false;
                                    Mensagem();
                                    TALKing = true;
                                    AvatarPlace.Image = MARCELUavt;
                                    Text1.Text = "Marcelu:";
                                    Text2.Text = "Ahhh... Me desculpe... Acho que eu me stressei...";
                                    Text3.Text = "Obrigado Etequer...";
                                    TALK++;
                                }

                                else if (TALK == 4)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Sem problemas, me disseram que para concluir o curso eu deveria";
                                    Text3.Text = "derrotar 3 professores chefes, acho que você já conta como um, certo?";
                                    TALK++;
                                }

                                else if (TALK == 6)
                                {
                                    AvatarPlace.Image = MARCELUavt;
                                    Text1.Text = "Marcelu:";
                                    Text2.Text = "Na verdade... Não... Isso foi um imprevisto, não estava dentro";
                                    Text3.Text = "dos planos do curso, ainda há três chefes... Errr.... hehe... Tchau";
                                    TALK++;
                                }

                                else if (TALK == 8)
                                {
                                    Mensagem();
                                    Controls.Remove(GameTeacher);
                                    TALK = 0;
                                    TALKing = false;
                                }
                            }
                        }
                        #endregion
                        #region Luta com Muacir
                        else if (GameTeacher.InitialImage == IMA_Muacir)
                        {
                            if (GameTeacher.Left - 120 < (ETEQUER.Left + ETEQUER.Width) && CP_Muacir == false)
                            {
                                CheckPoint = PLAYERpos;
                                CP_Muacir = true;
                            }

                            if (GameTeacher.Left - 90 < (ETEQUER.Left + ETEQUER.Width))
                            {
                                if (TALK == 0)
                                {
                                    TALKing = true;
                                    CanTryMoveAllforDIR = false;
                                    CanTryMoveAllforESQ = false;
                                    AvatarPlace.Image = ETEQUERavt;
                                    Mensagem();
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Coff... Coff... De onde vem toda";
                                    Text3.Text = "essa fumaça? Coff... Coff...";
                                    TALK++;
                                }
                                else if (TALK == 2)
                                {
                                    AvatarPlace.Image = MUACIRavt;
                                    Text1.Text = "Muacir:";
                                    Text2.Text = "Ahhh... Não vamos acusar ninguém, ora!";
                                    Text3.Text = "Me imagine como o marinheiro Popeye diferente.";
                                    TALK++;
                                }

                                else if (TALK == 4)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Você parece mais com o Lula Molusculo!";
                                    Text3.Text = "Você é um professor?";
                                    TALK++;
                                }

                                else if (TALK == 6)
                                {
                                    AvatarPlace.Image = MUACIRavt;
                                    Text1.Text = "Muacir:";
                                    Text2.Text = "Se eu sou um professor?";
                                    Text3.Text = "Eu sou Muacir! O professor!";
                                    TALK++;
                                }

                                else if (TALK == 8)
                                {
                                    AvatarPlace.Image = MUACIRavt;
                                    Text1.Text = "Muacir:";
                                    Text2.Text = "Comigo você irá aprender a técnologia";
                                    Text3.Text = "do futuro!";
                                    TALK++;
                                }

                                else if (TALK == 10)
                                {
                                    Mensagem();
                                    Videos.WhoPlay = 3;
                                    Videos PlayMuacir = new Videos();
                                   PlayMuacir.Show();
                                    ControlPanel.JogoVisibleFALSE = true;
                                    ControlPanel.TOTALblock = false;
                                    ControlPanel.GoFront = true;
                                    TALKing = false;
                                    TALK++;
                                    this.Controls.Remove(GameTeacher);
                                    MuacirFight = true;
                                    TALK = 0;
                                }
                            }
                        }
                        #endregion
                        #region Conversa com Renatu
                        else if (GameTeacher.InitialImage == IMA_Renatu)
                        {
                            if (GameTeacher.Left - 120 < (ETEQUER.Left + ETEQUER.Width) && CP_Renatu == false)
                            {
                                CheckPoint = PLAYERpos;
                                CP_Renatu = true;
                            }

                            if (GameTeacher.Left - 90 < (ETEQUER.Left + ETEQUER.Width))
                            {
                                if (TALK == 0)
                                {
                                    Banco.SendToBack();
                                    TALKing = true;
                                    CanTryMoveAllforDIR = false;
                                    CanTryMoveAllforESQ = false;
                                    AvatarPlace.Image = RENATUavt;
                                    Mensagem();
                                    Text1.Text = "Renatu:";
                                    Text2.Text = "Olá, eu sou Renatu da Vila... Eu sou um aliado...";
                                    Text3.Text = "Eu vou te entregar seu item, o banco de itens!";
                                    TALK++;
                                }

                                else if (TALK == 2)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Banco de items? O que isso faz?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 4)
                                {
                                    AvatarPlace.Image = RENATUavt;
                                    Text1.Text = "Renatu:";
                                    Text2.Text = "Sim, com isso você poderá carregar um item, apenas um, e esse item será";
                                    Text3.Text = "util para você. Aguarde mais informações do próximo aliado.";
                                    TALK++;
                                }

                                else if (TALK == 6)
                                {
                                    Banco.Image = BI;
                                    Banco.Visible = true;
                                    Mensagem();
                                    TALK = 0;
                                    TALKing = false;
                                    Controls.Remove(GameTeacher);
                                    RenatuTalk = true;
                                }
                            }

                        }
                        #endregion
                        #region Luta com Agustinho
                        else if (GameTeacher.InitialImage == IMA_Agustinho)
                        {
                            if (GameTeacher.Left - 120 < (ETEQUER.Left + ETEQUER.Width) && CP_Agustinho == false)
                            {
                                CheckPoint = PLAYERpos;
                                CP_Agustinho = true;
                            }

                            if (GameTeacher.Left - 90 < (ETEQUER.Left + ETEQUER.Width))
                            {
                                if (TALK == 0)
                                {
                                    Banco.SendToBack();
                                    TALKing = true;
                                    CanTryMoveAllforDIR = false;
                                    CanTryMoveAllforESQ = false;
                                    AvatarPlace.Image = ETEQUERavt;
                                    Mensagem();
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Wow!";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 2)
                                {
                                    AvatarPlace.Image = AGUSTINHOavt;
                                    Text1.Text = "Agustinho:";
                                    Text2.Text = "Eu sou Agustinho! O dono desse robo! Ele tem 50 Tera de memória RAM,";
                                    Text3.Text = "5.000 Tera de memória rigida e dois lança misseis destruidores de trabalhos!";
                                    TALK++;
                                }

                                else if (TALK == 4)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Você é um dos professores com quem eu devo lutar para passar no curso?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 6)
                                {
                                    AvatarPlace.Image = AGUSTINHOavt;
                                    Text1.Text = "Agustinho:";
                                    Text2.Text = "Sim, mas pode ter certeza que de mim você não passará... Não";
                                    Text3.Text = "enquanto eu estiver nesse robo!";
                                    TALK++;
                                }

                                else if (TALK == 8)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Se liga, esse robo tem OverClock...";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 10)
                                {
                                    AvatarPlace.Image = AGUSTINHOavt;
                                    Text1.Text = "Agustinho:";
                                    Text2.Text = "Então que vença o melhor, você tem direito de uma BCPE";
                                    Text3.Text = "(Barreira de Contenção de Professores Enraivecidos).";
                                    TALK++;
                                }

                                else if (TALK == 12)
                                {
                                    Mensagem();
                                    TALKing = false;
                                    this.Controls.Remove(GameTeacher);
                                    Chefe_Agustinho AgustFIGHT = new Chefe_Agustinho();
                                    AgustFIGHT.Show();
                                    ControlPanel.TOTALblock = true;
                                    ControlPanel.GoFront = true;
                                    ControlPanel.JogoVisibleFALSE = true;
                                    ControlPanel.MestreNumber = 3;
                                }
                            }
                        }
                        #endregion
                        #region Converso com Cleito
                        else if (GameTeacher.InitialImage == IMA_Cleito)
                        {
                            if (GameTeacher.Left - 120 < (ETEQUER.Left + ETEQUER.Width) && CP_Cleito == false)
                            {
                                CheckPoint = PLAYERpos;
                                CP_Cleito = true;
                            }

                            if (GameTeacher.Left - 90 < (ETEQUER.Left + ETEQUER.Width))
                            {
                                if (TALK == 0)
                                {
                                    Banco.SendToBack();
                                    Banco.Height = 141;
                                    Banco.Width = 109;
                                    TALKing = true;
                                    CanTryMoveAllforDIR = false;
                                    CanTryMoveAllforESQ = false;
                                    AvatarPlace.Image = CLEITOavt;
                                    Mensagem();
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Olá Etequer!";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 2)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Como.... como sabe meu nome?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 4)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Do mesmo jeito que eu sei sua idade, data de aniversario entre";
                                    Text3.Text = "outras coisas!";
                                    TALK++;
                                }

                                else if (TALK == 6)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = ":O";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 8)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Eu olhei nos registros da chamada, tem até foto lá...";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 10)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "hehehe...";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 12)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Eu sou um dos professores aliados e te ajudarei a enfrentar";
                                    Text3.Text = "o próximo chefe.";
                                    TALK++;
                                }

                                else if (TALK == 14)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Como?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 16)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Bem... Te ajudar indiretamente, te dando um item da sua escolha...";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 18)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Um item da minha escolha?!";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 20)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Sim! Sim! E esse item você guardará no banco de itens para usar somente quando";
                                    Text3.Text = "encontrar o ultimo chefe!";
                                    TALK++;
                                }

                                else if (TALK == 22)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Hum... Um item qualquer... Eu poderia pedir uma FireWall, uma Star, CD, DVD,";
                                    Text3.Text = "PenDrive ou então a BCPE... Mas, tenho outra coisa em mente...";
                                    TALK++;
                                }

                                else if (TALK == 24)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Outra coisa? Que coisa diferente de uma FireWall você vai querer?";
                                    Text3.Text = "A FireWall é o melhor item!";
                                    TALK++;
                                }

                                else if (TALK == 26)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Na verdade não! Eu quero que você me de uma arma!";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 28)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Uma arma? Uma espada?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 30)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Não... não... não... espada é muito medieval... Quero uma shotgun";
                                    Text3.Text = "com balas infinitas!";
                                    TALK++;
                                }

                                else if (TALK == 32)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Whaaaaaaa...!!! Esses alunos estão ficando cada vez mais violentos! Certo,";
                                    Text3.Text = "te darei a shotgun, mas você só poderá usa-la contra o ultimo chefe!";
                                    TALK++;
                                }

                                else if (TALK == 34)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Finalmente um pouco de ação dentro desse jogo que eu estou preso! Hehe...";
                                    Text3.Text = "Vou sair um pouco da história que o Ricardo desenvolveu... =D";
                                    TALK++;
                                }

                                else if (TALK == 36)
                                {
                                    AvatarPlace.Image = CLEITOavt;
                                    Text1.Text = "Cleito:";
                                    Text2.Text = "Verdade... de acordo com o roteiro agora você pedia uma FireWall... :S";
                                    Text3.Text = "";
                                    Banco.Image = BIused;
                                    TALK++;
                                }

                                else if (TALK == 38)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Hehehehehe... Obrigado Cleito!";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 40)
                                {
                                    Mensagem();
                                    CleitoTalk = true;
                                    TALKing = false;
                                    TALK = 0;
                                    Controls.Remove(GameTeacher);
                                }
                            }
                        }
                        #endregion
                        #region Luta com LC
                        else if (GameTeacher.InitialImage == IMA_LouisCarlos)
                        {
                            if (GameTeacher.Left - 120 < (ETEQUER.Left + ETEQUER.Width) && CP_LouisCarlos == false)
                            {
                                CheckPoint = PLAYERpos;
                                CP_LouisCarlos = true;
                            }

                            if (GameTeacher.Left - 90 < (ETEQUER.Left + ETEQUER.Width))
                            {
                                if (TALK == 0)
                                {
                                    Banco.SendToBack();
                                    TALKing = true;
                                    CanTryMoveAllforDIR = false;
                                    CanTryMoveAllforESQ = false;
                                    Mensagem();
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos";
                                    Text2.Text = "Finalmente nos encontramos, Etequer!";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 2)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Um homem armado! Ainda bem que eu pedi para o Cleito";
                                    Text3.Text = "me entregar essa ShotGun item e não uma FireWall";
                                    TALK++;
                                }

                                else if (TALK == 4)
                                {
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos:";
                                    Text2.Text = "Na verdade eu vi que você tinha pego esse item";
                                    Text3.Text = "e só me preparei...";
                                    TALK++;
                                }

                                else if (TALK == 6)
                                {
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Mas afinal, quem é você?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 8)
                                {
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos";
                                    Text2.Text = "Ora! Como assim não sabe quem sou eu?";
                                    Text3.Text = "Porém...";
                                    TALK++;
                                    ControlPanel.GoFront = true;
                                }

                                else if (TALK == 10)
                                {
                                    ControlPanel.JogoVisibleFALSE = true;
                                    Videos.WhoPlay = 5;
                                    Videos PlayLC = new Videos();
                                    PlayLC.Show();
                                    ControlPanel.GoFront = true;
                                    TALK++;
                                }

                                else if (TALK == 12)
                                {
                                    ControlPanel.GoFront = true;
                                    AvatarPlace.Image = ETEQUERavt;
                                    Text1.Text = "Etequer:";
                                    Text2.Text = "Cordenador Louis Carlos é? Então... você é  ultimo?";
                                    Text3.Text = "";
                                    TALK++;
                                }

                                else if (TALK == 14)
                                {
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos";
                                    Text2.Text = "Exato! Passando por mim você completará o curso! Nossa luta";
                                    Text3.Text = "será uma luta de armas, você poderá selecionar três opções,";
                                    TALK++;
                                }

                                else if (TALK == 16)
                                {
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos";
                                    Text2.Text = "Ataque rapido, Ataque comum e Ataque completo. Ataque rapido não";
                                    Text3.Text = "tira dano quando é usado pelos dois ou quando o inimigo usa um ataque";
                                    TALK++;
                                }

                                else if (TALK == 18)
                                {
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos";
                                    Text2.Text = "comum, porém, quando está contra um ataque completo ele tira um dano";
                                    Text3.Text = "mediano e não toma dano. O Ataque comum é o básico, tira um dano mediano";
                                    TALK++;
                                }


                                else if (TALK == 20)
                                {
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos";
                                    Text2.Text = "quando é enfrentado com outro ataque comum ou completo, ele tira um dano";
                                    Text3.Text = "minimo quando enfrenta um ataque rapido e nessa ocasião não toma dano.";
                                    TALK++;
                                }

                                else if (TALK == 22)
                                {
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos";
                                    Text2.Text = "O Ataque completo da um dano consideraval de vida, com exceção de quando";
                                    Text3.Text = "o oponente usa o ataque rapido, nesse caso o ataque completo não dá dano e";
                                    TALK++;
                                }

                                else if (TALK == 24)
                                {
                                    AvatarPlace.Image = LCavt;
                                    Text1.Text = "Louis Carlos";
                                    Text2.Text = "recebe um dano mediano. Essas são as informações necessarias";
                                    Text3.Text = "para que nossa batalha inicie!";
                                    TALK++;
                                }

                                else if (TALK == 26)
                                {
                                    ControlPanel.JogoVisibleFALSE = true;
                                    ControlPanel.MestreNumber = 4;
                                    Louis_Carlos ForthBOSS = new Louis_Carlos();
                                    ForthBOSS.Show();
                                    ControlPanel.GoFront = true;
                                    TALK++;
                                }
                            }
                        }
                        #endregion
                    }
                }
                #endregion
                #region Morte do Etequer caso caia num buraco
                if (ETEQUER.Top >= 700 && DiePig == false)
                {
                    DiePig = true;
                }
                #endregion
                #region Decrescendo FW
                if (IsFW == true && FWtime > 0)
                {
                    FWtime--;
                }

                else if (FWtime <= 0 && IsFW == true)
                {
                    FWtime = 0;
                    IsFW = false;
                }
                #endregion
            }
        }

        private void AnimationUpdater_Tick(object sender, EventArgs e)
        {
            if (ControlPanel.TOTALblock == false)
            {
                #region Executando as animações de quebra de caixa
                foreach (object OBJinGAME in this.Controls)
                {
                    if (OBJinGAME is PictureBox)
                    {
                        PictureBox GameThing = OBJinGAME as PictureBox;
                        if (GameThing.MaximumSize.Height == 998 && GameThing.MaximumSize.Width == 998)
                        {
                            if (GameThing.InitialImage == IMA_CdItem)
                            {
                                if (GameThing.Width == 60)
                                {
                                    //Aumenta o tamanho da picture para caber toda animação e envia para trás para evitar que algo suma
                                    GameThing.Width = 180;
                                    GameThing.Left = GameThing.Left - 60;
                                    GameThing.SendToBack();
                                }
                                //Animando
                                OpenBOXanimation_CD();
                                GameThing.BackgroundImage = CDanimage;
                                if (CDcount == 16)
                                {//Ajeitando a picturebox no fim da animação
                                    GameThing.Width = 60;
                                    GameThing.Left = GameThing.Left + 60;
                                    GameThing.SendToBack();
                                    GameThing.MaximumSize = new System.Drawing.Size(0, 0);
                                    GameThing.Image = CDitem;
                                    GameThing.BackgroundImage = null;
                                    CDcount = 0;
                                }
                            }
                            else if (GameThing.InitialImage == IMA_DvdItem)
                            {
                                if (GameThing.Width == 60)
                                {
                                    GameThing.Width = 180;
                                    GameThing.Left = GameThing.Left - 60;
                                    GameThing.SendToBack();
                                }
                                OpenBOXanimation_DVD();
                                GameThing.BackgroundImage = DVDanimage;
                                if (DVDcount == 16)
                                {
                                    GameThing.Width = 60;
                                    GameThing.Left = GameThing.Left + 60;
                                    GameThing.SendToBack();
                                    GameThing.MaximumSize = new System.Drawing.Size(0, 0);
                                    GameThing.Image = DVDitem;
                                    GameThing.BackgroundImage = null;
                                    DVDcount = 0;
                                }
                            }
                            else if (GameThing.InitialImage == IMA_StarItem)
                            {
                                if (GameThing.Width == 60)
                                {
                                    GameThing.Width = 180;
                                    GameThing.Left = GameThing.Left - 60;
                                    GameThing.SendToBack();
                                }
                                OpenBOXanimation_STAR();
                                GameThing.BackgroundImage = STARanimage;
                                if (STARcount == 16)
                                {
                                    GameThing.Width = 60;
                                    GameThing.Left = GameThing.Left + 60;
                                    GameThing.SendToBack();
                                    GameThing.MaximumSize = new System.Drawing.Size(0, 0);
                                    GameThing.Image = STARitem_SPR1;
                                    GameThing.BackgroundImage = null;
                                    STARcount = 0;
                                }
                            }
                            else if (GameThing.InitialImage == IMA_FwItem)
                            {
                                if (GameThing.Width == 60)
                                {
                                    GameThing.Width = 180;
                                    GameThing.Left = GameThing.Left - 60;
                                    GameThing.SendToBack();
                                }
                                OpenBOXanimation_FW();
                                GameThing.BackgroundImage = FWanimage;
                                if (FWcount == 16)
                                {
                                    GameThing.Width = 60;
                                    GameThing.Left = GameThing.Left + 60;
                                    GameThing.SendToBack();
                                    GameThing.MaximumSize = new System.Drawing.Size(0, 0);
                                    GameThing.Image = FWitem_SPR1;
                                    GameThing.BackgroundImage = null;
                                    FWcount = 0;
                                }
                            }
                            else if (GameThing.InitialImage == IMA_LifeItem)
                            {
                                if (GameThing.Width == 60)
                                {
                                    GameThing.Width = 180;
                                    GameThing.Left = GameThing.Left - 60;
                                    GameThing.SendToBack();
                                }
                                OpenBOXanimation_LIFE();
                                GameThing.BackgroundImage = LIFEanimage;
                                if (LIFEcount == 16)
                                {
                                    GameThing.Width = 60;
                                    GameThing.Left = GameThing.Left + 60;
                                    GameThing.SendToBack();
                                    GameThing.MaximumSize = new System.Drawing.Size(0, 0);
                                    GameThing.Image = LIFEitem;
                                    GameThing.BackgroundImage = null;
                                    LIFEcount = 0;
                                }
                            }
                            else if (GameThing.InitialImage == IMA_PenItem)
                            {
                                if (GameThing.Width == 60)
                                {
                                    GameThing.Width = 180;
                                    GameThing.Left = GameThing.Left - 60;
                                    GameThing.SendToBack();
                                }
                                OpenBOXanimation_PEN();
                                GameThing.BackgroundImage = PENanimage;
                                if (PENcount == 16)
                                {
                                    GameThing.Width = 60;
                                    GameThing.Left = GameThing.Left + 60;
                                    GameThing.SendToBack();
                                    GameThing.MaximumSize = new System.Drawing.Size(0, 0);
                                    GameThing.Image = PENitem;
                                    GameThing.BackgroundImage = null;
                                    PENcount = 0;
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Efeitos dos itens
                foreach (object OBJinGAME in this.Controls)
                {
                    if (OBJinGAME is PictureBox)
                    {
                        PictureBox GameThing = OBJinGAME as PictureBox;
                        //Verifica se o jogador pegou o item
                        if (ETEQUER.Left <= GameThing.Left && ETEQUER.Left + ETEQUER.Width >= GameThing.Left || ETEQUER.Left <= GameThing.Left && ETEQUER.Left + ETEQUER.Width >= GameThing.Left || GameThing.Left < ETEQUER.Left && ETEQUER.Left + ETEQUER.Width < GameThing.Left + GameThing.Width)
                        {
                            if (GameThing.Top <= ETEQUER.Top && (GameThing.Top + GameThing.Height) >= ETEQUER.Top || ETEQUER.Top < GameThing.Top && (ETEQUER.Top + ETEQUER.Height) > GameThing.Top)
                            {
                                if (GameThing.InitialImage == IMA_CdItem)
                                {
                                    //Instante
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 2;
                                    Controls.Remove(GameThing);
                                    ITEMSeff.Play();

                                    //Favorecimento ao jogador
                                    GB_points = GB_points + 0.7;

                                    //Animando o ganho
                                    Label POINTS = new Label();
                                    POINTS.Enabled = false;
                                    POINTS.TabIndex = 0;
                                    POINTS.Text = "+ 0.7 GB!";
                                    POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                    POINTS.Left = 175;
                                    POINTS.Top = ETEQUER.Top - 5;
                                    POINTS.SendToBack();
                                    this.Controls.Add(POINTS);
                                }

                                else if (GameThing.InitialImage == IMA_DvdItem)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 2;
                                    Controls.Remove(GameThing);
                                    ITEMSeff.Play();

                                    GB_points = GB_points + 4.7;

                                    //Animando o ganho
                                    Label POINTS = new Label();
                                    POINTS.Enabled = false;
                                    POINTS.TabIndex = 0;
                                    POINTS.Text = "+ 4.7 GB!";
                                    POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                    POINTS.Left = 175;
                                    POINTS.Top = ETEQUER.Top - 5;
                                    POINTS.SendToBack();
                                    this.Controls.Add(POINTS);
                                }

                                else if (GameThing.InitialImage == IMA_FwItem)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 2;
                                    Controls.Remove(GameThing);
                                    FWeff.Play();

                                    IsFW = true;
                                    FWtime = 1200;

                                    //Animando o ganho
                                    Label POINTS = new Label();
                                    POINTS.Enabled = false;
                                    POINTS.TabIndex = 0;
                                    POINTS.Text = "FireWall ativada!";
                                    POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                    POINTS.Left = 140;
                                    POINTS.Top = ETEQUER.Top - 5;
                                    POINTS.SendToBack();
                                    this.Controls.Add(POINTS);
                                }

                                else if (GameThing.InitialImage == IMA_LifeItem)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 2;
                                    Controls.Remove(GameThing);
                                    LIFEeff.Play();

                                    Vidas++;

                                    //Animando o ganho
                                    Label POINTS = new Label();
                                    POINTS.Enabled = false;
                                    POINTS.TabIndex = 0;
                                    POINTS.Text = "Vida!";
                                    POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                    POINTS.Left = 175;
                                    POINTS.Top = ETEQUER.Top - 5;
                                    POINTS.SendToBack();
                                    this.Controls.Add(POINTS);
                                }

                                else if (GameThing.InitialImage == IMA_PenItem)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 2;
                                    Controls.Remove(GameThing);
                                    ITEMSeff.Play();

                                    //Randomizando a pontuação
                                    PENrand = PENpoints.Next(3);
                                    if (PENrand == 0)
                                    {
                                        GB_points = GB_points + 1;

                                        //Animando o ganho
                                        Label POINTS = new Label();
                                        POINTS.Enabled = false;
                                        POINTS.TabIndex = 0;
                                        POINTS.Text = "+ 1.0 GB!";
                                        POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                        POINTS.Left = 175;
                                        POINTS.Top = ETEQUER.Top - 5;
                                        POINTS.SendToBack();
                                        this.Controls.Add(POINTS);
                                    }
                                    else if (PENrand == 1)
                                    {
                                        GB_points = GB_points + 2;

                                        //Animando o ganho
                                        Label POINTS = new Label();
                                        POINTS.Enabled = false;
                                        POINTS.TabIndex = 0;
                                        POINTS.Text = "+ 2.0 GB!";
                                        POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                        POINTS.Left = 175;
                                        POINTS.Top = ETEQUER.Top - 5;
                                        POINTS.SendToBack();
                                        this.Controls.Add(POINTS);
                                    }
                                    else if (PENrand == 2)
                                    {
                                        GB_points = GB_points + 4;

                                        //Animando o ganho
                                        Label POINTS = new Label();
                                        POINTS.Enabled = false;
                                        POINTS.TabIndex = 0;
                                        POINTS.Text = "+ 4.0 GB!";
                                        POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                        POINTS.Left = 175;
                                        POINTS.Top = ETEQUER.Top - 5;
                                        POINTS.SendToBack();
                                        this.Controls.Add(POINTS);
                                    }
                                    else if (PENrand == 3)
                                    {
                                        GB_points = GB_points + 8;

                                        //Animando o ganho
                                        Label POINTS = new Label();
                                        POINTS.Enabled = false;
                                        POINTS.TabIndex = 0;
                                        POINTS.Text = "+ 8.0 GB!";
                                        POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                        POINTS.Left = 175;
                                        POINTS.Top = ETEQUER.Top - 5;
                                        POINTS.SendToBack();
                                        this.Controls.Add(POINTS);
                                    }
                                }
                                else if (GameThing.InitialImage == IMA_StarItem)
                                {
                                    SituacaoDOSitems[int.Parse(GameThing.Name)] = 2;
                                    Controls.Remove(GameThing);
                                    STAReff.Play();

                                    LifeBAR.Enabled = true;

                                    //Animando o ganho
                                    Label POINTS = new Label();
                                    POINTS.Enabled = false;
                                    POINTS.TabIndex = 0;
                                    POINTS.Text = "Vida!";
                                    POINTS.Font = new System.Drawing.Font("Comic Sans MS", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                    POINTS.Left = 175;
                                    POINTS.Top = ETEQUER.Top - 5;
                                    POINTS.SendToBack();
                                    this.Controls.Add(POINTS);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Executando as animações de itens
                //Anima itens como FireWall e estrela
                foreach (object PICinGAME in this.Controls)
                {
                    if (PICinGAME is PictureBox)
                    {
                        PictureBox GameThing = PICinGAME as PictureBox;
                        if (GameThing.InitialImage == IMA_FwItem)
                        {
                            if (GameThing.Image == FWitem_SPR1)
                            {
                                GameThing.Image = FWitem_SPR2;
                            }
                            else if (GameThing.Image == FWitem_SPR2)
                            {
                                GameThing.Image = FWitem_SPR1;
                            }
                        }
                        else if (GameThing.InitialImage == IMA_StarItem)
                        {
                            if (GameThing.Image == STARitem_SPR1)
                            {
                                GameThing.Image = STARitem_SPR2;
                            }
                            else if (GameThing.Image == STARitem_SPR2)
                            {
                                GameThing.Image = STARitem_SPR1;
                            }
                        }
                    }
                }
                #endregion
                #region Animando a subida da escrita sobre a pontuação até que ela suma
                foreach (object OBJinGAME in this.Controls)
                {
                    if (OBJinGAME is Label)
                    {
                        Label GameThing = OBJinGAME as Label;
                        if (GameThing.Enabled == false)
                        {
                            GameThing.ForeColor = Color.Green;
                            if (GameThing.TabIndex > 20)
                            {
                                Controls.Remove(GameThing);
                            }

                            else
                            {
                                GameThing.Top = ETEQUER.Top - (ControlPanel.VELOCIDADE / 2) * GameThing.TabIndex;
                                GameThing.TabIndex = GameThing.TabIndex + 1;
                            }
                        }
                    }
                }
                #endregion
                #region Reenchendo a vida se pedir
                if (LifeBAR.Enabled == true)
                {
                    Porcent_of_Life = 100;
                    if (LifeBAR.Width == 500)
                    {
                        LifeBAR.Enabled = false;
                    }
                    else if (LifeBAR.Width >= 480)
                    {
                        LifeBAR.Width = 500;
                    }
                    else if (LifeBAR.Width < 480)
                    {
                        LifeBAR.Width = LifeBAR.Width + 20;
                    }
                }
                #endregion
            }
        }

        private void SlowAnimation_Tick(object sender, EventArgs e)
        {
            if (ControlPanel.TOTALblock == false)
            {
                #region Animação dos aliados e chefes
                foreach (object OBJinGAME in this.Controls)
                {
                    if (OBJinGAME is PictureBox)
                    {
                        PictureBox GameTeacher = OBJinGAME as PictureBox;
                        #region Roza
                        if (GameTeacher.BackgroundImage == Roza1)
                        {
                            GameTeacher.BackgroundImage = Roza2;
                        }

                        else if (GameTeacher.BackgroundImage == Roza2)
                        {
                            GameTeacher.BackgroundImage = Roza3;
                        }

                        else if (GameTeacher.BackgroundImage == Roza3)
                        {
                            GameTeacher.BackgroundImage = Roza2x2;
                        }

                        else if (GameTeacher.BackgroundImage == Roza2x2)
                        {
                            GameTeacher.BackgroundImage = Roza1;
                        }
                        #endregion
                        #region Marcelu
                        if (GameTeacher.InitialImage == IMA_Marcelu_Friend || GameTeacher.InitialImage == IMA_Marcelu_Boss)
                        {
                            if (GameTeacher.AccessibleName == "40")
                            {
                                GameTeacher.AccessibleName = "0";
                                GameTeacher.BackgroundImage = MarceluCE;
                            }
                            else
                            {
                                //Esse inteiro vai carregar o numero do chefe e soma-lo a 1 depois será convertida
                                int BossNumber = int.Parse(GameTeacher.AccessibleName) + 1;
                                GameTeacher.AccessibleName = BossNumber.ToString();
                                GameTeacher.BackgroundImage = MarceluOE;
                            }
                        }
                        #endregion
                        #region Muacir
                        if (GameTeacher.BackgroundImage == Muacir1)
                        {
                            if (PiscouMua == false)
                            {
                                GameTeacher.BackgroundImage = Muacir2_1;
                                PiscouMua = true;
                            }

                            else if (PiscouMua == true)
                            {
                                GameTeacher.BackgroundImage = Muacir2_2;
                                PiscouMua = false;
                            }
                        }

                        else if (GameTeacher.BackgroundImage == Muacir2_1 || GameTeacher.BackgroundImage == Muacir2_2)
                        {
                            GameTeacher.BackgroundImage = Muacir3;
                        }

                        else if (GameTeacher.BackgroundImage == Muacir3)
                        {
                            GameTeacher.BackgroundImage = Muacir4;
                        }

                        else if (GameTeacher.BackgroundImage == Muacir4)
                        {
                            GameTeacher.BackgroundImage = Muacir1;
                        }
                        #endregion
                        #region Agustinho
                        if (GameTeacher.InitialImage == IMA_Agustinho)
                        {
                            if (GameTeacher.AccessibleName == "0")
                            {
                                GameTeacher.BackgroundImage = Agustinho_01;
                                GameTeacher.AccessibleName = "1";
                            }

                            else if (GameTeacher.AccessibleName == "1")
                            {
                                GameTeacher.BackgroundImage = Agustinho_02;
                                GameTeacher.AccessibleName = "2";
                            }

                            else if (GameTeacher.AccessibleName == "2")
                            {
                                GameTeacher.BackgroundImage = Agustinho_03;
                                GameTeacher.AccessibleName = "3";
                            }

                            else if (GameTeacher.AccessibleName == "3")
                            {
                                GameTeacher.BackgroundImage = Agustinho_02;
                                GameTeacher.AccessibleName = "0";
                            }
                        }
                        #endregion
                    }
                }
                #endregion
            }
        }

        private void ETERdie_animation_Tick(object sender, EventArgs e)
        {
            #region Animando a morte do etequer
            //Num fica assim não.... =/
            //Sako a piada? Essa região é a "Animando a morte do etequer", to te animando por que o Etequer morreu.... ¬¬'
            if (DiePig == true)
            {
                if (KillANIM == 0)
                {
                    ControlPanel.TOTALblock = true;
                    ETERdie_animation.Interval = 300;
                    CanTryMoveAllforDIR = false;
                    CanTryMoveAllforESQ = false;
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 1)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 2)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 3)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 4)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 5)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 6)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    ETERdie_animation.Interval = 60;
                    KillANIM++;
                }

                else if (KillANIM == 7)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 8)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 9)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 10)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 11)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 12)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    ETERdie_animation.Interval = 30;
                    KillANIM++;
                }

                else if (KillANIM == 13)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 14)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 15)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 16)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 17)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 18)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    ETERdie_animation.Interval = 50;
                    KillANIM++;
                }

                else if (KillANIM == 19)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 20)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 21)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 22)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    KillANIM++;
                }

                else if (KillANIM == 23)
                {
                    ETEQUER.BackgroundImage = ETECdie_2;
                    KillANIM++;
                }

                else if (KillANIM == 24)
                {
                    ETEQUER.BackgroundImage = ETECdie_1;
                    ETERdie_animation.Interval = 15;
                    GuiLL.Play();
                    KillANIM++;
                }

                else if (KillANIM == 25)
                {
                    ETEQUER.BackgroundImage = ETECdie_3;
                    KillANIM++;
                }

                else if (KillANIM == 26)
                {
                    ETEQUER.BackgroundImage = ETECdie_4;
                    KillANIM++;
                }

                else if (KillANIM == 27)
                {
                    ETEQUER.BackgroundImage = ETECdie_3;
                    KillANIM++;
                }

                else if (KillANIM == 28)
                {
                    ETEQUER.BackgroundImage = ETECdie_4;
                    KillANIM++;
                }

                else if (KillANIM == 29)
                {
                    ETEQUER.BackgroundImage = ETECdie_3;
                    KillANIM++;
                }

                else if (KillANIM == 30)
                {
                    ETEQUER.BackgroundImage = ETECdie_4;
                    KillANIM++;
                }

                else if (KillANIM == 31)
                {
                    ETEQUER.BackgroundImage = ETECdie_3;
                    KillANIM++;
                }

                else if (KillANIM == 32)
                {
                    ETEQUER.BackgroundImage = ETECdie_4;
                    KillANIM++;
                    GuiLL.Play();
                }


                else if (KillANIM == 33)
                {
                    ETEQUER.BackgroundImage = ETECdie_5;
                    KillANIM++;
                }


                else if (KillANIM == 34)
                {
                    ETEQUER.BackgroundImage = ETECdie_6;
                    KillANIM++;
                }

                else if (KillANIM == 35)
                {
                    Vidas--;
                    if (Vidas < 0)
                    {
                        Videos.WhoPlay = 7;
                        Videos GameOver = new Videos();
                        ControlPanel.GoFront = true;
                        this.Close();
                        Fundo.KILL = true;
                        GameOver.Show();
                    }
                    else
                    {
                        SOMETUDO();
                        ETEQUER.Top = 280;
                        LifeBAR.Enabled = true;
                        KillANIM = 0;
                        DiePig = false;
                        ETEQUER.BackgroundImage = Etequer2_DIR;
                        ETERdie_animation.Interval = 120;
                        C_POINTED = false;
                        FirstDeclaration = false;
                        
                    }
                    ControlPanel.TOTALblock = false;
                }
            }
            #endregion
        }

        private void cheat_KeyDown(object sender, KeyEventArgs e)
        {
            #region CHeats
            if (e.KeyCode == Keys.Enter)
            {
                ControlPanel.GoFront = true;
                if (cheat.Text == "!PMUJDNAOG")
                {
                    if (Hpulo == 13)
                    {
                        MainMenu.WhenSelectOption.Play();
                        Hpulo = 23;
                    }
                    else if (Hpulo == 23)
                    {
                        Chefe_Marcelu.AquaSONG.Play();
                        Hpulo = 13;
                    }
                }

                else if (cheat.Text == "!YLFDNAOG")
                {
                    if (Hpulo == 13)
                    {
                        MainMenu.WhenSelectOption.Play();
                        Hpulo = 900000;
                    }
                    else if (Hpulo == 900000)
                    {
                        Chefe_Marcelu.AquaSONG.Play();
                        Hpulo = 13;
                    }
                }

                else if (cheat.Text == "CHECKAZOR")
                {
                    MainMenu.WhenSelectOption.Play();
                    CheckPoint = 50;
                }

                else if (cheat.Text == "TORRETALK")
                {
                    MainMenu.WhenSelectOption.Play();
                    CheckPoint = 3600;
                }

                else if (cheat.Text == "TORREFIGHT")
                {
                    MainMenu.WhenSelectOption.Play();
                    CheckPoint = 6120;
                }

                else if (cheat.Text == "ORRAGIC")
                {
                    MainMenu.WhenSelectOption.Play();
                    CheckPoint = 8820;
                }

                else if (cheat.Text == "ESABATAD")
                {
                    MainMenu.WhenSelectOption.Play();
                    CheckPoint = 11040;
                }

                else if (cheat.Text == "J.PRESMA")
                {
                    MainMenu.WhenSelectOption.Play();
                    CheckPoint = 14340;
                }

                else if (cheat.Text == "JOGO!!!")
                {
                    MainMenu.WhenSelectOption.Play();
                    CheckPoint = 16980;
                }

                else if (cheat.Text == "KCEHCSIOUL")
                {
                    MainMenu.WhenSelectOption.Play();
                    CheckPoint = 19680;
                }

                else if (cheat.Text == "ARTXEADIV")
                {
                    MainMenu.WhenSelectOption.Play();
                    Vidas++;
                }

                else if (cheat.Text == "ADIVEHCNE")
                {
                    MainMenu.WhenSelectOption.Play();
                    LifeBAR.Enabled = true;
                }

                else if (cheat.Text == "OGOFAGEP")
                {
                    MainMenu.WhenSelectOption.Play();
                    IsFW = true;
                    FWtime = 1200;
                }

                else if (cheat.Text == "EMAGDNE")
                {
                    MainMenu.WhenSelectOption.Play();
                    Register BD_Access = new Register();
                    BD_Access.BringToFront();
                    BD_Access.Show();
                }

                else
                {
                    Chefe_Marcelu.MadeWrong.Play();
                }
                ControlPanel.CHEAT = false;
                ControlPanel.PAUSEblock = false;
                ControlPanel.TOTALblock = false;
                cheat.Text = "";
            }
            #endregion
        }
    }
}