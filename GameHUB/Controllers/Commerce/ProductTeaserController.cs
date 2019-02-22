using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using GameHUB.Models.Commerce;
using GameHUB.Models.ViewModels;

namespace GameHUB.Controllers.Commerce
{
    [TemplateDescriptor(TemplateTypeCategory = TemplateTypeCategories.MvcPartialController)]
    public class ProductTeaserController : ContentController<SiteProduct>
    {
        public ActionResult Index(SiteProduct currentContent)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            
            switch (currentContent)
            {
                case GameProduct gameProduct:
                    var gameModel = ProductTeaserViewModel.Create(gameProduct);
                    return PartialView("Commerce/_GameProduct", gameModel);
                case ModProduct modProduct:
                    var modModel = ProductTeaserViewModel.Create(modProduct);
                    return PartialView("Commerce/_ModProduct", modModel);
                case MerchProduct merchProduct:
                    var merchModel = ProductTeaserViewModel.Create(merchProduct);
                    return PartialView("Commerce/_MerchProduct", merchModel);
            }
            var model = ProductTeaserViewModel.Create(currentContent);
            return PartialView(model);
        }
    }
}