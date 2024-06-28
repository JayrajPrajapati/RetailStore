namespace Retail_Store.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string ProductID { get; set; }
        public int QuantitySold { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
