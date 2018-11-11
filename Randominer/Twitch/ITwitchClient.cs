using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randominer.Twitch
{
    interface ITwitchClient
    {        
        Task<string> VerifyConnectionAsync();
        Task<StreamListDTO> GetStreams();

    }
}
