namespace CoreAsmntApplication.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
  
    }
}
