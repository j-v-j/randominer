using Microsoft.Extensions.Options;
using Randominer.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Randominer.TwitchClient
{
    public class TwitchClient : ITwitchClient
    {
        protected ApiKeys apiKeys;
        protected HttpClient twitchHttpClient;

        public TwitchClient(IOptions<ApiKeys> keys)
        {
            this.apiKeys = keys.Value;
        }

        public async Task<string> VerifyConnectionAsync()
        {
            twitchHttpClient = new HttpClient();

            twitchHttpClient.DefaultRequestHeaders.Add("Client-ID", apiKeys.twitch);
            var request = twitchHttpClient.GetStringAsync("https://api.twitch.tv/helix/streams?game_id=33214");

            var msg = await request;

            return msg;
        }

        public string GetRandomStreamUri()
        {
            throw new NotImplementedException();
        }

    }
}
