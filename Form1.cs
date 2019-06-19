using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _130603Win_FormMayınTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int skor = 0;
        void MayinDoldur(int mayin, int kareler)
        {

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Width = kareler * 35;
            flowLayoutPanel1.Height = kareler * 35;

            int[] mayinlar = new int[mayin];
            Random rst = new Random();
            for (int i = 0; i < mayin; i++)
            {
                int secilen = rst.Next(0, kareler * kareler);

                if (mayinlar.Contains(secilen))
                {
                    i--;
                    continue;
                }
                mayinlar[i] = secilen;

            }

            for (int i = 0; i < kareler * kareler; i++)
            {
                Button kare = new Button();
                kare.Width = kare.Height = 35;
                kare.Margin = new Padding(0);
                kare.Tag = mayinlar.Contains(i);
                kare.Click += kare_Click;
                flowLayoutPanel1.Controls.Add(kare);
            }

        }

        void kare_Click(object sender, EventArgs e)
        {
            Button tiklanan = (Button)sender;
            bool durum = (bool)tiklanan.Tag;
            if (durum == true)
            {
                tiklanan.BackColor = Color.Red;
                OyunBitir();
            }
            else
            {
                tiklanan.BackColor = Color.Green;
                skor++;
                textBox1.Text = skor.ToString();
            }
        }
        void OyunBitir()
        {

            foreach (Button item in flowLayoutPanel1.Controls)
            {
                bool durum = (bool)item.Tag;

                if (durum == true)
                {
                    item.BackColor = Color.Red;

                }
                else
                {
                    item.BackColor = Color.Green;
                    skor = 0;
                }

            }

            DialogResult sonuc = MessageBox.Show("Tekrar Oynamak İster Misiniz?", "Mayın Tarlası", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                MayinDoldur(10, 10);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MayinDoldur(10, 10);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
