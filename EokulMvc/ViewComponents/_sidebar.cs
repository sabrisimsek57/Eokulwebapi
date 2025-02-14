using Microsoft.AspNetCore.Mvc;

namespace EokulMvc.ViewComponents
{
    public class _sidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
 
    
}
