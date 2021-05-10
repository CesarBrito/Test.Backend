using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Backend.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
