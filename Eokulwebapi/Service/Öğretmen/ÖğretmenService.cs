using Eokulwebapi.Context;
using Eokulwebapi.Dtos.ÖğretmenDto;
using Eokulwebapi.Dtos.SınıfDto;
using Microsoft.EntityFrameworkCore;

namespace Eokulwebapi.Service.Öğretmen
{
    public class ÖğretmenService  : IÖğretmenService
    {

        private readonly OkulContext _context;

        public ÖğretmenService(OkulContext context)
        {
            _context = context;
        }


        // Yeni Öğretmen oluşturma
        public async Task CreateÖğretmenAsync(CreateÖğretmenDto createÖğretmen)
        {
            var öğretmen = new Eokulwebapi.Entities.Öğretmen
            {
                Sıra = createÖğretmen.Sıra,
                Ad = createÖğretmen.Ad,
                Soyad = createÖğretmen.Soyad,
                Görevi = createÖğretmen.Görevi,
                Branş = createÖğretmen.Branş
            };

            _context.Öğretmens.Add(öğretmen);
            await _context.SaveChangesAsync();
        }

        // Öğretmen silme
        public async Task DeleteÖğretmenAsync(int id)
        {
            var öğretmen = await _context.Öğretmens.FindAsync(id);

            if (öğretmen != null)
            {
                _context.Öğretmens.Remove(öğretmen);
                await _context.SaveChangesAsync();
            }
        }

        // Tüm öğretmenleri listeleme
        public async Task<List<ResultÖğretmenDto>> GetAllÖğretmenAsync()
        {
            return await _context.Öğretmens
                .Select(ö => new ResultÖğretmenDto
                {
                    ÖğretmenId = ö.ÖğretmenId,
                    Sıra = ö.Sıra ?? 0,
                    Ad = ö.Ad,
                    Soyad = ö.Soyad,
                    Görevi = ö.Görevi,
                    Branş = ö.Branş
                })
                .ToListAsync();
        }

        // Belirli bir öğretmeni ID ile getirme
        public async Task<GetByIdÖğretmenDto> GetByIdÖğretmenAsync(int id)
        {
            var öğretmen = await _context.Öğretmens.FindAsync(id);

            if (öğretmen == null)
                return null;

            return new GetByIdÖğretmenDto
            {
                ÖğretmenId = öğretmen.ÖğretmenId,
                Sıra = öğretmen.Sıra ?? 0,
                Ad = öğretmen.Ad,
                Soyad = öğretmen.Soyad,
                Görevi = öğretmen.Görevi,
                Branş = öğretmen.Branş
            };
        }

        // Öğretmen güncelleme
        public async Task UpdateÖğretmenAsync(UpdateÖğretmenDto updateÖğretmenDto)
        {
            var öğretmen = await _context.Öğretmens.FindAsync(updateÖğretmenDto.ÖğretmenId);

            if (öğretmen != null)
            {
                öğretmen.Sıra = updateÖğretmenDto.Sıra;
                öğretmen.Ad = updateÖğretmenDto.Ad;
                öğretmen.Soyad = updateÖğretmenDto.Soyad;
                öğretmen.Görevi = updateÖğretmenDto.Görevi;
                öğretmen.Branş = updateÖğretmenDto.Branş;

                await _context.SaveChangesAsync();
            }
        }


    }
}
