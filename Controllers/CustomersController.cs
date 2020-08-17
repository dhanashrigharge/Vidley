using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using System.Data.Entity;
using Vidley.ViewModels;
using System.Data.Entity.Validation;

namespace Vidley.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult ViewCustomers()
        {
            
            return View();
        }

        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id==id);
            if (customer == null)
                return HttpNotFound();
            var viewmodel = new NewCustomerViewModel
            {
                Customer = customer,
                Membershiptype = _context.MembershipTypes.ToList()
            };
            return View("New", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel
                {
                    Customer = new Customer(),
                    Membershiptype = _context.MembershipTypes.ToList()
                };
                return View("New",viewmodel);
            }
            if (Customer.Id == 0)
                _context.Customers.Add(Customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id==Customer.Id);
                TryUpdateModel(customerInDb);
                customerInDb.Name = Customer.Name;
                customerInDb.BirthDate = Customer.BirthDate;
                customerInDb.MembershipTypeId = Customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = Customer.IsSubscribedToNewsLetter;
            }
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("ViewCustomers","Customers");
        }
        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var newCustomerView = new NewCustomerViewModel
            {
                Customer = new Customer(),
                Membershiptype = membershiptypes
            };
            return View(newCustomerView);
        }
       
    }
}