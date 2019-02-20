using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using GameHUB.Infrastructure.Editor;

namespace GameHUB.Models.Pages
{
    [ContentType(DisplayName = "MasterPage", GUID = "b616383d-2e49-49c1-8a33-2e33fe4ae261", Description = "")]
    public class MasterPage : SitePageData
    {
        #region HEADER
        [Display(
            Name = "Logo Reference",
            Description = "Logo Image Reference",
            GroupName = GroupNames.Header,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference LogoReference { get; set; }

        [Display(
            Name = "Title",
            Description = "Site Title",
            GroupName = GroupNames.Header,
            Order = 2)]
        public virtual string Title { get; set; }

        [Display(
            Name = "Slogan",
            Description = "Site Slogan",
            GroupName = GroupNames.Header,
            Order = 3)]
        public virtual string Slogan { get; set; }

        [Display(
            Name = "Cart Image",
            Description = "Cart Image Reference",
            GroupName = GroupNames.Header,
            Order = 4)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference CartImageReference { get; set; }

        #endregion

        #region FOOTER


        [Display(
            Name = "About Links",
            Description = "About Links Collection",
            GroupName = GroupNames.Footer,
            Order = 10)]
        public virtual LinkItemCollection AboutLinks { get; set; }

        [Display(
            Name = "Legal Links",
            Description = "Legal Links Collection",
            GroupName = GroupNames.Footer,
            Order = 20)]
        public virtual LinkItemCollection LegalLinks { get; set; }

        #endregion

        #region MENU

        [Display(
            Name = "Cider Menu",
            Description = "Cider Menu Items",
            GroupName = GroupNames.Menu,
            Order = 10)]
        //[AllowedTypes(AllowedTypes = new []{ typeof(NodeContent)})]
        public virtual ContentArea Menu { get; set; }


        #endregion

        #region MAIN

        [Display(
            Name = "Main Content",
            Description = "Main Content Area",
            GroupName = GroupNames.Main,
            Order = 10)]
        public virtual ContentArea MainContent { get; set; }

        #endregion
    }
    
    

}