using ECommerceMvc.Models;

namespace ECommerceMvc.Dto
{
    public class CardViewModel
    {
        public List<CardItem> CardItems { get; set; }
        public decimal GenelToplam { get; set; }
    }
}
