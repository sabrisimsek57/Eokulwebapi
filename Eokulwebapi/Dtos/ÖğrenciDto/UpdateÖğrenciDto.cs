namespace Eokulwebapi.Dtos.ÖğrenciDto
{
    public class UpdateÖğrenciDto
    {
        public int ÖğrenciId { get; set; } // Öğrenci ID'si
        public int OkulNumarası { get; set; } // Öğrenci Okul Numarası
        public string Ad { get; set; } // Öğrenci Adı
        public string Soyad { get; set; } // Öğrenci Soyadı
        public string Cinsiyet { get; set; } // Öğrenci Cinsiyeti
        public string DevamDurumu { get; set; } // Öğrenci Devam Durumu
        public int ÖnKayıtId { get; set; } // Ön Kayıt ID'si
        public int SınıfId { get; set; } // Sınıf ID'si

        public string Şube { get; set; } // Sınıf Şubesi'si
    }
}
