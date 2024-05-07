using ECommerceMvc.Entity;
using ECommerceMvc.Models;
using ECommerceMvc.ViewModels;
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
            urunListesi = await _context.Products.ToListAsync();
            return View(urunListesi);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductViewModel model)
        {
            try
            {
                string yuklenenResimAdi = ResimYukle(model);
                Product urun = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Stock = model.Stock,
                    ProductImage = yuklenenResimAdi
                };

                _context.Add(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction(nameof(Index));
        }
        private string ResimYukle(NewProductViewModel model)
        {
            string dosyaAdi = "";
            string dosyaninYuklenecegiKlasorYolu = Path.Combine(_environment.WebRootPath, "Uploads");

            if (!Directory.Exists(dosyaninYuklenecegiKlasorYolu))
            {
                Directory.CreateDirectory(dosyaninYuklenecegiKlasorYolu);
            }

            if (model.ProductPicture.FileName != null)
            {
                dosyaAdi = model.ProductPicture.FileName;
                string filePath = Path.Combine(dosyaninYuklenecegiKlasorYolu, dosyaAdi);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductPicture.CopyTo(fileStream);
                }

            }
            return dosyaAdi;
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunDetay = await _context.Products.FindAsync(id);

            NewProductViewModel productViewModel = new()
            {
                Name = urunDetay.Name,
                Description = urunDetay.Description,
                Price = urunDetay.Price,
                Stock = urunDetay.Stock,
                ProductImage = urunDetay.ProductImage
            };
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductViewModel model)
        {
            var urun = await _context.Products.FindAsync(model.Id);
            //urun.Name = model.Name;
            //urun.Description = model.Description;
            //urun.Price = model.Price;
            //urun.Stock = model.Stock;
            //düzenleme sayfasında bir başka resim seçtiysem kontrolünü yapmam gerekiyro
            if (model.ProductPicture != null)
            {
                //resmini değiştirmek istediğim ürünün database deki ProductPicture kolonundaki adına göre
                // git wwwroot klasörü altındaki Uploads klasöründeki ilgili resmi bul ve sil
                //string filePath = Path.Combine(_environment.WebRootPath, "Uploads", urun.ProductImage);
                //System.IO.File.Delete(filePath);


                //Product guncellencekUrun = new Product();

                //urun.Id = model.Id;
                urun.Name = model.Name;
                urun.Description = model.Description;
                urun.Price = model.Price;
                urun.Stock = model.Stock;
                string guncellenenYuklenenResimAdi = ResimYukle(model);
                urun.ProductImage = guncellenenYuklenenResimAdi;

                //_context.Entry(guncellencekUrun).State = EntityState.Modified;
                _context.Products.Update(urun);
                try
                {
                    await _context.SaveChangesAsync(); //update 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //select * from Kitap where Id=id
            var urun = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            string filePath = Path.Combine(_environment.WebRootPath, "Uploads", urun.ProductImage);
            System.IO.File.Delete(filePath);
            _context.Products.Remove(urun);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunD = await _context.Products.FindAsync(id);

            NewProductViewModel productViewModel = new()
            {
                Name = urunD.Name,
                Description = urunD.Description,
                Price = urunD.Price,
                Stock = urunD.Stock,
                ProductImage = urunD.ProductImage
            };
            return View(productViewModel);
        }
    }
}
