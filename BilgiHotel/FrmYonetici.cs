using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        List<KeyValuePair<int, string>> Kampanyalar = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> OdaTipi = new List<KeyValuePair<int, string>>();

        SqlConnection con = new SqlConnection("Server=.;Database=DB_BilgiHotel;Trusted_Connection=True;");



        private void FrmYonetici_Load(object sender, EventArgs e)
        {
            panels = new List<Panel>() { pnlCalisanlar, pnlOdalar, pnlMusteriler, pnlKampanyalar };
            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }
            ComboboxDoldur();
        }

        private void VerileriTemizle(Panel panel)
        {
            foreach (var item in panel.Controls)
            {
                if (item is NumericUpDown)
                {
                    NumericUpDown nud = (NumericUpDown)item;
                    nud.Value = 0;
                }

                if (item is CheckedListBox)
                {
                    CheckedListBox ckl = (CheckedListBox)item;
                    for (int i = 0; i < ckl.Items.Count; i++)
                    {
                        ckl.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }

                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Text = "";
                }

                if (item is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)item;
                    dtp.Value = DateTime.Now;
                }

                if (item is RichTextBox)
                {
                    RichTextBox rtx = (RichTextBox)item;
                    rtx.Text = "";
                }

                if (item is CheckBox)
                {
                    CheckBox cb = (CheckBox)item;
                    cb.Checked = false;
                }

                if (item is ComboBox)
                {
                    ComboBox cmb = (ComboBox)item;
                    cmb.SelectedIndex = -1;
                }
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
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT kampanyaID, kampanyaAd FROM Kampanyalar", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Kampanyalar.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            cmbKampanyalar.DataSource = Kampanyalar;
            cmbKampanyalar.ValueMember = "Key";
            cmbKampanyalar.DisplayMember = "Value";
            reader.Close();
            con.Close();


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



            //Görevler
            cmd = new SqlCommand("SELECT gorevID, gorevAd FROM Gorevler", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Gorevler.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
            }
            reader.Close();
            con.Close();




        }

        private void tsOdalar_Click(object sender, EventArgs e)
        {
            PanelAc(pnlOdalar);

            //Katlar
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
            con.Close();

            //Oda tipleri
            /* cmd = new SqlCommand("SELECT odaTipiID, odaTipiOzellik FROM OdaTipleri", con);
             con.Open();
             reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 OdaTipi.Add(new KeyValuePair<int, string>((int)reader[0], reader[1].ToString()));
             }
             reader.Close();
             cmbOdaTipi.DataSource = OdaTipi;
             cmbOdaTipi.ValueMember = "Key";
             cmbOdaTipi.DisplayMember = "Value";
             con.Close();*/


            lvOdaListesi.Items.Clear();
            con.Open();
            cmd = new SqlCommand("Select odaNo, k.katNumarasi, odaFiyat, odaKisiSayisi from Odalar as o Join Katlar as k on o.katID = k.katID", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] satir = { reader["odaNo"].ToString(), reader["katNumarasi"].ToString(), reader["odaFiyat"].ToString(), reader["odaKisiSayisi"].ToString() };
                var listviewItem = new ListViewItem(satir);

                lvOdaListesi.Items.Add(listviewItem);
            }

            reader.Close();
            con.Close();






        }

        private void btnCalisanAra_Click(object sender, EventArgs e)
        {
            string tcKimlik = txtCalisanTC.Text;
            SqlCommand cmd = new SqlCommand($"Select calisanAd, calisanSoyad, calisanTCKimlikNo, calisanDogumTarih, calisanTelefonNo, calisanEposta, calisanAdres, ulkeId, sehirId, gorevID, cinsiyetID,calisanMaas,calisanSicilNo, calisanEngelliMi, acilDurumKisiAd, acilDurumTelefonNo,calisanIseBaslamaTarih, calisanIstenCikisTarih, calisanAktifMi, calisanAciklama from Calisanlar Where calisanTCKimlikNo = '{tcKimlik}'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtCalisanAd.Text = reader["calisanAd"].ToString();
                txtCalisanSoyad.Text = reader["calisanSoyad"].ToString();
                txtCalisanTC.Text = reader["calisanTCKimlikNo"].ToString();
                dtpCDogumTarihi.Value = reader.GetDateTime(3);
                txtCalisanTel.Text = reader["calisanTelefonNo"].ToString();
                txtCalisanEPosta.Text = reader["calisanEPosta"].ToString();
                txtCalisanAdres.Text = reader["calisanAdres"].ToString();
                txtCalisanMaas.Text = reader["calisanMaas"].ToString();
                txtcalisanSicilNo.Text = reader["calisanSicilNo"].ToString();
                cbEngelDurumu.Checked = (bool)reader["calisanEngelliMi"];
                txtAcilDurumKisiAd.Text = reader["acilDurumKisiAd"].ToString();
                txtAcilDurumKisiTel.Text = reader["acilDurumTelefonNo"].ToString();
                dtpIseBaslamaTarihi.Value = reader.GetDateTime(16);
                if (reader.IsDBNull(17))
                {
                    cbCalisiyorMu.Checked = true;
                }
                //dtpIstenAyrilmaTarihi.Value = reader.IsDBNull(17) ?  DateTime.Now : reader.GetDateTime(17);
                cbCalisanAktifMi.Checked = (bool)reader["calisanAktifMi"];
                txtCalisanAciklama.Text = reader["calisanAciklama"].ToString();
                cmbCinsiyet.SelectedValue = reader.GetInt32(10);
                cmbUlkeler.SelectedValue = reader.GetInt32(7);
                cmbSehirler.SelectedValue = reader.GetInt32(8);
                cmbGorevler.SelectedValue = reader.GetInt32(9);

            }
            reader.Close();
            con.Close();
        }

        private void btnCalisanGuncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_CalisanBilgiGuncelleme", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@calisanAd", txtCalisanAd.Text);
            cmd.Parameters.AddWithValue("@calisanSoyad", txtCalisanSoyad.Text);
            cmd.Parameters.AddWithValue("@calisanTCKimlikNo", txtCalisanTC.Text);
            cmd.Parameters.AddWithValue("@calisanDogumTarih", dtpCDogumTarihi.Value);
            cmd.Parameters.AddWithValue("@calisanTelefonNo", txtCalisanTel.Text);
            cmd.Parameters.AddWithValue("@ulkeID", cmbUlkeler.SelectedValue);
            cmd.Parameters.AddWithValue("@sehirID", cmbSehirler.SelectedValue);
            cmd.Parameters.AddWithValue("@cinsiyetID", cmbCinsiyet.SelectedValue);
            cmd.Parameters.AddWithValue("@gorevID", cmbGorevler.SelectedValue);
            cmd.Parameters.AddWithValue("@calisanEPosta", txtCalisanEPosta.Text);
            cmd.Parameters.AddWithValue("@calisanAdres", txtCalisanAdres.Text);
            cmd.Parameters.AddWithValue("@calisanMaas", Convert.ToDecimal(txtCalisanMaas.Text));
            cmd.Parameters.AddWithValue("@calisanSicilNo", txtcalisanSicilNo.Text);
            cmd.Parameters.AddWithValue("@calisanEngelliMi", cbEngelDurumu.Checked);
            cmd.Parameters.AddWithValue("@acilDurumKisiAd", txtAcilDurumKisiAd.Text);
            cmd.Parameters.AddWithValue("@acilDurumKisiTel", txtAcilDurumKisiTel.Text);
            cmd.Parameters.AddWithValue("@calisanIseBaslamaTarih", dtpIseBaslamaTarihi.Value);
            if (cbCalisiyorMu.Checked == true)
            {
                cmd.Parameters.AddWithValue("@calisanIstenCikisTarih", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@calisanIstenCikisTarih", dtpIstenAyrilmaTarihi.Value);
            }
            cmd.Parameters.AddWithValue("@calisanAciklama", txtCalisanAciklama.Text);
            cmd.Parameters.AddWithValue("@calisanAktifMi", cbCalisanAktifMi.Checked);


            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Çalışan bilgileri güncellendi");
            }
            else
            {
                MessageBox.Show("Çalışan bilgileri güncellenemedi");
            }
            con.Close();
        }

        private void cbCalisiyorMu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCalisiyorMu.Checked)
            {
                dtpIstenAyrilmaTarihi.Enabled = false;
            }
            else
            {
                dtpIstenAyrilmaTarihi.Enabled = true;
            }
        }

        private void btnCalisanEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_CalisanKaydet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@calisanAd", txtCalisanAd.Text);
            cmd.Parameters.AddWithValue("@calisanSoyad", txtCalisanSoyad.Text);
            cmd.Parameters.AddWithValue("@calisanTCKimlikNo", txtCalisanTC.Text);
            cmd.Parameters.AddWithValue("@calisanDogumTarih", dtpCDogumTarihi.Value);
            cmd.Parameters.AddWithValue("@calisanTelefonNo", txtCalisanTel.Text);
            cmd.Parameters.AddWithValue("@ulkeID", cmbUlkeler.SelectedValue);
            cmd.Parameters.AddWithValue("@sehirID", cmbSehirler.SelectedValue);
            cmd.Parameters.AddWithValue("@cinsiyetID", cmbCinsiyet.SelectedValue);
            cmd.Parameters.AddWithValue("@gorevID", cmbGorevler.SelectedValue);
            cmd.Parameters.AddWithValue("@calisanEPosta", txtCalisanEPosta.Text);
            cmd.Parameters.AddWithValue("@calisanAdres", txtCalisanAdres.Text);
            cmd.Parameters.AddWithValue("@calisanMaas", Convert.ToDecimal(txtCalisanMaas.Text));
            cmd.Parameters.AddWithValue("@calisanSicilNo", txtcalisanSicilNo.Text);
            cmd.Parameters.AddWithValue("@calisanEngelliMi", cbEngelDurumu.Checked);
            cmd.Parameters.AddWithValue("@acilDurumKisiAd", txtAcilDurumKisiAd.Text);
            cmd.Parameters.AddWithValue("@acilDurumTelefonNo", txtAcilDurumKisiTel.Text);
            cmd.Parameters.AddWithValue("@calisanIseBaslamaTarih", dtpIseBaslamaTarihi.Value);
            if (cbCalisiyorMu.Checked == true)
            {
                cmd.Parameters.AddWithValue("@calisanIstenCikisTarih", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@calisanIstenCikisTarih", dtpIstenAyrilmaTarihi.Value);
            }
            cmd.Parameters.AddWithValue("@calisanAciklama", txtCalisanAciklama.Text);
            cmd.Parameters.AddWithValue("@calisanAktifMi", cbCalisanAktifMi.Checked);


            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Yeni Çalışan Kaydedildi");
            }
            else
            {
                MessageBox.Show("Kayıt İşlemi Gerçekleştirilemedi");
            }
            con.Close();
        }

        private void btnCalisanSil_Click(object sender, EventArgs e)
        {
            string calisanTC = txtCalisanTC.Text;
            SqlCommand cmd = new SqlCommand($"Delete from Calisanlar where calisanTCKimlikNo='{calisanTC}'", con);

            try
            {
                con.Open();

                MessageBox.Show(cmd.ExecuteNonQuery() + "Çalışan Bilgileri Silindi");

            }
            catch (Exception hata)
            {

                MessageBox.Show("Çalışan Bilgileri Silinemedi" + hata.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void btnKampanyaGuncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_KampanyaGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kampanyaAd", txtKampanyaAdi.Text);
            cmd.Parameters.AddWithValue("@kampanyaIndirim", Convert.ToInt32(txtIndirimOrani.Text));
            cmd.Parameters.AddWithValue("@kampanyaBaslangicTarihi", dtpKBaslangicTarihi.Value);
            cmd.Parameters.AddWithValue("kampanyaBitisTarihi", dtpKBitisTarihi.Value);
            cmd.Parameters.AddWithValue("kampanyaAktifMi", cbKampanyaAktifMi.Checked);
            cmd.Parameters.AddWithValue("kampanyaAciklama", txtKampanyaAciklama.Text);


            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Kampanya Bilgileri Güncellendi");
            }
            else
            {
                MessageBox.Show("Kampanya Bilgileri Güncellenemedi");
            }
            con.Close();

        }

        private void cmbKampanyalar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int kampanya = (int)cmbKampanyalar.SelectedValue;
            SqlCommand cmd = new SqlCommand($"Select kampanyaAd, kampanyaIndirim, kampanyaBaslangicTarihi, kampanyaBitisTarihi, kampanyaAktifMi, kampanyaAciklama  From Kampanyalar Where kampanyaID={kampanya}", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                txtKampanyaAdi.Text = reader["kampanyaAd"].ToString();
                txtIndirimOrani.Text = reader["kampanyaIndirim"].ToString();
                dtpKBaslangicTarihi.Value = reader.GetDateTime(2);
                dtpKBitisTarihi.Value = reader.GetDateTime(3);
                cbKampanyaAktifMi.Checked = reader.GetBoolean(4);
                txtKampanyaAciklama.Text = reader["kampanyaAciklama"].ToString();

            }
            reader.Close();
            con.Close();


        }

        private void btnYeniKampanya_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_KampanyaEkle", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@kampanyaAd", txtKampanyaAdi.Text);
            cmd.Parameters.AddWithValue("@kampanyaIndirim", Convert.ToInt32(txtIndirimOrani.Text));
            cmd.Parameters.AddWithValue("@kampanyaBaslangicTarihi", dtpKBaslangicTarihi.Value);
            cmd.Parameters.AddWithValue("kampanyaBitisTarihi", dtpKBitisTarihi.Value);
            cmd.Parameters.AddWithValue("kampanyaAktifMi", cbKampanyaAktifMi.Checked);
            cmd.Parameters.AddWithValue("kampanyaAciklama", txtKampanyaAciklama.Text);


            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Yeni Kampanya Eklendi");
            }
            else
            {
                MessageBox.Show("Kampanya Eklenemedi");
            }
            con.Close();

            txtKampanyaAdi.Clear();
            txtIndirimOrani.Clear();
            cbKampanyaAktifMi.Checked = false;
            txtKampanyaAciklama.Clear();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtKampanyaAdi.Clear();
            txtIndirimOrani.Clear();
            cbKampanyaAktifMi.Checked = false;
            txtKampanyaAciklama.Clear();

        }

        private void btnOdaSec_Click(object sender, EventArgs e)
        {
            if (lvOdaListesi.SelectedItems.Count != 1)
            {
                MessageBox.Show("Oda Seçiniz");
                return;
            }

            VerileriTemizle(pnlOdalar);

            int odaID = 0;
            string odaNumara = lvOdaListesi.SelectedItems[0].SubItems[0].Text;
            SqlCommand cmd = new SqlCommand($"Select odaID, odaNo, k.katNumarasi, odaFiyat, odaKisiSayisi, odaAciklama, odaBosMu, odaTemizMi from Odalar as o Join Katlar as k on o.katID = k.katID where odaNo= '{odaNumara}'", con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                odaID = (int)reader["odaID"];
                nudOdaNo.Value = (int)reader["odaNo"];
                cmbOdaKat.SelectedIndex = (int)reader["katNumarasi"] - 1;
                txtOdaFiyat.Text = reader["odaFiyat"].ToString();
                txtOdaKapasite.Text = reader["odaKisiSayisi"].ToString();
                cbOdaBosMU.Checked = (bool)reader["odaBosMu"];
                cbOdaTemizMi.Checked = (bool)reader["odaTemizMi"];
            }

            reader.Close();
            con.Close();

            //Yatak sayıları yazdırma
            cmd = new SqlCommand($"Select odaID, yatakTipiID, yatakAdet from OdalarYatakTipleri where odaID={odaID}", con);
            con.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                switch ((int)reader["yatakTipiID"])
                {
                    case 1:
                        nudTekKisilikYatak.Value = Convert.ToDecimal(reader["yatakAdet"]);
                        break;
                    case 2:
                        nudCiftKisilikYatak.Value = Convert.ToDecimal(reader["yatakAdet"]);
                        break;
                }
            }
            reader.Close();

            con.Close();


            //Oda Özellikleri Yazdırma
            cmd = new SqlCommand($"Select odaOzellikleriID from OdalarOdaOzellikleri where odaID={odaID}", con);
            con.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                switch ((int)reader["odaOzellikleriID"])
                {
                    case 1:
                        clOdaOzellikleri.SetItemChecked(0 ,true);
                        break;
                    case 2:
                        clOdaOzellikleri.SetItemChecked(1, true);
                        break;
                    case 3:
                        clOdaOzellikleri.SetItemChecked(2, true);
                        break;
                    case 4:
                        clOdaOzellikleri.SetItemChecked(3, true);
                        break;
                    case 5:
                        clOdaOzellikleri.SetItemChecked(4, true);
                        break;
                    case 6:
                        clOdaOzellikleri.SetItemChecked(5, true);
                        break;
                    default:
                        break;
                }
            }
            reader.Close();

            con.Close();


        }

        private void lvOdaListesi_DoubleClick(object sender, EventArgs e)
        {
            btnOdaSec.PerformClick();
        }

        private void bntOdaBilgiGuncelle_Click(object sender, EventArgs e)
        {   
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_OdaBilgiGuncelleme", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("odaNo", nudOdaNo.Value);
            cmd.Parameters.AddWithValue("odaFiyat", Convert.ToDecimal(txtOdaFiyat.Text));
            cmd.Parameters.AddWithValue("odaKisiSayisi", Convert.ToInt32(txtOdaKapasite.Text));
            cmd.Parameters.AddWithValue("katID", cmbOdaKat.SelectedValue);
            cmd.Parameters.AddWithValue("odaBosMu", cbOdaBosMU.Checked);
            cmd.Parameters.AddWithValue("odaTemizMi", cbOdaTemizMi.Checked);
            cmd.Parameters.AddWithValue("odaAktifMi", cbOdaAktifMi.Checked);
            cmd.Parameters.AddWithValue("odaAciklama", txtOdaAciklama.Text);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Oda Bilgileri Güncellendi");
            }
            else
            {
                MessageBox.Show("Oda Bilgileri Güncellenemedi");
            }

            string commandString = $"SELECT odaID FROM Odalar WHERE odaNo = {nudOdaNo.Value}";

            cmd = new SqlCommand(commandString, con);
            int odaID = (int)cmd.ExecuteScalar();

            commandString = $"DELETE FROM OdalarOdaOzellikleri WHERE odaID = {odaID}";

            cmd = new SqlCommand(commandString, con);
            cmd.ExecuteNonQuery();

            foreach(int indis in clOdaOzellikleri.CheckedIndices)
            {
                commandString = $"INSERT INTO OdalarOdaOzellikleri (odaID,odaOzellikleriID) VALUES ({odaID},{indis+1})";
                cmd = new SqlCommand(commandString, con);
                cmd.ExecuteNonQuery();
            }

            commandString = $"DELETE FROM OdalarYatakTipleri WHERE odaID = {odaID}";

            cmd = new SqlCommand(commandString, con);
            cmd.ExecuteNonQuery();

            if(nudTekKisilikYatak.Value > 0)
            {
                commandString = $"INSERT INTO OdalarYatakTipleri (odaID,yatakTipiID, yatakAdet) VALUES ({odaID},1,{nudTekKisilikYatak.Value})";
                cmd = new SqlCommand(commandString, con);
                cmd.ExecuteNonQuery();
            }

            if(nudCiftKisilikYatak.Value > 0)
            {
                commandString = $"INSERT INTO OdalarYatakTipleri (odaID,yatakTipiID, yatakAdet) VALUES ({odaID},2,{nudCiftKisilikYatak.Value})";
                cmd = new SqlCommand(commandString, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private void txtAra_Click(object sender, EventArgs e)
        {
            string tcKimlik = txtMusteriTC.Text;
            SqlCommand cmd = new SqlCommand($"Select musteriAd, musteriSoyad, musteriTelNo, musteriEposta, musteriAdres, musteriFirmaAd, firmaVergiNo, cinsiyetID, musteriSirketMi from Musteriler Where musteriTC = '{tcKimlik}'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lbMusteriListele.Items.Add(reader["musteriAd"].ToString() +" " + reader["musteriSoyad"].ToString()+ " "+ reader[2].ToString());
            }
        }

        private void btnOdaEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_OdaEkleme", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("odaNo", nudOdaNo.Value);
            cmd.Parameters.AddWithValue("odaFiyat", Convert.ToDecimal(txtOdaFiyat.Text));
            cmd.Parameters.AddWithValue("odaKisiSayisi", Convert.ToInt32(txtOdaKapasite.Text));
            cmd.Parameters.AddWithValue("katID", cmbOdaKat.SelectedValue);
            cmd.Parameters.AddWithValue("odaBosMu", cbOdaBosMU.Checked);
            cmd.Parameters.AddWithValue("odaTemizMi", cbOdaTemizMi.Checked);
            cmd.Parameters.AddWithValue("odaAktifMi", cbOdaAktifMi.Checked);
            cmd.Parameters.AddWithValue("odaAciklama", txtOdaAciklama.Text);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Yeni Oda Eklendi");
            }
            else
            {
                MessageBox.Show("Yeni Oda Eklenemedi");
            }

            string odaNumara = lvOdaListesi.SelectedItems[0].SubItems[0].Text;
        
            cmd = new SqlCommand("Insert Into OdalarOdaOzellikleri (odaID , odaOzellikleriID) Values ()");





            con.Close();

        }

        private void btnOdaSil_Click(object sender, EventArgs e)
        {
            con.Open();
            string odaNumara = lvOdaListesi.SelectedItems[0].SubItems[0].Text;
            SqlCommand cmd = new SqlCommand($"Delete From Odalar Where odaNo= '{odaNumara}'", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand($"Delete From OdalarOdaOzellikleri Where odaID=(Select odaID from Odalar Where odaNo={odaNumara})", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand($"Delete From OdalarYatakTipleri Where odaID=(Select odaID from Odalar Where odaNo={odaNumara})", con);
            cmd.ExecuteNonQuery();

            con.Close();

            /*    if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Seçilen Oda Silindi");
                }
                else
                {
                    MessageBox.Show("Seçilen Oda Silinemedi");
                }
            */

        }
    }
}
