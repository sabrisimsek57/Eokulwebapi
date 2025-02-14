using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Service.Öğrenci;
using Eokulwebapi.Service.ÖnKayıtÖğrenci;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ÖğrenciController : ControllerBase
    {
        

     

        private readonly IÖğrenciService _öğrenciService;

        public ÖğrenciController(IÖğrenciService öğrenciService)
        {
            _öğrenciService = öğrenciService;
        }

        // Tüm öğrencileri listele
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllÖğrenci()
        {
            var result = await _öğrenciService.GetAllIÖğrenciAsync();
            return Ok(result);
        }

        // ID'ye göre öğrenci getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdÖğrenci(int id)
        {
            try
            {
                var result = await _öğrenciService.GetByIdIÖğrenciAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

       

        // Öğrenciyi güncelle
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateÖğrenci([FromBody] UpdateÖğrenciDto updateÖğrenciDto)
        {
            try
            {
                await _öğrenciService.UpdateIÖğrenciAsync(updateÖğrenciDto);
                return Ok("Öğrenci başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Öğrenciyi sil
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteÖğrenci(int id)
        {
            try
            {
                await _öğrenciService.DeleteIÖğrenciAsync(id);
                return Ok("Öğrenci başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return NotFound($"Hata: {ex.Message}");
            }
        }
    }
}
