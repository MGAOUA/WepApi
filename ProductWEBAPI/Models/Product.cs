namespace ProductWEBAPI.Models
{

    // Represents a 'Products' table in the database
    public class Product
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } // Foreign Key

        // Navigation property (defines the relationship)
       /// <summary>
        public Category Category { get; set; }
       /// </summary>
       /// // Lazy loading applied using virtual keyword
       // public virtual Category Category { get; set; } // Notice 'virtual' keyword
    }
}
