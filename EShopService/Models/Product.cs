using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace EShopService.Models
{
    public class Product : BaseModel
    {
        public string ean { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public string sku { get; set; }
        public Category category { get; set; }


    }
}
