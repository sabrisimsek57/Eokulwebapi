using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto;

namespace Eokulwebapi.Service.ÖnKayıtÖğrenci
{
    public interface IÖnKayıtÖğrenciService
    {
        Task<List<ResultÖnKayıtÖğrenciDto>> GetAllIÖnKayıtÖğrenciAsync();
        Task CreateIÖnKayıtÖğrenciAsync(CreateÖnKayıtÖğrenciDto createÖnKayıtÖğrenci);
        Task UpdateIÖnKayıtÖğrenciAsync(UpdateÖnKayıtÖğrenciDto updateÖnKayıtÖğrenciDto);
        Task DeleteIÖnKayıtÖğrenciAsync(int id);
        Task<GetByIdÖnKayıtÖğrenciDto> GetByIdIÖnKayıtÖğrenciAsync(int id);

        Task ÖnKaydıAsılKayıtaDönüştür(int önKayıtId, int sınıfId); // Ön Kayıdı Asıl Kayıta dönüştür
    }
}
