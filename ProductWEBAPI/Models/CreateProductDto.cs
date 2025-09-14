using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductWEBAPI.Models
{
    // DTO (for data transfer - Create operation)

    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [EmailAddress] // Example of a built-in validation attribute
        public string SupplierEmail { get; set; }
        public int CategoryId { get; set; } // Foreign Key
    }

}

