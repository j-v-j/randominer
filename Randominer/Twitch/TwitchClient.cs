using Microsoft.Extensions.Options;
using Randominer.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Randominer.Twitch
{
    public class TwitchClient : ITwitchClient
    {
        protected string _apiKey;
        protected HttpClient _httpClient;

        public TwitchClient(string apiKey, HttpClient httpClient = null)
        {
            _apiKey = apiKey;
            _httpClient = httpClient != null ? httpClient : new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Client-ID", _apiKey);
        }

        public async Task<string> VerifyConnectionAsync()
        {
            var request = _httpClient.GetStringAsync("https://api.twitch.tv/helix/streams?game_id=33214");

            var msg = await request;

            return msg;
        }
        
        public async Task<string> GetStreams()
        {
            var request = _httpClient.GetStringAsync("https://api.twitch.tv/helix/streams");

            var msg = await request;

            return msg;

        }
    }
}
