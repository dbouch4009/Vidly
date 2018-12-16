using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer GetCustomerById(int id)
        {
            var cust = new Customer();

            return null;
        }
    }
}