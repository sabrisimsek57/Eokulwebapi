using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Dtos.ÖğretmenDto;
using Eokulwebapi.Dtos.SınıfDto;
using Eokulwebapi.Entities;
using Eokulwebapi.Service.Sınıf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EokulMvc.Controllers
{
    [Authorize(Roles = "admin,ogretmen")]
    [Authorize]
    public class SınıfController : Controller
    {

        private readonly ISınıfService _sınıfService;
        private readonly IHttpClientFactory _httpClientFactory;


        public SınıfController(ISınıfService sınıfService, IHttpClientFactory httpClientFactory)
        {
            _sınıfService = sınıfService;
            _httpClientFactory = httpClientFactory;
        }



        // Tüm Sınıfları Listele
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var values = await _sınıfService.GetAllISınıfAsync();
            return View(values);
        }

        // ID'ye Göre Sınıf Getir (Güncelleme İçin)
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
            TempData["SuccessMessage"] = "Öğretmen başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        // Yeni Sınıf Oluştur
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Sınıf Oluştur (POST)
        [HttpPost]
        public async Task<IActionResult> Create(CreateSınıfDto createSınıfDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createSınıfDto);
            }

            try
            {
                var jsonContent = JsonConvert.SerializeObject(createSınıfDto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"); // JSON formatında gönderiyoruz

               var valıes =  _httpClientFactory.CreateClient();
                var response = await valıes.PostAsync("https://localhost:7051/api/Sınıf", content);
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sınıf oluşturulamadı: " + ex.Message;
                return View(createSınıfDto); // Oluşturma sayfasına geri dön
            }
        }

        // Sınıfı Sil
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            await _sınıfService.DeleteISınıfAsync(id);

            return RedirectToAction("Index");
        }

        
    }
}

