using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using GameHUB.Infrastructure.Rendering;

namespace GameHUB.Infrastructure.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FilterInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            GlobalFilters.Filters.Add(ServiceLocator.Current.GetInstance<LayoutActionFilter>());
        }

        public void Uninitialize(InitializationEngine context)
        {
            GlobalFilters.Filters.Remove(ServiceLocator.Current.GetInstance<LayoutActionFilter>());
        }
    }
}