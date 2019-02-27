using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Commerce.Order;

namespace GameHUB.Infrastructure.Commerce
{
    public interface ICartService
    {
        void AddToCart(ICart cart, string code, decimal quantity);
        ILineItem AddLineItem(ICart cart, string code, decimal quantity, string displayName);
        void ChangeCartItem(ICart cart, string code, decimal quantity);
        ICart LoadCart(string name);
        ICart LoadOrCreateCart(string name);

    }
}
