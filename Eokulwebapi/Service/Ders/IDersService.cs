using Eokulwebapi.Dtos.DersDto;

namespace Eokulwebapi.Service.Ders
{
    public interface IDersService
    {
        Task<List<ResultDersDto>> GetAllDersAsync();
        Task CreateDersAsync(CreateDersDto createDers);
        Task UpdateDersAsync(UpdateDersDto updateDersDto);
        Task DeleteDersAsync(int id);
        Task<GetByIdDersDto> GetByIdDersAsync(int id);
    }
}
