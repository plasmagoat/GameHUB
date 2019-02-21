using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Commerce.SpecializedProperties;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace GameHUB.Models.Commerce
{
    [CatalogContentType(DisplayName = "Merch", GUID = "8e13d872-77c3-4015-b5eb-f0cf20439b8b", Description = "A Merchandise Product", MetaClassName = "MerchProduct")]
    public class MerchProduct : SiteProduct, IReferencable
    {
        [Display(Name = "Related Game", Description = "Related Game Reference", GroupName = SystemTabNames.Content, Order = 3)]
        public virtual ContentReference GameReference { get; set; }
        
        public ContentReference GetGameReference()
        {
            return GameReference;
        }
    }
}