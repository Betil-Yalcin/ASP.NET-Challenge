using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SiparisYonetimServisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SiparisYonetimEntities db = new SiparisYonetimEntities();

        private void button_Listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TABLO_FIRMA
                                        select new
                                        {
                                            x.ID,
                                            x.FIRMAAD,
                                            x.ONAYDURUM,
                                            x.IZBAS,
                                            x.IZBIT,
                                        }).ToList();
        }

        private void button_Ekleme_Click(object sender, EventArgs e)
        {
            TABLO_FIRMA d = new TABLO_FIRMA();
            d.FIRMAAD = textBox2.Text;
            if (radioButton1.Checked == true)
            {
                d.ONAYDURUM = true;
            }
            else if (radioButton2.Checked == true)
            {
                d.ONAYDURUM = false;
            }
            d.IZBAS = TimeSpan.Parse(maskedTextBox1.Text);
            d.IZBIT = TimeSpan.Parse(maskedTextBox2.Text);
            db.TABLO_FIRMA.Add(d);
            db.SaveChanges();
            MessageBox.Show("Firma Sisteme Kaydedildi");
        }

        private void button_Guncelleme_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var firma = db.TABLO_FIRMA.Find(x);
            firma.FIRMAAD = textBox2.Text;
            firma.IZBAS = TimeSpan.Parse(maskedTextBox1.Text);
            firma.IZBIT = TimeSpan.Parse(maskedTextBox2.Text);
            db.SaveChanges();
            MessageBox.Show("Firma Guncellendi");
        }

        

        private void button_Ekle_Click(object sender, EventArgs e)
        {
            TABLO_URUN d = new TABLO_URUN();
            d.ID = int.Parse(textBox6.Text);
            d.URUNAD = textBox5.Text;
            d.STOK = int.Parse(textBox3.Text);
            d.FIYAT = decimal.Parse(textBox4.Text);
            d.FIRMAID = int.Parse(comboBox1.SelectedValue.ToString());
            db.TABLO_URUN.Add(d);
            db.SaveChanges();
            MessageBox.Show("Urun Sisteme Eklendi");
        }

        private void button_Olustur_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                TABLO_SIPARIS d = new TABLO_SIPARIS();
                d.ID = int.Parse(textBox9.Text);
                d.URUNID = int.Parse(comboBox3.SelectedValue.ToString());

                d.FIRMAID = int.Parse(comboBox2.SelectedValue.ToString());
                d.MUSTERIAD = textBox8.Text;
                d.MUSTERISOYAD = textBox7.Text;
                d.SIPARISTARIH = DateTime.Parse(dateTimePicker1.Text);
                db.TABLO_SIPARIS.Add(d);
                db.SaveChanges();
                MessageBox.Show("Siparis Sisteme Eklendi");
            }

            else
            {
                MessageBox.Show("Firma Onayli Degil");
            }
            TimeSpan t1 = new TimeSpan(08, 30, 00);
            TimeSpan t2 = new TimeSpan(11, 00, 00);

            if (TimeSpan.Parse(maskedTextBox1.Text) <= t1 && TimeSpan.Parse(maskedTextBox2.Text) >= t2)
            {
                TABLO_SIPARIS d = new TABLO_SIPARIS();
                d.ID = int.Parse(textBox9.Text);
                d.URUNID = int.Parse(comboBox3.SelectedValue.ToString());

                d.FIRMAID = int.Parse(comboBox2.SelectedValue.ToString());
                d.MUSTERIAD = textBox8.Text;
                d.MUSTERISOYAD = textBox7.Text;
                d.SIPARISTARIH = DateTime.Parse(dateTimePicker1.Text);
                db.TABLO_SIPARIS.Add(d);
                db.SaveChanges();
                MessageBox.Show("Siparis Sisteme Eklendi");
            }
            else
            {
                MessageBox.Show("Firma Su Anda Siparis Almiyor");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var Firmalar = (from x in db.TABLO_FIRMA
                            select new
                            {
                                x.ID,
                                x.FIRMAAD,
                            }).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "FIRMAAD";
            comboBox1.DataSource = Firmalar;

            comboBox2.ValueMember = "ID";
            comboBox2.DisplayMember = "FIRMAAD";
            comboBox2.DataSource = Firmalar;

            var Urunler = (from x in db.TABLO_URUN
                           select new
                           {
                               x.ID,
                               x.URUNAD,
                           }).ToList();
            comboBox3.ValueMember = "ID";
            comboBox3.DisplayMember = "URUNAD";
            comboBox3.DataSource = Urunler;
        }
    }
}
