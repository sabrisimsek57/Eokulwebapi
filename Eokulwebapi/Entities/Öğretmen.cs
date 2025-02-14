using System.ComponentModel.DataAnnotations;

namespace Eokulwebapi.Entities
{
    public class Öğretmen
    {
        [Key]
        public int ÖğretmenId { get; set; } // Öğretmen ID'si
        public int? Sıra { get; set; } // Öğretmen sıra
        public string Ad { get; set; } // Öğretmen Adı
        public string Soyad { get; set; } // Öğretmen Soyadı
        public string? Görevi { get; set; } // Öğretmen görevi
        public string Branş { get; set; } // Öğretmen Branşı (Örn: "Matematik")

        // Bir öğretmenin birçok dersi olabilir
        public List<Ders> Dersler { get; set; } = new List<Ders>();

        // AppUser ile ilişki kurmak için navigation property
        public AppUser AppUser { get; set; } // Öğrenciye bağlı AppUser

    }
}
