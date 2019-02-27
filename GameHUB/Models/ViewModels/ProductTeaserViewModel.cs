using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.Commerce.SpecializedProperties;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using GameHUB.Helpers;
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
        public string ImageUrl { get; set; }
        public IEnumerable<VariationContent> Variants { get; set; }
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

            viewModel.Variants = variations;
            
            switch (product)
            {
                case GameProduct gameProduct:
                    viewModel.ImageUrl = gameProduct.Image != null ? UrlResolver.Current.GetUrl(gameProduct.Image) : gameProduct.TwitchImageUrl;
                    break;
                case ModProduct modProduct:
                    viewModel.ImageUrl = modProduct.Image != null ? 
                        UrlResolver.Current.GetUrl(modProduct.Image) : 
                        _contentLoader.Service.Get<GameProduct>(modProduct.GameReference).TwitchImageUrl;
                    break;
                case MerchProduct merchProduct:
                    viewModel.ImageUrl = merchProduct.Image != null ?
                        UrlResolver.Current.GetUrl(merchProduct.Image) :
                        _contentLoader.Service.Get<GameProduct>(merchProduct.GameReference).TwitchImageUrl;
                    break;
            }

            return viewModel;
        }
    }
}