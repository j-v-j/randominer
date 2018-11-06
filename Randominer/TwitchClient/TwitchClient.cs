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
        protected string _apiKey;
        protected HttpClient _httpClient;

        public TwitchClient(IOptions<ApiKeys> keys, HttpClient httpClient = null)
        {
            _apiKey = keys.Value.twitch;
            _httpClient = httpClient != null ? httpClient : new HttpClient();
        }

        public async Task<string> VerifyConnectionAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("Client-ID", _apiKey);
            var request = _httpClient.GetStringAsync("https://api.twitch.tv/helix/streams?game_id=33214");

            var msg = await request;

            return msg;
        }

        public string GetRandomStreamUri()
        {
            throw new NotImplementedException();
        }

    }
}
