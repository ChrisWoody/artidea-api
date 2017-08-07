using System;

namespace ArtIdea.Core
{
    public class ArtIdeaProvider
    {
        private const string ArtPromptsUrl = "http://artprompts.org/";

        private static readonly string[] KnownCategories = new[]
        {
            "character",
            "creature-prompts",
            "environment-prompts",
            "object-prompt",
            "situation-prompts",
        };

        private readonly IWebClient _webClient;

        public ArtIdeaProvider()
        {
            _webClient = new ArtIdeaWebClient();
        }

        public ArtIdeaProvider(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public string GetRandomArtIdea()
        {
            var randomIndex = (new Random()).Next(0, KnownCategories.Length - 1);
            var category = KnownCategories[randomIndex];
            return GetAnArtIdea(category);
        }

        private string GetAnArtIdea(string category)
        {
            var response = _webClient.DownloadString(ArtPromptsUrl + category);

            var startIndex = response.IndexOf("prompttextdiv\">") + 15;
            var endIndex = response.IndexOf("<", startIndex);
            var idea = response.Substring(startIndex, endIndex - startIndex);

            var formattedCategory = category.Split(new[] {"-"}, StringSplitOptions.None)[0];

            return $"{formattedCategory}: {idea}";
        }
    }
}