using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.Commerce.SpecializedProperties;
using EPiServer.ServiceLocation;
using GameHUB.Models.Commerce;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Pricing;

namespace GameHUB.Models.ViewModels
{
    public class ProductTeaserViewModel<TProduct> where TProduct : SiteProduct
    {
        public ProductTeaserViewModel(TProduct product)
        {
            Product = product;
        }

        public TProduct Product { get; set; }
        public decimal FromPrice { get; set; }
        
    }

    public static class ProductTeaserViewModel
    {
        private static Injected<IRelationRepository> _relationRepo;
        private static Injected<IPriceService> _priceService;
        private static Injected<IContentLoader> _contentLoader;

        public static ProductTeaserViewModel<TProduct> Create<TProduct>(TProduct product) where TProduct : SiteProduct
        {
            var viewModel = new ProductTeaserViewModel<TProduct>(product);
            var variations = _relationRepo.Service.GetChildren<ProductVariation>(product.ContentLink).Select(x => _contentLoader.Service.Get<VariationContent>(x.Child));
            var price = _priceService.Service.GetCatalogEntryPrices(variations.Select(x => new CatalogKey(x.Code)));

            if (variations.Any() && price.Any())
            {
                viewModel.FromPrice = price.Min(x => x.UnitPrice.Amount);
            }

            return viewModel;
        }
    }
}