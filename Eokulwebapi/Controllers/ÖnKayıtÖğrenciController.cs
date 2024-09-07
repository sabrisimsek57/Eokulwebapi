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
