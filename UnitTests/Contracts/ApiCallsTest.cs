using ApiModels.Requests;
using Contracts.ApiCalls;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Contracts
{
    public class ApiCallsTest
    {
        [Fact]
        public async void GetPassingTest()
        {
            var request = new HelloWorldRequest();

            request.Message = "Hello World!";

            var helloWorldApiCall = new HelloWorldApiCall("http://localhost:53252/api/HelloWorld/GetMessage");

            var response = await helloWorldApiCall.Get(request);

            Assert.Equal(response.Message, request.Message);
        }
    }
}
