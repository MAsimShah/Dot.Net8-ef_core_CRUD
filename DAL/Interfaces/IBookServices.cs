using DTO;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBookServices
    {
        Task AddAsync(BookDto bookDto);

        Task<BookDto> UpdateAsync(BookDto bookDto);

        Task<List<BookDto>> ListAsync();

        Task<BookDto> GetAsync(int id);

        Task DeleteAsync(int id);
    }
}