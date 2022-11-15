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

        List<KeyValuePair<int, string>> Katlar = new List<KeyValuePair<int, string>>();
        SqlConnection con = new SqlConnection("Server=.;Database=DB_BilgiHotel;Trusted_Connection=True;");
        private void FrmYonetici_Load(object sender, EventArgs e)
        {
            panels = new List<Panel>(){pnlCalisanlar,pnlOdalar,pnlMusteriler, pnlKampanyalar};
            foreach(Panel panel in panels)
            {
                panel.Visible = false;
            }
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
        }

        private void tsKampanyalar_Click(object sender, EventArgs e)
        {
            PanelAc(pnlKampanyalar);
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
    }
}
