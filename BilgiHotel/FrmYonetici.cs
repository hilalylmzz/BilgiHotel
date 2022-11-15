using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgiHotel
{
    public partial class FrmYonetici : Form
    {
        int YoneticiID;
        List<Panel> panels;
        public FrmYonetici(int YoneticiID)
        {
            InitializeComponent();
            this.YoneticiID = YoneticiID;
        }


        List<KeyValuePair<int, string>> Ulkeler = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> Sehirler = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> Diller = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> Cinsiyetler = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> Katlar = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> Gorevler = new List<KeyValuePair<int, string>>();

        SqlConnection con = new SqlConnection("Server=.;Database=DB_BilgiHotel;Trusted_Connection=True;");
        private void FrmYonetici_Load(object sender, EventArgs e)
        {
            panels = new List<Panel>(){pnlCalisanlar,pnlOdalar,pnlMusteriler, pnlKampanyalar};
            foreach(Panel panel in panels)
            {
                panel.Visible = false;
            }
            ComboboxDoldur();
        }

        private void PanelAc(Panel panelac)
        {
            foreach(Panel panel in panels)
            {
                panel.Visible=false;
            }
            panelac.Visible = true;
        }

        private void tsMusteriler_Click(object sender, EventArgs e)
        {
            PanelAc(pnlMusteriler);
        }

        private void tsCalisanlar_Click(object sender, EventArgs e)
        {
            PanelAc(pnlCalisanlar);


            cmbUlkeler.DataSource = Ulkeler;
            cmbUlkeler.ValueMember = "Key";
            cmbUlkeler.DisplayMember = "Value";

            cmbSehirler.DataSource = Sehirler;
            cmbSehirler.ValueMember = "Key";
            cmbSehirler.DisplayMember = "Value";


            cmbCinsiyet.DataSource = Cinsiyetler;
            cmbCinsiyet.ValueMember = "Key";
            cmbCinsiyet.DisplayMember = "Value";

            cmbGorevler.DataSource = Gorevler;
            cmbGorevler.ValueMember = "Key";
            cmbGorevler.DisplayMember = "Value";
        }

        private void tsKampanyalar_Click(object sender, EventArgs e)
        {
            PanelAc(pnlKampanyalar);
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

        private void tsOdalar_Click(object sender, EventArgs e)
        {
            PanelAc(pnlOdalar);

            SqlCommand cmd = new SqlCommand("SELECT katID, katNumarasi FROM Katlar", con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Katlar.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            cmbOdaKat.DataSource = Katlar;
            cmbOdaKat.ValueMember = "Key";
            cmbOdaKat.DisplayMember = "Value";

        }

        private void btnCalisanAra_Click(object sender, EventArgs e)
        {
            /*string tcKimlik = txtCalisanTC.Text;
            SqlCommand cmd = new SqlCommand($"Select musteriAd, musteriSoyad, musteriTelNo, musteriEposta, musteriAdres, musteriFirmaAd, firmaVergiNo, cinsiyetID, musteriSirketMi from Calisanlar Where musteriTC = '{tcKimlik}'", con);
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
            con.Close();*/
        }
    }
}
