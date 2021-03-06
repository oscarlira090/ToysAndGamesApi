using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementEntities.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Range(0, 100)]
        public int AgeRestriction { get; set; }

        [StringLength(100)]
        [Required]
        public string? Company { get; set; }

        [Range(1, 1000)]
        [Required]
        public decimal Price { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }



    }
}
