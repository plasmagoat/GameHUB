using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using EPiServer.Logging.Compatibility;
using GameHUB.Business.Twitch.TwitchFetching;
using Newtonsoft.Json;

namespace GameHUB.Business.Twitch
{
    public class TwitchDataFetcher : ITwitchDataFetcher
    {

        private const string TwitchNewAPIUrl = "https://api.twitch.tv/helix/";
        private const string Twitchv5APIUrl = "https://api.twitch.tv/kraken/";


        public TwitchData.Game GetGame(string name)
        {
            var json = Get($"{Twitchv5APIUrl}search/games?query={Uri.EscapeDataString(name)}");
            var deserializedJson = JsonConvert.DeserializeObject<TwitchData.TopGamesResponse>(json);
            return deserializedJson.games.First();
        }
        public string GetChannel(int gameId)
        {
            var json = Get($"{TwitchNewAPIUrl}streams?game_id={gameId}&first=1");
            var deserializedJson = JsonConvert.DeserializeObject<TwitchData.TopStreams>(json);
            return deserializedJson.data.First().user_name;
        }




        private string Get(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.Accept = "application/vnd.twitchtv.v5+json";
                request.Headers.Add("Client-ID","n15junauvbvns3wu1xy9h6vbn4j17r"); // TODO: TESTING
                var response = request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    var errorText = reader.ReadToEnd();
                    //_logger.Error(errorText, ex); //TODO: Should log this
                }
                throw;
            }
        }
    }
}