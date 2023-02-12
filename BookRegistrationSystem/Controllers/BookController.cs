using BookRegistrationSystem.Data;
using BookRegistrationSystem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookRegistrationSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _bookDbContext;

        public BookController(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IActionResult Index()
        {
            var listItems = _bookDbContext.Books.Include(c=> c.Category).Include(c => c.Author).Include(c => c.Publisher).ToList();
            return View(listItems);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Category = new SelectList(_bookDbContext.BookCategorys.ToList(), "Id", "Name");
            ViewBag.Author = new SelectList(_bookDbContext.Authors.ToList(), "Id", "Name");
            ViewBag.Pulisher = new SelectList(_bookDbContext.Publishers.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Createold(Book book)
        {
           

            return View(book);
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
                _bookDbContext.Books.Add(book);
                _bookDbContext.SaveChanges();
                TempData["SuccesMesssage"] = "Book added succecfully";
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                ViewBag.Publisher = new SelectList(_bookDbContext.Publishers.ToList(), "Id", "Name");
                ViewBag.BookCategory = new SelectList(_bookDbContext.BookCategorys.ToList(), "Id", "Name");
                ViewBag.Author = new SelectList(_bookDbContext.Authors.ToList(), "Id", "Name");
                var book = _bookDbContext.Books.Find(id);
                return View(book);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(Book book)
        {
                _bookDbContext.Books.Update(book);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Book book = _bookDbContext.Books.Find(id);
                return View(book);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookDbContext.Books.Remove(book);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
