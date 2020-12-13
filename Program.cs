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
        //Import the C++ function to set the windows background from the DLL
        [DllImport("APODWinInteraction.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern void SetDesktopBackground(string filepath);

        static readonly HttpClient client = new HttpClient();

        async static Task Main(string[] args)
        {
            try
            {
                //Download the json containing the APOD.
                HttpResponseMessage response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=bqNHUv2ah1REfaNSpeW934ewvSx4iPCkB4sm9bpX");
                response.EnsureSuccessStatusCode();

                //Deserialize the JSON
                string responseBody = await response.Content.ReadAsStringAsync();
                APOD apod = JsonConvert.DeserializeObject<APOD>(responseBody);

                Console.WriteLine("Astronomy Picture Of The Day | Program Created by Weston McNamara\n");

                //Ouput the title, date, and an image explanation
                Console.WriteLine(apod.title);
                Console.WriteLine(apod.date + "\n\n");
                Console.WriteLine(apod.explanation + "\n\n");

                //After displaying that, download the background, and set the desktop background with the new image.
                using (var client = new WebClient())
                {
                    Console.WriteLine("Downloading Background...");
                    client.DownloadFile(apod.hdurl, "bg.jpg");
                    SetDesktopBackground(Path.GetFullPath("bg.jpg"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                Console.WriteLine("If you're seeing this, its quite likely that the APOD today is not a format that can be set to a desktop background, such as a video.");
                Console.ReadKey();
            }

            Console.WriteLine("Press Any Key To Close");
            Console.ReadKey();
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
