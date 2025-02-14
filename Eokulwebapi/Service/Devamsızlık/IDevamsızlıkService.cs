using Eokulwebapi.Dtos.DersProgramıDto;
using Eokulwebapi.Dtos.DevamsızlıkDto;

namespace Eokulwebapi.Service.Devamsızlık
{
    public interface IDevamsızlıkService
    {
        Task CreateDevamsızlıkAsync(CreateDevamsızlıkDto createDevamsızlıkDto);
        Task<ResultDevamsızlıkDto> GetDevamsızlıkByÖğrenciIdAsync(int öğrenciId);

      
        Task UpdateDevamsızlıkAsync(UpdateDevamsızlıkDto updateDevamsızlıkDto);
        Task DeleteDevamsızlıkAsync(int id);

        Task<List<ResultDevamsızlıkDto>> GetAllDevamsızlıkProgramıAsync();
        Task<List<ResultDevamsızlıkDto>> GetÖgrneciDevamsızlıkProgramıAsync(int id);
    }
}
