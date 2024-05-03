namespace ECommerceMvc.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsApproved { get; set; } //true ise bu ürün satışta

        public int CategoryId { get; set; } //category tablosundaki bir idye karşılık gelir
        public Category Category { get; set; }
    }
}
