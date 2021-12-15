using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp_MasrafOtomasyonu
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            List<Kullanici> kullanicilar = DosyaIslemleri.GetirKullanicilar();

            string kAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            foreach (Kullanici kullanici in kullanicilar)
            {
                if (kullanici.KullaniciAdi == kAdi && kullanici.Sifre == sifre)
                {
                    Degiskenler.GirisYapanKullanici = kullanici;
                    break;
                }
            }

            if (Degiskenler.GirisYapanKullanici != null)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı ya da şifre!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
