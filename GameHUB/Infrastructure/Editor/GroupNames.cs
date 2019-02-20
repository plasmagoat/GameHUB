using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.DataAnnotations;

namespace GameHUB.Infrastructure.Editor
{
    [GroupDefinitions]
    public static class GroupNames
    {

        [Display(Name = "Main Content", Order = 1)]
        public const string Main = "Main";

        [Display(Name = "Header Info", Order = 10)]
        public const string Header = "Header";

        [Display(Name = "Footer Info", Order = 20)]
        public const string Footer = "Footer";

        [Display(Name = "Menu Configuration", Order = 30)]
        public const string Menu = "Menu";
        
        [Display(Name = "SEO Info", Order = 10)]
        public const string SEO = "SEO";


    }
}