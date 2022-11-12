namespace BilgiHotel
{
    partial class FrmResepsiyon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResepsiyon));
            this.tsResepsiyon = new System.Windows.Forms.ToolStrip();
            this.tsRezervasyonlar = new System.Windows.Forms.ToolStripButton();
            this.tsRzvOdalar = new System.Windows.Forms.ToolStripButton();
            this.pnlRezervasyon = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tsResepsiyon.SuspendLayout();
            this.pnlRezervasyon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsResepsiyon
            // 
            this.tsResepsiyon.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tsResepsiyon.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsResepsiyon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRezervasyonlar,
            this.tsRzvOdalar});
            this.tsResepsiyon.Location = new System.Drawing.Point(0, 0);
            this.tsResepsiyon.Margin = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.tsResepsiyon.Name = "tsResepsiyon";
            this.tsResepsiyon.Size = new System.Drawing.Size(127, 450);
            this.tsResepsiyon.TabIndex = 0;
            this.tsResepsiyon.Text = "Resepsiyon";
            // 
            // tsRezervasyonlar
            // 
            this.tsRezervasyonlar.Image = ((System.Drawing.Image)(resources.GetObject("tsRezervasyonlar.Image")));
            this.tsRezervasyonlar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRezervasyonlar.Margin = new System.Windows.Forms.Padding(0);
            this.tsRezervasyonlar.Name = "tsRezervasyonlar";
            this.tsRezervasyonlar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.tsRezervasyonlar.Size = new System.Drawing.Size(124, 50);
            this.tsRezervasyonlar.Text = "REZERVASYONLAR";
            // 
            // tsRzvOdalar
            // 
            this.tsRzvOdalar.Image = ((System.Drawing.Image)(resources.GetObject("tsRzvOdalar.Image")));
            this.tsRzvOdalar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRzvOdalar.Margin = new System.Windows.Forms.Padding(0);
            this.tsRzvOdalar.Name = "tsRzvOdalar";
            this.tsRzvOdalar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.tsRzvOdalar.Size = new System.Drawing.Size(124, 50);
            this.tsRzvOdalar.Text = "ODALAR";
            // 
            // pnlRezervasyon
            // 
            this.pnlRezervasyon.Controls.Add(this.label1);
            this.pnlRezervasyon.Location = new System.Drawing.Point(126, 0);
            this.pnlRezervasyon.Name = "pnlRezervasyon";
            this.pnlRezervasyon.Size = new System.Drawing.Size(675, 450);
            this.pnlRezervasyon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // FrmResepsiyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlRezervasyon);
            this.Controls.Add(this.tsResepsiyon);
            this.Name = "FrmResepsiyon";
            this.Text = "Resepsiyon";
            this.tsResepsiyon.ResumeLayout(false);
            this.tsResepsiyon.PerformLayout();
            this.pnlRezervasyon.ResumeLayout(false);
            this.pnlRezervasyon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsResepsiyon;
        private System.Windows.Forms.ToolStripButton tsRezervasyonlar;
        private System.Windows.Forms.ToolStripButton tsRzvOdalar;
        private System.Windows.Forms.Panel pnlRezervasyon;
        private System.Windows.Forms.Label label1;
    }
}