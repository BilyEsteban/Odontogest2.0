using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Odontogest.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Odontogest.Controllers
{
    
    public class StoreController : Controller
    {
        private readonly odontogestContext _context;
        public StoreController(odontogestContext context) 
        {
            _context = context;
            //_environment = environment;
        }

        
        // GET: Store
        public ActionResult ListStores(string search)
        {
            //var stores = _context.Stores
            //     .Include(c=> c.Inventories)
            //     .AsNoTracking()
            //     .ToList();

            var stores = from s in _context.Stores
                         select s;


            if (!string.IsNullOrEmpty(search))
            {
                stores = stores.Where(s => s.NameStore.Contains(search));
            }

            return View(stores);
        }

  
              // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            var detail = _context.Stores.FirstOrDefault(d => d.IdStore == id);

            return View(detail);
        }
// GET: Store/CreateStore
        public ActionResult CreateStore(int? idstore)
        {
            ViewBag.PageName = idstore == null ? "Create New Store" : "Edit Store";
            ViewBag.isEdit = idstore == null ? false : true;

            if(idstore == null)
            {
                return View();
            }
            else
            {
                var storelist = _context.Stores.Find(idstore);

                if(storelist == null)
                {
                    NotFound();
                }

                return PartialView("_EditOrCreate",storelist);
            }
        }

        // POST: Store/CreateStore
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStore(int idstore,[Bind("IdStore,NameStore,Location,QuantityArticles,NewArticles,State")] 
                Store stores )
        {
            bool ExitStore = false;

            Store store1 = _context.Stores.Find(idstore);

            if(store1 != null)
            {
                ExitStore = true;
            }
            else
            {
                store1 = new Store();
            }
             

            if (ModelState.IsValid)
            {
                try
                {
                    store1.NameStore = stores.NameStore;
                    store1.Location = stores.Location;
                    store1.QuantityArticles = stores.QuantityArticles;
                    store1.NewArticles = stores.NewArticles;

                    if (ExitStore)
                    {
                        _context.Update(store1);
                    }
                    else
                    {
                        _context.Add(store1);
                    }
                    
                    _context.SaveChanges();

                }
                catch (DbUpdateException)
                {

                    return View();
                }

                return RedirectToAction(nameof(ListStores));

            }

            return View(stores);
        }


        //GET: Store/Delete/5
        public ActionResult Delete(int? id)
        {
            var storea =  _context.Stores
                .Include(e=>e.Inventories)
                .Single(i=>i.IdStore == id);

            var inve = _context.Inventories
                .Where(i => i.FkStore == id)
                .ToList();
            inve.ForEach(i => i.FkStore = null);

            _context.Stores.Remove(storea);
            //storea.Inventories.Clear();
            _context.SaveChanges();

            return RedirectToAction(nameof(ListStores));
           
        }

        // POST: Store/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {

            return View();
            
        }
    }

    
}
