using Eokulwebapi.Dtos.ÖğretmenDto;

namespace Eokulwebapi.Service.Öğretmen
{
    public interface IÖğretmenService
    {
        Task<List<ResultÖğretmenDto>> GetAllÖğretmenAsync();
        Task CreateÖğretmenAsync(CreateÖğretmenDto createÖğretmen);
        Task UpdateÖğretmenAsync(UpdateÖğretmenDto updateÖğretmenDto);
        Task DeleteÖğretmenAsync(int id);
        Task<GetByIdÖğretmenDto> GetByIdÖğretmenAsync(int id);
    }
}
