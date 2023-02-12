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
    public class AuthorController : Controller
    {
        private readonly BookDbContext _bookDbContext;

        public AuthorController(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
           
        }
        public IActionResult Index()
        {
           var listItems = _bookDbContext.Authors.ToList();
            return View(listItems);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Author author = new Author();

            return View(author);
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _bookDbContext.Authors.Add(author);
            _bookDbContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                Author author = _bookDbContext.Authors.Find(id);
                return View(author);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(Author author)
        {
                _bookDbContext.Authors.Update(author);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Author author = _bookDbContext.Authors.Find(id);
                return View(author);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(Author author)
        {
            if (ModelState.IsValid)
            {
                _bookDbContext.Authors.Remove(author);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }
    }
}
