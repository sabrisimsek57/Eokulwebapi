﻿namespace Eokulwebapi.Dtos.DersProgramıDto
{
    public class CreateDersProgramıDto
    {
        

        public string Gün { get; set; } // Gün (Örn: "Pazartesi")
        public int KaçıncıDers { get; set; } // Kaçıncı ders (1, 2, 3, 4, 5)

        public int SınıfId { get; set; } // İlgili sınıfın ID'si
        public int DersId { get; set; } // İlgili dersin ID'si

    }
}
