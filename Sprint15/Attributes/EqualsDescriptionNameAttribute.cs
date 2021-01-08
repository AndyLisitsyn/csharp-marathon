using ProductsValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Attributes
{
    public class EqualsDescriptionNameAttribute : ValidationAttribute
    {
        public EqualsDescriptionNameAttribute()
        {
            ErrorMessage = "The field Description should not be equal to Name but should start with the Name of the product.";
        }
        public override bool IsValid(object value)
        {
            Product product = value as Product;
            return product.Description == null ? false : !product.Name.Equals(product.Description) && product.Description.StartsWith(product.Name);
        }
    }
}
