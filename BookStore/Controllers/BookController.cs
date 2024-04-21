using BookStore.Models;
using DAL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookServices _bookService;
        public BookController(IBookServices bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var booksList = await _bookService.ListAsync();

            var books = (from book in booksList
                         select new BookViewModel
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
                         }).ToList();

            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bookDto = SetBookDto(model);

                await _bookService.AddAsync(bookDto);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
                throw new Exception("Id is not valid");

            BookViewModel model = new();
            BookDto book = await _bookService.GetAsync(id);
           
            if (book != null)
                model = SetBookViewModel(book);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bookDto = SetBookDto(model);

                await _bookService.UpdateAsync(bookDto);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id < 1)
                throw new Exception("Id is not valid");

            await _bookService.DeleteAsync(Id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            if (id < 1)
                throw new Exception("Id is not valid");

            var book = await _bookService.GetAsync(id);
            BookViewModel model = SetBookViewModel(book);

            return View(model);
        }

        private BookDto SetBookDto(BookViewModel model)
        {
            return new BookDto
            {
                Title = model.Title,
                Quantity = model.Quantity,
                Publisher = model.Publisher,
                PublicationYear = model.PublicationYear,
                Price = model.Price,
                ISBN = model.ISBN,
                Genre = model.Genre,
                Author = model.Author,
                Id = model.Id
            };
        }

        private BookViewModel SetBookViewModel(BookDto model)
        {
            return new BookViewModel
            {
                Title = model.Title,
                Quantity = model.Quantity,
                Publisher = model.Publisher,
                PublicationYear = model.PublicationYear,
                Price = model.Price,
                ISBN = model.ISBN,
                Genre = model.Genre,
                Author = model.Author,
                Id = model.Id
            };
        }
    }
}