using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Gene_App.Request
{

    class ApiRequests
    {
        
        static readonly HttpClient client = new HttpClient();

        private static string ToJson(object obj)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, serializerSettings);
        }

        
        
        public static async Task<Token> RequestToken(string url)           
        {
            var login = new Login("GabrielScotton",  "VivaLItalia");


            

            string loginJson = ToJson(login);

            StringContent postBody = new StringContent(loginJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, postBody);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var token = JsonConvert.DeserializeObject<Token>(responseBody);

            

            return token;





        }
        public static async Task<JobRequest> RequestJob(string url, Token token)
        {

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            

            

            var jobRequest = JsonConvert.DeserializeObject<JobRequest>(responseBody);

            return jobRequest;





        }
        public static async Task<JobRequest> PostJob(JobCompletedRequest jobCompletedRequest, Token token, string url)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

            string jobCompletedJson = ToJson(jobCompletedRequest);

            StringContent postBody = new StringContent(jobCompletedJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, postBody);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var jobRequest = JsonConvert.DeserializeObject<JobRequest>(responseBody);

            return jobRequest;

        }
    }
}
