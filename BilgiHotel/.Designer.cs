﻿namespace BilgiHotel
{
    partial class login
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
            System.Windows.Forms.Button button1;
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.lblSifremiUnuttum = new System.Windows.Forms.Label();
            this.btnGiris = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtKullaniciSifre = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.BackgroundImage = global::BilgiHotel.Properties.Resources.afdba5cbc4597fa43d4befa0600812d0;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button1.Location = new System.Drawing.Point(45, 79);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(41, 39);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            // 
            // gbLogin
            // 
            this.gbLogin.BackColor = System.Drawing.Color.Transparent;
            this.gbLogin.Controls.Add(this.lblSifremiUnuttum);
            this.gbLogin.Controls.Add(this.btnGiris);
            this.gbLogin.Controls.Add(this.button2);
            this.gbLogin.Controls.Add(button1);
            this.gbLogin.Controls.Add(this.txtKullaniciSifre);
            this.gbLogin.Controls.Add(this.txtKullaniciAdi);
            this.gbLogin.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.gbLogin.Location = new System.Drawing.Point(311, 127);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(254, 276);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Kullanıcı Giriş";
            // 
            // lblSifremiUnuttum
            // 
            this.lblSifremiUnuttum.AutoSize = true;
            this.lblSifremiUnuttum.Location = new System.Drawing.Point(119, 172);
            this.lblSifremiUnuttum.Name = "lblSifremiUnuttum";
            this.lblSifremiUnuttum.Size = new System.Drawing.Size(81, 13);
            this.lblSifremiUnuttum.TabIndex = 5;
            this.lblSifremiUnuttum.Text = "Şifremi Unuttum";
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.White;
            this.btnGiris.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnGiris.Location = new System.Drawing.Point(88, 203);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(75, 28);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "GİRİŞ YAP";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::BilgiHotel.Properties.Resources.png_transparent_computer_icons_padlock_icon_design_padlock_technic_desktop_wallpaper_computer_icons;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(45, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 33);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtKullaniciSifre
            // 
            this.txtKullaniciSifre.Location = new System.Drawing.Point(109, 145);
            this.txtKullaniciSifre.Name = "txtKullaniciSifre";
            this.txtKullaniciSifre.PasswordChar = '*';
            this.txtKullaniciSifre.Size = new System.Drawing.Size(100, 20);
            this.txtKullaniciSifre.TabIndex = 1;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(109, 87);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(100, 20);
            this.txtKullaniciAdi.TabIndex = 0;
            this.txtKullaniciAdi.Text = "H";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BilgiHotel.Properties.Resources.af8bc73c5f1c06034aa4d051a7c78fa1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(887, 538);
            this.Controls.Add(this.gbLogin);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "login";
            this.Text = "LOGIN";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox txtKullaniciSifre;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label lblSifremiUnuttum;
    }
}

