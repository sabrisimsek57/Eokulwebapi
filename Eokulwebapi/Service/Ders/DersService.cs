using Eokulwebapi.Context;
using Eokulwebapi.Dtos.DersDto;
using Microsoft.EntityFrameworkCore;

namespace Eokulwebapi.Service.Ders
{
    public class DersService : IDersService
    {

        private readonly OkulContext _context;

        public DersService(OkulContext context)
        {
            _context = context;
        }

        // Yeni bir ders oluşturma işlemi
        public async Task CreateDersAsync(CreateDersDto createDers)
        {
            var ders = new Eokulwebapi.Entities.Ders
            {
                DersKod = createDers.DersKod,
                DersAdı = createDers.DersAdı,
                HD_Sırası = createDers.HD_Sırası,
                ÖğretmenId = createDers.ÖğretmenId // Öğretmen atanmışsa eklenir, atanmamışsa null olabilir.
            };

            _context.Ders.Add(ders);
            await _context.SaveChangesAsync();
        }

        // Belirli bir dersi silme işlemi
        public async Task DeleteDersAsync(int id)
        {
            var ders = await _context.Ders.FindAsync(id);

            if (ders != null)
            {
                _context.Ders.Remove(ders);
                await _context.SaveChangesAsync();
            }
        }

        // Tüm dersleri listeleme işlemi
        public async Task<List<ResultDersDto>> GetAllDersAsync()
        {
            return await _context.Ders
                .Select(d => new ResultDersDto
                {
                    DersId = d.DersId,
                    DersKod = d.DersKod,
                    DersAdı = d.DersAdı,
                    HD_Sırası = d.HD_Sırası,
                    ÖğretmenId = d.ÖğretmenId
                }).ToListAsync();
        }

        // Belirli bir dersin detayını getirme işlemi
        public async Task<GetByIdDersDto> GetByIdDersAsync(int id)
        {
            var ders = await _context.Ders.FindAsync(id);

            if (ders == null)
                return null;

            return new GetByIdDersDto
            {
                DersId = ders.DersId,
                DersKod = ders.DersKod,
                DersAdı = ders.DersAdı,
                HD_Sırası = ders.HD_Sırası,
                ÖğretmenId = ders.ÖğretmenId
            };
        }

        // Belirli bir dersi güncelleme işlemi
        public async Task UpdateDersAsync(UpdateDersDto updateDersDto)
        {
            var ders = await _context.Ders.FindAsync(updateDersDto.DersId);

            if (ders != null)
            {
                ders.DersKod = updateDersDto.DersKod;
                ders.DersAdı = updateDersDto.DersAdı;
                ders.HD_Sırası = updateDersDto.HD_Sırası;
                ders.ÖğretmenId = updateDersDto.ÖğretmenId;

                await _context.SaveChangesAsync();
            }
        }
    }
}
