using MeetingManagerAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MeetingManagerAPI.Connectors
{
    public class LUISConnector
    {
        public LUISModel GetLUISResponse(string question)
        {
            //string a = s.Replace(" ", "%20");
            string URL = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/08d8c0ca-55e1-4e71-8800-9a297f90e8c8";
            string urlParameters = "?verbose=true&timezoneOffset=0&subscription-key=9143207c787247c5a65229db0d0321b9&q=" + question;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var temp = client.GetStringAsync(urlParameters).Result;            


            var res = JsonConvert.DeserializeObject<LUISModel>(temp);
            return res;
        }
    }
}
