using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;

namespace GameHUB.Models.Commerce
{
    public class SiteProduct : ProductContent
    {
        [Display(Name = "Image", Description = "Product Image", GroupName = SystemTabNames.Content, Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }
        
    }
}