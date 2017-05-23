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
        private ItemResopitory repo;
        public ShopLogicController()
        {
            repo = new ItemResopitory();
        }
        // GET: ShopLogic
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: ShopLogic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShopLogic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopLogic/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopLogic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopLogic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopLogic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopLogic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
