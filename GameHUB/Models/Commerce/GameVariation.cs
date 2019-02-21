using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace GameHUB.Models.Commerce
{
    [CatalogContentType(DisplayName = "GameVariation", GUID = "e70ee94f-d0e0-461d-8776-f2a9295a3124", Description = "Game Variation")]
    public class GameVariation : VariationContent
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Name { get; set; }
         */
    }
}