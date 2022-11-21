using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BilgiHotel
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server=.;Database=DB_BilgiHotel;Trusted_Connection=True;");
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullanici = txtKullaniciAdi.Text;
            string sifre = txtKullaniciSifre.Text;

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_KullaniciGiris", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kullaniciAd", kullanici);
            cmd.Parameters.AddWithValue("@kullaniciSifre", sifre);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                switch (reader[0])
                {
                    case 0:
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                        break;
                    case 1:
                        FrmResepsiyon resepsiyon = new FrmResepsiyon((int)reader[1]);
                        resepsiyon.Show();
                        this.Hide();
                        break;
                    case 2:
                        FrmYonetici yonetici = new FrmYonetici((int)reader[2]);
                        yonetici.Show();
                        this.Hide();
                        break;
                    default:
                        break;
                }
            }
            con.Close();

        }
    }
}
