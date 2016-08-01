using eCommerce.Contracts.Repositories;
using eCommerce.DAL.Data;
using eCommerce.DAL.Repositories;
using eCommerce.Model;
using eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Basket> baskets;
        BasketServices basketService;

        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products)
        {
            this.customers = customers;
            this.products = products;
            basketService = new BasketServices(this.baskets);
        }
        public ActionResult Index()
        {
            var model = products.GetAll();
            return View(model);
        }
        public ActionResult BasketSummary()
        {
            var model = basketService.GetBasket(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(int id)
        {
            basketService.AddToBasket(this.HttpContext,id,1);//always add one to ther basket
            return RedirectToAction("BasketSummary");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}