using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cloudant_IoT_Sumulated_Device_Ext
{
    class Program
    {
        static void Main(string[] args)
        {
            //read config data from a command line parameters
            var user = args[0];
            var password = args[1];
            var database = args[2];

            //base request builder for all requests containing user name and database name
            var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, password) };

            //create an http client
            using (var client = CreateHttpClient(handler, user, database))
            {               

                #region manage data from sensors

                //unfinite loop until esc key is pressed
                Console.WriteLine("Press ESC to stop");
                do
                {
                    while (!Console.KeyAvailable)
                    {

                        Sensor sensor = SensorDataGenerator.Generate();

                        var creationSensorResponse = Create(client, sensor);
                        PrintResponse(creationSensorResponse);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

                #endregion manage data from sensors
            }
        }

        #region Create
        private static HttpResponseMessage Create(HttpClient client, object doc)
        {
            var json = JsonConvert.SerializeObject(doc, Formatting.None);
            return client.PostAsync("", new StringContent(json, Encoding.UTF8, "application/json")).Result;
        }
        #endregion Create

        #region PrintResponse
        private static void PrintResponse(HttpResponseMessage response)
        {
            Console.WriteLine("Status code: {0}", response.StatusCode);
            Console.WriteLine(Convert.ToString(response));
        }
        #endregion PrintResponse


        #region CreateHttpClient
        private static HttpClient CreateHttpClient(HttpClientHandler handler, string user, string database)
        {
            return new HttpClient(handler)
            {
                BaseAddress = new Uri(string.Format("https://{0}.cloudant.com/{1}/", user, database))
            };
        }
        #endregion CreateHttpClient



    }
}
