using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req)
{
    try
    {
        //log.Info("Going to find an art idea...");
        var idea = FindRandomArtIdea();
        //log.Info($"Found the idea \"{idea}\"");
        
        return req.CreateResponse(HttpStatusCode.OK, idea);
    }
    catch (Exception ex)
    {
        return req.CreateResponse(HttpStatusCode.InternalServerError, "An internal server error has occured");
    }
}

private const string ArtPromptsUrl = "http://artprompts.org/";

private static readonly string[] KnownCategories = new[]
{
    "character",
    "creature-prompts",
    "environment-prompts",
    "object-prompt",
    "situation-prompts",
};

private static string FindRandomArtIdea()
{
    var randomIndex = (new Random()).Next(0, KnownCategories.Length - 1);
    var category = KnownCategories[randomIndex];
    return GetAnArtIdea(category);
}

private static string GetAnArtIdea(string category)
{
    using (var client = new WebClient())
    {        
        var response = client.DownloadString(ArtPromptsUrl + category);

        var startIndex = response.IndexOf("prompttextdiv\">") + 15;
        var endIndex = response.IndexOf("<", startIndex);
        var idea = response.Substring(startIndex, endIndex - startIndex);

        var formattedCategory = category.Split(new[] { "-" }, StringSplitOptions.None)[0];

        return $"{formattedCategory}: {idea}";
    }
}