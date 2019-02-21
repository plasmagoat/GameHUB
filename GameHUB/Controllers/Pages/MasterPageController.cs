using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using GameHUB.Models.Pages;
using GameHUB.Models.ViewModels;

namespace GameHUB.Controllers
{
    public class MasterPageController : PageController<MasterPage>
    {
        public ActionResult Index(MasterPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View(model);
        }
    }
}