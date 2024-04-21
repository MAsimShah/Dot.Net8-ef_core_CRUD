using DTO;

namespace DAL.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetAsync(int id);

        Task AddAsync(CustomerDto customerDto);

        Task<CustomerDto> UpdateAsync(CustomerDto customerDto);

        Task<List<CustomerDto>> ListAsync();

        Task DeleteAsync(int id);
    }
}