using BookStore.Models;
using DAL.Interfaces;
using DAL.Repositories;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customerList = await _customerService.ListAsync();

            var customers = (from customer in customerList
                             select new CustomerViewModel
                             {
                                 Address = customer.Address,
                                 Email = customer.Email,
                                 FirstName = customer.FirstName,
                                 LastName = customer.LastName,
                                 Id = customer.Id,
                                 PhoneNumber = customer.PhoneNumber
                             }).ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerDto customerDto = SetCustomerDto(model);
                await _customerService.AddAsync(customerDto);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
                throw new Exception("Id is not valid");

            CustomerViewModel model = new();
            CustomerDto customer = await _customerService.GetAsync(id);
            
            if (customer != null)
                model = SetCustomerViewModel(customer);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerDto customerDto = SetCustomerDto(model);

                await _customerService.UpdateAsync(customerDto);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                throw new Exception("Id is not valid");

            await _customerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            if (id < 1)
                throw new Exception("Id is not valid");

            CustomerDto customer = await _customerService.GetAsync(id);
            CustomerViewModel model = SetCustomerViewModel(customer);

            return View(model);
        }

        private CustomerDto SetCustomerDto(CustomerViewModel model)
        {
            return new CustomerDto
            {
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = model.Id,
                PhoneNumber = model.PhoneNumber
            };
        }

        private CustomerViewModel SetCustomerViewModel(CustomerDto model)
        {
            return new CustomerViewModel
            {
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = model.Id,
                PhoneNumber = model.PhoneNumber
            };
        }
    }
}