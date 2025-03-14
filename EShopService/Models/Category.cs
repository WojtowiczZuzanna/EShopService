using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShopService.Models
{
    public class Category : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
    }
}