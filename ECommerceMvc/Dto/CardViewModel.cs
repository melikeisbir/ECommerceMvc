using ECommerceMvc.Models;

namespace ECommerceMvc.Dto //data transfer object
{
    public class CardViewModel
    {
        public List<CardItem> CardItems { get; set; }
        public decimal GenelToplam { get; set; }
        public decimal GrandTotal
        {
            get => CardItems.Sum(x => x.Quantity * x.Price);
        }
    }
}