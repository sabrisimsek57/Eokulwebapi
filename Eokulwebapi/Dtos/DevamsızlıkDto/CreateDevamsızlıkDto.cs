namespace Eokulwebapi.Dtos.DevamsızlıkDto
{
    public class CreateDevamsızlıkDto
    {
        public int ÖğrenciId { get; set; } // İlgili öğrencinin ID'si
        public DateTime Tarih { get; set; } // Devamsızlık tarihi
        public bool RaporluMu { get; set; } // Öğrencinin raporlu olup olmadığı
        public bool NöbetçiMi { get; set; } // Öğrencinin nöbetçi olup olmadığı
    }
}
