using Eokulwebapi.Dtos.SınıfDto;
using Eokulwebapi.Service.ÖnKayıtÖğrenci;
using Eokulwebapi.Service.Sınıf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eokulwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SınıfController : ControllerBase
    {
        private readonly ISınıfService _sınıfService;

        public SınıfController(ISınıfService sınıfService)
        {
            _sınıfService = sınıfService;
        }

        // Get all classes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _sınıfService.GetAllISınıfAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Get class by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _sınıfService.GetByIdISınıfAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound($"Hata: {ex.Message}");
            }
        }

        // Create a new class
        [HttpPost]
        public async Task<IActionResult> Create(CreateSınıfDto createSınıf)
        {
            try
            {
                await _sınıfService.CreateISınıfAsync(createSınıf);
                return Ok("işlem başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Update a class
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSınıfDto updateSınıfDto)
        {
            try
            {
                await _sınıfService.UpdateISınıfAsync(updateSınıfDto);
                return Ok("işlem başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sınıfService.DeleteISınıfAsync(id);
                return Ok("işlem başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Get students by class ID
        [HttpGet("{id}/öğrenciler")]
        public async Task<IActionResult> GetStudentsByClassId(int id)
        {
            try
            {
                var result = await _sınıfService.GetStudentsByClassIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound($"Hata: {ex.Message}");
            }
        }
    }
}
