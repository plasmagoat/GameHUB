using System.Collections.Generic;
using EPiServer.Logging;
using GameHUB.Business.Twitch.TwitchFetching;

namespace GameHUB.Business.Twitch
{
    public static class TwitchUtils
    {
        /// <summary>
        /// Holds twitches current top 100 games with their names and id's.
        /// </summary>
        /// <summary>
        /// Fetches the channelname of the top twitch stream of a specific game.
        /// </summary>
        /// <param name="id">Twitch game id</param>
        /// <returns>The username aka. the channelname for a stream on twitch, can be used for _Twitch (block)</returns>
        public static string ChannelByGameTitle(int id)
        {
            return new TwitchDataFetcher().GetChannel(id);
        }

        public static TwitchData.Game GameByTitle(string gameTitle)
        {
            return new TwitchDataFetcher().GetGame(gameTitle);
        }



    }
}