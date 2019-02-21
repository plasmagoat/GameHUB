using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using GameHUB.Models.Commerce;
using Mediachase.BusinessFoundation.Data.Meta.Management;

namespace GameHUB.Helpers
{
    public static class HtmlHelpers
    {
        private static Injected<IContentLoader> _contentLoader;

        public static string ForGameTitle(this HtmlHelper helper, SiteProduct p)
        {
            if (!(p is IReferencable productWithGameReference)) return "";
            var game = _contentLoader.Service.Get<GameProduct>(productWithGameReference.GetGameReference());

            return game.Name + ":";
        }

        public static IHtmlString MenuList(
            this HtmlHelper helper,
            ContentArea root,
            Func<MenuItem, HelperResult> itemTemplate)
        {
            var topMenuItems = new List<MenuItem>();
            foreach (var topMenuItem in root.Items)
            {
                
                var topMenu = _contentLoader.Service.Get<IContent>(topMenuItem.ContentLink);
                var item = new MenuItem(topMenu.Name, topMenu.ContentLink);
                

                foreach (var child in _contentLoader.Service.GetChildren<IContent>(topMenu.ContentLink))
                {

                    //297
                    if(child is ProductContent || child is VariationContent) continue;
                    item.SubMenu.Add(child.Name, child.ContentLink);

                    
                }
                topMenuItems.Add(item);
            }

            var buffer = new StringBuilder();
            var writer = new StringWriter(buffer);
            foreach (var menuItem in topMenuItems)
            {
                itemTemplate(menuItem).WriteTo(writer);
            }

            return new MvcHtmlString(buffer.ToString());
        }

        public class MenuItem
        {
            public MenuItem(string title, ContentReference link)
            {
                Title = title;
                SubMenu = new Dictionary<string, ContentReference>(){{"All", link}};
            }

            public string Title { get; set; }
            public Dictionary<string, ContentReference> SubMenu { get; set; }

        }

    }
}