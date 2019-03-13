using System;
using System.Linq;
using System.Threading.Tasks;

namespace Randominer.Twitch
{
    public class TwitchApi : ITwitchApi
    {
        private TwitchClient _twitchClient;

        public TwitchApi(string apiKey, TwitchClient twitchClient = null)
        {
            _twitchClient = twitchClient != null ? twitchClient : new TwitchClient(apiKey);
        }

        public async Task<StreamDTO> GetRandomStream()
        {
            var streams = await _twitchClient.GetStreams();

            return streams.data.ElementAt(new Random().Next(1, streams.data.Count()));
        }
    }
}
