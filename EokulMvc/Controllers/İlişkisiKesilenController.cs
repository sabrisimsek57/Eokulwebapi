using Eokulwebapi.Dtos.İlişkisiKesilen;
using Eokulwebapi.Service.İlişkisiKesilen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EokulMvc.Controllers
{
    [Authorize(Roles = "admin")]
    [Authorize]
    public class İlişkisiKesilenController : Controller
    {
        private readonly IİlişkisiKesilenService _ilişkisiKesilenService;

        public İlişkisiKesilenController(IİlişkisiKesilenService ilişkisiKesilenService)
        {
            _ilişkisiKesilenService = ilişkisiKesilenService;
        }

        // Tüm ilişkisi kesilenleri listele
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var ilişkisiKesilenler = await _ilişkisiKesilenService.GetAllİlişkisiKesilenAsync();
                return View(ilişkisiKesilenler);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(new List<ResultİlişkisiKesilenDto>());
            }
        }

        //// İlişkisi kesilen kaydını detaylı görüntüle
        //[HttpGet("Details/{id}")]
        //public async Task<IActionResult> Details(int id)
        //{
        //    try
        //    {
        //        var ilişkisiKesilen = await _ilişkisiKesilenService.GetByIdİlişkisiKesilenAsync(id);
        //        if (ilişkisiKesilen == null)
        //        {
        //            TempData["ErrorMessage"] = "İlişkisi kesilen kaydı bulunamadı.";
        //            return RedirectToAction("Index");
        //        }
        //        return View(ilişkisiKesilen);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = $"Hata: {ex.Message}";
        //        return RedirectToAction("Index");
        //    }
        //}

        // Yeni ilişkisi kesilen kaydı oluşturma
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateİlişkisiKesilen createİlişkisiKesilen)
        {
            if (!ModelState.IsValid)
                return View(createİlişkisiKesilen);

            try
            {
                await _ilişkisiKesilenService.KesilmeİşlemiAsync(createİlişkisiKesilen);
                TempData["SuccessMessage"] = "Öğrencinin ilişkisi başarıyla kesildi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(createİlişkisiKesilen);
            }
        }

        // İlişkisi kesilen kaydını güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var ilişkisiKesilen = await _ilişkisiKesilenService.GetByIdİlişkisiKesilenAsync(id);
                if (ilişkisiKesilen == null)
                {
                    TempData["ErrorMessage"] = "İlişkisi kesilen kaydı bulunamadı.";
                    return RedirectToAction("Index");
                }
                var updateİlişkisiKesilenDto = new UpdateİlişkisiKesilenDto
                {
                    İlişkisiKesilenId = ilişkisiKesilen.İlişkisiKesilenId,
                    İlişkisiKesilmeTarihi = ilişkisiKesilen.İlişkisiKesilmeTarihi,
                    ÖğrenciId = ilişkisiKesilen.ÖğrenciId,
                    gerekçe = ilişkisiKesilen.gerekçe
                };
                return View(updateİlişkisiKesilenDto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateİlişkisiKesilenDto updateİlişkisiKesilenDto)
        {
           

            try
            {
                await _ilişkisiKesilenService.UpdateİlişkisiKesilenAsync(updateİlişkisiKesilenDto);
                TempData["SuccessMessage"] = "İlişkisi kesilen başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(updateİlişkisiKesilenDto);
            }
        }

        // İlişkisi kesilen kaydını silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ilişkisiKesilenService.DeleteİlişkisiKesilenAsync(id);
                TempData["SuccessMessage"] = "İlişkisi kesilen başarıyla silindi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
