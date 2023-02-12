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
    public class BookCategoryController : Controller
    {
        private readonly BookDbContext _bookDbContext;
 
        public BookCategoryController(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IActionResult Index()
        {
            var listItems = _bookDbContext.BookCategorys.ToList();
            return View(listItems);
        }
        [HttpGet]
        public IActionResult Create()
        {
            BookCategory bookCategory = new BookCategory();

            return View(bookCategory);
        }
        [HttpPost]
        public IActionResult Create(BookCategory bookCategory)
        {
            _bookDbContext.BookCategorys.Add(bookCategory);
            _bookDbContext.SaveChanges();
            TempData["SuccesMesssage"] = "BookCategory added succecfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id != null)
            {
               BookCategory bookCategory = _bookDbContext.BookCategorys.Find(id);
                return View(bookCategory);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(BookCategory bookCategory)
        {
            _bookDbContext.BookCategorys.Update(bookCategory);
            _bookDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                BookCategory bookCategory = _bookDbContext.BookCategorys.Find(id);
                return View(bookCategory);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _bookDbContext.BookCategorys.Remove(bookCategory);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookCategory);
        }
    }
}
