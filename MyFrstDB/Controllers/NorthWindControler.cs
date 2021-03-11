using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyFrstDB.ModelNorthwind;
namespace MyFrstDB.Controllers
{
    [ApiController]
    [Route("controller")]
    public class NorthWindControler : ControllerBase
    {
        
        [HttpGet("Orders")]
        public IActionResult GetOrders()
        {
            IEnumerable<Order> orders;

            using (var dbContext = new NorthwindContext())
            {

                orders = dbContext.Orders.ToList().Take(10);
            }

            return Ok(orders);
        }
        [HttpGet("Customer")]
        public IActionResult GetCustomer()
        {
            IEnumerable<Customer> customers;
            
            using (var dbContext = new NorthwindContext())
            {

                customers = dbContext.Customers.ToList().Take(10);
            }

            return Ok(customers);
        }
        //[HttpGet("CustomerFiltr")]
        //public IActionResult GetcustomerFilter([FromQuery] CustomerProprty filter)
        //{
        //    IEnumerable<Customer> customers;
        //    var query = from custom in _dbContext.Customers
        //                where 
        //               (string.IsNullOrEmpty(filter.Address) || custom.Address.Contains(filter.Address))
        //               && (string.IsNullOrEmpty(filter.City) || custom.Address.Contains(filter.City))
        //                 && (string.IsNullOrEmpty(filter.CompanyName) || custom.Address.Contains(filter.CompanyName))
        //                select custom;

        //    customers = query.ToList();
        //    return Ok(customers);
        //}

    }
}
