using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMvc.Entity
{
    public class Admin : IdentityUser
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KullaniciAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Sifre { get; set; }
        //[Column(TypeName = "Char")]
        //[StringLength(1)]
        //public string Yetki { get; set; }

    }
}
