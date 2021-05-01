using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridge.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }
        public CategoryDTO Category { get; set; }
        public int CategoryId { get; set; }
    }
}