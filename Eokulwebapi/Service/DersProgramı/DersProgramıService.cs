using Eokulwebapi.Context;
using Eokulwebapi.Dtos.DersProgramıDto;
using Eokulwebapi.Dtos.ÖğretmenDto;
using Microsoft.EntityFrameworkCore;

namespace Eokulwebapi.Service.DersProgramı
{
    public class DersProgramıService : IDersProgramıService
    {
        private readonly OkulContext _context;

        public DersProgramıService(OkulContext context)
        {
            _context = context;
        }

        public async Task CreateDersAsync(CreateDersProgramıDto createDersProgramı)
        {
            var dersProgramı = new Eokulwebapi.Entities.DersProgramı
            {
                Gün = createDersProgramı.Gün,
                KaçıncıDers = createDersProgramı.KaçıncıDers,
                SınıfId = createDersProgramı.SınıfId,
                DersId = createDersProgramı.DersId
            };

            _context.dersProgramıs.Add(dersProgramı);
            await _context.SaveChangesAsync();
        }

        // Ders Programını silme
        public async Task DeleteDersProgramıAsync(int id)
        {
            var dersProgramı = await _context.dersProgramıs.FindAsync(id);

            if (dersProgramı != null)
            {
                _context.dersProgramıs.Remove(dersProgramı);
                await _context.SaveChangesAsync();
            }
        }

        // Tüm Ders Programlarını listeleme
        public async Task<List<ResultDersProgramıDto>> GetAllDersProgramıAsync()
        {
            return await _context.dersProgramıs
                .Select(dp => new ResultDersProgramıDto
                {
                    DersProgramıId = dp.DersProgramıId,
                    Gün = dp.Gün,
                    KaçıncıDers = dp.KaçıncıDers,
                    SınıfId = dp.SınıfId,
                    DersId = dp.DersId,
                    SınıfAdı = dp.Sınıf.SınıfAdı, // Navigation property
                    DersAdı = dp.Ders.DersAdı // Navigation property
                })
                .ToListAsync();
        }

        // Belirli bir Ders Programını ID ile getirme
        public async Task<GetByIdDersProgramıDto> GetByIdDersProgramıAsync(int id)
        {
            var dersProgramı = await _context.dersProgramıs
                .Include(dp => dp.Sınıf)
                .Include(dp => dp.Ders)
                .FirstOrDefaultAsync(dp => dp.DersProgramıId == id);

            if (dersProgramı == null)
                return null;

            return new GetByIdDersProgramıDto
            {
                DersProgramıId = dersProgramı.DersProgramıId,
                Gün = dersProgramı.Gün,
                KaçıncıDers = dersProgramı.KaçıncıDers,
                SınıfId = dersProgramı.SınıfId,
                DersId = dersProgramı.DersId,
                SınıfAdı = dersProgramı.Sınıf.SınıfAdı,
                DersAdı = dersProgramı.Ders.DersAdı
            };
        }

        public async Task<List<ResultDersProgramıDto>> GetDersProgramıBySınıfIdAsync(int sınıfId)
        {
            // Ders programlarını al ve gerekli ilişkiyi dahil et
            var dersProgramları = await _context.dersProgramıs
                .Where(dp => dp.SınıfId == sınıfId)
                .Include(dp => dp.Ders) // Ders bilgilerini dahil et
                .ToListAsync();

            // DTO'ya dönüştür
            var result = dersProgramları.Select(dp => new ResultDersProgramıDto
            {
                DersProgramıId = dp.DersProgramıId,
                
                DersId = dp.DersId,
                SınıfId = dp.SınıfId,
                
                Gün = dp.Gün,
                KaçıncıDers = dp.KaçıncıDers,
                DersAdı = dp.Ders.DersAdı
                
            }).ToList();

            return result;
        }

        public async Task<List<ResultDersProgramıDto>> GetOğretmenDersProgramıByÖğretmenIdAsync(int öğretmenId)
        {
            var dersProgramları = await _context.dersProgramıs
        .Where(dp => dp.Ders.ÖğretmenId == öğretmenId)
        .Include(dp => dp.Ders) // Ders bilgilerini dahil et
        .ToListAsync();

            var result = dersProgramları.Select(dp => new ResultDersProgramıDto
            {
                Gün = dp.Gün,
        
                DersProgramıId = dp.DersProgramıId,
                DersId = dp.DersId,
                SınıfId = dp.SınıfId,
                KaçıncıDers = dp.KaçıncıDers,
                DersAdı = dp.Ders.DersAdı // Ders adı
            }).ToList();

            return result;
        }

        // Ders Programı güncelleme
        public async Task UpdateDersProgramıAsync(UpdateDersProgramıDto updateDersProgramıDto)
        {
            var dersProgramı = await _context.dersProgramıs.FindAsync(updateDersProgramıDto.DersProgramıId);

            if (dersProgramı != null)
            {
                dersProgramı.Gün = updateDersProgramıDto.Gün;
                dersProgramı.KaçıncıDers = updateDersProgramıDto.KaçıncıDers;
                dersProgramı.SınıfId = updateDersProgramıDto.SınıfId;
                dersProgramı.DersId = updateDersProgramıDto.DersId;

                await _context.SaveChangesAsync();
            }
        }
    }
}
