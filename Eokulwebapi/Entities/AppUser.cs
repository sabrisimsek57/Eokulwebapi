using Microsoft.AspNetCore.Identity;

namespace Eokulwebapi.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        // Öğrenci ile ilişki kurmak için ÖğrenciId ve navigation property
        public int? ÖğrenciId { get; set; } // Öğrenci ID'si (nullable olabilir)
        public Öğrenci Öğrenci { get; set; } // İlişkili Öğrenci


        // Öğrenci ile ilişki kurmak için ÖğrenciId ve navigation property
        public int? ÖğretmenId { get; set; } // Öğrenci ID'si (nullable olabilir)
        public Öğretmen Öğretmen { get; set; } // İlişkili Öğrenci
    }
}
