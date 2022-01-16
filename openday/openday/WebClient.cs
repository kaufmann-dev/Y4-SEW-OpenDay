using System.Threading;

namespace openday
{
    public class WebClient
    {
        public string DownloadHTML(string url)
        {
            Thread.Sleep(500);
            return $"{url}: data";
        }
    }
}