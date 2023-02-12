using BookRegistrationSystem.Data;
using BookRegistrationSystem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookRegistrationSystem.Controllers
{
    public class BookAuthorsController : Controller
    {
        private readonly BookDbContext _bookDbContext;

        public BookAuthorsController(BookDbContext bookDbContext)
        {  
            _bookDbContext = bookDbContext;
        }

        public IActionResult Index()
        {
            var listItems = _bookDbContext.BookAuthorss.ToList();
            return View(listItems);
        }
        [HttpGet]
        public IActionResult Create()
        {
            BookAuthors bookAuthors = new BookAuthors();

            return View(bookAuthors);
        }
        [HttpPost]
        public IActionResult Create(BookAuthors bookAuthors)
        {
                _bookDbContext.BookAuthorss.Add(bookAuthors);
                _bookDbContext.SaveChanges();
                TempData["SuccesMesssage"] = "BookAuthors added succecfully";
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                BookAuthors bookAuthors = _bookDbContext.BookAuthorss.Find(id);
                return View(bookAuthors);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(BookAuthors bookAuthors)
        {
                _bookDbContext.BookAuthorss.Update(bookAuthors);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                BookAuthors bookAuthors = _bookDbContext.BookAuthorss.Find(id);
                return View(bookAuthors);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(BookAuthors bookAuthors)
        {
            if (ModelState.IsValid)
            {
                _bookDbContext.BookAuthorss.Remove(bookAuthors);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookAuthors);
        }
    }
}
