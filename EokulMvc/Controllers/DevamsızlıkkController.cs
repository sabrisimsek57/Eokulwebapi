using Eokulwebapi.Dtos.DevamsızlıkDto;
using Eokulwebapi.Service.Devamsızlık;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EokulMvc.Controllers
{
    [Authorize(Roles = "admin,ogretmen")]
    [Authorize]
    public class DevamsızlıkkController : Controller
    {
        private readonly IDevamsızlıkService _devamsızlıkService;

        public DevamsızlıkkController(IDevamsızlıkService devamsızlıkService)
        {
            _devamsızlıkService = devamsızlıkService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDevamsızlıkDto createDevamsızlıkDto)
        {


            try
            {
                await _devamsızlıkService.CreateDevamsızlıkAsync(createDevamsızlıkDto);

                return RedirectToAction("Index", "Devamsızlık");
            }
            catch (Exception ex)
            {
               
                return View(createDevamsızlıkDto);
            }
        }

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

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDevamsızlıkDto updateDevamsızlıkDto)
        {
            if (!ModelState.IsValid)
                return View(updateDevamsızlıkDto);

            try
            {
                await _devamsızlıkService.UpdateDevamsızlıkAsync(updateDevamsızlıkDto);
               
                return RedirectToAction("Index", "Devamsızlık");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(updateDevamsızlıkDto);
            }
        }

        // Devamsızlık silme
        [HttpGet]
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
            return RedirectToAction("Index", "Devamsızlık");
        }
    }
}
