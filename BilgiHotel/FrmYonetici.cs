using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgiHotel
{
    public partial class FrmYonetici : Form
    {
        List<Panel> panels;
        public FrmYonetici()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PanelAc(pnlOdalar);
        }

        private void FrmYonetici_Load(object sender, EventArgs e)
        {
            panels = new List<Panel>(){pnlCalisanlar,pnlOdalar,pnlMusteriler, pnlKampanyalar, pnlSatislar};
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

        private void tsSatislar_Click(object sender, EventArgs e)
        {
            PanelAc(pnlSatislar);
        }
    }
}
