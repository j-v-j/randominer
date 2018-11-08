using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Randominer.Twitch;
using System.Net.Http;

namespace TestRandominer.Twitch
{
    class TestTwitchApi
    {
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private TwitchClient _twitchClient;

        public TestTwitchApi()
        {
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            _twitchClient = new TwitchClient("1234",new HttpClient(_fakeHttpMessageHandler.Object));
        }

    }
}
