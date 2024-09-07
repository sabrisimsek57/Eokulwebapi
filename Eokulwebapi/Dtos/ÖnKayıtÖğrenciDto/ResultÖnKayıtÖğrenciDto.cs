namespace Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto
{
    public class ResultÖnKayıtÖğrenciDto
    {
        public int ÖnkayıtId { get; set; } // Ön Kayıt ID'si
        public string ÖğrenciAD { get; set; } // Öğrenci Adı
        public string ÖğrenciSoyad { get; set; } // Öğrenci Soyadı
        public string Cinsiyet { get; set; } // Öğrenci Cinsiyeti
        public string BitirdiğiOkul { get; set; } // Mezun Olduğu Okul
        public double NotOrtalamsı { get; set; } // Not Ortalaması
        public string VeliAd { get; set; } // Veli Adı
        public string VeliSoyad { get; set; } // Veli Soyadı
        public int EvTelefonu { get; set; } // Ev Telefonu
        public int İşTelefonu { get; set; } // İş Telefonu
        public string EvAdresi { get; set; } // Ev Adresi
        public string İlçe { get; set; } // İlçe
        public string İl { get; set; } // İl

    }
}
