using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameHUB.Business.Twitch.TwitchFetching
{
    public class TwitchData
    {


        


        public class TopStreams
        {
            public List<TwitchStream> data;
        }

        public class TwitchStream
        {
            public string user_name;
        }

        public class TopGamesResponse
        {
            public List<Game> games;
        }

        public class Game
        {
            public string name;
            public int _id;
            public Image box;
            public int popularity;
        }

        public class Image
        {
            public string Large;
            public string Medium;
            public string Small;
            public string Template;
        }




    }
}