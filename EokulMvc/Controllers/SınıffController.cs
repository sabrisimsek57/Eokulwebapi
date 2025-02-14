using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto;
using Eokulwebapi.Dtos.SınıfDto;
using Eokulwebapi.Service.ÖnKayıtÖğrenci;
using Eokulwebapi.Service.Sınıf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EokulMvc.Controllers
{
    [Authorize(Roles = "admin,ogretmen")]
    public class SınıffController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ISınıfService _sınıfService;

        public SınıffController(HttpClient httpClient, IÖnKayıtÖğrenciService önKayıtÖğrenciService, ISınıfService sınıfService)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7051/api/");
            _sınıfService = sınıfService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Create(CreateSınıfDto createSınıfDto)
        {
            var jsonContent = JsonConvert.SerializeObject(createSınıfDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Sınıf", content);
            if (response.IsSuccessStatusCode)
            {
                 return RedirectToAction("Index", "Sınıf");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            await _sınıfService.DeleteISınıfAsync(id);

            return RedirectToAction("Index", "Sınıf");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var sınıf = await _sınıfService.GetByIdISınıfAsync(id);

            var updateSınıfDto = new UpdateSınıfDto
            {
                SınıfId = sınıf.SınıfId,
                SınıfAdı = sınıf.SınıfAdı,
                Şubesi = sınıf.Şubesi
            };
            return View("Update", updateSınıfDto);


        }

        // Sınıfı Güncelle
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSınıfDto updateSınıfDto)
        {
            await _sınıfService.UpdateISınıfAsync(updateSınıfDto);
            
            return RedirectToAction("Index", "Sınıf");
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsByClassId(int id)
        {
            var response = await _httpClient.GetAsync($"Sınıf/{id}/öğrenciler");
            if (response.IsSuccessStatusCode)
            {
                var öğrenciler = JsonConvert.DeserializeObject<List<ResultÖğrenciDto>>(await response.Content.ReadAsStringAsync());
                return View(öğrenciler);
            }
            ViewBag.Message = "Öğrenciler bulunamadı.";
            return RedirectToAction("Index", "Sınıf");

        }

    }
}
