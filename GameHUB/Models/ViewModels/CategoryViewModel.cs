using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.ServiceLocation;

namespace GameHUB.Models.ViewModels
{
    public class CategoryViewModel<TCategory> : IViewModel<TCategory> where TCategory : NodeContent
    {
        public CategoryViewModel(TCategory currentContent, IEnumerable<ProductContent> products)
        {
            CurrentContent = currentContent;
            Products = products;
        }
        public TCategory CurrentContent { get; }
        public LayoutModel Layout { get; set; }
        public IEnumerable<ProductContent> Products { get; set; }
        
    }

    public static class CategoryViewModel
    {
        private static Injected<IContentLoader> _contentLoader;
        public static CategoryViewModel<TCategory> Create<TCategory>(TCategory category) where TCategory : NodeContent
        {
            var products = _contentLoader.Service.GetChildren<ProductContent>(category.ContentLink);
            return new CategoryViewModel<TCategory>(category, products);
        }
    }


}