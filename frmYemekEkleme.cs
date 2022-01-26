using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YemekTarifi
{
    public partial class frmYemekEkleme : Form
    {
        public frmYemekEkleme()
        {
            InitializeComponent();
        }

        Sınıflar.Yemek yemek = new Sınıflar.Yemek();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6CF2A79;Initial Catalog=eminproje;Integrated Security=True");
        private void btnYemekEklemeYemekEkle_Click(object sender, EventArgs e)
        {
            yemek.yemekAdi = txtYemekEklemeYemekAdi.Text;
            baglanti.Open();
            SqlCommand ekleme = new SqlCommand("insert into Yemek (YemekAdi) values (@p1)", baglanti);
            ekleme.Parameters.AddWithValue("@p1", yemek.yemekAdi);
            ekleme.ExecuteNonQuery();

            SqlCommand command = new SqlCommand("Select *from Yemek where YemekAdi='" + yemek.yemekAdi + "'", baglanti);
           SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                lbYemeklerVeMalzemeler.Items.Add(yemek.yemekAdi);
                MessageBox.Show("Yemek Eklendi");

            }
            else
            {
                MessageBox.Show("Hata\nTekrar Deneyiniz.");
                
            }

            baglanti.Close();

            
            
        }

        private void btnYemekEkleMalzemeEkle_Click(object sender, EventArgs e)
        {    
            yemek.malzemeAdi = txtYemekEklemeMalzemeler.Text;
            baglanti.Open();
            SqlCommand ekleme = new SqlCommand("insert into Malzeme (MalzemeAdi) values (@a1)", baglanti);
            ekleme.Parameters.AddWithValue("@a1", yemek.malzemeAdi);
            ekleme.ExecuteNonQuery();

            SqlCommand command = new SqlCommand("Select *from Malzeme where MalzemeAdi='" + yemek.malzemeAdi + "'", baglanti);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string[] malzemeler = new string[] { yemek.malzemeAdi };
                yemek.malzemeListe.AddRange(malzemeler);
                lbYemeklerVeMalzemeler.Items.AddRange(malzemeler);
                MessageBox.Show("Malzeme Eklendi");

            }
            else
            {
                MessageBox.Show("Hata\nTekrar Deneyiniz.");

            }

            baglanti.Close();


            

        }

        private void frmYemekEkleme_Load(object sender, EventArgs e)
        {

        }
    }
}
