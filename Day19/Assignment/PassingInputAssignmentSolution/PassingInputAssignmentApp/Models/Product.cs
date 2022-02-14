using System.ComponentModel.DataAnnotations;

namespace PassingInputAssignmentApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        [Range(1, 50, ErrorMessage = "Invalid price")]
        public double Price { get; set; }
        [Range(1, 20, ErrorMessage = "Invalid quantity")]
        public int Quantity { get; set; }
        public string Pic { get; set; }
        public string Description { get; set; }
    }
}
