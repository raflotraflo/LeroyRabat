using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeroyRabat
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        //private static string cookie = "VARNISHTTPSID=A1; XSRF-TOKEN=dd4f6d3e-514b-4157-8ecf-451d00fe71de; _snrs_uuid=a768e222-3f1b-44ae-8028-68191563b49c; _snrs_puuid=a768e222-3f1b-44ae-8028-68191563b49c; ftchatuid=b0ibk206dz824clkpmnyo6; ftchatwcbu=0; ftchatset=1586270180786; ftfirsttime=false; ftchatbrowserid=p7scqy3c9no9uilqa5edr; ftVisitedPages=1; fromGeolocation=false; shopIsSet=true; ftVisitCount=7; userShop=28; ftchatsid=t0xuhdurncd6iceq5uao9; lastViewed=%5B432487%2C452016%2C384505%2C181291%5D; SITE_PREFERENCE=NORMAL; JSESSIONID=510AB90F972636E16CBBAD342B346DEE.ap05; userIdHash=%7B%22id%22%3A%22%2B6y2SnsZ%2BjNjcv%2FYhSMuDaWCVZUXlmZkvsIxXgdYtzo%3D%22%2C%22type%22%3A%22login%22%7D; searchHistory=c50%26%2332%3Bmig%3Afalse%7Cc-50%26%2332%3B%C5%9Bmig%3Afalse%7Cblat%3Afalse%7Cceresit%26%2332%3Bct17%3Afalse; _snrs_sa=ssuid:e8523e6c-4634-44f1-bfc9-f926a8291571&appear:1587910063&sessionVisits:7; _snrs_sb=ssuid:e8523e6c-4634-44f1-bfc9-f926a8291571&leaves:1587910185; _snrs_p=host:www.leroymerlin.pl&permUuid:a768e222-3f1b-44ae-8028-68191563b49c&uuid:a768e222-3f1b-44ae-8028-68191563b49c&emailHash:&user_hash:&init:1582548472&last:1587910063.501&current:1587910185&uniqueVisits:15&allVisits:396";
        //private static string token = "dd4f6d3e-514b-4157-8ecf-451d00fe71de";
        private static string cookie = "VARNISHTTPSID=A1; SITE_PREFERENCE=NORMAL; XSRF-TOKEN=c74dad78-c309-483b-9cdc-596259601a99; _snrs_uuid=9e539e22-cb44-4ce7-9dfc-d7fb7901c85a; _snrs_puuid=9e539e22-cb44-4ce7-9dfc-d7fb7901c85a; __utma=97569408.1991491405.1587939526.1587939526.1587939526.1; __utmz=97569408.1587939526.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); __utmc=97569408; __utmt=1; _gcl_au=1.1.186551176.1587939527; _ga=GA1.2.1991491405.1587939526; _gid=GA1.2.1280241540.1587939527; tangiblee:widget:user=22f88e0d-5ca5-4046-b363-d38631ace068; _hjid=40b6996b-f004-4dea-a1f4-8848541261de; _ga_tng=GA1.3.22f88e0d-5ca5-4046-b363-d38631ace068; _ga_tng_gid=GA1.3.1898147031.1587939529; _CXIDLOC=59c9eef839dd86ffe922a127054cc4d6; _CXIDLOCSES=59c9eef839dd86ffe922a127054cc4d6; JSESSIONID=2DC1C7C2755AE1C62A74A6EEB4C56A52.ap05; userIdHash=%7B%22id%22%3A%22OuZV6tdG3ww6DASTTHy6U%2BPFYJT2ZRBCRTCz%2F15w6OY%3D%22%2C%22type%22%3A%22login%22%7D; lastViewed=%5B450723%5D; ftchatsid=p02t5qlz0jxotgfok6kbc; ftchatuid=v990wsnkgzlex8hkblazja; ftchatwcbu=0; fromGeolocation=false; userShop=22; shopIsSet=true; _snrs_sb=ssuid:4d203a08-7bc7-42fe-a5d7-1438bdf9427b&leaves:1587939842; _snrs_sa=ssuid:4d203a08-7bc7-42fe-a5d7-1438bdf9427b&appear:1587939525&sessionVisits:22; _snrs_p=host:www.leroymerlin.pl&permUuid:9e539e22-cb44-4ce7-9dfc-d7fb7901c85a&uuid:9e539e22-cb44-4ce7-9dfc-d7fb7901c85a&emailHash:2061135569&user_hash:&init:1587939525&last:1587939525&current:1587939842&uniqueVisits:1&allVisits:10; __utmb=97569408.14.9.1587939828454; __wph_s=813297069.1587939842381; __wph_a=6789663839.1587939842387; ins-storage-version=9";
        private static string token = "c74dad78-c309-483b-9cdc-596259601a99";
        private static long cardNumber = 2046040808587;
        private static List<Card> cards = new List<Card>();
        private static List<Award> awards = new List<Award>();

        static void Main()
        {
            Console.WriteLine("start");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    ProgramDom program = new ProgramDom(cookie, token, cardNumber + i);
                    var card = program.GetResponse();

                    if (card != null && !string.IsNullOrWhiteSpace(card.cardStatus))
                    {
                        cards.Add(card);

                        awards.AddRange(card.awards);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            sw.Stop();

            Console.WriteLine("Elapsed={0}", sw.Elapsed);


            Console.WriteLine("end");
            Console.ReadLine();
        }

        //private void copy()
        //{

        //    var request = (HttpWebRequest)WebRequest.Create("https://www.leroymerlin.pl/klient/check-loyalty-program-card.html");


        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        //    request.Headers.Add(HttpRequestHeader.Cookie, cookie);
        //    request.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
        //    request.Headers["X-XSRF-TOKEN"] = "dd4f6d3e-514b-4157-8ecf-451d00fe71de";


        //    var postData = "loyaltyProgramCardNumber=" + Uri.EscapeDataString("2046040808587");
        //    var data = Encoding.ASCII.GetBytes(postData);
        //    request.ContentLength = data.Length;
        //    using (var stream = request.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }

        //    var response = (HttpWebResponse)request.GetResponse();

        //    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

        //    var loyaltyProgramInfo = JsonConvert.DeserializeObject<LoyaltyProgram>(responseString);

        //    Console.WriteLine($"response.StatusCode {response.StatusCode}");
        //    Console.WriteLine($"responseString {responseString}");
        //}
    }
}
