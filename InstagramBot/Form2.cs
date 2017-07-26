using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.IO;

namespace InstagramBot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader oku = new StreamReader(openFileDialog1.FileName);
                string satir = oku.ReadLine();
                while (satir != null)
                {
                    listBox1.Items.Add(satir);
                    satir = oku.ReadLine();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        string isim;
        int sinir;
        int tutulan;
        int tutulan2, tutulan3;
        string van, tu,tri;
        public int r1()
        {
            Random rnd = new Random();
            tutulan = rnd.Next(0, sinir);
            //an = tutulan;
            return tutulan;
            
        }
        public int r2()
        {
            Random rnd2 = new Random();
            tutulan2 = rnd2.Next(0, sinir);
            
            return tutulan2;
        }
        public int r3()
        {
            Random rnd3 = new Random();
            tutulan3 = rnd3.Next(1000, 999999);
            return tutulan3;

        }
        int isimsayisi = 0;
        string vo = "", vu = "",ku="";
        private void button3_Click(object sender, EventArgs e)
        {
            sinir = listBox1.Items.Count;
            for (int i = 0; i < (sinir*sinir-1); i++)
            {
                van = "";
                tu = "";
                tri = "";
                van = listBox1.Items[r1()].ToString();
                tu = listBox1.Items[r2()].ToString();
                while (van == tu)
                {
                    van = listBox1.Items[r1()].ToString();
                    tu = listBox1.Items[r2()].ToString();
                }
                tri = van + " " + tu;
                listBox2.Items.Add(tri);
                label2.Text = isimsayisi.ToString();
                isimsayisi++;
            }
            for (int i = 0; i < (sinir * sinir - 1); i++)
            {
                vo = "";
                vu = "";
                ku = "";
                vo = listBox1.Items[r1()].ToString();
                vu = r3().ToString();
                ku = vo+""+vu;
                while (textBox1.Text==ku)
                {
                    vo = listBox1.Items[r1()].ToString();
                    vu = r3().ToString();
                    ku = vo + "" + vu;
                }

                listBox3.Items.Add(ku);
                label4.Text = listBox3.Items.Count.ToString();
                textBox1.Text=ku;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String[] isimsoyisim = new String[listBox2.Items.Count];
            String[] kullaniciadi = new String[listBox3.Items.Count];

            listBox2.Items.CopyTo(isimsoyisim, 0);
            System.IO.File.WriteAllLines("isimvesoyisimler.txt", isimsoyisim);

            listBox3.Items.CopyTo(kullaniciadi, 0);
            System.IO.File.WriteAllLines("kullaniciadlari.txt", kullaniciadi);
            System.Diagnostics.Process.Start(Application.StartupPath);
            MessageBox.Show("İsim ve soyisimler : isimvesoyisimler.txt    Kullanıcı Adları: kullaniciadlari.txt");
            
        }
    }
}
