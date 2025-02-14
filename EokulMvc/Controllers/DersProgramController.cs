using Eokulwebapi.Dtos.DersProgramıDto;
using Eokulwebapi.Service.DersProgramı;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EokulMvc.Controllers
{
    [Authorize]
    public class DersProgramController : Controller
    {
        private readonly IDersProgramıService _dersProgramıService;
        private readonly IHttpClientFactory _httpClientFactory;
        public DersProgramController(IDersProgramıService dersProgramıService, IHttpClientFactory httpClientFactory)
        {
            _dersProgramıService = dersProgramıService;
            _httpClientFactory = httpClientFactory;

        }
        [Authorize(Roles = "admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var dersProgramları = await _dersProgramıService.GetAllDersProgramıAsync();
                return View(dersProgramları);
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin,ogretmen")]
        [HttpGet]
        public IActionResult CreateDersProgramı()
        {
            return View();
        }

        // Yeni Ders Programı Oluştur
        [Authorize(Roles = "admin,ogretmen")]
        [HttpPost]
        public async Task<IActionResult> CreateDersProgramı(CreateDersProgramıDto createDersProgramıDto)
        {
           

            try
            {
                await _dersProgramıService.CreateDersAsync(createDersProgramıDto);
                return RedirectToAction("Index", "DersProgram");
            }
            catch
            {
                ViewBag.Message = "Ders programı oluşturulamadı.";
                return View(createDersProgramıDto);
            }
        }
        [Authorize(Roles = "admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _dersProgramıService.DeleteDersProgramıAsync(id);
                return RedirectToAction("Index", "DersProgram");
            }
            catch
            {
                ViewBag.Message = "Ders programı silinemedi.";
                return View();
            }
        }
        [Authorize(Roles = "admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var ders = await _dersProgramıService.GetByIdDersProgramıAsync(id);
                var updateDersProgramıDto = new UpdateDersProgramıDto
                {
                    DersId = ders.DersId,
                    DersProgramıId = ders.DersProgramıId,
                    KaçıncıDers = ders.KaçıncıDers,
                    Gün = ders.Gün,
                    SınıfId = ders.SınıfId
                };
                return View(updateDersProgramıDto);
            }
            catch
            {
                return RedirectToAction("GetAllDersProgramı");
            }
        }

        // Ders Programını Güncelle
        [Authorize(Roles = "admin,ogretmen")]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDersProgramıDto updateDersProgramıDto)
        {
           

            try
            {
                await _dersProgramıService.UpdateDersProgramıAsync(updateDersProgramıDto);
                return RedirectToAction("Index", "DersProgram");
            }
            catch
            {
                ViewBag.Message = "Ders programı güncellenemedi.";
                return View(updateDersProgramıDto);
            }
        }
        [Authorize(Roles = "ogrenci,admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> GetDersProgramıBySınıfId(int sınıfId = 2)
        {

            try
            {
                // API'ye GET isteği gönderiyoruz
                var client = _httpClientFactory.CreateClient();

                var response = await client.GetAsync("https://localhost:7051/api/DersProgramı/GetDersProgramıBySınıfId/" + sınıfId);

                // Yanıtın başarılı olup olmadığını kontrol ediyoruz
                if (response.IsSuccessStatusCode)
                {
                    // JSON yanıtını alıp deserialize ediyoruz
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var dersProgramıList = JsonConvert.DeserializeObject<List<ResultDersProgramıDto>>(jsonData);

                    // Veriyi View'a gönderiyoruz
                    return View(dersProgramıList);
                }
                else
                {
                    // API'den başarılı bir yanıt alınamazsa hata mesajı gösteriyoruz
                    ViewBag.Message = "Belirtilen sınıf için ders programı bulunamadı.";
                    return RedirectToAction("ındex");
                }
            }
            catch
            {
                // Bir hata oluşursa uygun hata mesajını gösteriyoruz
                ViewBag.Message = "Bir hata oluştu. Lütfen tekrar deneyin.";
                return RedirectToAction("GetAllDersProgramı");
            }
        }

        // Öğretmene Göre Ders Programı Listele
        [Authorize(Roles = "admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> GetDersProgramıByÖğretmenId(int id)
        {
            try
            {
                var dersProgramıList = await _dersProgramıService.GetOğretmenDersProgramıByÖğretmenIdAsync(id);
                return View(dersProgramıList);
            }
            catch
            {
                ViewBag.Message = "Öğretmen için ders programı bulunamadı.";
                return RedirectToAction("GetAllDersProgramı");
            }
        }

        // Ders Programı Seçimi Formu
        [HttpGet]
        public IActionResult SelectDersProgramı()
        {
            return View();
        }

    }
}
