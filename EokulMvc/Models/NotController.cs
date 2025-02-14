using Eokulwebapi.Dtos.NotDto;
using Eokulwebapi.Service.Not;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EokulMvc.Controllers
{
    [Authorize]
    public class NotController : Controller
    {
        private readonly INotService _notService;

        public NotController(INotService notService)
        {
            _notService = notService;
        }

        // Tüm notları listele
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var notlar = await _notService.GetAllNotAsync();
                return View(notlar);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(new List<ResultNewNotDto>());
            }
        }

       

        // Yeni not oluşturma
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNotDto createNotDto)
        {
            if (!ModelState.IsValid)
                return View(createNotDto);

            try
            {
                await _notService.CreateNotAsync(createNotDto);
                TempData["SuccessMessage"] = "Not başarıyla oluşturuldu.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(createNotDto);
            }
        }

        // Not güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var not = await _notService.GetByIdNotAsync(id);
                if (not == null)
                {
                    TempData["ErrorMessage"] = "Not bulunamadı.";
                    return RedirectToAction("Index");
                }

                var updateNotDto = new UpdateNotDto
                {
                    NotId = not.NotId,
                    DersId = not.DersId,
                    NotDeğeri = not.NotDeğeri,
                    ÖğrenciId = not.ÖğrenciId
                };

                // Notu düzenleme görünümüne gönder
                return View(updateNotDto);
             
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateNotDto updateNotDto)
        {
            if (!ModelState.IsValid)
                return View(updateNotDto);

            try
            {
                await _notService.UpdateNotAsync(updateNotDto);
                TempData["SuccessMessage"] = "Not başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(updateNotDto);
            }
        }

        // Not silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _notService.DeleteNotAsync(id);
                TempData["SuccessMessage"] = "Not başarıyla silindi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            }
            return RedirectToAction("Index");
        }

        // Öğrenci ID'sine göre notları listele
        [Authorize(Roles = "ogrenci,admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> GetByÖğrenciId(int id)
        {
            try
            {
                var notlar = await _notService.GetNotlarByÖğrenciIdAsync(id);
              
                TempData["ÖğrenciId"] = id;  // Öğrenci ID'sini TempData'ya ekle
                return View(notlar);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        // Diploma hesaplama
        [Authorize(Roles = "ogrenci,admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> HesaplaDiploma(int id)
        {
            try
            {
                var diplomaDurumu = await _notService.HesaplaDiplomaAsync(id);
                return View( diplomaDurumu);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
