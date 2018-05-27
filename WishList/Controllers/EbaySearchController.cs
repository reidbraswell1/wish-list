using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace wish_list.Controllers
{
    public class EbaySearchController : Controller
    {
        // GET: EbaySearch
        public ActionResult Index()
        {
            return View();
        }

        // GET: EbaySearch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EbaySearch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EbaySearch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EbaySearch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EbaySearch/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EbaySearch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EbaySearch/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}