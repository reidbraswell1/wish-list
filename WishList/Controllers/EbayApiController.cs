using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace wish_list.Controllers
{
    public class EbayApiController : Controller
    {
        // GET: EbayApi
        public ActionResult Index()
        {
            return View();
        }

        // GET: EbayApi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EbayApi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EbayApi/Create
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

        // GET: EbayApi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EbayApi/Edit/5
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

        // GET: EbayApi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EbayApi/Delete/5
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