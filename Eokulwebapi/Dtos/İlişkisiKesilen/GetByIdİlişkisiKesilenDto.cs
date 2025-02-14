namespace Eokulwebapi.Dtos.İlişkisiKesilen
{
    public class GetByIdİlişkisiKesilenDto
    {
        public int İlişkisiKesilenId { get; set; } // İlişkisi Kesilen ID'si

        public int ÖğrenciId { get; set; } // Öğrenci ID'si
        public DateTime İlişkisiKesilmeTarihi { get; set; } // İlişkisi Kesilme Tarihi

        public string gerekçe { get; set; }
    }
}
