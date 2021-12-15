using System;

namespace WinFormsApp_MasrafOtomasyonu
{
    public class Masraf
    {
        // GUID : 729BABF6-1D1A-49F6-AFEF-C0E5203A9FC2

        public Guid Id { get; set; }
        public string MasrafTipi { get; set; }
        public Fis FisBilgisi { get; set; }
        public string Aciklama { get; set; }
        public MasrafDurum Durumu { get; set; }
        public Guid KullaniciId { get; set; }
    }

    public class MasrafRapor
    {
        public Guid Id { get; set; }
        public string MasrafTipi { get; set; }
        public string FisNo { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public string Durumu { get; set; }
        public string Sahibi { get; set; }
    }

    public enum MasrafDurum
    {
        OnayBekliyor = 0,
        Onaylandi = 1,
        Reddedildi = 2,
        Odendi = 3
    }

    public class Fis
    {
        public string No { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }

    public class Kullanici
    {
        public Guid Id { get; set; }
        public string TamAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public KullaniciTipi Tipi { get; set; }
        public Guid? YoneticiId { get; set; } 
        //public bool YoneticiMi { get; set; }


        //public string DisplayText
        //{
        //    get { return $"{TamAdi} ({KullaniciAdi})"; }
        //}

        public override string ToString()
        {
            return $"{TamAdi} ({KullaniciAdi})";
        }
    }

    public enum KullaniciTipi
    {
        admin = 0,
        personel = 1,
        yonetici = 2,
        muhasebeci = 3
    }
}
