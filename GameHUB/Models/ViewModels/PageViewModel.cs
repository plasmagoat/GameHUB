using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;

namespace GameHUB.Models.ViewModels
{
    public class PageViewModel<TPage> : IViewModel<TPage> where TPage : IContent
    {
        public PageViewModel(TPage currentPage)
        {
            CurrentContent = currentPage;
        }
        public TPage CurrentContent { get; set; }
        public LayoutModel Layout { get; set; }
    }

    public static class PageViewModel
    {
        public static PageViewModel<TPage> Create<TPage>(TPage page) where TPage : IContent
        {
            return new PageViewModel<TPage>(page);
        }
    }
}