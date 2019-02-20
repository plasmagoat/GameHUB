using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;

namespace GameHUB.Models.ViewModels
{
    public interface IViewModel<out TContent> where TContent : IContent
    {
        TContent CurrentContent { get; }
        LayoutModel Layout { get; set; }

    }
    

    public interface IDataViewModel<out TContent> where TContent : IContentData
    {
        TContent CurrentContent { get; }
    }
}