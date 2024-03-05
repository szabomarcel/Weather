using Idojaras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather;

namespace Weather
{
    internal class Program
    {
        static Weatherses ido = null;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Írja be a város nevét.");
            await ido_jaras();
            Console.WriteLine("A megjelölt város hőfokja: ");
            Console.ReadLine();
        }

        private static async Task ido_jaras()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.api-ninjas.com/v1/weather?city=debrecen");
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Hiba a lekérdezés során");
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            ido = Weatherses.FromJson(jsonString);
        }        
    }
}
