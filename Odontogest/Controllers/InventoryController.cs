using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Odontogest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Odontogest.Controllers
{
    public class InventoryController : Controller
    {
        private readonly odontogestContext _context;
        private IWebHostEnvironment _enviroment;

        public InventoryController(odontogestContext context)
        {
            _context = context;
            //_enviroment = enviroment;
        }

        
        //public Inventory listInven { get; set; }

        //var listInve = new Inventory();

        private void drownCategori(object selecCategory = null)
        {
            var categoria = from d in _context.Categories
                            orderby d.NameCategory
                            select d;

            ViewBag.IdCategory = new SelectList(categoria.AsNoTracking(),
                nameof(Category.IdCategory),
                nameof(Category.NameCategory),
                selecCategory);
        }
        private void drownStore(object Selectstories = null)
        {
            var stories = from d in _context.Stores
                          orderby d.NameStore
                          select d;

            ViewBag.IdStore = new SelectList(stories.AsNoTracking(),
                nameof(Store.IdStore),
                nameof(Store.NameStore),
                Selectstories);
        }

        

        // GET: Inventory
        public ActionResult ListInventory()
        {
            var listInven = new Inventory();
            drownStore(listInven.FkStore);
            drownCategori(listInven.FkCategory);

            //var inventary = _context.Inventories
            //    .Include(c => c.FkCategoryNavigation)
            //    .Include(s => s.FkStoreNavigation)
            //    .AsNoTracking();

            var inventary = _context.Inventories
            .Select(item => new
            {
                Item = item,
                Category = item.FkCategoryNavigation,
                Store = item.FkStoreNavigation
            })
            .AsNoTracking()
            .ToList()
            .Select(result => result.Item);

            return View(inventary.ToList());
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        public ActionResult AddorEdit(int? id, IFormFile upload)
        {
            ViewBag.PageName = id == null ? "Add Inventory" : "Edit Inventory";
            ViewBag.isExit = id == null ? false : true;
            var listInven = new Inventory();

            if (id == null)
            {
                drownStore(listInven.FkStore);
                drownCategori(listInven.FkCategory);
                return View();
            }
            else
            {
                listInven = _context.Inventories
                    .AsNoTracking()
                    .FirstOrDefault(i => id == i.IdInventory);

                if (listInven == null)
                {
                    NotFound();
                }

                drownStore(listInven.FkStore);
                drownCategori(listInven.FkCategory);
                return View(listInven);
            }

        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddorEdit(int id, [Bind("NameInventory,FkCategory,FkStore,Price,Quantity,Description,Image")]
            Inventory inventory, IFormFile upload)
        {
            
            bool Exits = false;

            string folderpaht = @"wwwroot\Images\Inventory";
            var paht = "";
            var ft = "";


            Inventory inventories = _context.Inventories
                .AsNoTracking()
                .FirstOrDefault(i => id == i.IdInventory);
            

                drownStore(inventory.FkStore);
            drownCategori(inventory.FkCategory);

            if (!Directory.Exists(folderpaht))
            {
                Directory.CreateDirectory(folderpaht);
            }
            
            if (inventories != null)
            {
                Exits = true;
                
            }
            else
            {
                inventories = new Inventory();
            }

            if (ModelState.IsValid)
            {

                if (upload == null)
                {
                    //var ft = _context.Inventories.SingleOrDefault(i => i.IdInventory == inventories.IdInventory).Image;

                    if (inventories.Image == null)
                    {
                        ft = "avatar.PNG";
                    }
                    else
                    {
                        ft = inventories.Image;
                    }

                    

                    paht = @"wwwroot\Images\Inventory\"+ft;
                    

                    using (var str = new FileStream(paht, FileMode.Open, FileAccess.Read))
                    {
                        upload = new FormFile(str, 0, str.Length, ft, ft);

                        inventories.NameInventory = inventory.NameInventory;
                        inventories.FkCategory = inventory.FkCategory;
                        inventories.FkStore = inventory.FkStore;
                        inventories.Price = inventory.Price;
                        inventories.Quantity = inventory.Quantity;
                        inventories.QuantityAvailable = inventory.QuantityAvailable;
                        inventories.Description = inventory.Description;

                        inventories.Image = upload.FileName;

                    }

                    if (Exits)
                    {
                        inventories.DateUpdate = DateTime.Now;
                        _context.Update(inventories);
                    }
                    else
                    {
                        inventories.CreationDate = DateTime.Now;
                        _context.Add(inventories);
                    }

                    _context.SaveChanges();
                    return RedirectToAction(nameof(ListInventory));
                }
                else
                {
                    paht = @"wwwroot\Images\Inventory\"+inventories.Image;
                    var file = Path.Combine(folderpaht, upload.FileName);

                    try
                    {
                        
                        using (var stream = new FileStream(file, FileMode.Create))
                        {
                            upload.CopyTo(stream);

                            inventories.NameInventory = inventory.NameInventory;
                            inventories.FkCategory = inventory.FkCategory;
                            inventories.FkStore = inventory.FkStore;
                            inventories.Price = inventory.Price;
                            inventories.Quantity = inventory.Quantity;
                            inventories.QuantityAvailable = inventory.QuantityAvailable;
                            inventories.Description = inventory.Description;
                            inventories.Image = upload.FileName;

                            ViewBag.image = inventories.Image;

                        }


                        if (Exits)
                        {
                            inventories.DateUpdate = DateTime.Now;
                            _context.Update(inventories);
                        }
                        else
                        {
                            inventories.CreationDate = DateTime.Now;
                            _context.Add(inventories);
                        }

                        _context.SaveChanges();

                    }
                    catch (DbUpdateException)
                    {
                        return View();
                    }

                    return RedirectToAction(nameof(ListInventory));
                }
                
            }

            drownStore(inventory.FkStore);
            drownCategori(inventory.FkCategory);
            return View(inventories);
        }

       
    
                    

        // GET: Inventory/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if(id == null)
        //    {
        //        return NotFound();
        //    }

        //    var inventoris = _context.Inventories
        //            .AsNoTracking()
        //            .FirstOrDefault(i => id == i.IdInventory);

        //    if (inventoris == null)
        //    {
        //        return NotFound();
        //    }
                        
        //    return View(inventoris);
        //}

        // POST: Inventory/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            var inventor = _context.Inventories.Find(id);

            try
            {
                _context.Inventories.Remove(inventor);
                _context.SaveChanges();
                ViewBag.Message = "Se Elimino correctamente";
                return RedirectToAction(nameof(ListInventory));
            }
            catch
            {
                return View();
            }
        }
               
    }
}


//inventories.NameInventory = inventory.NameInventory;
//inventories.FkCategory = inventory.FkCategory;
//inventories.FkStore = inventory.FkStore;
//inventories.Price = inventory.Price;
//inventories.Quantity = inventory.Quantity;
//inventories.QuantityAvailable = inventory.QuantityAvailable;
//inventories.Description = inventory.Description;
//inventories.Image = inventory.Image;

//if (await TryUpdateModelAsync<Inventory>(inventories, "",
//               i => i.NameInventory,
//               i => i.FkCategory,
//               i => i.FkStore,
//               i => i.Price,
//               i => i.Quantity,
//               i => i.Description,
//               i => i.Image))
//{
//    try
//    {
//        if (Exits)
//        {
//            _context.Update(inventories);
//        }
//        else
//        {
//            _context.Add(inventories);
//        }

//        _context.SaveChanges();

//    }
//    catch (DbUpdateException)
//    {
//        return View();
//    }

//    return RedirectToAction(nameof(ListInventory));
//}

//drownStore(inventories.FkStore);
//drownCategori(inventories.FkCategory);
//return View(inventories);