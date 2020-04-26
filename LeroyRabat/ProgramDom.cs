using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeroyRabat
{
    public class ProgramDom
    {
        private readonly HttpWebRequest request;
        public ProgramDom(string cookie, string token, long cardNumber)
        {
            request = (HttpWebRequest)WebRequest.Create("https://www.leroymerlin.pl/klient/check-loyalty-program-card.html");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add(HttpRequestHeader.Cookie, cookie);
            request.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            request.Headers["X-XSRF-TOKEN"] = token;

            Console.WriteLine($"cardNumber: { cardNumber }");

            var postData = "loyaltyProgramCardNumber=" + Uri.EscapeDataString(cardNumber.ToString());
            var data = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }

        public Card GetResponse()
        {
            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                Console.WriteLine($"response.StatusCode: {response.StatusCode}");

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return JsonConvert.DeserializeObject<Card>(responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:");
                Console.WriteLine(ex);
                return null;
            }
            
        }
    }
}
