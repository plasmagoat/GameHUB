using System.Collections.Generic;
using EPiServer.Logging;
using GameHUB.Business.Twitch.Levenshtein;

namespace GameHUB.Business.Twitch
{
    public static class TwitchUtils
    {
        /// <summary>
        /// Holds twitches current top 100 games with their names and id's.
        /// </summary>
        public static IDictionary<string, int> GamesList = new Dictionary<string, int>();

        /// <summary>
        /// Fetches the channelname of the top twitch stream of a specific game.
        /// </summary>
        /// <param name="gameTitle">The title of the game</param>
        /// <returns>The username aka. the channelname for a stream on twitch, can be used for _Twitch (block)</returns>
        public static string ChannelByGameTitle(string gameTitle)
        {
            var realTitle = LevenshteinDistance.BestMatch(gameTitle);
            var id = GamesList[realTitle];
            return new TwitchDataFetcher().GetChannel(id);
        }

    }
}