using System;
using System.Collections.Generic;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Logging.Compatibility;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using GameHUB.Models.Commerce;

namespace GameHUB.Business.Twitch.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class TwitchGamesListInitialization : IInitializableModule
    {
        private static Injected<IContentRepository> contentRepository;
        

        public void Initialize(InitializationEngine context)
        {
            var events = context.Locate.ContentEvents();
            events.PublishedContent += EventsPublishingContent;
        }

        private void EventsPublishingContent(object sender, ContentEventArgs e)
        {
            if (!(e.Content is GameProduct product)) return;
            
            var tempGame = product.CreateWritableClone<GameProduct>();
            var game = TwitchUtils.GameByTitle(product.Name);
            tempGame.TwitchGameId = game._id;
            tempGame.TwitchImageUrl = game.box.Large;
            if (product.TwitchGameId == tempGame.TwitchGameId) return;
            contentRepository.Service.Save(tempGame, SaveAction.Publish | SaveAction.ForceCurrentVersion);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }

    




}