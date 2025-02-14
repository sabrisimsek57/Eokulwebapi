using Eokulwebapi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EokulMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace EokulMvc.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        
        

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(loginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {
                    // Giriş yapan kullanıcıyı al
                    var user = await _userManager.FindByNameAsync(loginUserDto.Username);
                    var öğrenciId = user.ÖğrenciId;
                    var öğretmenid = user.ÖğretmenId;

                    if (öğrenciId != null)
                    {
                        // ÖğrenciId'yi al
                       
                       

                        // ÖğrenciId'yi URL parametresi ile gönder
                        return RedirectToAction("GetByÖğrenciId", "Not", new { id = öğrenciId });
                    }
                    else if (öğretmenid != null)
                    {
                        return RedirectToAction("GetDersProgramıByÖğretmenId", "DersProgram", new { id = öğretmenid });
                    }
                    else if(öğrenciId == null && öğretmenid == null )
                    {
                        return RedirectToAction("Index", "Öğretmen"); // Kullanıcı bulunamadıysa hata sayfası dönebilir
                    }
                    return View("Index","Öğretmen"); // Kullanıcı bulunamadıysa hata sayfası dönebilir
                    
                }
                else
                {
                    // Giriş başarısızsa, uygun bir model ile Login görünümüne yönlendir
                    return View("Index");
                }

            }
            return View("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }
    }
}
