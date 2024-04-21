using DAL.Interfaces;
using DomainEntities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericService<Customer> _customerRepo;

        public CustomerService(IGenericService<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<CustomerDto> GetAsync(int id)
        {
            var customer = await _customerRepo.GetAsync(x => x.Id == id);

            return new CustomerDto
            {
                Address = customer.Address,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Id = customer.Id,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task AddAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Id = customerDto.Id,
                Address = customerDto.Address,
                Email = customerDto.Email,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                PhoneNumber = customerDto.PhoneNumber
            };

            await _customerRepo.AddWithSaveAsync(customer);
        }

        public async Task<CustomerDto> UpdateAsync(CustomerDto customerDto)
        {
            var customerObj = await _customerRepo.GetAsync(x => x.Id == customerDto.Id) ?? throw new Exception("Customer not found.");

            customerObj.Address = customerDto.Address;
            customerObj.Email = customerDto.Email;
            customerObj.FirstName = customerDto.FirstName;
            customerObj.LastName = customerDto.LastName;
            customerObj.PhoneNumber = customerDto.PhoneNumber;

            await _customerRepo.UpdateAsync(customerObj);
            return customerDto;
        }

        public async Task<List<CustomerDto>> ListAsync()
        {
            var customers = _customerRepo.List();

            return await (from customer in customers
                          select new CustomerDto
                          {
                              Id = customer.Id,
                              Address = customer.Address,
                              Email = customer.Email,
                              FirstName = customer.FirstName,
                              LastName = customer.LastName,
                              PhoneNumber = customer.PhoneNumber
                          }).ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _customerRepo.GetAsync(x => x.Id == id) ?? throw new Exception("Customer not found.");
            await _customerRepo.DeleteAsync(customer);
        }
    }
}