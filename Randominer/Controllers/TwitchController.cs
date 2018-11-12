using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Randominer.Settings;
using Randominer.Twitch;

namespace Randominer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitchController : ControllerBase
    {

        private ApiKeys _apikeys;

        public TwitchController(IOptions<ApiKeys> apikeys)
        {
            _apikeys = apikeys.Value;

        }

        [HttpGet("[action]")]
        public async Task<StreamDTO> RandomStream()
        {
            var twitchApi = new TwitchApi(_apikeys.twitch);
            return await twitchApi.GetRandomStream();
        }

    }
}