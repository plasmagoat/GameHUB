using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using GameHUB.Models.Commerce;
using GameHUB.Models.ViewModels;

namespace GameHUB.Controllers
{
    public class GameProductController : ContentController<GameProduct>
    {
        public ActionResult Index(GameProduct currentContent)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var model = PageViewModel.Create(currentContent);
            return View(model);
        }
    }
}