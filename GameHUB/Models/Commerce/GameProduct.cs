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
    public class GameProduct : ProductContent
    {
        [Display(Name = "Title", Description = "Game Title", GroupName = SystemTabNames.Content, Order = 1)]
        public virtual string Title { get; set; }

        [Display(Name = "Description", Description = "Game Description", GroupName = SystemTabNames.Content, Order = 2)]
        [UIHint(UIHint.Textarea)]
        public virtual string Description { get; set; }

        [Display(Name = "Image", Description = "Game Image", GroupName = SystemTabNames.Content, Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(Name = "Genre", Description = "Game Genre List", GroupName = SystemTabNames.Content, Order = 4)]
        [BackingType(typeof(PropertyDictionaryMultiple))]
        public virtual ItemCollection<string> GenreList { get; set; }

        [Display(Name = "Twitch String", Description = "Game Twitch String", GroupName = SystemTabNames.Content, Order = 5)]
        public virtual string TwitchString { get; set; }
    }
}