using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sprint_16.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Address { get; set; }

        public string Discount { get; set; }

    }
}
