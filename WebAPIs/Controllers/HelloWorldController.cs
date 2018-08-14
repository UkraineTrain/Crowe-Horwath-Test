using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModels.Requests;
using ApiModels.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIs.DAL;
using WebAPIs.DAL.Models;
using WebAPIs.Mappers;

namespace WebAPIs.Controllers
{
    [Produces("application/json")]
    [Route("api/HelloWorld")]
    public class HelloWorldController : Controller
    {
        private HelloWorldContext _context = new HelloWorldContext(new DbContextOptions<HelloWorldContext>());

        //public HelloWorldController(HelloWorldContext context)
        //{
        //    _context = context;
        //}

        // GET: api/HelloWorld
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value3", "value4" };
        }

        // GET: api/HelloWorld/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet]
        [Route("GetMessage")]
        public async Task<HelloWorldResponse> GetMessage([FromBody] HelloWorldRequest request)
        {
            var response = new HelloWorldResponse();

            if (!ModelState.IsValid)
            {
                response.Message = "Invalid request";

                return response;
            }

            //implement logic here to get the message from the database once the database becomes available
            //similar to the below
            //var helloWorld = await _context.HelloWorld
            //                    .AsNoTracking()
            //                    .Where(x => x.Message == request.Message)
            //                    .FirstOrDefaultAsync();

            //since the database is not available at this time to return the data into the HelloWorld model, 
            //I'm assigning it the value of HelloWorldRequest
            var helloWorld = new HelloWorld();
            helloWorld.Message = request.Message;

            response = HelloWorldMapper.MapFromEntity(helloWorld);

            return response;
        }
        
        // POST: api/HelloWorld
        [HttpPost]
        public async Task<HelloWorldResponse> Post(HelloWorldRequest request)
        {
            var response = new HelloWorldResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var entityToStore = HelloWorldMapper.MapToEntity(request);

                    _context.HelloWorld.Add(entityToStore);

                    //uncomment this once the database is actually set up
                    await _context.SaveChangesAsync();

                    response.Message = "Message successfully saved to the database";
                }
            }
            catch (DbUpdateException ex)
            {
                response.Message = string.Format("There was an error when updating database: {0}", ex.InnerException);
            }

            return response;
        }

        // PUT: api/HelloWorld/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
