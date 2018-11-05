using Randominer.TwitchClient;
using System;
using Xunit;

namespace TestRandominer
{
    public class TestTwitchClient
    {
        [Fact]
        public async System.Threading.Tasks.Task TestVerifyConnectionAsyncMustReturnStringAsync()
        {
            var client = new TwitchClient();
            var result = await client.VerifyConnectionAsync();
            Assert.IsType<string>(result);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
