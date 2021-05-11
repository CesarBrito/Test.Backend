using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Backend.Domain.Models.ViewModel
{
    public class UpdateCustomer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
