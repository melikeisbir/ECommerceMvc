namespace ECommerceMvc.Models
{
    public class CardItem
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public string Image { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; } //ürün miktarıyla fiyatı çarpsın toplamda getirsin
        }
        public CardItem() { }
        public CardItem (Product products) //constructor
        {
            ProductId = products.Id;
            ProductName = products.Name;
            Quantity = 1;
            Price = Convert.ToDecimal(products.Price);
            Image = products.ProductImage;
        }
    }
}
