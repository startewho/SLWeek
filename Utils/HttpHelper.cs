using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace SLWeek.Utils
{
   public class HttpHelper
    {
        public static void CreateHttpClient(ref HttpClient httpClient)
        {
            if (httpClient != null)
            {
                httpClient.Dispose();
            }
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new HttpProductInfoHeaderValue("ie", AppStrings.UerAgent));
        }

        public static async Task<string> GetTextByPost(string posturi, string poststr, List<KeyValuePair<string, string>> body)
        {
            HttpClient httpClient = new HttpClient();
            CreateHttpClient(ref httpClient);
            var postData = new HttpFormUrlEncodedContent(body);
            var response = await httpClient.PostAsync(new Uri(posturi), postData);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public static async Task<string> GetTextByGet(string posturi)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(new Uri(posturi));

            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

    }
        
}
