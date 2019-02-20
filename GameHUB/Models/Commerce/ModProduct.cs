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
    public class ModProduct : ProductContent
    {
        [Display(Name = "Title", Description = "Mod Title", GroupName = SystemTabNames.Content, Order = 1)]
        public virtual string Title { get; set; }

        [Display(Name = "Description", Description = "Mod Description", GroupName = SystemTabNames.Content, Order = 2)]
        [UIHint(UIHint.Textarea)]
        public virtual string Description { get; set; }

        [Display(Name = "Image", Description = "Mod Image", GroupName = SystemTabNames.Content, Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(Name = "Related Game", Description = "Related Game Reference", GroupName = SystemTabNames.Content, Order = 4)]
        public virtual ContentReference GameReference { get; set; }
    }
}