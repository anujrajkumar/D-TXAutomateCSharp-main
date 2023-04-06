using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.APIFrameworkUtilities
{
    public class ResponseUtil
    {
        static RestResponse? response = null;

        static string? responseContent = null;

        public static string ResponseGetAsync(RestClient restclient, RestRequest restRequest)
        {
            response = restclient.GetAsync(restRequest).Result;
            responseContent = JsonConvert.DeserializeObject(response.Content).ToString();
            return responseContent;
        }

        public static string ResponsePostAsync(RestClient restclient, RestRequest restRequest)
        {
            try
            {
                response = restclient.PostAsync(restRequest).Result;
                responseContent = JsonConvert.DeserializeObject(response.Content).ToString();
            }
            catch(Exception e)
            {
                _ = e.StackTrace;
            }
            return responseContent;
        }
    }
}
