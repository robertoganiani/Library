using Library.Models;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            var books = GetBooks();

            return View(books);
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book { Id = 1, Name = "Pride and Prejudice " },
                new Book { Id = 2, Name = "The Book Thief" }
            };
        }

        // GET: Books/Random
        public ActionResult Random()
        {
            var book = new Book() { Name = "The Hunger Games" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomBookViewModel
            {
                Book = book,
                Customers = customers
            };

            return View(viewModel); 
        }
    }
}