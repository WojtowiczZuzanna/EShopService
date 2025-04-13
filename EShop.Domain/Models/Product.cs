using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Domain.Models
{
    [Table("Products")]
    public class Product : BaseModel
    {
        [Required]
        [Column("Id")]
        public int Id { get; set; }


        [Required]
        [Column ("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }


        [Required]
        [Column("Ean", TypeName = "varchar(50)")]
        public string Ean { get; set; }
        
        
        [Required]
        [Column("Price)", TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        
        [Required]
        [Column("Stock")]
        public int Stock { get; set; } = 0;

        
        [Required]
        [Column("Sku", TypeName = "varchar(50)")]
        public string Sku { get; set; }

        
        [ForeignKey("Category")]
        public Category Category { get; set; } = default;


    }
}
