using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ASP.Models;
using ASP.Data;

namespace ASP.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerDataAccess _dataAccess;

        public CustomersController()
        {
            _dataAccess = new CustomerDataAccess();
        }

        public IActionResult Index()
        {
            var customers = _dataAccess.GetAllCustomers();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerInfo customer)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.CreateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _dataAccess.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(CustomerInfo customer)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _dataAccess.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _dataAccess.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
