using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Services.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
