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
    public class PublisherController : Controller
    {
        private readonly BookDbContext _bookDbContext;

        public PublisherController(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
       }

        public IActionResult Index()
        {
            var listItems = _bookDbContext.Publishers.ToList();
            return View(listItems);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Publisher publisher = new Publisher();

            return View(publisher);
        }
        [HttpPost]
        public IActionResult Createold(Publisher publisher)
        {
            _bookDbContext.Publishers.Add(publisher);
            _bookDbContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Create(Publisher publisher)
        {
                _bookDbContext.Publishers.Add(publisher);
                _bookDbContext.SaveChanges();
                TempData["SuccesMesssage"] = "Publisher added succecfully";
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                Publisher publisher = _bookDbContext.Publishers.Find(id);
                return View(publisher);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(Publisher publisher)
        {
               _bookDbContext.Publishers.Update(publisher);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Publisher publisher = _bookDbContext.Publishers.Find(id);
                return View(publisher);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _bookDbContext.Publishers.Remove(publisher);
                _bookDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
    }
}
