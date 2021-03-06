﻿using AutoMapper;
using Library.Dtos;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Library.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/books
        public IEnumerable<BookDto> GetBooks(string query = null)
        {
            var booksQuery = _context.Books
                .Include(b => b.Genre)
                .Where(b => b.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                booksQuery = booksQuery.Where(b => b.Name.Contains(query));

            return booksQuery
                .ToList()
                .Select(Mapper.Map<Book, BookDto>);
        }

        // GET /api/books/:id
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Book, BookDto>(book));
            }
        }

        // POST /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }

        // PUT /api/books/:id
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);

            if (bookInDb == null)
            {
                return NotFound();
            }
            else
            {
                Mapper.Map(bookDto, bookInDb);

                _context.SaveChanges();
            }
            return Ok();
        }

        // DELETE /api/books/:id
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);

            if (bookInDb == null)
            {
                return NotFound();
            }
            else
            {
                _context.Books.Remove(bookInDb);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}
