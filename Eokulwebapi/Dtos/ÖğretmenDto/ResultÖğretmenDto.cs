namespace Eokulwebapi.Dtos.ÖğretmenDto
{
    public class ResultÖğretmenDto
    {
        public int ÖğretmenId { get; set; } // Öğretmen ID'si
        public int Sıra { get; set; } // Öğretmen sıra
        public string Ad { get; set; } // Öğretmen Adı
        public string Soyad { get; set; } // Öğretmen Soyadı
        public string? Görevi { get; set; } // Öğretmen görevi
        public string Branş { get; set; } // Öğretmen Branşı (Örn: "Matematik")
    }
}
