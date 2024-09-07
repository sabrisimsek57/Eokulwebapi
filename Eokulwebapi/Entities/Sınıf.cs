using System.ComponentModel.DataAnnotations;

namespace Eokulwebapi.Entities
{
    public class Sınıf
    {
        [Key]
        public int SınıfId { get; set; } // Sınıf ID'si
        public string SınıfAdı { get; set; } // Sınıf Adı (Örneğin: "9")
        public string Şubesi { get; set; } // Şube (Örneğin: "A")

        // Bir sınıf birden fazla öğrenci içerebilir
        public List<Öğrenci> Öğrenciler { get; set; } = new List<Öğrenci>();
    }
}
