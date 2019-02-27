using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Commerce.Order;
using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace GameHUB.Models.ViewModels
{
    public class LayoutModel
    {
        public Header Header { get; set; }
        public Footer Footer { get; set; }
        public ContentArea CiderMenu { get; set; }
        public ICart Cart { get; set; }
    }

    public class Footer
    {
        public LinkItemCollection AboutLinks { get; set; }
        public LinkItemCollection LegalLinks { get; set; }
        
    }

    public class Header
    {
        public ContentReference LogoUrl { get; set; }
        public string Title { get; set; }
        public string Slogan { get; set; }
        public ContentReference CartImageUrl { get; set; }
    }
}