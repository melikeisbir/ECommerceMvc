using ECommerceMvc.Entity;
using ECommerceMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMvc.Controllers
{
    public class ProductController : Controller
    {
        public Context _context;
        public IWebHostEnvironment _environment;

        public ProductController(Context context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> urunListesi = new List<Product>();
            urunListesi = await _context.Products.ToListAsync(); //select * from Kitap 
            return View(urunListesi);
        }
            public IActionResult Detail()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
