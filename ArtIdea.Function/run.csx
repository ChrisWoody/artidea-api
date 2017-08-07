#r "ApiIdea.Core.dll" // note for future, might require to be in a bin folder, https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-csharp#referencing-custom-assemblies

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    try
    {
        log.Info("Going to find an art idea...");
        var provider = new ArtIdeaProvider();
        log.Info($"Found \"{idea}\"");
        
        return req.CreateResponse(HttpStatusCode.OK, idea);
    }
    catch (Exception ex)
    {
        return req.CreateResponse(HttpStatusCode.InternalServerError, "An internal server error has occured");
    }
}