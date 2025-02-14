using Eokulwebapi.Dtos.İlişkisiKesilen;
using Eokulwebapi.Dtos.NotDto;

namespace Eokulwebapi.Service.Not
{
    public interface INotService
    {
        Task CreateNotAsync(CreateNotDto createNotDto);

        Task<List<ResultNotDto>> GetNotlarByÖğrenciIdAsync(int öğrenciId);

        Task<DiplomaResultDto> HesaplaDiplomaAsync(int öğrenciId);



        Task<List<ResultNewNotDto>> GetAllNotAsync();

        Task UpdateNotAsync(UpdateNotDto updateNotDto);
        Task DeleteNotAsync(int id);
        Task<GetByIdNotDto> GetByIdNotAsync(int id);
    }
}
