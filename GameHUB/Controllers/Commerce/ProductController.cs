using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using GameHUB.Models.Commerce;
using GameHUB.Models.ViewModels;

namespace GameHUB.Controllers.Commerce
{
    public class ProductController : ContentController<SiteProduct>
    {
        public ActionResult Index(SiteProduct currentContent)
        {
            var model = ProductViewModel.Create(currentContent);
            return View(model);
        }
    }
}
