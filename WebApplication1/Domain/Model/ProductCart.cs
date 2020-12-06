using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    public class ProductCart : Entity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
