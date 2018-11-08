using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Randominer.Twitch;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Xunit.Abstractions;

namespace TestRandominer.Twitch
{
    public class TestTwitchApi
    {
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private TwitchClient _twitchClient;
        private ITestOutputHelper _outputter;

        public TestTwitchApi(ITestOutputHelper output)
        {
            _outputter = output;
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            _twitchClient = new TwitchClient("1234",new HttpClient(_fakeHttpMessageHandler.Object));
        }
        
        [Fact]
        public async System.Threading.Tasks.Task TestGetRandomStreamMustHaveOneStream()
        {
            _fakeHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent
                (File.ReadAllText("streams.json"))
            });

            var api = new TwitchApi("1234", _twitchClient);

            var result = await api.GetRandomStream();
            
            _outputter.WriteLine($"Stream title: {result.title}" );
            _outputter.WriteLine($"Stream username: {result.user_name}");

            Assert.IsType<StreamDTO>(result);

        }
    }
}
