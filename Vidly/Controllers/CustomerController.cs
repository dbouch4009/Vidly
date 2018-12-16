using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        [Route("CustomersList")]
        public ActionResult CustomersList()
        {
            List<Customer> customerList = new List<Customer>();
            customerList.Add(new Customer { Id = 0, Name = "John Gray" });
            customerList.Add(new Customer { Id = 1, Name = "John Bronw" });
            customerList.Add(new Customer { Id = 2, Name = "John Brown" });
            customerList.Add(new Customer { Id = 3, Name = "Mary Grace" });
            customerList.Add(new Customer { Id = 4, Name = "Kyle McCormick" });

            CustomerListViewModel custListVM = new CustomerListViewModel();

            custListVM.CustomerList = new List<Customer>();
            custListVM.CustomerList = customerList;

            return View(custListVM);
        }

        [Route("Customers/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            List<Customer> customerList = new List<Customer>();
            customerList.Add(new Customer { Id = 0, Name = "John Gray" });
            customerList.Add(new Customer { Id = 1, Name = "John Bronw" });
            customerList.Add(new Customer { Id = 2, Name = "John Brown" });
            customerList.Add(new Customer { Id = 3, Name = "Mary Grace" });
            customerList.Add(new Customer { Id = 4, Name = "Kyle McCormick" });

            var custDetails = customerList.Where(c => (c.Id == id));

            var custViewModel = new CustomerViewModel();

            for(int i = 0; i < customerList.Count; i++)
            {
                if(customerList[i].Id == id)
                {
                    custViewModel.id = customerList[i].Id;
                    custViewModel.name = customerList[i].Name;
                }
            }

            custViewModel.id = id;
            //custViewModel.name = customerList.Where(c => (c.Id == id));
            
            return View(custViewModel);
        }

        // GET: Customer
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}