using Eokulwebapi.Context;
using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto;
using Eokulwebapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eokulwebapi.Service.Öğrenci
{
    public class ÖğrenciService : IÖğrenciService
    {

        private readonly OkulContext _context;

        public ÖğrenciService(OkulContext context)
        {
            _context = context;
        }


        public async Task DeleteIÖğrenciAsync(int id)
        {
            var öğrenci = await _context.Öğrencis.FindAsync(id);
            if (öğrenci == null)
            {
                throw new Exception("Öğrenci bulunamadı.");
            }

            _context.Öğrencis.Remove(öğrenci);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultÖğrenciDto>> GetAllIÖğrenciAsync()
        {
            return await _context.Öğrencis
           .Select(o => new ResultÖğrenciDto
           {
               ÖğrenciId = o.ÖğrenciId,
               OkulNumarası = o.OkulNumarası,
               Ad = o.Ad,
               Soyad = o.Soyad,
               Cinsiyet = o.Cinsiyet,
               DevamDurumu = o.DevamDurumu,
               ÖnKayıtId = o.ÖnKayıtId,
               SınıfId = o.SınıfId,
               Şube = $"{o.Sınıf.SınıfAdı} {o.Sınıf.Şubesi}" // İlgili sınıfın şubesini çekiyoruz
           })
           .ToListAsync();
        }

        public async Task<GetByIdÖğrenciDto> GetByIdIÖğrenciAsync(int id)
        {
            var öğrenci = await _context.Öğrencis
         .Include(o => o.Sınıf) // Sınıf bilgilerini dahil ediyoruz
         .FirstOrDefaultAsync(o => o.ÖğrenciId == id);

            if (öğrenci == null)
            {
                throw new Exception("Öğrenci bulunamadı.");
            }

            return new GetByIdÖğrenciDto
            {
                ÖğrenciId = öğrenci.ÖğrenciId,
                Ad = öğrenci.Ad,
                Soyad = öğrenci.Soyad,
                Cinsiyet = öğrenci.Cinsiyet,
                DevamDurumu = öğrenci.DevamDurumu,
                OkulNumarası = öğrenci.OkulNumarası,
                ÖnKayıtId = öğrenci.ÖnKayıtId,
                SınıfId = öğrenci.SınıfId,
                Şube = $"{öğrenci.Sınıf.SınıfAdı} {öğrenci.Sınıf.Şubesi}" // Sınıf adı ve şubesi birleştiriliyor
            };
        }

        public async Task UpdateIÖğrenciAsync(UpdateÖğrenciDto updateÖğrenciDto)
        {
            var öğrenci = await _context.Öğrencis.FindAsync(updateÖğrenciDto.ÖğrenciId);
            if (öğrenci == null)
            {
                throw new Exception("Öğrenci bulunamadı.");
            }

            öğrenci.Ad = updateÖğrenciDto.Ad;
            öğrenci.Soyad = updateÖğrenciDto.Soyad;
            öğrenci.Cinsiyet = updateÖğrenciDto.Cinsiyet;
            öğrenci.DevamDurumu = updateÖğrenciDto.DevamDurumu;
            öğrenci.SınıfId = updateÖğrenciDto.SınıfId;

            _context.Öğrencis.Update(öğrenci);
            await _context.SaveChangesAsync();
        }
    }
}
