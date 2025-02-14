using Eokulwebapi.Dtos.DersProgramıDto;
using Eokulwebapi.Service.DersProgramı;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersProgramıController : ControllerBase
    {
        private readonly IDersProgramıService _dersProgramıService;

        public DersProgramıController(IDersProgramıService dersProgramıService)
        {
            _dersProgramıService = dersProgramıService;
        }

        [HttpGet("GetDersProgramıBySınıfId/{sınıfId}")]
        public async Task<IActionResult> GetDersProgramıBySınıfId(int sınıfId)
        {
            var dersProgramı = await _dersProgramıService.GetDersProgramıBySınıfIdAsync(sınıfId);
            if (dersProgramı == null || !dersProgramı.Any())
            {
                return NotFound();
            }
            return Ok(dersProgramı);
        }
        // GET api/öğretmendersprogramı/{öğretmenId}
        [HttpGet("GetDersProgramıByÖğretmenId/{öğretmenId}")]
        public async Task<IActionResult> GetDersProgramıByÖğretmenId(int öğretmenId)
        {
            try
            {
                var dersProgramıList = await _dersProgramıService.GetOğretmenDersProgramıByÖğretmenIdAsync(öğretmenId);

                if (dersProgramıList == null || !dersProgramıList.Any())
                {
                    return NotFound("Öğretmen için ders programı bulunamadı.");
                }

                return Ok(dersProgramıList);
            }
            catch (Exception ex)
            {
                // Hata işleme
                return StatusCode(StatusCodes.Status500InternalServerError, $"İç sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDersProgramı()
        {
            try
            {
                var dersProgramları = await _dersProgramıService.GetAllDersProgramıAsync();
                return Ok(dersProgramları);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // Yeni bir ders programı oluştur
        [HttpPost]
        public async Task<IActionResult> CreateDersProgramı( CreateDersProgramıDto createDersProgramıDto)
        {
            if (createDersProgramıDto == null)
            {
                return BadRequest("Ders programı bilgileri boş olamaz.");
            }

            try
            {
                await _dersProgramıService.CreateDersAsync(createDersProgramıDto);
               return Ok( "Ders programı başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // Ders programını güncelle
        [HttpPut]
        public async Task<IActionResult> UpdateDersProgramı( UpdateDersProgramıDto updateDersProgramıDto)
        {
            if (updateDersProgramıDto == null)
            {
                return BadRequest("Ders programı bilgileri boş olamaz.");
            }

            try
            {
                await _dersProgramıService.UpdateDersProgramıAsync(updateDersProgramıDto);
                return Ok("Ders programı başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // Ders programını sil
        [HttpDelete("DeleteDersProgramı/{id}")]
        public async Task<IActionResult> DeleteDersProgramı(int id)
        {
            try
            {
                await _dersProgramıService.DeleteDersProgramıAsync(id);
                return Ok("Ders programı başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // ID'ye göre ders programını getir
        [HttpGet("GetByIdDersProgramı/{id}")]
        public async Task<IActionResult> GetByIdDersProgramı(int id)
        {
            try
            {
                var dersProgramı = await _dersProgramıService.GetByIdDersProgramıAsync(id);
                if (dersProgramı == null)
                {
                    return NotFound("Ders programı bulunamadı.");
                }
                return Ok(dersProgramı);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç sunucu hatası: {ex.Message}");
            }
        }

        
    }
}
