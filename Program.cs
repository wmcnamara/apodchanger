using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Drawing;

namespace WinAPODChanger
{
    class Program
    {
        [DllImport("APODWinInteraction.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern void SetDesktopBackground(string filepath);

        static readonly HttpClient client = new HttpClient();
        
        async static Task Main(string[] args)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=bqNHUv2ah1REfaNSpeW934ewvSx4iPCkB4sm9bpX");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
                APOD apod = JsonConvert.DeserializeObject<APOD>(responseBody);

                using (var client = new WebClient())
                {
                    client.DownloadFile(apod.hdurl, "bg.jpg");
                    SetDesktopBackground(Path.GetFullPath("bg.jpg"));

                    Console.WriteLine("Setting Background!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                Console.ReadKey();
            }
        }

        public class APOD
        {
            [JsonProperty("copyright")]  public string copyright { get; set; }
            [JsonProperty("date")] public DateTime date { get; set; }
            [JsonProperty("explanation")] public string explanation { get; set; }
            [JsonProperty("hdurl")] public string hdurl { get; set; }
            [JsonProperty("media_type")] public string media_type { get; set; }
            [JsonProperty("service_version")] public string service_version { get; set; }
            [JsonProperty("title")] public string title { get; set; }
            [JsonProperty("url")] public string url { get; set; }
        }
    }
}
