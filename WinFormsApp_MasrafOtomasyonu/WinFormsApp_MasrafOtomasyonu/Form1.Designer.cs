
namespace WinFormsApp_MasrafOtomasyonu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOturumKapat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYonetim = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKullanicilar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHarcamaTipleri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasrafYonetimi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasraflar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRaporlar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonelRapor = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUygulamaHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblGirisYapan = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.mnuYonetim,
            this.mnuMasrafYonetimi,
            this.mnuRaporlar,
            this.hakkındaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOturumKapat,
            this.toolStripMenuItem1,
            this.mnuCikis});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // mnuOturumKapat
            // 
            this.mnuOturumKapat.Name = "mnuOturumKapat";
            this.mnuOturumKapat.Size = new System.Drawing.Size(158, 22);
            this.mnuOturumKapat.Text = "Oturum Kapat";
            this.mnuOturumKapat.Click += new System.EventHandler(this.mnuOturumKapat_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // mnuCikis
            // 
            this.mnuCikis.Name = "mnuCikis";
            this.mnuCikis.Size = new System.Drawing.Size(158, 22);
            this.mnuCikis.Text = "Çıkış";
            this.mnuCikis.Click += new System.EventHandler(this.mnuCikis_Click);
            // 
            // mnuYonetim
            // 
            this.mnuYonetim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKullanicilar,
            this.mnuHarcamaTipleri});
            this.mnuYonetim.Name = "mnuYonetim";
            this.mnuYonetim.Size = new System.Drawing.Size(66, 21);
            this.mnuYonetim.Text = "Yönetim";
            // 
            // mnuKullanicilar
            // 
            this.mnuKullanicilar.Name = "mnuKullanicilar";
            this.mnuKullanicilar.Size = new System.Drawing.Size(168, 22);
            this.mnuKullanicilar.Text = "Kullanıcılar";
            this.mnuKullanicilar.Click += new System.EventHandler(this.mnuKullanicilar_Click);
            // 
            // mnuHarcamaTipleri
            // 
            this.mnuHarcamaTipleri.Name = "mnuHarcamaTipleri";
            this.mnuHarcamaTipleri.Size = new System.Drawing.Size(168, 22);
            this.mnuHarcamaTipleri.Text = "Harcama Tipleri";
            this.mnuHarcamaTipleri.Click += new System.EventHandler(this.mnuHarcamaTipleri_Click);
            // 
            // mnuMasrafYonetimi
            // 
            this.mnuMasrafYonetimi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMasraflar});
            this.mnuMasrafYonetimi.Name = "mnuMasrafYonetimi";
            this.mnuMasrafYonetimi.Size = new System.Drawing.Size(114, 21);
            this.mnuMasrafYonetimi.Text = "Masraf Yönetimi";
            // 
            // mnuMasraflar
            // 
            this.mnuMasraflar.Name = "mnuMasraflar";
            this.mnuMasraflar.Size = new System.Drawing.Size(132, 22);
            this.mnuMasraflar.Text = "Masraflar";
            this.mnuMasraflar.Click += new System.EventHandler(this.mnuMasraflar_Click);
            // 
            // mnuRaporlar
            // 
            this.mnuRaporlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPersonelRapor});
            this.mnuRaporlar.Name = "mnuRaporlar";
            this.mnuRaporlar.Size = new System.Drawing.Size(71, 21);
            this.mnuRaporlar.Text = "Raporlar";
            // 
            // mnuPersonelRapor
            // 
            this.mnuPersonelRapor.Name = "mnuPersonelRapor";
            this.mnuPersonelRapor.Size = new System.Drawing.Size(180, 22);
            this.mnuPersonelRapor.Text = "Personel Raporu";
            this.mnuPersonelRapor.Click += new System.EventHandler(this.mnuPersonelRapor_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUygulamaHakkinda});
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            // 
            // mnuUygulamaHakkinda
            // 
            this.mnuUygulamaHakkinda.Name = "mnuUygulamaHakkinda";
            this.mnuUygulamaHakkinda.Size = new System.Drawing.Size(191, 22);
            this.mnuUygulamaHakkinda.Text = "Uygulama Hakkında";
            this.mnuUygulamaHakkinda.Click += new System.EventHandler(this.mnuUygulamaHakkinda_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblGirisYapan});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblGirisYapan
            // 
            this.lblGirisYapan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGirisYapan.Name = "lblGirisYapan";
            this.lblGirisYapan.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Masraf Otomasyonu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCikis;
        private System.Windows.Forms.ToolStripMenuItem mnuYonetim;
        private System.Windows.Forms.ToolStripMenuItem mnuKullanicilar;
        private System.Windows.Forms.ToolStripMenuItem mnuHarcamaTipleri;
        private System.Windows.Forms.ToolStripMenuItem mnuMasrafYonetimi;
        private System.Windows.Forms.ToolStripMenuItem mnuMasraflar;
        private System.Windows.Forms.ToolStripMenuItem mnuRaporlar;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonelRapor;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUygulamaHakkinda;
        private System.Windows.Forms.ToolStripMenuItem mnuOturumKapat;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblGirisYapan;
    }
}

