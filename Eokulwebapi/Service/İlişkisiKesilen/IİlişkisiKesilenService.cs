using Eokulwebapi.Dtos.DersProgramıDto;
using Eokulwebapi.Dtos.İlişkisiKesilen;

namespace Eokulwebapi.Service.İlişkisiKesilen
{
    public interface IİlişkisiKesilenService
    {
        Task KesilmeİşlemiAsync(CreateİlişkisiKesilen createİlişkisiKesilen);

        Task<List<ResultİlişkisiKesilenDto>> GetAllİlişkisiKesilenAsync();
     
        Task UpdateİlişkisiKesilenAsync(UpdateİlişkisiKesilenDto updateİlişkisiKesilenDto);
        Task DeleteİlişkisiKesilenAsync(int id);
        Task<GetByIdİlişkisiKesilenDto> GetByIdİlişkisiKesilenAsync(int id);
    }
}
