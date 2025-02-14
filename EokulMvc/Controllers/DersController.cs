using Eokulwebapi.Dtos.DersDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EokulMvc.Controllers
{
    [Authorize(Roles = "admin,ogretmen")]
    [Authorize]
    public class DersController : Controller
    {
        private readonly HttpClient _httpClient;

        public DersController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7051/api/")
            };
        }

        // Tüm dersleri listele
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Ders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var dersList = JsonConvert.DeserializeObject<List<ResultDersDto>>(jsonData);
                return View(dersList);
            }
            return View("Error");
        }

        // Yeni ders oluşturma sayfası
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni ders oluştur
        [HttpPost]
        public async Task<IActionResult> Create(CreateDersDto createDersDto)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(createDersDto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("Ders", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(createDersDto);
        }

        // Ders güncelleme sayfası
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"Ders/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var ders = JsonConvert.DeserializeObject<UpdateDersDto>(jsonData);
                return View(ders);
            }
            return View("Error");
        }

        // Ders güncelle
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDersDto updateDersDto)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(updateDersDto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync("Ders", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(updateDersDto);
        }

        // Ders sil
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Ders/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        //// Ders detaylarını görüntüle
        //public async Task<IActionResult> Details(int id)
        //{
        //    var response = await _httpClient.GetAsync($"Ders/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonData = await response.Content.ReadAsStringAsync();
        //        var ders = JsonConvert.DeserializeObject<ResultDersDto>(jsonData);
        //        return View(ders);
        //    }
        //    return View("Error");
        //}
    }
}
