using Eokulwebapi.Context;
using Eokulwebapi.Dtos.DevamsızlıkDto;
using Eokulwebapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eokulwebapi.Service.Devamsızlık
{
    public class DevamsızlıkService : IDevamsızlıkService
    {
        private readonly OkulContext _context;

        public DevamsızlıkService(OkulContext context)
        {
            _context = context;
        }

        public async Task CreateDevamsızlıkAsync(CreateDevamsızlıkDto createDevamsızlıkDto)
        {
            // Öğrenciyi kontrol et
            var öğrenci = await _context.Öğrencis
                .FirstOrDefaultAsync(o => o.ÖğrenciId == createDevamsızlıkDto.ÖğrenciId);

            if (öğrenci == null)
            {
                throw new ArgumentException("Öğrenci bulunamadı");
            }

            // Devamsızlık kaydını oluştur
            var devamsızlık = new Eokulwebapi.Entities.Devamsızlık 
            {
                ÖğrenciId = createDevamsızlıkDto.ÖğrenciId,
                Tarih = DateTime.Now,
                RaporluMu = createDevamsızlıkDto.RaporluMu,
                NöbetçiMi = createDevamsızlıkDto.NöbetçiMi,
            };

            _context.Devamsızlıks.Add(devamsızlık);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDevamsızlıkAsync(int id)
        {
            var devamsızlık = await _context.Devamsızlıks.FindAsync(id);
            if (devamsızlık == null)
            {
                throw new ArgumentException("Devamsızlık kaydı bulunamadı");
            }

            _context.Devamsızlıks.Remove(devamsızlık);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultDevamsızlıkDto>> GetAllDevamsızlıkProgramıAsync()
        {
            var devamsızlıklar = await _context.Devamsızlıks.ToListAsync();

            return devamsızlıklar.Select(d => new ResultDevamsızlıkDto
            {
                ÖğrenciId = d.ÖğrenciId,
                DevamsızlıkId = d.DevamsızlıkId,
                Tarih = d.Tarih,
                RaporluMu = d.RaporluMu,
                NöbetçiMi = d.NöbetçiMi
            }).ToList();
        }

        public async Task<ResultDevamsızlıkDto> GetDevamsızlıkByÖğrenciIdAsync(int öğrenciId)
        {
            // Öğrencinin devamsızlık bilgilerini getir
          
            var devamsızlık = await _context.Devamsızlıks.FindAsync(öğrenciId);

            if (devamsızlık == null)
            {
                // Eğer devamsızlık kaydı bulunamadıysa null döndür
                return null;
            }

            // DTO'ya dönüştür ve geri döndür
            return new ResultDevamsızlıkDto
            {
                ÖğrenciId = devamsızlık.ÖğrenciId,
                DevamsızlıkId = devamsızlık.DevamsızlıkId,
                Tarih = devamsızlık.Tarih,
                RaporluMu = devamsızlık.RaporluMu,
                NöbetçiMi = devamsızlık.NöbetçiMi
            };
        }

        public async Task<List<ResultDevamsızlıkDto>> GetÖgrneciDevamsızlıkProgramıAsync(int id)
        {
            var devamsızlıklar = await _context.Devamsızlıks
           .Where(d => d.ÖğrenciId == id) // Filtreleme
           .ToListAsync(); // Listeye dönüştürme

            // Devamsızlıkları DTO'ya dönüştür
            return devamsızlıklar.Select(d => new ResultDevamsızlıkDto
            {
                ÖğrenciId = d.ÖğrenciId,
                DevamsızlıkId = d.DevamsızlıkId,
                Tarih = d.Tarih,
                RaporluMu = d.RaporluMu,
                NöbetçiMi = d.NöbetçiMi
            }).ToList();
        }

        public async Task UpdateDevamsızlıkAsync(UpdateDevamsızlıkDto updateDevamsızlıkDto)
        {
            var devamsızlık = await _context.Devamsızlıks.FindAsync(updateDevamsızlıkDto.DevamsızlıkId);
            if (devamsızlık == null)
            {
                throw new ArgumentException("Devamsızlık kaydı bulunamadı");
            }

            devamsızlık.Tarih = updateDevamsızlıkDto.Tarih;
            devamsızlık.RaporluMu = updateDevamsızlıkDto.RaporluMu;
            devamsızlık.NöbetçiMi = updateDevamsızlıkDto.NöbetçiMi;
            devamsızlık.ÖğrenciId = updateDevamsızlıkDto.ÖğrenciId;

            _context.Devamsızlıks.Update(devamsızlık);
            await _context.SaveChangesAsync();
        }
    }
}
