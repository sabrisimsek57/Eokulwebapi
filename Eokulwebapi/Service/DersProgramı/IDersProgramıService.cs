using Eokulwebapi.Dtos.DersDto;
using Eokulwebapi.Dtos.DersProgramıDto;
using Eokulwebapi.Dtos.ÖğretmenDto;

namespace Eokulwebapi.Service.DersProgramı
{
    public interface IDersProgramıService
    {
        Task<List<ResultDersProgramıDto>> GetAllDersProgramıAsync();
        Task CreateDersAsync(CreateDersProgramıDto createDersProgramı);
        Task UpdateDersProgramıAsync(UpdateDersProgramıDto updateDersProgramıDto);
        Task DeleteDersProgramıAsync(int id);
        Task<GetByIdDersProgramıDto> GetByIdDersProgramıAsync(int id);

        Task<List<ResultDersProgramıDto>> GetDersProgramıBySınıfIdAsync(int sınıfId);

        Task<List<ResultDersProgramıDto>> GetOğretmenDersProgramıByÖğretmenIdAsync(int öğretmenId);
    }
}
