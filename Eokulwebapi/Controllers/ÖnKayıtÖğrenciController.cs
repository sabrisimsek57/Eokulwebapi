using Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto;
using Eokulwebapi.Service.ÖnKayıtÖğrenci;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ÖnKayıtÖğrenciController : ControllerBase
    {
        private readonly IÖnKayıtÖğrenciService _önKayıtÖğrenciService;

        public ÖnKayıtÖğrenciController(IÖnKayıtÖğrenciService önKayıtÖğrenciService)
        {
            _önKayıtÖğrenciService = önKayıtÖğrenciService;
        }


        // Create Ön Kayıt Öğrenci
        [HttpPost("create")]
        public async Task<IActionResult> CreateÖnKayıtÖğrenci(CreateÖnKayıtÖğrenciDto createÖnKayıtÖğrenciDto)
        {
            try
            {
                await _önKayıtÖğrenciService.CreateIÖnKayıtÖğrenciAsync(createÖnKayıtÖğrenciDto);
                return Ok("Ön kayıt başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Update Ön Kayıt Öğrenci
        [HttpPut]
        public async Task<IActionResult> UpdateÖnKayıtÖğrenci(UpdateÖnKayıtÖğrenciDto updateÖnKayıtÖğrenciDto)
        {
            try
            {
                await _önKayıtÖğrenciService.UpdateIÖnKayıtÖğrenciAsync(updateÖnKayıtÖğrenciDto);
                return Ok("Ön kayıt başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Delete Ön Kayıt Öğrenci
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteÖnKayıtÖğrenci(int id)
        {
            try
            {
                await _önKayıtÖğrenciService.DeleteIÖnKayıtÖğrenciAsync(id);
                return Ok("Ön kayıt başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Get All Ön Kayıt Öğrenci
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllÖnKayıtÖğrenci()
        {
            try
            {
                var result = await _önKayıtÖğrenciService.GetAllIÖnKayıtÖğrenciAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Get By Id Ön Kayıt Öğrenci
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetByIdÖnKayıtÖğrenci(int id)
        {
            try
            {
                var result = await _önKayıtÖğrenciService.GetByIdIÖnKayıtÖğrenciAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }


        // Ön Kaydı Asıl Kayıta Dönüştür
        [HttpPost("donustur/{önKayıtId}/{sınıfId}")]
        public async Task<IActionResult> ÖnKaydıAsılKayıtaDönüştür(int önKayıtId, int sınıfId)
        {
            try
            {
                await _önKayıtÖğrenciService.ÖnKaydıAsılKayıtaDönüştür(önKayıtId, sınıfId);
                return Ok("Ön kayıt başarıyla asıl kayıt olarak dönüştürüldü.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }
    }
}
