using ShopMVC.Resopitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    public class WarehouseController : Controller
    {
        //Private Variable
        private ItemRepository repo;
        //Constructor
        public WarehouseController()
        {
            repo = new ItemRepository();
        }

        // GET: ShopLogic/Index/
        [HttpGet]
        public ActionResult Index(string Sort,string Search="")
        {
            if(Sort!=null)
            {
                return View(repo.GetAll(Sort,false,Search)); 
            }
            return View(repo.Search(Search));
        }
        // GET: ShopLogic/Details/5
        public ActionResult Details(int id)
        {
            if (repo.GetItem(id) as Models.StockItem != null)
            {
                return View(repo.GetItem(id));
            }
            return RedirectToAction("Index", "Warehouse");
        }

        // GET: ShopLogic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopLogic/Create
        [HttpPost]
        public ActionResult Create(Models.StockItem item)
        {
            repo.Add(item);
            return RedirectToAction("Index");
        }
        // GET: ShopLogic/Edit/5
        public ActionResult Edit(int id)
        {
            if (repo.GetItem(id) as Models.StockItem != null)
            {
                return View(repo.GetItem(id));
            }
            return RedirectToAction("Index");
        }
        // POST: ShopLogic/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.StockItem item)
        {
                repo.Edit(item);
                return RedirectToAction("Index");
        }

        // GET: ShopLogic/Delete/5
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
        // A Secret View
        public ActionResult Secret()
        {
            return View();
        }
        //Contact
        public ActionResult Contact()
        {
            return View();
        }
        //About
        public ActionResult About()
        {
            return View();
        }
    }
}
