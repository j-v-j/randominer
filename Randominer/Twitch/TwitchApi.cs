using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randominer.Twitch
{
    public class TwitchApi
    {
        private TwitchClient _twitchClient;

        public TwitchApi(string apiKey, TwitchClient twitchClient = null)
        {
            _twitchClient = twitchClient != null ? twitchClient : new TwitchClient(apiKey);
        }

        public async Task<string> GetRandomStreamUri()
        {
            throw new NotImplementedException();
        }
    }
}
