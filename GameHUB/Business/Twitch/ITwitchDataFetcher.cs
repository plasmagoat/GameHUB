using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHUB.Business.Twitch
{
    public interface ITwitchDataFetcher
    {
        string GetChannel(int gameId);
        IDictionary<string, int> TopGames();
    }
}
