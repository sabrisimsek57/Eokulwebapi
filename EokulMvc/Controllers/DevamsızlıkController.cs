using Eokulwebapi.Dtos.DevamsızlıkDto;
using Eokulwebapi.Service.Devamsızlık;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EokulMvc.Controllers
{
    [Authorize]
    public class DevamsızlıkController : Controller
    {
        private readonly IDevamsızlıkService _devamsızlıkService;

        public DevamsızlıkController(IDevamsızlıkService devamsızlıkService)
        {
            _devamsızlıkService = devamsızlıkService;
        }

        // Tüm devamsızlıkları listele
        [Authorize(Roles = "admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var devamsızlıklar = await _devamsızlıkService.GetAllDevamsızlıkProgramıAsync();
                return View(devamsızlıklar);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(new List<ResultDevamsızlıkDto>());
            }
        }
        [Authorize(Roles = "ogrenci,admin,ogretmen")]
        [HttpGet]
        public async Task<IActionResult> ÖgrenciDevamsizlik(int id)
        {
            try
            {
               
                var values = await _devamsızlıkService.GetÖgrneciDevamsızlıkProgramıAsync(id);
                return View(values);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(new List<ResultDevamsızlıkDto>());
            }
        }

        // Öğrenciye ait devamsızlık bilgilerini listele
        //[HttpGet("Öğrenci/{öğrenciId}")]
        //public async Task<IActionResult> GetByÖğrenciId(int öğrenciId)
        //{
        //    try
        //    {
        //        var devamsızlıklar = await _devamsızlıkService.GetDevamsızlıkByÖğrenciIdAsync(öğrenciId);
        //        return View("Index", devamsızlıklar);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = $"Hata: {ex.Message}";
        //        return RedirectToAction("Index");
        //    }
        //}

        // Yeni devamsızlık kaydı oluşturma
        [Authorize(Roles = "admin,ogretmen")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin,ogretmen")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateDevamsızlıkDto createDevamsızlıkDto)
        {
          

            try
            {
                await _devamsızlıkService.CreateDevamsızlıkAsync(createDevamsızlıkDto);
              
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(createDevamsızlıkDto);
            }
        }
        [Authorize(Roles = "admin,ogretmen")]
        // Devamsızlık güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var values = await _devamsızlıkService.GetDevamsızlıkByÖğrenciIdAsync(id);
                if (values == null)
                {
                    TempData["ErrorMessage"] = "Devamsızlık kaydı bulunamadı.";
                    return RedirectToAction("Index");
                }
                var updateDevamsızlıkDto = new UpdateDevamsızlıkDto
                {
                    DevamsızlıkId = values.DevamsızlıkId,
                    NöbetçiMi = values.NöbetçiMi,
                    RaporluMu = values.RaporluMu,
                    Tarih = values.Tarih,
                    ÖğrenciId = values.ÖğrenciId
                };

                return View(updateDevamsızlıkDto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        [Authorize(Roles = "admin,ogretmen")]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDevamsızlıkDto updateDevamsızlıkDto)
        {
            if (!ModelState.IsValid)
                return View(updateDevamsızlıkDto);

            try
            {
                await _devamsızlıkService.UpdateDevamsızlıkAsync(updateDevamsızlıkDto);
                TempData["SuccessMessage"] = "Devamsızlık başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(updateDevamsızlıkDto);
            }
        }
        [Authorize(Roles = "admin,ogretmen")]
        // Devamsızlık silme
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _devamsızlıkService.DeleteDevamsızlıkAsync(id);
                TempData["SuccessMessage"] = "Devamsızlık başarıyla silindi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
