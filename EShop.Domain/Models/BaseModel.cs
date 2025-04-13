using System.Data;

namespace EShop.Domain.Models
{
    public class BaseModel
    {
        public bool Deleted { get; set; }
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public Guid Created_by { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.UtcNow;
        public Guid Updated_by { get; set; }
    }
}