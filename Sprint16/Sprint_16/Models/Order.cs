using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sprint_16.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int SupermarketId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }

        public Supermarket Supermarket { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
