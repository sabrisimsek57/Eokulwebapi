using Eokulwebapi.Dtos.ÖnKayıtÖğrenciDto;
using Eokulwebapi.Entities;
using Eokulwebapi.Service.ÖnKayıtÖğrenci;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EokulMvc.Controllers
{
    [Authorize(Roles = "admin")]
    [Authorize]
    public class ÖnKayıtÖğrenciController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IÖnKayıtÖğrenciService _önKayıtÖğrenciService;

        public ÖnKayıtÖğrenciController(HttpClient httpClient, IÖnKayıtÖğrenciService önKayıtÖğrenciService)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7051/api/");
            _önKayıtÖğrenciService = önKayıtÖğrenciService;
        }



        // Tüm Ön Kayıt Öğrencilerini Listele
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("ÖnKayıtÖğrenci/getall");
            if (response.IsSuccessStatusCode)
            {
                var önKayıtÖğrenciler = JsonConvert.DeserializeObject<List<ResultÖnKayıtÖğrenciDto>>(await response.Content.ReadAsStringAsync());
                return View(önKayıtÖğrenciler);
            }
            ViewBag.Message = "Ön kayıt öğrencileri bulunamadı.";
            return View(new List<ResultÖnKayıtÖğrenciDto>());
        }

        // ID'ye göre Ön Kayıt Öğrenci Detayı
        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var response = await _httpClient.GetAsync($"ÖnKayıtÖğrenci/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var önKayıtÖğrenci = JsonConvert.DeserializeObject<GetByIdÖnKayıtÖğrenciDto>(await response.Content.ReadAsStringAsync());
        //        return View(önKayıtÖğrenci);
        //    }
        //    ViewBag.Message = "Ön kayıt öğrencisi bulunamadı.";
        //    return RedirectToAction("Index");
        //}

        // Yeni Ön Kayıt Öğrenci Oluşturma
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateÖnKayıtÖğrenciDto createÖnKayıtÖğrenciDto)
        {
            if (!ModelState.IsValid)
                return View(createÖnKayıtÖğrenciDto);

            var jsonContent = JsonConvert.SerializeObject(createÖnKayıtÖğrenciDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("ÖnKayıtÖğrenci/create", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Ön kayıt öğrencisi oluşturulamadı.";
            return View(createÖnKayıtÖğrenciDto);
        }

        [HttpGet]
        public IActionResult Dönüştür()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dönüştür(int önKayıtId, int sınıfId)
        {
            try
            {
               await _önKayıtÖğrenciService.ÖnKaydıAsılKayıtaDönüştür(önKayıtId, sınıfId);
                TempData["SuccessMessage"] = "Ön kayıt başarıyla asıl kayıt olarak dönüştürüldü.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               
                return RedirectToAction("Index");
            }
        }


        // Ön Kayıt Öğrenci Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"ÖnKayıtÖğrenci/getbyid/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var öğrenci = JsonConvert.DeserializeObject<UpdateÖnKayıtÖğrenciDto>(jsonData);
                return View(öğrenci);
            }
            ViewBag.Message = "Ön kayıt öğrencisi bulunamadı.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateÖnKayıtÖğrenciDto updateÖnKayıtÖğrenciDto)
        {
            if (!ModelState.IsValid)
                return View(updateÖnKayıtÖğrenciDto);

            var jsonContent = JsonConvert.SerializeObject(updateÖnKayıtÖğrenciDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("ÖnKayıtÖğrenci", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Ön kayıt öğrencisi güncellenemedi.";
            return View(updateÖnKayıtÖğrenciDto);
        }

        // Ön Kayıt Öğrenci Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _önKayıtÖğrenciService.DeleteIÖnKayıtÖğrenciAsync(id);
            ViewBag.Message = "Ön kayıt öğrencisi silinemedi.";
            return RedirectToAction("Index");
        }






    }
}
