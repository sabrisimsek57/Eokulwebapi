namespace Eokulwebapi.Dtos.DersDto
{
    public class CreateDersDto
    {
      
        public string DersKod { get; set; } // Ders Kodu (Örn: "MAT101")
        public string DersAdı { get; set; } // Ders Adı (Örn: "Matematik")
        public int HD_Sırası { get; set; } // Ders Sırası

        // Nullable Öğretmen ile ilişki (Öğretmen atanmamış olabilir)
        public int? ÖğretmenId { get; set; }
    }
}
