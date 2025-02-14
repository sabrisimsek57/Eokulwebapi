using Eokulwebapi.Dtos.DevamsızlıkDto;
using Eokulwebapi.Service.DersProgramı;
using Eokulwebapi.Service.Devamsızlık;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevamsızlıkController : ControllerBase
    {
        private readonly IDevamsızlıkService _devamsızlıkService;

        public DevamsızlıkController(IDevamsızlıkService devamsızlıkService)
        {
            _devamsızlıkService = devamsızlıkService;
        }

        // Devamsızlık kaydı oluşturma
        [HttpPost]
        public async Task<IActionResult> Create( CreateDevamsızlıkDto dto)
        {
            try
            {
                await _devamsızlıkService.CreateDevamsızlıkAsync(dto);
                return Ok("Devamsızlık kaydı başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Öğrenciye ait devamsızlık bilgilerini listeleme
        [HttpGet("{öğrenciId}")]
        public async Task<IActionResult> GetByÖğrenciId(int öğrenciId)
        {
            try
            {
                var devamsızlıklar = await _devamsızlıkService.GetDevamsızlıkByÖğrenciIdAsync(öğrenciId);
                return Ok(devamsızlıklar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Tüm devamsızlıkları getir
        [HttpGet]
        public async Task<IActionResult> GetAllDevamsızlık()
        {
            try
            {
                var devamsızlıklar = await _devamsızlıkService.GetAllDevamsızlıkProgramıAsync();
                return Ok(devamsızlıklar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDevamsızlık( UpdateDevamsızlıkDto updateDevamsızlıkDto)
        {
            if (updateDevamsızlıkDto == null)
            {
                return BadRequest("Devamsızlık bilgileri boş olamaz.");
            }

            try
            {
                await _devamsızlıkService.UpdateDevamsızlıkAsync(updateDevamsızlıkDto);
                return Ok("Devamsızlık başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Devamsızlığı sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevamsızlık(int id)
        {
            try
            {
                await _devamsızlıkService.DeleteDevamsızlıkAsync(id);
                return Ok("Devamsızlık başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        


    }
}
