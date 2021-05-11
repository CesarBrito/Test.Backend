using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Backend.Domain.Models.ViewModel
{
    public class RequestResult
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public RequestResult()
        {
            Errors = new List<string>();
        }
    }
}
