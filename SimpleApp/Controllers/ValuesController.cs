﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {

        private CustomerContext context;

        public CustomerController(CustomerContext context) {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll() 
            => await context.Customers.ToArrayAsync();

        [HttpPost]
        public async Task<Customer> Add([FromBody] Customer c) {
            context.Customers.Add(c);
            await context.SaveChangesAsync();
            return c;
        }


    }
}
