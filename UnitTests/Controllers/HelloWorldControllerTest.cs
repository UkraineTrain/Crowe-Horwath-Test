using ApiModels.Requests;
using System;
using WebAPIs.Controllers;
using Xunit;

namespace UnitTests
{
    public class HelloWorldControllerTest
    {
        [Fact]
        public async void GetPassingTest()
        {
            var request = new HelloWorldRequest();
            request.Message = "Hello World";

            var controller = new HelloWorldController();

            var response = await controller.GetMessage(request);

            Assert.Equal(response.Message, request.Message);
        }
   
        [Fact]
        public async void GetFalingTest()
        {
            var request = new HelloWorldRequest();
            request.Message = "Hello World";

            var controller = new HelloWorldController();

            var response = await controller.GetMessage(request);

            Assert.NotEqual("Hi there", response.Message);
        }
    }
}
