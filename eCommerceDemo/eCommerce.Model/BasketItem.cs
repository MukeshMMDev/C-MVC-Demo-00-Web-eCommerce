namespace eCommerce.Model
{
    public class BasketItem
    {
        public int BasketItemID { get; set; }
        public int BasketID { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}