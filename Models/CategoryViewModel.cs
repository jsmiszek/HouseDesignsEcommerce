using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HouseDesignsEcommerce.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required]
        [MinLength(4)]
        public string CategoryName { get; set; }
    }
}
