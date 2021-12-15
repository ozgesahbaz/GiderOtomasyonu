using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp_MasrafOtomasyonu
{
    public partial class frmMasraflar : Form
    {
        public frmMasraflar()
        {
            InitializeComponent();
        }

        List<Masraf> Masraflar = new List<Masraf>();
        List<string> MasrafTipleri = new List<string>();

        private void frmMasraflar_Load(object sender, EventArgs e)
        {
            MasrafTipleri = DosyaIslemleri.GetirMasrafTipleri();
            Masraflar = DosyaIslemleri.GetirMasraflar();
            Listele();

            cmbMasrafTipi.DataSource = null;
            cmbMasrafTipi.DataSource = MasrafTipleri;

            dtpTarih.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTarih.MaxDate = DateTime.Now;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Fis fis = new Fis()
            {
                No = txtFisNo.Text,
                Tarih = dtpTarih.Value,
                Tutar = nudTutar.Value
            };

            MasrafDurum durum = (Degiskenler.GirisYapanKullanici.YoneticiId == null) ? MasrafDurum.Onaylandi : MasrafDurum.OnayBekliyor;

            Masraf masraf = new Masraf()
            {
                Id = Guid.NewGuid(),
                FisBilgisi = fis,
                Aciklama = txtAciklama.Text,
                Durumu = durum,
                MasrafTipi = cmbMasrafTipi.SelectedItem.ToString(),
                KullaniciId = Degiskenler.GirisYapanKullanici.Id
            };

            Masraflar.Add(masraf);
            Listele();

            DosyaIslemleri.KaydetMasraflar(Masraflar);
        }

        private void Listele()
        {
            listView1.Items.Clear();

            List<Kullanici> kullanicilar = DosyaIslemleri.GetirKullanicilar();
            List<Kullanici> personellerim = new List<Kullanici>();

            // personel listem elde edildi.
            foreach (Kullanici kullanici in kullanicilar)
            {
                if (kullanici.YoneticiId == Degiskenler.GirisYapanKullanici.Id)
                {
                    personellerim.Add(kullanici);
                }
            }


            foreach (Masraf masraf in Masraflar)
            {
                // 1. Kural : Kendi masraflarım listelenmeli
                // 2. Kural : Yöneticisi olduğum kişilerin masrafları listelenmeli

                bool ekenecekMi = false;
                string masrafSahibi = string.Empty;

                if (masraf.KullaniciId == Degiskenler.GirisYapanKullanici.Id)
                {
                    ekenecekMi = true;
                    masrafSahibi = Degiskenler.GirisYapanKullanici.TamAdi;
                }
                else
                {
                    if (Degiskenler.GirisYapanKullanici.Tipi == KullaniciTipi.muhasebeci)
                    {
                        // muhasebeci ise mutlaka masraf görünmeli
                        ekenecekMi = true;

                        // masraf sahibi adı tüm kullanıcılara bakılarak elde edilir.
                        foreach (Kullanici k in kullanicilar)
                        {
                            if (masraf.KullaniciId == k.Id)
                            {
                                masrafSahibi = k.TamAdi;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // giriş yapan muhasebeci değil ise, yönetici ise personellerinde masraf sahibi adı bulunur.
                        foreach (Kullanici personel in personellerim)
                        {
                            if (masraf.KullaniciId == personel.Id)
                            {
                                ekenecekMi = true;
                                masrafSahibi = personel.TamAdi;
                                break;
                            }
                        }
                    }
                }

                if (ekenecekMi)
                {
                    ListViewItem listViewItem = new ListViewItem(masrafSahibi);
                    listViewItem.SubItems.Add(masraf.MasrafTipi);
                    listViewItem.SubItems.Add(masraf.FisBilgisi.Tarih.ToShortDateString());
                    listViewItem.SubItems.Add(masraf.FisBilgisi.No);
                    listViewItem.SubItems.Add(masraf.FisBilgisi.Tutar.ToString("C2"));
                    // currency : 1000 = 1000.00 TL
                    listViewItem.SubItems.Add(EnumHelper.GetMasrafDurumName(masraf.Durumu));
                    listViewItem.Tag = masraf;

                    listView1.Items.Add(listViewItem);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];

                //ListViewItem listViewItem = listView1.Items[selectedIndex];
                ListViewItem listViewItem = listView1.SelectedItems[0];
                Masraf masraf = listViewItem.Tag as Masraf;

                if (masraf != null)
                {
                    txtFisNo.Text = masraf.FisBilgisi.No;
                    txtAciklama.Text = masraf.Aciklama;
                    nudTutar.Value = masraf.FisBilgisi.Tutar;
                    dtpTarih.Value = masraf.FisBilgisi.Tarih;
                    cmbMasrafTipi.SelectedItem = masraf.MasrafTipi;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];

                //ListViewItem listViewItem = listView1.Items[selectedIndex];
                ListViewItem listViewItem = listView1.SelectedItems[0];
                Masraf masraf = listViewItem.Tag as Masraf;

                if (masraf != null)
                {
                    if (masraf.Durumu == MasrafDurum.OnayBekliyor)
                    {
                        masraf.FisBilgisi.No = txtFisNo.Text;
                        masraf.Aciklama = txtAciklama.Text;
                        masraf.FisBilgisi.Tutar = nudTutar.Value;
                        masraf.FisBilgisi.Tarih = dtpTarih.Value;
                        masraf.MasrafTipi = cmbMasrafTipi.SelectedItem.ToString();

                        Listele();
                        DosyaIslemleri.KaydetMasraflar(Masraflar);
                    }
                    else
                    {
                        MessageBox.Show("Sadece \"Onay Bekleyen\" masraflar güncellenebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];

                //ListViewItem listViewItem = listView1.Items[selectedIndex];
                ListViewItem listViewItem = listView1.SelectedItems[0];
                Masraf masraf = listViewItem.Tag as Masraf;

                if (masraf != null)
                {
                    if (masraf.Durumu == MasrafDurum.OnayBekliyor)
                    {
                        DialogResult dialogResult = MessageBox.Show($"{masraf.FisBilgisi.No} fiş numaralı masrafı silmek istediğinize emin misiniz?", "Masraf Sil", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            Masraflar.RemoveAt(selectedIndex);
                            //Masraflar.Remove(masraf);

                            Listele();
                            DosyaIslemleri.KaydetMasraflar(Masraflar);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sadece \"Onay Bekleyen\" masraflar silinebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmnuOnayBekliyor.Enabled = false;
            cmnuOnaylandi.Enabled = false;
            cmnuReddedildi.Enabled = false;
            cmnuOdendi.Enabled = false;

            switch (Degiskenler.GirisYapanKullanici.Tipi)
            {
                case KullaniciTipi.admin:
                    break;
                case KullaniciTipi.personel:
                    break;
                case KullaniciTipi.yonetici:
                    cmnuOnayBekliyor.Enabled = true;
                    cmnuOnaylandi.Enabled = true;
                    cmnuReddedildi.Enabled = true;
                    break;
                case KullaniciTipi.muhasebeci:
                    cmnuOdendi.Enabled = true;
                    break;
                default:
                    break;
            }

            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                ListViewItem listViewItem = listView1.SelectedItems[0];
                Masraf masraf = listViewItem.Tag as Masraf;

                if (masraf != null)
                {
                    switch (masraf.Durumu)
                    {
                        case MasrafDurum.OnayBekliyor:
                            cmnuOnayBekliyor.Enabled = false;
                            cmnuOdendi.Enabled = false;
                            break;
                        case MasrafDurum.Onaylandi:
                            cmnuOnaylandi.Enabled = false;
                            break;
                        case MasrafDurum.Reddedildi:
                            cmnuReddedildi.Enabled = false;
                            cmnuOdendi.Enabled = false;
                            break;
                        case MasrafDurum.Odendi:
                            cmnuOdendi.Enabled = false;
                            cmnuOnayBekliyor.Enabled = false;
                            cmnuReddedildi.Enabled = false;
                            cmnuOnaylandi.Enabled = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void cmnuOnayBekliyor_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];

                //ListViewItem listViewItem = listView1.Items[selectedIndex];
                ListViewItem listViewItem = listView1.SelectedItems[0];
                Masraf masraf = listViewItem.Tag as Masraf;

                if (masraf != null)
                {
                    if (masraf.Durumu != MasrafDurum.Odendi)
                    {
                        masraf.Durumu = MasrafDurum.OnayBekliyor;
                        
                        Listele();
                        listView1.SelectedIndices.Add(selectedIndex);

                        DosyaIslemleri.KaydetMasraflar(Masraflar);
                    }
                    else
                    {
                        MessageBox.Show("\"Ödendi\" durumundaki masrafların durumu değiştirilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cmnuOnaylandi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];

                //ListViewItem listViewItem = listView1.Items[selectedIndex];
                ListViewItem listViewItem = listView1.SelectedItems[0];
                Masraf masraf = listViewItem.Tag as Masraf;

                if (masraf != null)
                {
                    if (masraf.Durumu == MasrafDurum.OnayBekliyor || masraf.Durumu == MasrafDurum.Reddedildi)
                    {
                        masraf.Durumu = MasrafDurum.Onaylandi;

                        Listele();
                        listView1.SelectedIndices.Add(selectedIndex);

                        DosyaIslemleri.KaydetMasraflar(Masraflar);
                    }
                    else
                    {
                        MessageBox.Show("\"Ödendi\" durumundaki masrafların durumu değiştirilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cmnuReddedildi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];

                //ListViewItem listViewItem = listView1.Items[selectedIndex];
                ListViewItem listViewItem = listView1.SelectedItems[0];
                Masraf masraf = listViewItem.Tag as Masraf;

                if (masraf != null)
                {
                    if (masraf.Durumu != MasrafDurum.Odendi)
                    {
                        masraf.Durumu = MasrafDurum.Reddedildi;

                        Listele();
                        listView1.SelectedIndices.Add(selectedIndex);

                        DosyaIslemleri.KaydetMasraflar(Masraflar);
                    }
                    else
                    {
                        MessageBox.Show("\"Ödendi\" durumundaki masrafların durumu değiştirilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cmnuOdendi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                int selectedIndex = listView1.SelectedIndices[0];

                //ListViewItem listViewItem = listView1.Items[selectedIndex];
                ListViewItem listViewItem = listView1.SelectedItems[0];
                Masraf masraf = listViewItem.Tag as Masraf;

                if (masraf != null)
                {
                    if (masraf.Durumu == MasrafDurum.Onaylandi)
                    {
                        masraf.Durumu = MasrafDurum.Odendi;

                        Listele();
                        listView1.SelectedIndices.Add(selectedIndex);

                        DosyaIslemleri.KaydetMasraflar(Masraflar);
                    }
                    else
                    {
                        MessageBox.Show("Onaylanmamış masraflar \"Ödendi\" durumuna dönüştürülemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
