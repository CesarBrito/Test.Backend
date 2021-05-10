using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Backend.Domain.Models;

namespace Test.Backend.Repository.Context
{
    public class TestBackendContext : DbContext
    {
        public TestBackendContext(DbContextOptions<TestBackendContext> options) : base(options) {}
        public DbSet<Customer> Customers { get; set; }
    }
}
