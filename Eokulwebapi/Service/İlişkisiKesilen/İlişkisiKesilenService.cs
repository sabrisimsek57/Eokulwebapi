using Eokulwebapi.Context;
using Eokulwebapi.Dtos.İlişkisiKesilen;
using Eokulwebapi.Entities;
using Eokulwebapi.Service.Öğrenci;
using Microsoft.EntityFrameworkCore;

namespace Eokulwebapi.Service.İlişkisiKesilen
{
    public class İlişkisiKesilenService : IİlişkisiKesilenService
    {
        private readonly OkulContext _context;

        public İlişkisiKesilenService(OkulContext context)
        {
            _context = context;
        }


        public async Task KesilmeİşlemiAsync(CreateİlişkisiKesilen createİlişkisiKesilen)
        {
            var öğrenci = await _context.Öğrencis
                .Include(o => o.İlişkisiKesilen)
                .FirstOrDefaultAsync(o => o.ÖğrenciId == createİlişkisiKesilen.öğrenciId);

            if (öğrenci == null)
            {
                throw new ArgumentException("Öğrenci bulunamadı");
            }

            if (öğrenci.İlişkisiKesilen != null)
            {
                throw new InvalidOperationException("Öğrencinin ilişkisi zaten kesilmiş.");
            }

            öğrenci.DevamDurumu = "devam etmiyor";

            var ilişkisiKesilen = new Eokulwebapi.Entities.İlişkisiKesilen
            {
                ÖğrenciId = createİlişkisiKesilen.öğrenciId,
                İlişkisiKesilmeTarihi = DateTime.Now,
                Gerekçe = createİlişkisiKesilen.gerekçe
            };

            _context.İlişkisiKesilens.Add(ilişkisiKesilen);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultİlişkisiKesilenDto>> GetAllİlişkisiKesilenAsync()
        {
            var ilişkisiKesilenler = await _context.İlişkisiKesilens.ToListAsync();

            return ilişkisiKesilenler.Select(i => new ResultİlişkisiKesilenDto
            {
                ÖğrenciId = i.ÖğrenciId,
                İlişkisiKesilenId = i.İlişkisiKesilenId,
                gerekçe = i.Gerekçe,
                İlişkisiKesilmeTarihi = i.İlişkisiKesilmeTarihi
            }).ToList();
        }

        public async Task UpdateİlişkisiKesilenAsync(UpdateİlişkisiKesilenDto updateİlişkisiKesilenDto)
        {
            var ilişkisiKesilen = await _context.İlişkisiKesilens.FindAsync(updateİlişkisiKesilenDto.İlişkisiKesilenId);
            if (ilişkisiKesilen == null)
            {
                throw new ArgumentException("İlişkisi kesilen kaydı bulunamadı");
            }

            ilişkisiKesilen.Gerekçe = updateİlişkisiKesilenDto.gerekçe;
            ilişkisiKesilen.İlişkisiKesilmeTarihi = updateİlişkisiKesilenDto.İlişkisiKesilmeTarihi;
            ilişkisiKesilen.İlişkisiKesilenId = ilişkisiKesilen.İlişkisiKesilenId;
            ilişkisiKesilen.ÖğrenciId = ilişkisiKesilen.ÖğrenciId;

            _context.İlişkisiKesilens.Update(ilişkisiKesilen);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteİlişkisiKesilenAsync(int id)
        {
            var ilişkisiKesilen = await _context.İlişkisiKesilens.FindAsync(id);
            if (ilişkisiKesilen == null)
            {
                throw new ArgumentException("İlişkisi kesilen kaydı bulunamadı");
            }

            _context.İlişkisiKesilens.Remove(ilişkisiKesilen);
            await _context.SaveChangesAsync();
        }

        public async Task<GetByIdİlişkisiKesilenDto> GetByIdİlişkisiKesilenAsync(int id)
        {
            var ilişkisiKesilen = await _context.İlişkisiKesilens.FindAsync(id);
            if (ilişkisiKesilen == null)
            {
                throw new ArgumentException("İlişkisi kesilen kaydı bulunamadı");
            }

            return new GetByIdİlişkisiKesilenDto
            {
                ÖğrenciId = ilişkisiKesilen.ÖğrenciId,
                İlişkisiKesilenId = ilişkisiKesilen.İlişkisiKesilenId,
                gerekçe = ilişkisiKesilen.Gerekçe,
                İlişkisiKesilmeTarihi = ilişkisiKesilen.İlişkisiKesilmeTarihi
            };
        }
    }
}
