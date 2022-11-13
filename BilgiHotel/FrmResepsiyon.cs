using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgiHotel
{
    public partial class FrmResepsiyon : Form
    {
        List<Panel> panels;
        public FrmResepsiyon()
        {
            InitializeComponent();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PanelAc(pnlMusteriler);

            //Ulkeler
            SqlCommand cmd = new SqlCommand("SELECT ulkeID, UlkeAd FROM Ulkeler", con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ulkeler.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            cmbUlkeler.DataSource = Ulkeler;
            cmbUlkeler.ValueMember = "Key";
            cmbUlkeler.DisplayMember = "Value";


            //Sehirler
            cmd = new SqlCommand("SELECT sehirID, sehirAd FROM Sehirler", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sehirler.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            cmbSehirler.DataSource = Sehirler;
            cmbSehirler.ValueMember = "Key";
            cmbSehirler.DisplayMember = "Value";


            //Diller
            cmd = new SqlCommand("SELECT dilID, dilAd FROM Diller", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Diller.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            cmbMusteriDil.DataSource = Diller;
            cmbMusteriDil.ValueMember = "Key";
            cmbMusteriDil.DisplayMember = "Value";

            //Cinsiyetler
            cmd = new SqlCommand("SELECT cinsiyetID, cinsiyetAd FROM Cinsiyetler", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cinsiyetler.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
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
            SqlCommand cmd = new SqlCommand($"Select musteriAd, musteriSoyad, musteriTelNo, musteriEposta, musteriAdres, musteriFirmaAd, firmaVergiNo from Musteriler Where musteriTC = '{tcKimlik}'", con);
            cmd.Parameters.AddWithValue("@tckimlik", "musteriTC");
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

            }
            reader.Close();
            con.Close();
        }

        private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_MusteriEkleme", con);
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
        }
    }
}
