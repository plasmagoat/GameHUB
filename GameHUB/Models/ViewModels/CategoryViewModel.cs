using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.ServiceLocation;
using GameHUB.Models.Commerce;

namespace GameHUB.Models.ViewModels
{
    public class CategoryViewModel<TCategory> : IViewModel<TCategory> where TCategory : NodeContent
    {
        public CategoryViewModel(TCategory currentContent, IEnumerable<SiteProduct> products)
        {
            CurrentContent = currentContent;
            Products = products;
        }
        public TCategory CurrentContent { get; }
        public LayoutModel Layout { get; set; }
        public IEnumerable<SiteProduct> Products { get; set; }
        
    }

    public static class CategoryViewModel
    {
        private static Injected<IContentLoader> _contentLoader;
        public static CategoryViewModel<TCategory> Create<TCategory>(TCategory category) where TCategory : NodeContent
        {
            var products = _contentLoader.Service.GetChildren<SiteProduct>(category.ContentLink).ToHashSet();
            var subCategories = _contentLoader.Service.GetChildren<Category>(category.ContentLink);
            foreach (var subCategory in subCategories)
            {
                products.UnionWith(_contentLoader.Service.GetChildren<SiteProduct>(subCategory.ContentLink));
            }

            return new CategoryViewModel<TCategory>(category, products);
        }
    }


}