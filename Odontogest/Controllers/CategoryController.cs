using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odontogest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Odontogest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly odontogestContext _context;

        public CategoryController(odontogestContext contex)
        {
            _context = contex;
        }
        // GET: Category
        public ActionResult ListCategory()
        {
           var category = _context.Categories.ToList();
            return View(category);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult CreateCategory(int? id)
        {
            ViewBag.PageName = id == null ? "Create Categori" : "Edit Category";
            ViewBag.isEdit = id == null ? false : true;

            if(id == null)
            {
                return View();
            }
            else
            {
                var categori = _context.Categories.Find(id);

                if(categori == null)
                {
                    NotFound();
                }

                return View(categori);
            }
            
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(int id, [Bind("IdCategory,NameCategory")] Category category)
        {
            bool exist = false;

            Category categorys = _context.Categories.Find(id);

            if(categorys != null)
            {
                exist = true;
            }
            else
            {
                categorys = new Category();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    categorys.NameCategory = category.NameCategory;

                    if (exist)
                    {
                        _context.Update(categorys);
                    }
                    else
                    {
                        _context.Add(category);
                    }
                    
                    _context.SaveChanges();
                    
                }
                catch(DbUpdateConcurrencyException)
                {

                    NotFound();
                }
                return RedirectToAction(nameof(ListCategory));
            }
            return View(category);
            
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
