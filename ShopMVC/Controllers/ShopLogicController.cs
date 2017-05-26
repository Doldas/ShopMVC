using ShopMVC.Resopitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    public class ShopLogicController : Controller
    {
        private ItemRepository repo;
        public ShopLogicController()
        {
            repo = new ItemRepository();
        }
        // GET: ShopLogic
        [HttpGet]
        public ActionResult Index(string Button="",string Search="")
        {
            Button = Button.ToLower();
            if(Button=="articlenumber")
            {
                return View(repo.GetAll(Button, true));
            }
            return View(repo.Search(Search));
        }
        // GET: ShopLogic/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetItem(id));
        }

        // GET: ShopLogic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopLogic/Create
        /*
        [HttpPost]
        public ActionResult Create(string article,string name,string description,string shelf,Models.ItemCategory category,double price ,int quantity)
        {
                repo.Add(article, name, description, shelf, category, price, quantity);
                // TODO: Add insert logic here
                return RedirectToAction("Index");
        }
        */
        [HttpPost]
        public ActionResult Create(Models.StockItem item)
        {
            repo.Add(item);
            return RedirectToAction("Index");
        }
        // GET: ShopLogic/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetItem(id));
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
    }
}
