using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
