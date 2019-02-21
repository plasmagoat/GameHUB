using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using EPiServer.Logging.Compatibility;
using Newtonsoft.Json;

namespace GameHUB.Business.Twitch
{
    public class TwitchDataFetcher : ITwitchDataFetcher
    {

        private const string TwitchApiUrl = "https://api.twitch.tv/helix/";



        public string GetChannel(int gameId)
        {
            var json = Get($"{TwitchApiUrl}streams?game_id={gameId}&first=1");
            var deserializedJson = JsonConvert.DeserializeObject<TopStreams>(json);
            return deserializedJson.data.First().user_name;
        }

        public IDictionary<string, int> TopGames()
        {
            var json = Get($"{TwitchApiUrl}games/top?first=100");
            var deserializedJson = JsonConvert.DeserializeObject<TopGamesResponse>(json);
            var dic = new Dictionary<string, int>();
            foreach (var game in deserializedJson.data)
            {
                dic.Add(game.name, game.id);
            }
            return dic;
        }

        private class TopStreams
        {
            public List<TwitchStream> data;
        }

        private class TwitchStream
        {
            public string user_name;
        }

        private class TopGamesResponse
        {
            public List<Game> data;
        }

        private class Game
        {
            public string name;
            public int id;
        }


        private string Get(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.Headers.Add($"Client-ID: n15junauvbvns3wu1xy9h6vbn4j17r"); // TODO: TESTING
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