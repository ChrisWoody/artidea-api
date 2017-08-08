using System;
using ArtIdea.Core;
using NSubstitute;
using Xunit;

namespace ArtIdea.Tests
{
    public class ArtIdeaTests
    {
        private readonly IWebClient _webClient;
        private readonly ArtIdeaProvider _artIdeaProvider;

        private const string ValidHtml = @"<prompttextdiv\>a unit test running in space<";

        public ArtIdeaTests()
        {
            _webClient = Substitute.For<IWebClient>();
            _artIdeaProvider = new ArtIdeaProvider(_webClient);
        }

        [Fact]
        public void CallsWebClient()
        {
            _webClient.DownloadString(Arg.Any<string>()).Returns(ValidHtml);

            var result = _artIdeaProvider.GetRandomArtIdea();

            _webClient.Received(1).DownloadString(Arg.Any<string>());
        }
    }
}