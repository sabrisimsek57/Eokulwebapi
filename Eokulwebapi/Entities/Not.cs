using System.ComponentModel.DataAnnotations;

namespace Eokulwebapi.Entities
{
    public class Not
    {
        [Key]
        public int NotId { get; set; } // Not ID'si

        public int ÖğrenciId { get; set; }
        public Öğrenci Öğrenci { get; set; } // İlişkili öğrenci

        public int DersId { get; set; }
        public Ders Ders { get; set; } // İlişkili ders

        public int NotDeğeri { get; set; } // int not 
    }
}
