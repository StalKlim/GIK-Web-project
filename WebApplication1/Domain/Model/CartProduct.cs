using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.Model
{
    public class CartProduct : Entity
    {
        public long CartId { get; set; }
        public Cart Cart { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
