using ECommerceMvc.Data;
using ECommerceMvc.Dto;
using ECommerceMvc.Models;
using ECommerceMvc.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMvc.Component
{
    public class SepetSumList : ViewComponent
    {
        private readonly Context _context;

        public SepetSumList(Context context) //nesneyi constructor içine at
        {//veriyi tanımlar tanımlamaz veri tabanına bağlansın
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            List<CardItem> card = HttpContext.Session.GetJson<List<CardItem>>("Card") ?? new List<CardItem>(); //session içinde tutulan tüm listeler carda atılıyor
            CardViewModel cardVm = new()
            {
                CardItems = card,
                GenelToplam = card.Sum(x => x.Quantity * x.Price)
            };
            return View(cardVm);
        }
    }
}
