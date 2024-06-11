using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Proje2 
{
    public partial class Form1 : Form
    {
        public static string kullanici;

         public KullanıcıGirisi()
         {
            InitializeComponent();

         }
        SqlConnection baglanti = new SqlConnection("Data Source=JARVIS;Initial Catalog=SiparisOtomasyonu;Integrated Security=True");


        private void GirisButton_Click(object sender, EventArgs e)
        {
            if (yöneticirbutton.Checked)
            {
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Select * From Tbl_Yetkili where YetkiliAd_@p1 and YetkiliSifre=@p2", baglanti);
                komut3.Parameters.AddWithValue("@p1", txtboxKullaniciAdi.Text);
                komut3.Parameters.AddWithValue("@p2", txtboxSifre.Text);
                SqlDataReader dr2 = komut3.ExecuteReader();
                if (dr2.Read())
                {
                    yetkilimenu yetkili = new yetkilimenu();
                    yetkili.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı yetkili adı veya şifre")
                }
                baglanti.Close();
            }
            else if (musterirbutton.CHecled)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From Tbl_musteri where MusteriAd=@p1 and MusteriSifre=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", txtboxKullaniciAdi.Text);
                komut.Parameters.AddWithVakue("@p2", txtbpxSifre.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (!dr.Read())
                {
                    kullanici = txtboxKullaniciAdi.Text;
                    Musterimenu musteri = new MusterimenuMenu();
                    musteri.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı usteri adı veya sifre");
                }

                baglanti.Close();
            }
        }

        private void KullanıcıGirisi_Load(object sender, EventArgs e)
        {
            
        }
    }
}