using System.ComponentModel.DataAnnotations;

namespace ECommerceMvc.ViewModels
{
    public class NewProductViewModel : EditImageViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public string ProductImage { get; set; }
        public bool IsApproved { get; set; }
    }
}
