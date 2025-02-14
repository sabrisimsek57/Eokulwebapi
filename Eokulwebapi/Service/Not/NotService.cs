using Eokulwebapi.Context;
using Eokulwebapi.Dtos.NotDto;
using Eokulwebapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eokulwebapi.Service.Not
{
    public class NotService : INotService
    {
        private readonly OkulContext _context;

        public NotService(OkulContext context)
        {
            _context = context;
        }
        public async Task<DiplomaResultDto> HesaplaDiplomaAsync(int öğrenciId)
        {
            var notlar = await _context.Nots
        .Where(n => n.ÖğrenciId == öğrenciId)
        .ToListAsync();

            if (!notlar.Any())
            {
                return new DiplomaResultDto
                {
                    DiplomaDurumu = "Öğrencinin notu bulunamadı.",
                    Ortalama = 0
                };
            }

            // Notların ortalamasını hesapla
            var ortalama = notlar.Average(n => n.NotDeğeri);

            // Teşekkür, Takdir, Onur Belgesi hesapla
            string diplomaDurumu;

            if (ortalama >= 95)
            {
                diplomaDurumu = "Onur Belgesi";
            }
            else if (ortalama >= 85)
            {
                diplomaDurumu = "Takdir Belgesi";
            }
            else if (ortalama >= 70)
            {
                diplomaDurumu = "Teşekkür Belgesi";
            }
            else
            {
                diplomaDurumu = "Belge Yok";
            }

            return new DiplomaResultDto
            {
                DiplomaDurumu = diplomaDurumu,
                Ortalama = ortalama
            };
        }

        public async Task CreateNotAsync(CreateNotDto createNotDto)
        {
            // Öğrenciyi kontrol et
            var öğrenci = await _context.Öğrencis
                .Include(o => o.Sınıf) // Sınıf bilgilerini dahil et
                .FirstOrDefaultAsync(o => o.ÖğrenciId == createNotDto.ÖğrenciId);

            if (öğrenci == null)
            {
                throw new ArgumentException("Öğrenci bulunamadı");
            }

            // Ders bilgilerini kontrol et
            var ders = await _context.Ders
                .FirstOrDefaultAsync(d => d.DersId == createNotDto.DersId);

            if (ders == null)
            {
                throw new ArgumentException("Ders bulunamadı");
            }

            // Öğrencinin sınıfına ait derslerin kontrolü
            var dersProgramı = await _context.dersProgramıs
                .AnyAsync(dp => dp.SınıfId == öğrenci.SınıfId && dp.DersId == ders.DersId);

            if (!dersProgramı)
            {
                throw new ArgumentException("Bu ders, öğrencinin sınıfında mevcut değil.");
            }

            // Notu oluştur ve veritabanına ekle
            var not = new Eokulwebapi.Entities.Not
            {
                ÖğrenciId = createNotDto.ÖğrenciId,
                DersId = createNotDto.DersId,
                NotDeğeri = createNotDto.NotDeğeri // int olarak güncellendi
            };

            // Notu veritabanına ekle
            _context.Nots.Add(not);

            // Veritabanı değişikliklerini kaydet
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultNotDto>> GetNotlarByÖğrenciIdAsync(int öğrenciId)
        {
            var öğrenci = await _context.Öğrencis
             .FirstOrDefaultAsync(o => o.ÖğrenciId == öğrenciId);

            if (öğrenci == null)
            {
                throw new ArgumentException("Öğrenci bulunamadı");
            }

            // Öğrenciye ait notları al
            var notlar = await _context.Nots
                .Where(n => n.ÖğrenciId == öğrenciId)
                .Include(n => n.Ders) // Ders bilgilerini dahil et
                .ToListAsync();

            // DTO dönüşümü
            var result = notlar.Select(n => new ResultNotDto
            {
                DersAdı = n.Ders.DersAdı,
                NotDeğeri = n.NotDeğeri
            }).ToList();

            return result;
        }

        public async Task DeleteNotAsync(int id)
        {
            var not = await _context.Nots.FindAsync(id);
            if (not == null)
            {
                throw new ArgumentException("Not bulunamadı");
            }

            _context.Nots.Remove(not);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultNewNotDto>> GetAllNotAsync()
        {
            return await _context.Nots
                .Select(n => new ResultNewNotDto
                {
                    NotId = n.NotId,
                    ÖğrenciId = n.ÖğrenciId,
                    DersId = n.DersId,
                    NotDeğeri = n.NotDeğeri
                }).ToListAsync();
        }

        public async Task<GetByIdNotDto> GetByIdNotAsync(int id)
        {
            var not = await _context.Nots
                .Where(n => n.NotId == id)
                .Select(n => new GetByIdNotDto
                {
                    NotId = n.NotId,
                    ÖğrenciId = n.ÖğrenciId,
                    DersId = n.DersId,
                    NotDeğeri = n.NotDeğeri
                }).FirstOrDefaultAsync();

            if (not == null)
            {
                throw new ArgumentException("Not bulunamadı");
            }

            return not;
        }

        public async Task UpdateNotAsync(UpdateNotDto updateNotDto)
        {
            var not = await _context.Nots.FindAsync(updateNotDto.NotId);
            if (not == null)
            {
                throw new ArgumentException("Not bulunamadı");
            }

            not.ÖğrenciId = updateNotDto.ÖğrenciId;
            not.DersId = updateNotDto.DersId;
            not.NotDeğeri = updateNotDto.NotDeğeri;

            _context.Nots.Update(not);
            await _context.SaveChangesAsync();
        }
    }
}

