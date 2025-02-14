using Eokulwebapi.Dtos.ÖğrenciDto;
using Eokulwebapi.Service.Öğrenci;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EokulMvc.Controllers
{
    [Authorize(Roles = "admin,ogretmen")]
    [Authorize]
    public class OgrenciController : Controller
    {
        private readonly IÖğrenciService _öğrenciService;

        public OgrenciController(IÖğrenciService öğrenciService)
        {
            _öğrenciService = öğrenciService;
        }

        // Tüm öğrencileri listele
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var öğrenciler = await _öğrenciService.GetAllIÖğrenciAsync();
                return View(öğrenciler);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View();
            }
        }

        // Öğrenci güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var öğrenci = await _öğrenciService.GetByIdIÖğrenciAsync(id);
                if (öğrenci == null)
                {
                    TempData["ErrorMessage"] = "Öğrenci bulunamadı.";
                    return RedirectToAction("Index");
                }

                var updateÖğrenciDto = new UpdateÖğrenciDto
                {
                    ÖğrenciId = öğrenci.ÖğrenciId,
                    Ad = öğrenci.Ad,
                    Soyad = öğrenci.Soyad,
                    Cinsiyet = öğrenci.Cinsiyet,
                    DevamDurumu = öğrenci.DevamDurumu,
                    ÖnKayıtId = öğrenci.ÖnKayıtId,
                    SınıfId = öğrenci.SınıfId,
                    OkulNumarası = öğrenci.OkulNumarası
                    
                };

                return View(updateÖğrenciDto);
               
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateÖğrenciDto updateÖğrenciDto)
        {
            if (!ModelState.IsValid)
                return View(updateÖğrenciDto);

            try
            {
                await _öğrenciService.UpdateIÖğrenciAsync(updateÖğrenciDto);

                TempData["SuccessMessage"] = "Öğrenci başarıyla güncellendi.";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(updateÖğrenciDto);
            }
        }

        // Öğrenci silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _öğrenciService.DeleteIÖğrenciAsync(id);
                TempData["SuccessMessage"] = "Öğrenci başarıyla silindi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            }
            return RedirectToAction("List");
        }
    }
}
