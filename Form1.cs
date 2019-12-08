using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {

        public int velocidade_esquerda = 4;
        public int velocidade_topo = 4;
        public int pontos = 0;


        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            raquete.Top = playground.Bottom - (playground.Bottom / 10);

            lblFimDeJogo.Left = (playground.Width / 2) - (lblFimDeJogo.Width / 2);
            lblFimDeJogo.Top = (playground.Height / 2) - (lblFimDeJogo.Height / 2);
            lblFimDeJogo.Visible = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            raquete.Left = Cursor.Position.X - (raquete.Width / 2);

            bola.Left += velocidade_esquerda;
            bola.Top += velocidade_topo;

            if (bola.Bottom >= raquete.Top && bola.Bottom <= raquete.Bottom && bola.Left >= raquete.Left && bola.Right <= raquete.Right)
            {
                velocidade_topo += 2;
                velocidade_esquerda += 2;
                velocidade_topo = -velocidade_topo;
                pontos += 1;
                lblPontos.Text = pontos.ToString();

                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
            }

            if(bola.Left <= playground.Left)
            {
                velocidade_esquerda = -velocidade_esquerda;
            }
            if(bola.Right >= playground.Right)
            {
                velocidade_esquerda = -velocidade_esquerda;
            }
            if(bola.Top <= playground.Top)
            {
                velocidade_topo = -velocidade_topo;
            }
            if (bola.Bottom >= playground.Bottom)
            {
                timer.Enabled = false;
                lblFimDeJogo.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if(e.KeyCode == Keys.F1)
            {
                bola.Top = 50;
                bola.Left = 50;
                velocidade_esquerda = 4;
                velocidade_topo = 4;
                pontos = 0;
                playground.BackColor = Color.White;
                timer.Enabled = true;
                lblFimDeJogo.Visible = false;
            }
        }
    }
}
