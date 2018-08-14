using ApiModels.Requests;
using ApiModels.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var request = new HelloWorldRequest();

            request.Message = "Hello World!";

            var response = new HelloWorldResponse();

            Task.Run(async() =>
                response = await GetHelloWorldMessage(request)
            ).Wait();
            
            Console.WriteLine(response.Message);

            System.Threading.Thread.Sleep(10000);
        }

        static async Task<HelloWorldResponse> GetHelloWorldMessage(HelloWorldRequest request)
        {
            var response = new HelloWorldResponse();

            client.BaseAddress = new Uri("http://localhost:53252/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

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
    }
}
