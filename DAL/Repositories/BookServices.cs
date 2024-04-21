using DAL.Interfaces;
using DomainEntities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BookServices : IBookServices
    {
        private readonly IGenericService<Book> _bookRepo;

        public BookServices(IGenericService<Book> bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task AddAsync(BookDto bookDto)
        {
            var book = new Book
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                ISBN = bookDto.ISBN,
                Price = bookDto.Price,
                PublicationYear = bookDto.PublicationYear,
                Publisher = bookDto.Publisher,
                Quantity = bookDto.Quantity
            };

            await _bookRepo.AddWithSaveAsync(book);
        }

        public async Task<BookDto> UpdateAsync(BookDto bookDto)
        {
            var bookObj = await _bookRepo.GetAsync(x => x.Id == bookDto.Id) ?? throw new Exception("Book not found.");

            bookObj.Title = bookDto.Title;
            bookObj.Author = bookDto.Author;
            bookObj.Genre = bookDto.Genre;
            bookObj.ISBN = bookDto.ISBN;
            bookObj.Price = bookDto.Price;
            bookObj.PublicationYear = bookDto.PublicationYear;
            bookObj.Publisher = bookDto.Publisher;
            bookObj.Quantity = bookDto.Quantity;

            await _bookRepo.UpdateAsync(bookObj);
            return bookDto;
        }

        public async Task<List<BookDto>> ListAsync()
        {
            var books = _bookRepo.List();

            return await (from book in books
                           select new BookDto
                           {
                               Id = book.Id,
                               Author = book.Author,
                               Genre = book.Genre,
                               ISBN = book.ISBN,
                               Price = book.Price,
                               PublicationYear = book.PublicationYear,
                               Publisher = book.Publisher,
                               Quantity = book.Quantity,
                               Title = book.Title
                           }).ToListAsync();
        }

        public async Task<BookDto> GetAsync(int id)
        {
            var book = await _bookRepo.GetAsync(x => x.Id == id);

            return new BookDto
            {
                Author = book.Author,
                Id = book.Id,
                Genre = book.Genre,
                ISBN= book.ISBN,
                Price= book.Price,
                PublicationYear= book.PublicationYear,
                Publisher= book.Publisher,
                Quantity= book.Quantity,
                Title = book.Title
            };
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepo.GetAsync(x => x.Id == id) ?? throw new Exception("Book not found.");

            await _bookRepo.DeleteAsync(book);
        }
    }
}