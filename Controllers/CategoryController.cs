using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BulkybooksWeb.Data;
using BulkybooksWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BulkybooksWeb.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(categoryObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryObj);
        }


        [HttpGet("Edit")]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _db.Categories.Find(Id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);

        }
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(categoryObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryObj);
        }
   
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _db.Categories.Find(id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }






    }
}