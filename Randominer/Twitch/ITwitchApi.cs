using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randominer.Twitch
{
    interface ITwitchApi
    {
        Task<StreamDTO> GetRandomStream();
    }
}
