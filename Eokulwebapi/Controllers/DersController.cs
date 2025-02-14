using Eokulwebapi.Dtos.DersDto;
using Eokulwebapi.Service.Ders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersController : ControllerBase
    {
        private readonly IDersService _dersService;

        public DersController(IDersService dersService)
        {
            _dersService = dersService;
        }



        // Tüm dersleri getir
        [HttpGet]
        public async Task<IActionResult> GetAllDers()
        {
            try
            {
                var dersler = await _dersService.GetAllDersAsync();
                return Ok(dersler);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Yeni bir ders oluştur
        [HttpPost]
        public async Task<IActionResult> CreateDers(CreateDersDto createDersDto)
        {
            if (createDersDto == null)
            {
                return BadRequest("Ders bilgileri boş olamaz.");
            }

            try
            {
                await _dersService.CreateDersAsync(createDersDto);
                return Ok(" başarıyla işlem yapıldı.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Ders güncelle
        [HttpPut]
        public async Task<IActionResult> UpdateDers( UpdateDersDto updateDersDto)
        {
            if (updateDersDto == null)
            {
                return BadRequest("Ders bilgileri boş olamaz.");
            }

            try
            {
                await _dersService.UpdateDersAsync(updateDersDto);
                return Ok(" başarıyla işlem yapıldı.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Ders sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDers(int id)
        {
            try
            {
                await _dersService.DeleteDersAsync(id);
                return Ok(" başarıyla işlem yapıldı.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // ID'ye göre ders bilgilerini getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDers(int id)
        {
            try
            {
                var ders = await _dersService.GetByIdDersAsync(id);
                if (ders == null)
                {
                    return NotFound(); // Ders bulunamadı
                }
                return Ok(ders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
