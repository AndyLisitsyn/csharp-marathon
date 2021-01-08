using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sprint_16.Models
{
    public class Product
    {
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        public double Price { get; set; } // decimal float

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
