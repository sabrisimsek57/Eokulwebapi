using Eokulwebapi.Context;
using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto;
using Eokulwebapi.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteIÖnKayıtÖğrenciAsync(int id)
        {
            var önKayıt = await _context.ÖnKayıtÖğrencis.FindAsync(id);

            if (önKayıt == null)
            {
                throw new Exception("Ön kayıt bulunamadı.");
            }

            _context.ÖnKayıtÖğrencis.Remove(önKayıt);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultÖnKayıtÖğrenciDto>> GetAllIÖnKayıtÖğrenciAsync()
        {
            return await _context.ÖnKayıtÖğrencis
            .Select(o => new ResultÖnKayıtÖğrenciDto
            {
                ÖnkayıtId = o.ÖnkayıtId,
                ÖğrenciAD = o.ÖğrenciAD,
                ÖğrenciSoyad = o.ÖğrenciSoyad,
                Cinsiyet = o.Cinsiyet,
                BitirdiğiOkul = o.BitirdiğiOkul,
                NotOrtalamsı = o.NotOrtalamsı,
                VeliAd = o.VeliAd,
                VeliSoyad = o.VeliSoyad,
                EvTelefonu = o.EvTelefonu,
                İşTelefonu = o.İşTelefonu,
                EvAdresi = o.EvAdresi,
                İlçe = o.İlçe,
                İl = o.İl
            })
            .ToListAsync();
        }

        public async Task<GetByIdÖnKayıtÖğrenciDto> GetByIdIÖnKayıtÖğrenciAsync(int id)
        {
            var önKayıt = await _context.ÖnKayıtÖğrencis.FindAsync(id);

            if (önKayıt == null)
            {
                throw new Exception("Ön kayıt bulunamadı.");
            }

            return new GetByIdÖnKayıtÖğrenciDto
            {
                ÖnkayıtId = önKayıt.ÖnkayıtId,
                ÖğrenciAD = önKayıt.ÖğrenciAD,
                ÖğrenciSoyad = önKayıt.ÖğrenciSoyad,
                Cinsiyet = önKayıt.Cinsiyet,
                BitirdiğiOkul = önKayıt.BitirdiğiOkul,
                NotOrtalamsı = önKayıt.NotOrtalamsı,
                VeliAd = önKayıt.VeliAd,
                VeliSoyad = önKayıt.VeliSoyad,
                EvTelefonu = önKayıt.EvTelefonu,
                İşTelefonu = önKayıt.İşTelefonu,
                EvAdresi = önKayıt.EvAdresi,
                İlçe = önKayıt.İlçe,
                İl = önKayıt.İl
            };
        }

        public async Task UpdateIÖnKayıtÖğrenciAsync(UpdateÖnKayıtÖğrenciDto updateÖnKayıtÖğrenciDto)
        {
            var önKayıt = await _context.ÖnKayıtÖğrencis.FindAsync(updateÖnKayıtÖğrenciDto.ÖnkayıtId);

            if (önKayıt == null)
            {
                throw new Exception("Ön kayıt bulunamadı.");
            }

            önKayıt.ÖğrenciAD = updateÖnKayıtÖğrenciDto.ÖğrenciAD;
            önKayıt.ÖğrenciSoyad = updateÖnKayıtÖğrenciDto.ÖğrenciSoyad;
            önKayıt.Cinsiyet = updateÖnKayıtÖğrenciDto.Cinsiyet;
            önKayıt.BitirdiğiOkul = updateÖnKayıtÖğrenciDto.BitirdiğiOkul;
            önKayıt.NotOrtalamsı = updateÖnKayıtÖğrenciDto.NotOrtalamsı;
            önKayıt.VeliAd = updateÖnKayıtÖğrenciDto.VeliAd;
            önKayıt.VeliSoyad = updateÖnKayıtÖğrenciDto.VeliSoyad;
            önKayıt.EvTelefonu = updateÖnKayıtÖğrenciDto.EvTelefonu;
            önKayıt.İşTelefonu = updateÖnKayıtÖğrenciDto.İşTelefonu;
            önKayıt.EvAdresi = updateÖnKayıtÖğrenciDto.EvAdresi;
            önKayıt.İlçe = updateÖnKayıtÖğrenciDto.İlçe;
            önKayıt.İl = updateÖnKayıtÖğrenciDto.İl;

            _context.ÖnKayıtÖğrencis.Update(önKayıt);
            await _context.SaveChangesAsync();
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

            var öğrenci =  new Eokulwebapi.Entities.Öğrenci
            {
                OkulNumarası = await GenerateOkulNumarası(), // Okul numarası oluşturulacak veya mevcut bir numara kullanılacak
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

        private async Task< int> GenerateOkulNumarası()
        {
            // Veritabanındaki en yüksek okul numarasını buluyoruz
            var maxOkulNumarası = await _context.Öğrencis.MaxAsync(o => (int?)o.OkulNumarası) ?? 101; // Eğer hiç öğrenci yoksa 101'den başla

            // Son okul numarasını bir artırıp döndürüyoruz
            return maxOkulNumarası + 1;

        }

    }
}
