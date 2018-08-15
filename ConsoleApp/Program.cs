using ApiModels.Requests;
using ApiModels.Responses;
using Contracts.ApiCalls;
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
            var helloWorldApiCall = new HelloWorldApiCall("http://localhost:53252/api/HelloWorld/GetMessage");

            Task.Run(async() =>
                response = await helloWorldApiCall.Get(request)
            ).Wait();
            
            Console.WriteLine(response.Message);

            System.Threading.Thread.Sleep(10000);
        }
    }
}
