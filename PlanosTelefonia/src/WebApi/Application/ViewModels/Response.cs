using System;
using System.Collections.Generic;

namespace WebApi.Application.ViewModels
{
    public class Response
    {
        public bool Success { get; set; }
        public Object Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
