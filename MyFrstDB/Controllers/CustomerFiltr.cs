using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyFrstDB.Models;
using MyFrstDB.ModelNorthwind;
namespace MyFrstDB.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CustomerFiltr: ControllerBase
    {
        private readonly NorthwindContext _dbContext;

        public CustomerFiltr(NorthwindContext context)
        {
            _dbContext = context;
        }
        [HttpGet()]
        public IActionResult GetcustomerFilter([FromQuery] CustomerProprty filter)
        {
            IEnumerable<Customer> customers;
            var query = from custom in _dbContext.Customers
                        where
                       (string.IsNullOrEmpty(filter.Address) || custom.Address.Contains(filter.Address))
                       && (string.IsNullOrEmpty(filter.City) || custom.Address.Contains(filter.City))
                         && (string.IsNullOrEmpty(filter.CompanyName) || custom.Address.Contains(filter.CompanyName))
                        select custom;

            customers = query.ToList();
            return Ok(customers);
        }
    }
}
