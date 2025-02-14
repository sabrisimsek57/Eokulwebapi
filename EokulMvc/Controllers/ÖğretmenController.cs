using Eokulwebapi.Dtos.ÖğretmenDto;
using Eokulwebapi.Service.Öğretmen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EokulMvc.Controllers
{
    [Authorize(Roles = "admin")]

    [Authorize]
    public class ÖğretmenController : Controller
    {
        private readonly IÖğretmenService _öğretmenService;

        public ÖğretmenController(IÖğretmenService öğretmenService)
        {
            _öğretmenService = öğretmenService;
        }

        // Öğretmenleri listele
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var öğretmenler = await _öğretmenService.GetAllÖğretmenAsync();
                return View(öğretmenler);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(new List<ResultÖğretmenDto>());
            }
        }

        // Öğretmen detayını göster
        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    try
        //    {
        //        var öğretmen = await _öğretmenService.GetByIdÖğretmenAsync(id);
        //        if (öğretmen == null)
        //        {
        //            TempData["ErrorMessage"] = "Öğretmen bulunamadı.";
        //            return RedirectToAction("Index");
        //        }
        //        return View(öğretmen);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = $"Hata: {ex.Message}";
        //        return RedirectToAction("Index");
        //    }
        //}

        // Yeni öğretmen oluşturma
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateÖğretmenDto createÖğretmenDto)
        {
            if (!ModelState.IsValid)
                return View(createÖğretmenDto);

            try
            {
                await _öğretmenService.CreateÖğretmenAsync(createÖğretmenDto);
                TempData["SuccessMessage"] = "Öğretmen başarıyla oluşturuldu.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(createÖğretmenDto);
            }
        }

        // Öğretmen güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var öğretmen = await _öğretmenService.GetByIdÖğretmenAsync(id);
                if (öğretmen == null)
                {
                    TempData["ErrorMessage"] = "Öğretmen bulunamadı.";
                    return RedirectToAction("Index");
                }
                // `GetByIdÖğretmenDto` türündeki öğretmeni `UpdateÖğretmenDto`'ya dönüştür
                var updateÖğretmenDto = new UpdateÖğretmenDto
                {
                    ÖğretmenId = öğretmen.ÖğretmenId,
                    Ad = öğretmen.Ad,
                    Soyad = öğretmen.Soyad,
                    Görevi = öğretmen.Görevi,
                    Branş = öğretmen.Branş,
                    Sıra = öğretmen.Sıra
                };

                return View(updateÖğretmenDto);
            
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateÖğretmenDto updateÖğretmenDto)
        {
            if (!ModelState.IsValid)
                return View(updateÖğretmenDto);

            try
            {
                await _öğretmenService.UpdateÖğretmenAsync(updateÖğretmenDto);
                TempData["SuccessMessage"] = "Öğretmen başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(updateÖğretmenDto);
            }
        }

        // Öğretmen silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _öğretmenService.DeleteÖğretmenAsync(id);
                TempData["SuccessMessage"] = "Öğretmen başarıyla silindi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
