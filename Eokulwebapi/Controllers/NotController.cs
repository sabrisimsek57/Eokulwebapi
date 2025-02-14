using Eokulwebapi.Dtos.NotDto;
using Eokulwebapi.Service.DersProgramı;
using Eokulwebapi.Service.Not;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotController : ControllerBase
    {
        private readonly INotService _notService;

        public NotController(INotService notService)
        {
            _notService = notService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNot(CreateNotDto createNotDto)
        {
            try
            {
                await _notService.CreateNotAsync(createNotDto);
                return Ok(); // Başarıyla oluşturuldu
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Hatalı istek durumu
            }
        
        }

        [HttpGet("GetNotlarByÖğrenciId/{öğrenciId}")]
        public async Task<IActionResult> GetNotlarByÖğrenciId(int öğrenciId)
        {
            try
            {
                var notlar = await _notService.GetNotlarByÖğrenciIdAsync(öğrenciId);
                return Ok(notlar); // Notları başarıyla döndür
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // Öğrenci bulunamadı durumu
            }
        }

        [HttpGet("diploma/{ıd}")]
        public async Task<IActionResult> HesaplaDiplomaAsync(int ıd)
        {
            try
            {
                var diplomaDurumu = await _notService.HesaplaDiplomaAsync(ıd);
                return Ok(diplomaDurumu);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"İç sunucu hatası: {ex.Message}");
            }
        }

        // Tüm notları getir
        [HttpGet]
        public async Task<IActionResult> GetAllNot()
        {
            try
            {
                var notlar = await _notService.GetAllNotAsync();
                return Ok(notlar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // ID'ye göre not bilgilerini getir
        [HttpGet("GetByIdNot/{id}")]
        public async Task<IActionResult> GetByIdNot(int id)
        {
            try
            {
                var not = await _notService.GetByIdNotAsync(id);
                if (not == null)
                {
                    return NotFound(); // Not bulunamadı
                }
                return Ok(not);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

       
        // Not güncelle
        [HttpPut]
        public async Task<IActionResult> UpdateNot( UpdateNotDto updateNotDto)
        {
            if (updateNotDto == null)
            {
                return BadRequest("Not bilgileri boş olamaz.");
            }

            try
            {
                await _notService.UpdateNotAsync(updateNotDto);
                return Ok("Not başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Not sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNot(int id)
        {
            try
            {
                await _notService.DeleteNotAsync(id);
                return Ok("Not başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
