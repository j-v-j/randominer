using Randominer.Twitch;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using Randominer.Settings;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace TestRandominer
{
    public class TestTwitchClient
    {    
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private HttpClient _httpClient;

        public TestTwitchClient()
        {
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            _httpClient = new HttpClient(_fakeHttpMessageHandler.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestVerifyConnectionAsyncMustReturnStringAsync()
        {
            _fakeHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content =new StringContent("{\"success\": false,\"error-codes\": [\"It's a fake error!\",\"It's a fake error\"]}")
            });


            var apiKeys = Options.Create(new ApiKeys());
            apiKeys.Value.twitch = "1234";


            var client = new TwitchClient(apiKeys.Value.twitch, _httpClient);
            var result = await client.VerifyConnectionAsync();

            Assert.IsType<string>(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestGetRandomStreamsMustReturnStreamListDTO()
        {

            _fakeHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent
                (File.ReadAllText("streams.json"))
            });
            
            var apiKeys = Options.Create(new ApiKeys());
            apiKeys.Value.twitch = "1234";

            var client = new TwitchClient(apiKeys.Value.twitch,_httpClient);
            var result = await client.GetStreams();

            Assert.IsType<StreamListDTO>(result);
        }
    }
}
