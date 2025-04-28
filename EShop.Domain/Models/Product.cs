using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Domain.Models
{
    [Table("Products")]
    public class Product : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column ("Name", TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        
        [Column("Ean", TypeName = "varchar(50)")]
        public string Ean { get; set; }
        
        
        [Column("Price", TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        
        [Column("Stock")]
        public int Stock { get; set; } = 0;


        [Column("Sku", TypeName = "varchar(50)")]
        public string Sku { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } = default;

        public bool Deleted { get; set; } = false;

    }
}
