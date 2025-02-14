namespace Eokulwebapi.Dtos.ÖğretmenDto
{
    public class ResultOğretmenDersProgramıDto
    {
        public string Gün { get; set; } // Gün (Pazartesi, Salı, vb.)
        public int KaçıncıDers { get; set; } // Kaçıncı Ders (1, 2, 3, 4, 5, vb.)
        public string DersAdı { get; set; } // Ders Adı
        public string ÖğretmenAdı { get; set; } // Öğretmen Adı (isteğe bağlı)
    }
}
