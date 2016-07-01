using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;

namespace CloudantAzureWebApp.Helpers
{
    public class CloudantCounterRequest
    {
        public static string GetCount(string Index, string counter)
        {
            var client = new RestClient("https://"+ ConfigurationManager.AppSettings["username"] + ".cloudant.com/sensordata");
            client.Authenticator = new HttpBasicAuthenticator(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

            var request = new RestRequest("_design/app/_search/" + Index, Method.GET);
            request.AddQueryParameter("q", "*:*");
            request.AddQueryParameter("counts", "[\""+counter+"\"]"); //
            request.AddQueryParameter("limit", "0");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);
            var jsonString = response.Content;
            dynamic dynObj = JsonConvert.DeserializeObject(jsonString);
            dynamic counts = dynObj.counts;
            dynamic errors = counts[counter];
            return JsonConvert.SerializeObject(errors);
        }

        public static string GetGeoPoints(string lon, string lat)
        {
            var client = new RestClient("https://" + ConfigurationManager.AppSettings["username"] + ".cloudant.com/sensordata");
            client.Authenticator = new HttpBasicAuthenticator(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

            var request = new RestRequest("_design/app/_search/searchAll", Method.GET);
            request.AddQueryParameter("q", "*:*");
            request.AddQueryParameter("sort", "\"<distance,lon,lat," + lon + "," + lat + ",km>\"");
            request.AddQueryParameter("limit", "5");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);
            var jsonString = response.Content;
            dynamic dynObj = JsonConvert.DeserializeObject(jsonString);
            dynamic rows = dynObj.rows;
            return JsonConvert.SerializeObject(rows);
        }

        public static string SearchMessage(string text)
        {
            var client = new RestClient("https://" + ConfigurationManager.AppSettings["username"] + ".cloudant.com/sensordata");
            client.Authenticator = new HttpBasicAuthenticator(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

            var request = new RestRequest("_design/app/_search/searchAll", Method.GET);
            request.AddQueryParameter("q", "userMessage:" + text + "*");
            request.AddQueryParameter("limit", "10");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);
            var jsonString = response.Content;
            dynamic dynObj = JsonConvert.DeserializeObject(jsonString);
            dynamic rows = dynObj.rows;
            return JsonConvert.SerializeObject(rows);
        }
    }
}