using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHUB.Business.Twitch.TwitchFetching;

namespace GameHUB.Business.Twitch
{
    public interface ITwitchDataFetcher
    {
        TwitchData.Game GetGame(string name);
        string GetChannel(int gameId);
    }
}
