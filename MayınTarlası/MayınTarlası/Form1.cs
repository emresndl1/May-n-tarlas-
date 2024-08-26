using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayınTarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            butonUret();
        }

        private void butonUret()
        {
            flowLayoutPanel1.Controls.Clear();

            Random rnd = new Random();
            List<int> mayinlar = new List<int>();
            while (mayinlar.Count < 5)
            {
                int sayi = rnd.Next(1, 53);
                if (!mayinlar.Contains(sayi))
                {
                    mayinlar.Add(sayi);
                }
            }

            for (int i = 1; i < 53; i++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(33, 34);
                btn.Text = i.ToString();
                flowLayoutPanel1.Controls.Add(btn);
                if (mayinlar.Contains(i))
                {
                    btn.Tag = true;
                }
                else
                {
                    btn.Tag = false;
                }
                btn.Click += Btn_Clik;
            }
        }

         int seçilen = 0;
         int bulunan = 0;

        private void Btn_Clik(object sender , EventArgs e) 
        {

            Button basilanButon = (Button)sender;
            bool mayin = (bool)basilanButon.Tag;

            seçilen++;

            if (mayin)
            {
                basilanButon.BackColor = Color.Red;
                basilanButon.Enabled = false;
                MessageBox.Show("Mayın Bulundu !","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bulunan++;
                seçilen--;
            }
            else
            {
                basilanButon.BackColor= Color.Green;
                basilanButon.Enabled = false;
            }
            textBox1.Text = seçilen.ToString();
            textBox2.Text = bulunan.ToString();
            if (bulunan>=5)
            {
               DialogResult res =  MessageBox.Show("Bütün Mayınlar imha edildi. Devam etmek istiyormusun ?","",MessageBoxButtons.YesNo,MessageBoxIcon.None);
                if (res==DialogResult.Yes)
                {
                    butonUret();
                    bulunan = 0;
                    seçilen = 0;
                }
            }
        }


    }
}
