using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Description;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Logging.Compatibility;
using EPiServer.ServiceLocation;
using GameHUB.Business.Twitch;

namespace GameHUB.Infrastructure.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class TwitchGamesListInitialization : IInitializableModule
    {
        private ITwitchDataFetcher _fetcher = new TwitchDataFetcher(LogManager.GetLogger("twitch"));


        public void Initialize(InitializationEngine context)
        {
            TwitchGamesList.GamesList = _fetcher.TopGames();
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }


    public static class TwitchGamesList
    {
        /// <summary>
        /// Holds twitches current top 100 games with their names and id's.
        /// </summary>
        public static IDictionary<string, int> GamesList = new Dictionary<string, int>();
    }

}