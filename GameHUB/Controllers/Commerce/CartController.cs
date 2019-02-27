using System;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Order;
using EPiServer.ServiceLocation;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Customers;
using System.Linq;
using System.Web.Mvc;
using GameHUB.Infrastructure.Commerce;
using Mediachase.Commerce.Pricing;

namespace GameHUB.Controllers.Commerce
{
    public class CartController : Controller
    {
        private ICart _cart;
        private readonly Injected<IContentLoader> _contentLoader;
        private readonly Injected<ReferenceConverter> _referenceConverter;
        private readonly Injected<IOrderRepository> _orderRepository;
        private readonly Injected<IOrderGroupFactory> _orderGroupFactory;
        private readonly Injected<IOrderGroupCalculator> _orderGroupCalculator;
        private readonly Injected<IPriceService> _priceService;
        private readonly Injected<CustomerContext> _customerContext;
        private readonly Injected<ICartService> _cartService;

        private ICart Cart => _cart ?? (_cart = _cartService.Service.LoadOrCreateCart("Default"));

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MiniCart()
        {
            return PartialView("Commerce/_MiniCart", Cart);
        }

        [HttpPost]
        public ActionResult AddToCart(string code)
        {
            if (Cart == null)
            {
                _cart = _cartService.Service.LoadOrCreateCart("Default");
            }

            _cartService.Service.AddToCart(Cart, code, 1);
            _orderRepository.Service.Save(Cart);

            return MiniCart();
        }

        [HttpPost]
        public ActionResult ChangeCartItem(string code, decimal quantity)
        {
            _cartService.Service.ChangeCartItem(Cart, code, quantity);
            _orderRepository.Service.Save(Cart);

            return MiniCart();
        }
    }
}