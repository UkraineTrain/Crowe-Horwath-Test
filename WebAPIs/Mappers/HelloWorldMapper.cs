using ApiModels.Requests;
using ApiModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIs.DAL.Models;

namespace WebAPIs.Mappers
{
    public static class HelloWorldMapper
    {
        public static HelloWorld MapToEntity(HelloWorldRequest request)
        {
            var helloWorld = new HelloWorld();
            helloWorld.Message = request.Message;

            return helloWorld;
        }

        public static HelloWorldResponse MapFromEntity(HelloWorld helloWorld)
        {
            var response = new HelloWorldResponse();

            response.Message = helloWorld.Message;

            return response;
        }
    }
}
