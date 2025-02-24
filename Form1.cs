using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory
{
    public partial class Form1 : Form
    {
        enum ModoJogo
        {
            Normal,
            Dificil
        }

        ModoJogo modoAtual = ModoJogo.Normal;
        int[,] jogoNormal;
        int[,] jogoDificil;
        PictureBox c1;
        PictureBox c2;
        int iguais;
        int tentativas;
        int tempoTotal = 30;
        int contagemRegressiva;
        bool gameover = false;



        public Form1()
        {
            InitializeComponent();
            IniciarJogoNormal();
        }
        private void LimparPictureBoxes()
        {
            //remove as picture box para poder colocar as novas após embaralhar
            foreach (Control control in Controls.OfType<PictureBox>().ToList())
            {
                Controls.Remove(control);
                control.Dispose();
            }
        }

        private void IniciarJogoNormal()
        {
            //limpa o espaço ocupado pelas cartas anteriores
            LimparPictureBoxes();
            SoundPlayer player = new SoundPlayer($"audio/tema.wav");
            player.Play();

            int[] cartas = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
            Misturar(cartas);
            jogoNormal = new int[4, 3];
            int tamanhoCarta = 50;
            int espaçamento = 60;
            int margemEsquerda = 20;
            int margemSuperior = 20;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.BackgroundImage = Image.FromFile($"cartas/bloco.png");
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = pictureBox.Height = tamanhoCarta;
                    pictureBox.Left = margemEsquerda + j * espaçamento;
                    pictureBox.Top = margemSuperior + i * espaçamento;
                    pictureBox.Click += PictureBox_Click;
                    pictureBox.Tag = cartas[i * 3 + j];
                    Controls.Add(pictureBox);
                    jogoNormal[i, j] = cartas[i * 3 + j];
                }
            }

            contagemRegressiva = tempoTotal;
            timer1.Start();

        }

        



        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (gameover)
                return;

            PictureBox pictureBox = sender as PictureBox;
            int valor = (int)pictureBox.Tag;

            //checa quais cartas foram viradas
            if (pictureBox.Image != null || (c1 != null && c1 == pictureBox))
                return;

            //checa se a primeira carta foi selecionada
            if (c1 == null)
            {
                c1 = pictureBox;
                c1.Image = Image.FromFile($"cartas/{valor}.png");
                c1.BackgroundImage = null;
            }
            else if (c2 == null) //checa se a segunda carta foi selecionada
            {
                c2 = pictureBox;
                c2.Image = Image.FromFile($"cartas/{valor}.png");
                c2.BackgroundImage = null;

                //checa se as cartas são iguais
                if ((int)c1.Tag == (int)c2.Tag)
                {
                    c1 = c2 = null;
                    iguais++;
                    if (iguais == 6 && modoAtual == ModoJogo.Normal)
                    {
                        Fim("Você ganhou!");
                    }
                    else if (iguais == 8 && modoAtual == ModoJogo.Dificil)
                    {
                        Fim("Você ganhou!");
                    }
                }
                else
                {
                    tentativas++;
                    txtPontos.Text = $"{tentativas}";
                    Task.Delay(100).ContinueWith((continua) =>
                    {
                        c1.Image = c2.Image = null;
                        c1.BackgroundImage = c2.BackgroundImage = Image.FromFile($"cartas/bloco.png");
                        c1 = c2 = null;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }

        }

        private void IniciarJogoDificil()
        {
            //limpa o espaço ocupado pelas cartas anteriores
            LimparPictureBoxes();
            SoundPlayer player = new SoundPlayer($"audio/tema_dificil.wav");
            player.Play();

            int[] cartas = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
            Misturar(cartas);
            jogoDificil = new int[4, 4];
            int tamanhoCarta = 50;
            int espaçamento = 60;
            int margemEsquerda = 20;
            int margemSuperior = 20;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.BackgroundImage = Image.FromFile($"cartas/bloco.png");
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = pictureBox.Height = tamanhoCarta;
                    pictureBox.Left = margemEsquerda + j * espaçamento;
                    pictureBox.Top = margemSuperior + i * espaçamento;
                    pictureBox.Click += PictureBox_Click;

                    //coloca os valores embaralhados na picture box
                    int index = i * 4 + j;
                    pictureBox.Tag = cartas[index];
                    Controls.Add(pictureBox);
                    jogoDificil[i, j] = cartas[index];
                }
            }
        }

     

        private void Reiniciar()
        {
            //reinicia o jogo
            tentativas = iguais = 0;
            VirarCartasParaBaixo();

            gameover = false;

            switch (modoAtual)
            {
                case ModoJogo.Normal:
                    IniciarJogoNormal();
                    break;
                case ModoJogo.Dificil:
                    IniciarJogoDificil();
                    break;
                default:
                    break;
            }

            //reinicia o tempo
            tentativas = 0;
            txtPontos.Text = $"{tentativas}";
            contagemRegressiva = tempoTotal;
            timer1.Start();
        }
        private void VirarCartasParaBaixo()
        {
            //vira todas as cartas para baixo
            foreach (Control control in Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    pictureBox.Image = null;
                    pictureBox.BackgroundImage = Image.FromFile($"cartas/bloco.png");
                }
            }
        }


        private void Fim(String mensagem)
        {
            //final bom
            SoundPlayer player = new SoundPlayer($"audio/vitoria.wav");
            player.Play();
            timer1.Stop();
            gameover = true;
            MessageBox.Show($"{mensagem} Clique em Reiniciar para jogar novamente!", "Fim");
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        private void btnModoNormal_Click(object sender, EventArgs e)
        {
            modoAtual = ModoJogo.Normal;
            Reiniciar();
        }

        private void btnModoDificil_Click(object sender, EventArgs e)
        {
            modoAtual = ModoJogo.Dificil;
            Reiniciar();
        }

        private void Misturar(int[] array)
        {
            //embaralha as cartas
            Random x = new Random();
            int n = array.Length;
            while (n > 0)
            {
                n--;
                int y = x.Next(n + 1);
                int temp = array[y];
                array[y] = array[n];
                array[n] = temp;
            }
        }

        private void lblTempo_Click(object sender, EventArgs e)
        {
           //final ruim
            contagemRegressiva--;
            lblTempo.Text = $"Tempo Restante: {contagemRegressiva}";
            if (contagemRegressiva == 0)
            {  
                timer1.Stop();
                SoundPlayer player = new SoundPlayer($"audio/perdeu.wav");
                player.Play();
                MessageBox.Show("Acabou o tempo.", "FIM");
                
                gameover = true;
                
            }
        }

        private void txtPontos_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPontos_Click(object sender, EventArgs e)
        {

        }
    }
}
