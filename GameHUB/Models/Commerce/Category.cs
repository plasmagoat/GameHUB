using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace GameHUB.Models.Commerce
{
    [CatalogContentType(DisplayName = "Category", GUID = "2380bb57-162d-48cb-ab85-d17c63c80ff5", MetaClassName = "Category")]
    public class Category : NodeContent
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