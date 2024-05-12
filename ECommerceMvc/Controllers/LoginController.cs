using Microsoft.AspNetCore.Mvc;

namespace ECommerceMvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
