using Eokulwebapi.Context;
using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto;
using Eokulwebapi.Entities;

namespace Eokulwebapi.Service.ÖnKayıtÖğrenci
{
    public class ÖnKayıtÖğrenciService : IÖnKayıtÖğrenciService
    {

        private readonly OkulContext _context;

        public ÖnKayıtÖğrenciService(OkulContext context)
        {
            _context = context;
        }

        // Ön Kayıt Öğrencisini oluşturur
        public async Task CreateIÖnKayıtÖğrenciAsync(CreateÖnKayıtÖğrenciDto createÖnKayıtÖğrenci)
        {


            var önKayıt = new Eokulwebapi.Entities.ÖnKayıtÖğrenci
            {
                ÖğrenciAD = createÖnKayıtÖğrenci.ÖğrenciAD,
                ÖğrenciSoyad = createÖnKayıtÖğrenci.ÖğrenciSoyad,
                Cinsiyet = createÖnKayıtÖğrenci.Cinsiyet,
                BitirdiğiOkul = createÖnKayıtÖğrenci.BitirdiğiOkul,
                NotOrtalamsı = createÖnKayıtÖğrenci.NotOrtalamsı,
                VeliAd = createÖnKayıtÖğrenci.VeliAd,
                VeliSoyad = createÖnKayıtÖğrenci.VeliSoyad,
                EvTelefonu = createÖnKayıtÖğrenci.EvTelefonu,
                İşTelefonu = createÖnKayıtÖğrenci.İşTelefonu,
                EvAdresi = createÖnKayıtÖğrenci.EvAdresi,
                İlçe = createÖnKayıtÖğrenci.İlçe,
                İl = createÖnKayıtÖğrenci.İl
            };


            _context.ÖnKayıtÖğrencis.Add(önKayıt);
            await _context.SaveChangesAsync();

        }

        public Task DeleteIÖnKayıtÖğrenciAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultÖnKayıtÖğrenciDto>> GetAllIÖnKayıtÖğrenciAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdÖnKayıtÖğrenciDto> GetByIdIÖnKayıtÖğrenciAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIÖnKayıtÖğrenciAsync(UpdateÖnKayıtÖğrenciDto updateÖnKayıtÖğrenciDto)
        {
            throw new NotImplementedException();
        }

        public async Task ÖnKaydıAsılKayıtaDönüştür(int önKayıtId, int sınıfId)
        {
            var önKayıt = await _context.ÖnKayıtÖğrencis.FindAsync(önKayıtId);

            if (önKayıt == null)
            {
                throw new Exception("Ön kayıt bulunamadı.");
            }

            var sınıf = await _context.Sınıfs.FindAsync(sınıfId);

            if (sınıf == null)
            {
                throw new Exception("Sınıf bulunamadı.");
            }

            var öğrenci = new Öğrenci
            {
                OkulNumarası = GenerateOkulNumarası(), // Okul numarası oluşturulacak veya mevcut bir numara kullanılacak
                Ad = önKayıt.ÖğrenciAD,
                Soyad = önKayıt.ÖğrenciSoyad,
                Cinsiyet = önKayıt.Cinsiyet,
                DevamDurumu = "Devam Ediyor", // Varsayılan değer
                ÖnKayıtId = önKayıt.ÖnkayıtId,
                SınıfId = sınıfId,
                Şube = $"{sınıf.SınıfAdı} {sınıf.Şubesi}" // Sınıf modelinden şube bilgisini alıyoruz
            };

            _context.Öğrencis.Add(öğrenci);
            await _context.SaveChangesAsync();


           
        }

        private int GenerateOkulNumarası()
        {
            // Okul numarası oluşturma veya almanın yolu buraya gelecek
            return new Random().Next(100000, 999999); // Örnek olarak rastgele bir okul numarası
        }

    }
}
