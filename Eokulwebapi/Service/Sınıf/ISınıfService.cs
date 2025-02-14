using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Dtos.SınıfDto;

namespace Eokulwebapi.Service.Sınıf
{
    public interface ISınıfService
    {
        Task<List<ResultSınıfDto>> GetAllISınıfAsync();
        Task CreateISınıfAsync(CreateSınıfDto createSınıf);
        Task UpdateISınıfAsync(UpdateSınıfDto updateSınıfDto);
        Task DeleteISınıfAsync(int id);
        Task<GetByIdSınıfDto> GetByIdISınıfAsync(int id);

        Task<List<ResultÖğrenciDto>> GetStudentsByClassIdAsync(int sınıfId);
    }
}
