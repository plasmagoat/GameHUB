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
    public class MerchProduct : ProductContent
    {
        [Display(Name = "Title", Description = "Merch Title", GroupName = SystemTabNames.Content, Order = 1)]
        public virtual string Title { get; set; }

        [Display(Name = "Description", Description = "Merch Description", GroupName = SystemTabNames.Content, Order = 2)]
        [UIHint(UIHint.Textarea)]
        public virtual string Description { get; set; }

        [Display(Name = "Related Game", Description = "Related Game Reference", GroupName = SystemTabNames.Content, Order = 3)]
        public virtual ContentReference GameReference { get; set; }
        
    }
}