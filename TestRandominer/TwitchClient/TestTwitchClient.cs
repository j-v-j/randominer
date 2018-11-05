using Randominer.TwitchClient;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using Randominer.Settings;

namespace TestRandominer
{
    public class TestTwitchClient
    {      


        [Fact]
        public async System.Threading.Tasks.Task TestVerifyConnectionAsyncMustReturnStringAsync()
        {
            var apiKeys = Options.Create(new ApiKeys());
            apiKeys.Value.twitch = "1234";
            var client = new TwitchClient(apiKeys);
            var result = await client.VerifyConnectionAsync();
            Assert.IsType<string>(result);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
