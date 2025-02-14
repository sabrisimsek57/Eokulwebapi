﻿using System.ComponentModel.DataAnnotations;

namespace Eokulwebapi.Entities
{
    public class DersProgramı
    {
        [Key]
        public int DersProgramıId { get; set; } // Ders Programı ID'si
      
        public string Gün { get; set; } // Gün (Örn: "Pazartesi")
        public int KaçıncıDers { get; set; } // Kaçıncı ders (1, 2, 3, 4, 5)

        public int SınıfId { get; set; } // İlgili sınıfın ID'si
        public int DersId { get; set; } // İlgili dersin ID'si

        // Navigation properties
        public Sınıf Sınıf { get; set; } // İlgili sınıf
        public Ders Ders { get; set; } // İlgili ders
    }
}
