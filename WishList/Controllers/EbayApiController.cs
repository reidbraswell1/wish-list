using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Repositories;
using MyCompany.Shared;

namespace wish_list.Controllers
{
    public class EbayApiController : Controller
    {
        private readonly EbayRepository _ebayRepo;

        public EbayApiController(EbayRepository ebayRepo)
        {
            _ebayRepo = ebayRepo;
        }
        // GET: EbayApi
        public ActionResult Index()
        {
            var tokens = _ebayRepo.GetEbayApiKeys();
            return View(tokens);
        }

        // GET: EbayApi/Details/5
        public ActionResult Details(string apiKey, DateTime updateTime)
        {
            var item = new EbayApi { ApiKey = apiKey, UpdateTime = updateTime };
            return View(item);
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
        public ActionResult Edit(string id, string apiKey, string updateTime)
        {
            //updateTime = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");
            var model = new EbayApi { ApiKey = apiKey, UpdateTime = DateTime.Now };
            return View();
        }

        // POST: EbayApi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                var provider = CultureInfo.InvariantCulture;
                var ebay = new EbayApi { ApiKey=collection["ApiKey"], UpdateTime=DateTime.ParseExact(collection["UpdateTime"],"MM/dd/yyyy HH:mm:ss",provider) };
                var result = _ebayRepo.UpdateApiKey(ebay);
                return RedirectToAction("Details",new { id=ebay.ID, apiKey=ebay.ApiKey,updateTime=ebay.UpdateTime});
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