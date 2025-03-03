using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShopService.Models
{
    public class Category : BaseModel
    {
        public int id { get; set; }
        public string name { get; set; } = default;
    }
}