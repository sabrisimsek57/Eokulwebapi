using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto;

namespace Eokulwebapi.Service.Öğrenci
{
    public interface IÖğrenciService
    {
        Task<List<ResultÖğrenciDto>> GetAllIÖğrenciAsync();
      
        Task UpdateIÖğrenciAsync(UpdateÖğrenciDto updateÖğrenciDto);
        Task DeleteIÖğrenciAsync(int id);
        Task<GetByIdÖğrenciDto> GetByIdIÖğrenciAsync(int id);
    }
}
