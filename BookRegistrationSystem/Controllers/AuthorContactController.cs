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
    public class AuthorContactController : Controller
    {
        private readonly BookDbContext _bookDbContext;
        public AuthorContactController(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IActionResult Index()
        {
           var listItems = _bookDbContext.AuthorContacts.ToList();
            return View(listItems);
        }
        [HttpPost]
        public IActionResult Create(AuthorContact authorContact)
        {
                _bookDbContext.AuthorContacts.Add(authorContact);
                _bookDbContext.SaveChanges();
                TempData["SuccesMesssage"] = "AuthorContact added succecfully";
                return RedirectToAction("Index");
         
        }
        [HttpGet]
        public IActionResult Create()
        {
         
            return View();
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                var authorContact = _bookDbContext.AuthorContacts.Find(id);
                return View(authorContact);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(AuthorContact authorContact)
        {
                _bookDbContext.AuthorContacts.Update(authorContact);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                 var authorContact = _bookDbContext.AuthorContacts.Find(id);
                return View(authorContact);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(AuthorContact authorContact)
        {
            if (ModelState.IsValid)
            {
                _bookDbContext.AuthorContacts.Remove(authorContact);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorContact);
        }
    }
}
