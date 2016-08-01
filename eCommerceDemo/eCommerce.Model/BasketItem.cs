using System;

namespace eCommerce.Model
{
    public class BasketItem
    {
        public int BasketItemID { get; set; }
        public Guid BasketID { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}