using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Eokulwebapi.Entities
{
    public class Öğrenci
    {
        [Key]
        public int ÖğrenciId { get; set; } // Öğrenci ID'si

        public int OkulNumarası { get; set; } // Öğrenci Okul Numarası

        public string Ad { get; set; } // Öğrenci Adı
        public string Soyad { get; set; } // Öğrenci Soyadı

        public string Cinsiyet { get; set; }//cinsiyet

        public string DevamDurumu { get; set; }//devam durumu devam ediyor

        // Ön Kayıt ile ilişkilendirme
        public int ÖnKayıtId { get; set; } // Ön Kayıt ID'si
        public ÖnKayıtÖğrenci ÖnKayıt { get; set; } // İlişkili Ön Kayıt

        // İlişkili Sınıf
        public int SınıfId { get; set; } // Sınıf ID'si
        public string Şube { get; set; } // Sınıf ID'si
        public Sınıf Sınıf { get; set; } // İlişkili Sınıf

        // Öğrencinin devamsızlık bilgileri
        public List<Devamsızlık> Devamsızlıklar { get; set; } = new List<Devamsızlık>();

        // Mezuniyet, sevk gibi durumlarda ilişkisi kesilen öğrenci bilgisi
        public İlişkisiKesilen İlişkisiKesilen { get; set; } // İlişkisi kesilen bilgi


        // AppUser ile ilişki kurmak için navigation property
        public AppUser AppUser { get; set; } // Öğrenciye bağlı AppUser

    }
}
