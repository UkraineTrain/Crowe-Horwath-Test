using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiModels.Requests;
using ApiModels.Responses;
using Newtonsoft.Json;

namespace Contracts.ApiCalls
{
    public class HelloWorldApiCall : IApiCalls<HelloWorldRequest, HelloWorldResponse>
    {
        private string url;
        static HttpClient client;

        public HelloWorldApiCall(string _url)
        {
            url = _url;
            client = new HttpClient();
        }

        public async Task<HelloWorldResponse> Get(HelloWorldRequest request)
        {
            var response = new HelloWorldResponse();

            //client.BaseAddress = new Uri("http://localhost:53252/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            string serilizedRequest = JsonConvert.SerializeObject(request);
            var inputMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:53252/api/HelloWorld/GetMessage");
            inputMessage.Content = new StringContent(serilizedRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await client.SendAsync(inputMessage);
            //HttpResponseMessage httpResponse = await client.GetAsync("api/HelloWorld/GetMessage/");
            if (httpResponse.IsSuccessStatusCode)
            {
                response = await httpResponse.Content.ReadAsAsync<HelloWorldResponse>();
            }

            return response;
        }

        public HelloWorldResponse Post(HelloWorldRequest request)
        {
            var response = new HelloWorldResponse();

            //put implementation code here

            return response;
        }
    }
}
