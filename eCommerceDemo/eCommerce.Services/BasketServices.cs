using eCommerce.Contracts.Repositories;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Services
{
    public class BasketServices
    {
        IRepositoryBase<Basket> baskets;

        public const string BasketSessionName = "eCommerceBasket";

        public BasketServices(IRepositoryBase<Basket> baskets) {
            this.baskets = baskets;
        }

        private Basket createNewBasket(HttpContextBase httpContext) {
            HttpCookie cookie = new HttpCookie(BasketSessionName);

            Basket basket = new Basket();
            basket.date = DateTime.Now;

            Random random = new Random();
            
            basket.BasketID = Guid.NewGuid();

            baskets.Insert(basket);
            baskets.Commit();

            cookie.Value = basket.BasketID.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;

        }

        public bool AddToBasket(HttpContextBase httpContext,int productId,int quantity) {
            bool success = true;

            Basket basket = GetBasket(httpContext);

            //Get item with id
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.ProductId == productId);

            //Check if item alread exist with id
            if (item == null)
            {
                item = new BasketItem()
                {
                    BasketID = basket.BasketID,
                    ProductId = productId,
                    Quantity = quantity
                };
                basket.BasketItems.Add(item);
            }
            else {
                item.Quantity = item.Quantity + quantity;
            }

            baskets.Commit();

            return success;
        }

        public Basket GetBasket(HttpContextBase httpContext) {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
            Basket basket;

            Guid basketId;

            if (cookie != null)
            {

                if (Guid.TryParse(cookie.Value, out basketId))
                {
                    basket = baskets.GetById(basketId);
                }
                else {
                    //Basket is expire
                    basket = createNewBasket(httpContext);
                }
            }
            else
            {
                basket = createNewBasket(httpContext);
            }

            return basket;
        }
    }
}
