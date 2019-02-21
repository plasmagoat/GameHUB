using System.Collections.Generic;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Logging.Compatibility;

namespace GameHUB.Business.Twitch.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class TwitchGamesListInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            TwitchUtils.GamesList = new TwitchDataFetcher().TopGames();
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }

    




}