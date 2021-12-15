using System;
using System.Windows.Forms;

namespace WinFormsApp_MasrafOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuUygulamaHakkinda_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void mnuCikis_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuHarcamaTipleri_Click(object sender, EventArgs e)
        {
            frmMasrafTipYonetimi frm = new frmMasrafTipYonetimi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuKullanicilar_Click(object sender, EventArgs e)
        {
            frmKullaniciYonetimi frm = new frmKullaniciYonetimi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuMasraflar_Click(object sender, EventArgs e)
        {
            frmMasraflar frm = new frmMasraflar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //try
            //{
            ShowGirisFormu();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void ShowGirisFormu()
        {
            //throw new Exception("heyyyy");

            frmGiris frmGirisFormu = new frmGiris();
            frmGirisFormu.FormClosed += FrmGirisFormu_FormClosed;
            frmGirisFormu.MdiParent = this;
            frmGirisFormu.Show();
        }

        private void FrmGirisFormu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Degiskenler.GirisYapanKullanici != null)
            {
                menuStrip1.Visible = true;
                lblGirisYapan.Text = Degiskenler.GirisYapanKullanici.TamAdi;

                mnuYonetim.Visible = false;
                mnuMasrafYonetimi.Visible = false;
                mnuRaporlar.Visible = false;

                switch (Degiskenler.GirisYapanKullanici.Tipi)
                {
                    case KullaniciTipi.admin:
                        mnuYonetim.Visible = true;
                        break;
                    case KullaniciTipi.personel:
                        mnuMasrafYonetimi.Visible = true;
                        break;
                    case KullaniciTipi.yonetici:
                        mnuMasrafYonetimi.Visible = true;
                        mnuRaporlar.Visible = true;
                        break;
                    case KullaniciTipi.muhasebeci:
                        mnuMasrafYonetimi.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void mnuOturumKapat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Oturum kapatmak istediğinize emin misiniz?", "Oturumu Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                Degiskenler.GirisYapanKullanici = null;

                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                }

                menuStrip1.Visible = false;
                ShowGirisFormu();
            }
        }

        private void mnuPersonelRapor_Click(object sender, EventArgs e)
        {
            frmRaporPersonel frm = new frmRaporPersonel();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
