using Eokulwebapi.Context;
using Eokulwebapi.Entities;
using Eokulwebapi.Dtos.SınıfDto;
using Microsoft.EntityFrameworkCore;
using Eokulwebapi.Dtos.ÖğrenciDto;

namespace Eokulwebapi.Service.Sınıf
{
    public class SınıfService : ISınıfService
    {
        private readonly OkulContext _context;

        public SınıfService(OkulContext context)
        {
            _context = context;
        }
        public async Task CreateISınıfAsync(CreateSınıfDto createSınıf)
        {
            var sınıf = new Eokulwebapi.Entities.Sınıf
            {
                SınıfAdı = createSınıf.SınıfAdı,
                Şubesi = createSınıf.Şubesi
            };

            _context.Sınıfs.Add(sınıf);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteISınıfAsync(int id)
        {
            var sınıf = await _context.Sınıfs.FindAsync(id);
            if (sınıf == null)
            {
                throw new Exception("Sınıf bulunamadı.");
            }

            _context.Sınıfs.Remove(sınıf);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultSınıfDto>> GetAllISınıfAsync()
        {
            return await _context.Sınıfs
                .Select(s => new ResultSınıfDto
                {
                    SınıfId = s.SınıfId,
                    SınıfAdı = s.SınıfAdı,
                    Şubesi = s.Şubesi
                })
                .ToListAsync();
        }

        public async Task<GetByIdSınıfDto> GetByIdISınıfAsync(int id)
        {
            var sınıf = await _context.Sınıfs.FirstOrDefaultAsync(s => s.SınıfId == id);

            if (sınıf == null)
            {
                throw new Exception("Sınıf bulunamadı.");
            }

            return new GetByIdSınıfDto
            {
                SınıfId = sınıf.SınıfId,
                SınıfAdı = sınıf.SınıfAdı,
                Şubesi = sınıf.Şubesi
            };
        }

        public async Task<List<ResultÖğrenciDto>> GetStudentsByClassIdAsync(int sınıfId)
        {
            var sınıf = await _context.Sınıfs
        .Include(s => s.Öğrenciler) // Sınıf ile ilişkili öğrencileri dahil et
        .FirstOrDefaultAsync(s => s.SınıfId == sınıfId);

            if (sınıf == null)
            {
                throw new Exception("Sınıf bulunamadı.");
            }

            return sınıf.Öğrenciler
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
                    Şube = $"{o.Sınıf.SınıfAdı} {o.Sınıf.Şubesi}"
                })
                .ToList();
        }

        public async Task UpdateISınıfAsync(UpdateSınıfDto updateSınıfDto)
        {
            var sınıf = await _context.Sınıfs.FindAsync(updateSınıfDto.SınıfId);
            if (sınıf == null)
            {
                throw new Exception("Sınıf bulunamadı.");
            }

            sınıf.SınıfAdı = updateSınıfDto.SınıfAdı;
            sınıf.Şubesi = updateSınıfDto.Şubesi;

            _context.Sınıfs.Update(sınıf);
            await _context.SaveChangesAsync();
        }
    }

}

