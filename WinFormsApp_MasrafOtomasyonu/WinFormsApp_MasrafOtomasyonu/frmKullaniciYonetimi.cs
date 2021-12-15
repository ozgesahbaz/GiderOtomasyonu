using Ganss.Excel;
using MFramework.Services.FakeData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp_MasrafOtomasyonu
{
    public partial class frmKullaniciYonetimi : Form
    {
        public frmKullaniciYonetimi()
        {
            InitializeComponent();
        }

        List<Kullanici> Kullanicilar = new List<Kullanici>();
        List<Kullanici> Yoneticiler = new List<Kullanici>();
        string Path = Application.StartupPath + "\\kullanicilar.json";

        private void frmKullaniciYonetimi_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < 25; i++)
            //{
            //    string fullName = NameData.GetFullName();

            //    Kullanicilar.Add(new Kullanici
            //    {
            //        Id = Guid.NewGuid(),
            //        TamAdi = fullName,
            //        KullaniciAdi = fullName.Replace(" ", "-"),
            //        Sifre = NumberData.GetNumber(100000, 999999).ToString(),
            //        Tipi = EnumData.GetElement<KullaniciTipi>()
            //    });
            //}

            Kullanicilar = DosyaIslemleri.GetirKullanicilar();

            YoneticiListesiOlustur();

            foreach (Kullanici kullanici in Kullanicilar)
            {
                if (BooleanData.GetBoolean())
                {
                    Kullanici yonetici = CollectionData.GetElement<Kullanici>(Yoneticiler);
                    kullanici.YoneticiId = yonetici.Id;
                }
            }


            lstKullanicilar.DataSource = null;
            lstKullanicilar.DataSource = Kullanicilar;

            cmbYonetici.DataSource = null;
            cmbYonetici.DataSource = Yoneticiler;

            cmbTipi.DataSource = null;
            cmbTipi.DataSource = EnumHelper.GetKullaniciTipiList();
        }

        private void YoneticiListesiOlustur()
        {
            Yoneticiler = new List<Kullanici>();

            foreach (Kullanici kullanici in Kullanicilar)
            {
                if (kullanici.Tipi == KullaniciTipi.yonetici)
                {
                    Yoneticiler.Add(kullanici);
                }
            }
        }

        private void lstKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            KullaniciDetayYazdir();

            if (lstKullanicilar.SelectedIndex > -1)
            {
                Kullanici seciliKullanici = lstKullanicilar.SelectedItem as Kullanici;
                Kullanici seciliYonetici = null;

                foreach (Kullanici yonetici in Yoneticiler)
                {
                    if (yonetici.Id == seciliKullanici.YoneticiId)
                    {
                        seciliYonetici = yonetici;
                        break;
                    }
                }

                txtTamAdi.Text = seciliKullanici.TamAdi;
                txtKullaniciAdi.Text = seciliKullanici.KullaniciAdi;
                txtSifre.Text = seciliKullanici.Sifre;
                cmbTipi.SelectedValue = (int)seciliKullanici.Tipi;
                cmbYonetici.SelectedItem = seciliYonetici;
            }
        }

        private void KullaniciDetayYazdir()
        {
            if (lstKullanicilar.SelectedIndex == -1)
            {
                //lblTamAdi.ResetText();
                ////lblTamAdi.Text = "";
                ////lblTamAdi.Text = string.Empty;
                //lblKullaniciAdi.ResetText();
                //lblSifre.ResetText();
                //lblTipi.ResetText();
                //lblYoneticisi.ResetText();


                // hepsi label ise bu kod hata vermeden çalışır.
                //foreach (Label label in flpLabels.Controls)
                //{
                //    label.ResetText();
                //}

                foreach (Control control in flpLabels.Controls)
                {
                    if (control.GetType() == typeof(Label))
                    {
                        (control as Label).ResetText();
                    }
                }
            }
            else
            {
                Kullanici kullanici = (Kullanici)lstKullanicilar.SelectedItem;

                lblTamAdi.Text = kullanici.TamAdi;
                lblKullaniciAdi.Text = kullanici.KullaniciAdi;
                lblSifre.Text = kullanici.Sifre;
                lblTipi.Text = EnumHelper.GetKullaniciTipiName(kullanici.Tipi);

                string yonecitiTamAdi = string.Empty;

                foreach (Kullanici yonetici in Yoneticiler)
                {
                    if (yonetici.Id == kullanici.YoneticiId)
                    {
                        yonecitiTamAdi = yonetici.ToString();
                        break;
                    }
                }

                lblYoneticisi.Text = yonecitiTamAdi;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.Id = Guid.NewGuid();
            kullanici.TamAdi = txtTamAdi.Text.Trim();
            kullanici.KullaniciAdi = txtKullaniciAdi.Text.Trim();
            kullanici.Sifre = txtSifre.Text.Trim();
            kullanici.Tipi = (KullaniciTipi)(cmbTipi.SelectedItem as EnumObject).Value;
            kullanici.YoneticiId = (cmbYonetici.SelectedItem as Kullanici)?.Id;

            Kullanicilar.Add(kullanici);

            lstKullanicilar.DataSource = null;
            lstKullanicilar.DataSource = Kullanicilar;

            // Eğer yeni eklenen kullanıcı bir yönetici ise onu yönetici listesine ve combobox a da ekle.
            if (kullanici.Tipi == KullaniciTipi.yonetici)
            {
                Yoneticiler.Add(kullanici);

                cmbYonetici.DataSource = null;
                cmbYonetici.DataSource = Yoneticiler;
            }

            // CTRL + K + D
            DosyaIslemleri.KaydetKullanicilar(Kullanicilar);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lstKullanicilar.SelectedIndex > -1)
            {
                Kullanici seciliKullanici = lstKullanicilar.SelectedItem as Kullanici;
                seciliKullanici.TamAdi = txtTamAdi.Text.Trim();
                seciliKullanici.KullaniciAdi = txtKullaniciAdi.Text.Trim();
                seciliKullanici.Sifre = txtSifre.Text.Trim();
                seciliKullanici.Tipi = (KullaniciTipi)(cmbTipi.SelectedItem as EnumObject).Value;
                seciliKullanici.YoneticiId = (cmbYonetici.SelectedItem as Kullanici)?.Id;

                KullaniciListboxYenileYoneticiListeYenile();

                DosyaIslemleri.KaydetKullanicilar(Kullanicilar);
            }
        }

        private void KullaniciListboxYenileYoneticiListeYenile()
        {
            lstKullanicilar.DataSource = null;
            lstKullanicilar.DataSource = Kullanicilar;

            YoneticiListesiOlustur();

            cmbYonetici.DataSource = null;
            cmbYonetici.DataSource = Yoneticiler;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstKullanicilar.SelectedIndex > -1)
            {
                // silmeden önce bu kullanıcı herhangi bir kullanıcının yöneticisi mi diye bakılır
                // Eğer başka bir kullanıcı da yöneticiId olarak kayıtlı ise Id si oradan temizlenir.

                Kullanici seciliKullanici = lstKullanicilar.SelectedItem as Kullanici;

                if (seciliKullanici.Tipi == KullaniciTipi.yonetici)
                {
                    foreach (Kullanici kullanici in Kullanicilar)
                    {
                        if (kullanici.YoneticiId == seciliKullanici.Id)
                        {
                            kullanici.YoneticiId = Guid.Empty;
                        }
                    }
                }

                Kullanicilar.RemoveAt(lstKullanicilar.SelectedIndex);

                KullaniciListboxYenileYoneticiListeYenile();

                DosyaIslemleri.KaydetKullanicilar(Kullanicilar);
            }
        }

        private void mnuKaydet_Click(object sender, EventArgs e)
        {
            btnKaydet_Click(btnEkle, EventArgs.Empty);
        }

        private void mnuSil_Click(object sender, EventArgs e)
        {
            btnSil_Click(btnSil, e);
        }

        private void mnuExcelAktar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Title = "Excel Aktar";
            saveFileDialog.FileName = "kullanicilar.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelMapper mapper = new ExcelMapper();
                mapper.Save<Kullanici>(saveFileDialog.FileName, Kullanicilar, "Kullanıcılar");

                notifyIcon1.ShowBalloonTip(5000);
            }
        }
    }
}
