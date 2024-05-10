using ECommerceMvc.Data;
using Microsoft.AspNetCore.Mvc;
using ECommerceMvc.Models;
using ECommerceMvc.Oturum;
using ECommerceMvc.Dto;

namespace ECommerceMvc.Controllers
{
    public class CardController : Controller
    {
        private readonly Context _context;

        public CardController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CardItem> items = HttpContext.Session.GetJson<List<CardItem>>("Card") ?? new List<CardItem>();
            CardViewModel cartvn = new()
            {
                CardItems = items,
                GenelToplam = items.Sum(x => x.Price)
            };
            return View();
        }
    }
}
