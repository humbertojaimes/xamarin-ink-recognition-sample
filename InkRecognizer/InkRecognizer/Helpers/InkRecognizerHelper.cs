using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InkRecognizer.Model;
using Newtonsoft.Json;

namespace InkRecognizer.Helpers
{
    public class InkRecognizerHelper
    {

        static HttpClient httpClient;

        private static void initClient()
        {

            if (httpClient is null)
            {
                httpClient = new HttpClient() { BaseAddress = new Uri(Constants.InkRecognizerConstants.API_ADDRESS) };
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constants.InkRecognizerConstants.API_KEY);
            }
        }

        public static async Task<InkRecognizerResponse> Recognize(InkRecognizerRequest request)
        {
            initClient();
            InkRecognizerResponse inkRecognizerResponse = null;
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(Constants.InkRecognizerConstants.API_RECOGNIZE_METHOD, httpContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    inkRecognizerResponse =
                        JsonConvert.DeserializeObject<InkRecognizerResponse>(await httpResponse.Content.ReadAsStringAsync());

                }

                return inkRecognizerResponse;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
