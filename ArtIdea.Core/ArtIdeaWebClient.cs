using System.Net;

namespace ArtIdea.Core
{
    public class ArtIdeaWebClient : IWebClient
    {
        public string DownloadString(string address)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(address);
            }
        }
    }
}