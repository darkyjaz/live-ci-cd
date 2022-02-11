using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleApp.Controllers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SimpleApp.Tests {
    public class UnitTest1 {
        [Fact]
        public void Test1() {
            Assert.True(1 == 1);

        }

        [Fact]
        public void Test2() {
            Assert.True(0 == 0);
        }

        [Fact]
        public async Task CustomerIntegrationTest() {
            // We first have to copy appsettings to Test project
            // Next in Test project, add ref to main project

            // It should create a dbContext
            var configuration = new ConfigurationBuilder()
                // We make sure app setting can be overwritten by env variables,
                // not just read from appsettings.json
                .AddJsonFile("appsettings.json")
                // This will make sure env var can overwrite appsettings, default for web api, but not for unit test
                .AddEnvironmentVariables()
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            
            var context = new CustomerContext(optionsBuilder.Options);

            // This drops the db, takes a bit time
            await context.Database.EnsureDeletedAsync();
            // This builds the db, takes a bit time
            await context.Database.EnsureCreatedAsync();

            // It should create controller
            var controller = new CustomerController(context);

            // IT should add customer
            await controller.Add(new Customer() { CustomerName = "Foobar" });

            // It should check GetAll returns the customer
            var result = (await controller.GetAll()).ToArray();
            Assert.Single(result);
            Assert.Equal("Foobar", result[0].CustomerName);
        }
    }
}