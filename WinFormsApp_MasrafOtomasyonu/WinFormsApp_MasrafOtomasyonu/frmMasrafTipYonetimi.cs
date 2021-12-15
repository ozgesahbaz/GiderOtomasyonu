using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp_MasrafOtomasyonu
{
    public partial class frmMasrafTipYonetimi : Form
    {
        public frmMasrafTipYonetimi()
        {
            InitializeComponent();
        }

        string Path = Application.StartupPath + "\\masraftipleri.json";
        List<string> MasrafTipleri = new List<string>();

        private void frmHarcamaYonetimi_Load(object sender, EventArgs e)
        {
            MasrafTipleri = DosyaIslemleri.GetirMasrafTipleri();
            YukleListbox();
        }

        private void YukleListbox()
        {
            lstMasrafTipi.DataSource = null;
            lstMasrafTipi.DataSource = MasrafTipleri;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // "     "
            string tip = txtMasrafTipi.Text?.Trim();

            //if (tip != null)
            //{
            //    tip = tip.Trim();
            //}

            //if (string.IsNullOrEmpty(txtMasrafTipi.Text) || string.IsNullOrWhiteSpace(txtMasrafTipi.Text))
            if (string.IsNullOrEmpty(tip))
            {
                MessageBox.Show("Lütfen bir masraf tipi değeri giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MasrafTipleri.Contains(tip))
                {
                    // aynı isimli veri varsa
                    MessageBox.Show($"{tip} isimli masraf tipi zaten mevcuttur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MasrafTipleri.Add(tip);
                    DosyaIslemleri.KaydetMasrafTipleri(MasrafTipleri);
                    YukleListbox();
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lstMasrafTipi.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen güncelleme için bir masraf tipi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string tip = txtMasrafTipi.Text?.Trim();

            if (string.IsNullOrEmpty(tip))
            {
                MessageBox.Show("Lütfen bir masraf tipi değeri giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MasrafTipleri.Contains(tip))
                {
                    // aynı isimli veri varsa
                    MessageBox.Show($"{tip} isimli masraf tipi zaten mevcuttur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MasrafTipleri[lstMasrafTipi.SelectedIndex] = tip;

                    DosyaIslemleri.KaydetMasrafTipleri(MasrafTipleri);
                    YukleListbox();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstMasrafTipi.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen silmek için bir masraf tipi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //string masrafTipi = lstMasrafTipi.SelectedItem.ToString();
            string masrafTipi = MasrafTipleri[lstMasrafTipi.SelectedIndex];

            DialogResult dialogResult = MessageBox.Show($"{masrafTipi} tipini silmek istediğinize emin misiniz?", "Masraf Tipi Sil", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (dialogResult == DialogResult.Yes)
            {
                MasrafTipleri.RemoveAt(lstMasrafTipi.SelectedIndex);
                DosyaIslemleri.KaydetMasrafTipleri(MasrafTipleri);
                YukleListbox();
            }
        }

        private void lstMasrafTipi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstMasrafTipi.SelectedIndex > -1)
            {
                txtMasrafTipi.Text = lstMasrafTipi.SelectedItem.ToString();
            }
        }
    }
}
