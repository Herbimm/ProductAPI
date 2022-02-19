using MongoDB.Bson;

namespace ProductAPI.Models
{
    public class Product
    {
        public ObjectId Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
