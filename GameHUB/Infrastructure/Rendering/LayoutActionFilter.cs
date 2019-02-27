using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using GameHUB.Models.ViewModels;
using System.Web.Mvc;
using EPiServer.Web;
using GameHUB.Infrastructure.Commerce;
using GameHUB.Models.Pages;

namespace GameHUB.Infrastructure.Rendering
{
    [ServiceConfiguration(ServiceType = typeof(LayoutActionFilter), Lifecycle = ServiceInstanceScope.Singleton)]
    public class LayoutActionFilter : IActionFilter
    {
        private readonly IContentLoader _contentLoader;
        private readonly ICartService _cartService;

        public LayoutActionFilter(IContentLoader contentLoader, ICartService cartService)
        {
            _contentLoader = contentLoader;
            _cartService = cartService;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!(filterContext.Controller.ViewData.Model is IViewModel<IContent> model)) return;

            model.Layout = CreateLayoutModel(model.CurrentContent.ContentLink);
        }

        private LayoutModel CreateLayoutModel(ContentReference currentContentLink)
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;
            
            // Use the content link with version information when editing the startpage,
            // otherwise the published version will be used when rendering the props below.
            if (currentContentLink.CompareToIgnoreWorkID(startPageContentLink))
            {
                startPageContentLink = currentContentLink;
            }

            var startPage = _contentLoader.Get<MasterPage>(startPageContentLink);

            return new LayoutModel()
            {
                CiderMenu = startPage.Menu,
                Header = new Header()
                {
                    CartImageUrl = startPage.CartImageReference,
                    LogoUrl = startPage.LogoReference,
                    Title = startPage.Title,
                    Slogan = startPage.Slogan
                },
                Footer = new Footer()
                {
                    AboutLinks = startPage.AboutLinks,
                    LegalLinks = startPage.LegalLinks
                },
                Cart = _cartService.LoadOrCreateCart("Default")
            };
        }
    }
}