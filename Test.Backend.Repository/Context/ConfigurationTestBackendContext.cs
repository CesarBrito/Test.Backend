using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test.Backend.Repository.Context
{
    public class ConfigurationTestBackendContext : IDesignTimeDbContextFactory<TestBackendContext>
    {
        public TestBackendContext CreateDbContext(string[] args)
        {
            var directory = Directory.GetCurrentDirectory().Replace("Repository", "WebApi");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<TestBackendContext>();

            var connection = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connection);

            return new TestBackendContext(builder.Options);

        }
    }
}
