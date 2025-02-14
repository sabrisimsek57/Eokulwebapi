using System.ComponentModel.DataAnnotations;

namespace Eokulwebapi.Entities
{
    public class Ders
    {

      
        [Key]
        public int DersId { get; set; } // Ders ID'si
        public string DersKod { get; set; } // Ders Kodu (Örn: "MAT101")
        public string DersAdı { get; set; } // Ders Adı (Örn: "Matematik")
        public int HD_Sırası { get; set; } // Ders Sırası

        // Nullable Öğretmen ile ilişki (Öğretmen atanmamış olabilir)
        public int? ÖğretmenId { get; set; }
        public Öğretmen? Öğretmen { get; set; } // Öğretmen nullable olabilir

        // Bir ders birçok ders programında yer alabilir
        public List<DersProgramı> DersProgramları { get; set; } = new List<DersProgramı>();
    }
}
