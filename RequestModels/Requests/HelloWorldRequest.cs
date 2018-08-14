using System;
using System.ComponentModel.DataAnnotations;

namespace ApiModels.Requests
{
    public class HelloWorldRequest
    {
        [Required]
        public string Message { get; set; }
    }
}
