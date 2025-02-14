using Eokulwebapi.Dtos.ÖğretmenDto;
using Eokulwebapi.Service.Öğretmen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ÖğretmenController : ControllerBase
    {
        private readonly IÖğretmenService _öğretmenService;

        public ÖğretmenController(IÖğretmenService öğretmenService)
        {
            _öğretmenService = öğretmenService;
        }

        // Tüm öğretmenleri getir
        [HttpGet]
        public async Task<IActionResult> GetAllÖğretmen()
        {
            try
            {
                var öğretmenler = await _öğretmenService.GetAllÖğretmenAsync();
                return Ok(öğretmenler);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // Yeni bir öğretmen oluştur
        [HttpPost]
        public async Task<IActionResult> CreateÖğretmen(CreateÖğretmenDto createÖğretmenDto)
        {
            if (createÖğretmenDto == null)
            {
                return BadRequest("Öğretmen bilgileri boş olamaz.");
            }

            try
            {
                await _öğretmenService.CreateÖğretmenAsync(createÖğretmenDto);
                return Ok( "Öğretmen başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // Öğretmeni güncelle
        [HttpPut]
        public async Task<IActionResult> UpdateÖğretmen( UpdateÖğretmenDto updateÖğretmenDto)
        {
            if (updateÖğretmenDto == null)
            {
                return BadRequest("Güncelleme bilgileri boş olamaz.");
            }

            try
            {
                await _öğretmenService.UpdateÖğretmenAsync(updateÖğretmenDto);
                return Ok("Öğretmen başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // Öğretmeni sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteÖğretmen(int id)
        {
            try
            {
                await _öğretmenService.DeleteÖğretmenAsync(id);
                return Ok("Öğretmen başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // ID'ye göre öğretmeni getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdÖğretmen(int id)
        {
            try
            {
                var öğretmen = await _öğretmenService.GetByIdÖğretmenAsync(id);
                if (öğretmen == null)
                {
                    return NotFound("Öğretmen bulunamadı.");
                }
                return Ok(öğretmen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }
    }
}
