using System.ComponentModel.DataAnnotations;

namespace Eokulwebapi.Entities
{
    public class İlişkisiKesilen
    {
        [Key]
        public int İlişkisiKesilenId { get; set; } // İlişkisi Kesilen ID'si

        public int ÖğrenciId { get; set; } // Öğrenci ID'si
        public Öğrenci Öğrenci { get; set; } // İlişkili öğrenci

        public DateTime İlişkisiKesilmeTarihi { get; set; } // İlişkisi Kesilme Tarihi
        public string Gerekçe { get; set; } // İlişkisi Kesilme Gerekçesi
    }
}
