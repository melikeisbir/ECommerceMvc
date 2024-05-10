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
            List<CardItem> items = HttpContext.Session.GetJson<List<CardItem>>("Card") ?? new List<CardItem>(); //sepet listesi boş değilse sepet listesini gönder
            CardViewModel cardvm = new()
            {
                CardItems = items,
                GenelToplam = items.Sum(x => x.Price)
            };
            return View(cardvm);
        }
        public async Task<IActionResult> Add(int id)
        {
            Product product = _context.Products.Find(id);
            List<CardItem> items = HttpContext.Session.GetJson<List<CardItem>>("Card") ?? new List<CardItem>();//sepet boş mu dolu mu
            CardItem cardItem = items.FirstOrDefault(x => x.ProductId == id); //carditem içinde bu değer var mı ? değer varsa değeri kart içine ekleme yapacak, değer boşsa ekleme olacak, değer doluysa adet 1 artacak
            if (cardItem == null)
            {
                items.Add(new CardItem(product)); //boşsa ekle
            }
            else
            {
                cardItem.Quantity += 1; //doluysa 1 artır
            }
            HttpContext.Session.SetJson("Card", items);
            TempData["Mesaj"] = "Ürün sepete eklenmiştir"; //bir sayfadan bir sayfaya veri gönderme

            return Redirect(Request.Headers["Referer"].ToString()); //istekte bulunduktan sonra aynı sayfaya yönlendirme
        }
        public async Task<IActionResult> Decrease(int id) //azaltma işlemi
        {
            List<CardItem> card = HttpContext.Session.GetJson<List<CardItem>>("Card"); //card anahtarıyla gönderilen json verisini al
            CardItem cardItem = card.Where(c => c.ProductId == id).FirstOrDefault();
            if (cardItem.Quantity > 1) //eğer miktar 1den büyükse
            {
                cardItem.Quantity -= 1; //1 azalt
            }
            else
            {
                card.RemoveAll(c => c.ProductId == id); //değeri 1 den küçükse o sepeti full sil
            }
            if(card.Count > 0) //cardin içindeki adet 0dan büyükse
            {
                HttpContext.Session.SetJson("Card", card); //setjsondaki card değerlerini bunun içerisine ata
            }
            TempData["Mesaj"] = "Ürün sepetten silindi";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int id)
        {
            List<CardItem> card = HttpContext.Session.GetJson<List<CardItem>>("Card");
            card.RemoveAll(c=>c.ProductId == id);
            if(card.Count > 0)
            {
                HttpContext.Session.Remove("Card");
            }
            else
            { //sıfırdan küçükse card değerini ata
                HttpContext.Session.SetJson("Card", card);
            }
            TempData["Mesaj"] = "Ürün sepeti silindi";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Clear()
        {
            HttpContext.Session.Remove("Card");//card anahtarını sil
            return RedirectToAction("Index");
        }
    }
}
