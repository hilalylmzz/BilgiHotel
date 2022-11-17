using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgiHotel
{
    public partial class FrmResepsiyon : Form
    {
        int CalisanID;
        List<Panel> panels;
        public FrmResepsiyon(int CalisanID)
        {
            InitializeComponent();
            this.CalisanID = CalisanID;
        }

        List<KeyValuePair<int, string>> Ulkeler = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> Sehirler = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> Diller = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> Cinsiyetler = new List<KeyValuePair<int, string>>();


        SqlConnection con = new SqlConnection("Server=.;Database=DB_BilgiHotel;Trusted_Connection=True;");
        private void FrmResepsiyon_Load(object sender, EventArgs e)
        {
            panels = new List<Panel>() { pnlAyarlar, pnlROdalar, pnlRezervasyon, pnlMusteriler };
            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }
            ComboboxDoldur();
        }
        private void PanelAc(Panel panelac)
        {
            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }
            panelac.Visible = true;
        }

        private void tsRzvOdalar_Click(object sender, EventArgs e)
        {
            PanelAc(pnlROdalar);
        }

        private void tsYeniRezervasyon_Click(object sender, EventArgs e)
        {
            PanelAc(pnlRezervasyon);
        }

        private void tsSifreGuncelleme_Click(object sender, EventArgs e)
        {
            PanelAc(pnlAyarlar);
        }

        private void ComboboxDoldur()
        {
            //Ulkeler
            SqlCommand cmd = new SqlCommand("SELECT ulkeID, UlkeAd FROM Ulkeler", con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ulkeler.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();


            //Sehirler
            cmd = new SqlCommand("SELECT sehirID, sehirAd FROM Sehirler", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sehirler.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            


            //Diller
            cmd = new SqlCommand("SELECT dilID, dilAd FROM Diller", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Diller.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            

            //Cinsiyetler
            cmd = new SqlCommand("SELECT cinsiyetID, cinsiyetAd FROM Cinsiyetler", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cinsiyetler.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            con.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PanelAc(pnlMusteriler);

            cmbUlkeler.DataSource = Ulkeler;
            cmbUlkeler.ValueMember = "Key";
            cmbUlkeler.DisplayMember = "Value";

            cmbSehirler.DataSource = Sehirler;
            cmbSehirler.ValueMember = "Key";
            cmbSehirler.DisplayMember = "Value";

            cmbMusteriDil.DataSource = Diller;
            cmbMusteriDil.ValueMember = "Key";
            cmbMusteriDil.DisplayMember = "Value";

            cmbCinsiyet.DataSource = Cinsiyetler;
            cmbCinsiyet.ValueMember = "Key";
            cmbCinsiyet.DisplayMember = "Value";
        }

        private void cbSirketMi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSirketMi.Checked)
            {
                gbSirketBilgileri.Visible = true;
            }
            else
            {
                gbSirketBilgileri.Visible = false;
            }

        }

        private void btnMusteriAra_Click(object sender, EventArgs e)
        {
            string tcKimlik = txtTCKimlik.Text;
            SqlCommand cmd = new SqlCommand($"Select musteriAd, musteriSoyad, musteriTelNo, musteriEposta, musteriAdres, musteriFirmaAd, firmaVergiNo, cinsiyetID, musteriSirketMi from Musteriler Where musteriTC = '{tcKimlik}'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtMusteriAd.Text = reader["musteriAd"].ToString();
                txtMusteriSoyad.Text = reader["musteriSoyad"].ToString();
                txtMusteriTelNo.Text = reader["musteriTelNo"].ToString();
                txtMusteriEPosta.Text = reader["musteriEPosta"].ToString();
                txtMusteriAdres.Text = reader["musteriAdres"].ToString();
                txtFirmaAdi.Text = reader["musteriFirmaAd"].ToString();
                txtVergiNo.Text = reader["firmaVergiNo"].ToString();
                // cmbCinsiyet.SelectedValue = (int)reader["cinsiyetID"];
                if ((bool)reader["musteriSirketMi"])
                {
                    cbSirketMi.Checked = true;
                }
                else
                {
                    cbSirketMi.Checked = false;
                }
            }
            reader.Close();
            con.Close();
        }

        private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_MusteriEkle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@musteriAd", txtMusteriAd.Text);
            cmd.Parameters.AddWithValue("@musteriSoyad", txtMusteriSoyad.Text);
            cmd.Parameters.AddWithValue("@musteriTelNo", txtMusteriTelNo.Text);
            cmd.Parameters.AddWithValue("@musteriEPosta", txtMusteriEPosta.Text);
            cmd.Parameters.AddWithValue("@musteriAdres", txtMusteriAdres.Text);
            cmd.Parameters.AddWithValue("@ulkeID", cmbUlkeler.SelectedValue);
            cmd.Parameters.AddWithValue("@sehirID", cmbSehirler.SelectedValue);
            cmd.Parameters.AddWithValue("@cinsiyetID", cmbCinsiyet.SelectedValue);
            cmd.Parameters.AddWithValue("@dilID", cmbMusteriDil.SelectedValue);
            cmd.Parameters.AddWithValue("@musteriFirmaAd", txtFirmaAdi.Text);
            cmd.Parameters.AddWithValue("@firmaVergiNo", txtVergiNo.Text);
            cmd.Parameters.AddWithValue("@musterisirketMi", cbSirketMi.Checked);
            cmd.Parameters.AddWithValue("@musteriTC", txtTCKimlik.Text);
            cmd.Parameters.AddWithValue("@musteriAciklama", txtMusteriAciklama.Text);
            cmd.Parameters.AddWithValue("@musteriAktifMi", cbMusteriAktifMi.Checked);


            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Müşteri Eklendi");
            }
            else
            {
                MessageBox.Show("Müşteri Eklenemedi");
            }
            con.Close();
            txtMusteriAd.Clear();
            txtMusteriSoyad.Clear();
            txtMusteriAdres.Clear();
            txtFirmaAdi.Clear();
            txtVergiNo.Clear();
            txtMusteriEPosta.Clear();
            txtMusteriAciklama.Clear();
            txtTCKimlik.Clear();
            txtMusteriTelNo.Clear();
            cbMusteriAktifMi.Checked = false;
            cbSirketMi.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_MusteriGuncelleme", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@musteriAd", txtMusteriAd.Text);
            cmd.Parameters.AddWithValue("@musteriSoyad", txtMusteriSoyad.Text);
            cmd.Parameters.AddWithValue("@musteriTelNo", txtMusteriTelNo.Text);
            cmd.Parameters.AddWithValue("@musteriEPosta", txtMusteriEPosta.Text);
            cmd.Parameters.AddWithValue("@musteriAdres", txtMusteriAdres.Text);
            cmd.Parameters.AddWithValue("@ulkeID", cmbUlkeler.SelectedValue);
            cmd.Parameters.AddWithValue("@sehirID", cmbSehirler.SelectedValue);
            cmd.Parameters.AddWithValue("@cinsiyetID", cmbCinsiyet.SelectedValue);
            cmd.Parameters.AddWithValue("@dilID", cmbMusteriDil.SelectedValue);
            cmd.Parameters.AddWithValue("@musteriFirmaAd", txtFirmaAdi.Text);
            cmd.Parameters.AddWithValue("@firmaVergiNo", txtVergiNo.Text);
            cmd.Parameters.AddWithValue("@musterisirketMi", cbSirketMi.Checked);
            cmd.Parameters.AddWithValue("@musteriTC", txtTCKimlik.Text);
            cmd.Parameters.AddWithValue("@musteriAciklama", txtMusteriAciklama.Text);
            cmd.Parameters.AddWithValue("@musteriAktifMi", cbMusteriAktifMi.Checked);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Müşteri bilgileri güncellendi");
            }
            else
            {
                MessageBox.Show("Müşteri bilgileri güncellenemedi");
            }
            con.Close();

            txtMusteriAd.Clear();
            txtMusteriSoyad.Clear();
            txtMusteriAdres.Clear();
            txtFirmaAdi.Clear();
            txtVergiNo.Clear();
            txtMusteriEPosta.Clear();
            txtMusteriAciklama.Clear();
            txtTCKimlik.Clear();
            txtMusteriTelNo.Clear();
            cbMusteriAktifMi.Checked = false;
            cbSirketMi.Checked = false;

        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            string musteriTC = txtTCKimlik.Text;
            SqlCommand cmd = new SqlCommand($"Delete from Musteriler where musteriTC='{musteriTC}'", con);
     
            try
            {
                con.Open();

                MessageBox.Show(cmd.ExecuteNonQuery() + "Müşteri Bilgileri Silindi");

            }
            catch (Exception hata)
            {

                MessageBox.Show("Müşteri Bilgileri Silinemedi" + hata.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            txtMusteriAd.Clear();
            txtMusteriSoyad.Clear();
            txtMusteriAdres.Clear();
            txtFirmaAdi.Clear();
            txtVergiNo.Clear();
            txtMusteriEPosta.Clear();
            txtMusteriAciklama.Clear();
            txtTCKimlik.Clear();
            txtMusteriTelNo.Clear();
            cbMusteriAktifMi.Checked = false;
            cbSirketMi.Checked = false;
        }

        private void btnBosOdalar_Click(object sender, EventArgs e)
        {
            lbBosOdalar.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select odaNo From Odalar Where odaBosMu=1", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbBosOdalar.Items.Add(reader[0].ToString());
            }
            reader.Close();
            con.Close();

        }

        private void btnTemizlenecekOda_Click(object sender, EventArgs e)
        {
            lbTemizlenecekOdalar.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select odaNo From Odalar Where odaTemizMi=0", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbTemizlenecekOdalar.Items.Add(reader[0].ToString());
            }
            reader.Close();
            con.Close();
        }

        private void btnSifreGuncelle_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand($"Select kullaniciID from Kullanicilar Where kullaniciSifre='{txtEskiSifre.Text}' and kullaniciEPosta='{txtKullaniciEPosta.Text}'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                reader.Close();
                SqlCommand komut = new SqlCommand($"Update Kullanicilar SET kullaniciSifre='{txtYeniSifre.Text}' where kullaniciEPosta='{txtKullaniciEPosta.Text}'",con);

                if(komut.ExecuteNonQuery() >0)
                {
                    MessageBox.Show("Şifre Güncellendi");
                }
            }
            con.Close();
        }

      

        private void btnIDAra_Click(object sender, EventArgs e)
        {
            string tcKimlik = txtMusteriTC.Text;
            SqlCommand cmd = new SqlCommand($"Select musteriID from Musteriler Where musteriTC = '{tcKimlik}'", con);
                
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtMusteriID.Text = reader["musteriID"].ToString();
            }
            reader.Close();
            con.Close();
        }

        private void btnRzvKaydet_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_RezervasyonKaydet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rezervasyonBaslangicTarih", dtpGirisTarihi.Value);
            cmd.Parameters.AddWithValue("@rezervasyonBitisTarihi", dtpCikisTarihi.Value);
            cmd.Parameters.AddWithValue("@rezervasyonIndirim", txtRzvIndirim.Text);
            cmd.Parameters.AddWithValue("@rezervasyonAktifMi", cbRzvAktifMi.Checked);
            cmd.Parameters.AddWithValue("@rezervasyonAciklama", txtRzvAciklama.Text);
            cmd.Parameters.AddWithValue("@calisanID", CalisanID);
            cmd.Parameters.AddWithValue("@musteriID", txtMusteriID.Text);
            cmd.Parameters.AddWithValue("@odaNo", 100); //lvUygunOdalar.SelectedItems[0].SubItems[0].Text);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Rezervasyon Kaydedildi");
            }
            else
            {
                MessageBox.Show("Rezervasyon Kaydedilemedi");
            }
            con.Close();



        }

        private void pnlMusteriler_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
