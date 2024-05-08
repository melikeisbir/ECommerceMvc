using ECommerceMvc.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMvc.Controllers
{
    public class LoginController : Controller
    {
        public Context _context;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = _context.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                //FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                //Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
