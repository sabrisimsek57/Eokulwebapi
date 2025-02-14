using Eokulwebapi.Dtos.İlişkisiKesilen;
using Eokulwebapi.Service.İlişkisiKesilen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class İlişkisiKesilenController : ControllerBase
    {
        private readonly IİlişkisiKesilenService _ilişkisiKesilenService;

        public İlişkisiKesilenController(IİlişkisiKesilenService ilişkisiKesilenService)
        {
            _ilişkisiKesilenService = ilişkisiKesilenService;
        }

        [HttpPost]
        public async Task<IActionResult> Kesilmeİşlemi(CreateİlişkisiKesilen createİlişkisiKesilen)
        {
            try
            {
                await _ilişkisiKesilenService.KesilmeİşlemiAsync(createİlişkisiKesilen);
                return Ok("Öğrencinin ilişkisi başarıyla kesildi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Tüm ilişkisi kesilenleri getir
        [HttpGet]
        public async Task<IActionResult> GetAllİlişkisiKesilen()
        {
            try
            {
                var ilişkisiKesilenler = await _ilişkisiKesilenService.GetAllİlişkisiKesilenAsync();
                return Ok(ilişkisiKesilenler);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // İlişkisi kesilen kaydını güncelle
        [HttpPut]
        public async Task<IActionResult> UpdateİlişkisiKesilen([FromBody] UpdateİlişkisiKesilenDto updateİlişkisiKesilenDto)
        {
            if (updateİlişkisiKesilenDto == null)
            {
                return BadRequest("İlişkisi kesilen bilgileri boş olamaz.");
            }

            try
            {
                await _ilişkisiKesilenService.UpdateİlişkisiKesilenAsync(updateİlişkisiKesilenDto);
                return Ok("İlişkisi kesilen başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // İlişkisi kesilen kaydını sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteİlişkisiKesilen(int id)
        {
            try
            {
                await _ilişkisiKesilenService.DeleteİlişkisiKesilenAsync(id);
                return Ok("İlişkisi kesilen başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // ID'ye göre ilişkisi kesilen bilgilerini getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdİlişkisiKesilen(int id)
        {
            try
            {
                var ilişkisiKesilen = await _ilişkisiKesilenService.GetByIdİlişkisiKesilenAsync(id);
                if (ilişkisiKesilen == null)
                {
                    return NotFound(); // İlişkisi kesilen bulunamadı
                }
                return Ok(ilişkisiKesilen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
