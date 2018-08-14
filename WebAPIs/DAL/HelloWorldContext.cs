using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIs.DAL.Models;

namespace WebAPIs.DAL
{
    public class HelloWorldContext : DbContext
    {
        public HelloWorldContext(DbContextOptions<HelloWorldContext> options) : base(options)
        {
        }

        public DbSet<HelloWorld> HelloWorld { get; set; }
    }
}
