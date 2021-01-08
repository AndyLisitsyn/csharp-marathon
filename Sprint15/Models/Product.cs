using ProductsValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    [EqualsDescriptionName]
    public class Product
    {
        public enum Category { Toy, Technique, Clothes, Transport}
        public int Id { get; set; }
        public Category Type { get; set; }
		[Required(ErrorMessage = "The field Name is a mandatory field.")]
        public string Name { get; set; }
        [StringLength(int.MaxValue,MinimumLength = 3, ErrorMessage = "The field Description must contain more than 2 characters.")]
		public string Description { get; set; }
        [Range(0, 100000, ErrorMessage = "The field Price should be in range from 0 to 100000.")]
        public decimal Price { get; set; }
    }
}
