using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Order;
using EPiServer.ServiceLocation;
using Mediachase.Commerce;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Customers;
using Mediachase.Commerce.Pricing;

namespace GameHUB.Infrastructure.Commerce
{
    [ServiceConfiguration(typeof(ICartService), Lifecycle = ServiceInstanceScope.Singleton)]
    public class CartService : ICartService
    {
        private readonly Injected<IContentLoader> _contentLoader;
        private readonly Injected<ReferenceConverter> _referenceConverter;
        private readonly Injected<IOrderRepository> _orderRepository;
        private readonly Injected<IOrderGroupFactory> _orderGroupFactory;
        private readonly Injected<IOrderGroupCalculator> _orderGroupCalculator;
        private readonly Injected<IPriceService> _priceService;
        private readonly Injected<ICurrentMarket> _currentMarket;
        private readonly Injected<CustomerContext> _customerContext;

        public void AddToCart(ICart cart, string code, decimal quantity)
        {
            var contentLink = _referenceConverter.Service.GetContentLink(code);
            var entryContent = _contentLoader.Service.Get<EntryContentBase>(contentLink);
            
            var lineItem = cart.GetAllLineItems().FirstOrDefault(x => x.Code == code);

            if (lineItem == null)
            {
                lineItem = AddLineItem(cart, code, quantity, entryContent.DisplayName);
            }
            else
            {
                var shipment = cart.GetFirstShipment();
                cart.UpdateLineItemQuantity(shipment, lineItem, lineItem.Quantity + quantity);
            }
        }

        public ILineItem AddLineItem(ICart cart, string newCode, decimal quantity, string displayName)
        {
            var newLineItem = cart.CreateLineItem(newCode, _orderGroupFactory.Service);
            newLineItem.Quantity = quantity;
            newLineItem.DisplayName = displayName;
            cart.AddLineItem(newLineItem, _orderGroupFactory.Service);

            var price = _priceService.Service.GetDefaultPrice(cart.MarketId, DateTime.Today, new CatalogKey(newCode),
                cart.Currency);
            newLineItem.PlacedPrice = price.UnitPrice.Amount;

            return newLineItem;
        }

        public void ChangeCartItem(ICart cart, string code, decimal quantity)
        {
            if (quantity > 0)
            {
                var lineItem = cart.GetAllLineItems().FirstOrDefault(x => x.Code == code);
                if (lineItem == null) return;
                var shipment = cart.GetFirstShipment();
                cart.UpdateLineItemQuantity(shipment, lineItem, quantity);
            }
            else
            {
                RemoveLineItem(cart, code);
            }
        }

        private void RemoveLineItem(ICart cart, string code)
        {
            var lineItem = cart.GetAllLineItems().FirstOrDefault(x => x.Code == code);
            if (lineItem != null)
            {
                cart.GetFirstShipment().LineItems.Remove(lineItem);
            }
        }

        public ICart LoadCart(string name)
        {
            throw new NotImplementedException();
        }

        public ICart LoadOrCreateCart(string name)
        {
            var cart = _orderRepository.Service.LoadOrCreateCart<ICart>(_customerContext.Service.CurrentContactId, name, _currentMarket.Service);
            return cart;
        }
    }
}