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
    [CatalogContentType(DisplayName = "Game", GUID = "6cf1275e-0e24-4023-9aa0-ad6d7f7a2a70", Description = "A Game Product", MetaClassName = "GameProduct")]
    public class GameProduct : SiteProduct
    {
        [Display(Name = "Twitch String", Description = "Game Twitch String", GroupName = SystemTabNames.Content, Order = 5)]
        public virtual string TwitchString { get; set; }

        public virtual string TwitchImageUrl { get; set; }

        public virtual int TwitchGameId { get; set; }

    }
}