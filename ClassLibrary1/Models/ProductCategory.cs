using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ProductCategory
    {
        public int ProductId { get; set; }

        [NotMapped]
        public Product Product { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        public Category Category { get; set; }
    }
}
