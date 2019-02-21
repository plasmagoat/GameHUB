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
    [CatalogContentType(DisplayName = "Mod", GUID = "af3635a4-7a37-4fac-aa8c-685e15142791", Description = "A Mod Product", MetaClassName = "ModProduct")]
    public class ModProduct : SiteProduct, IReferencable
    {

        [Display(Name = "Related Game", Description = "Related Game Reference", GroupName = SystemTabNames.Content, Order = 4)]
        public virtual ContentReference GameReference { get; set; }

        public ContentReference GetGameReference()
        {
            return GameReference;
        }
    }
}