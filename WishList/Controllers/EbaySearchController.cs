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
    public class EbaySearchController : Controller
    {
        private readonly EbaySearchRepository _ebaySearchRepo;

        public EbaySearchController(EbaySearchRepository ebaySearchRepo)
        {
            _ebaySearchRepo = ebaySearchRepo;
        }
        // GET: EbayApi
        public ActionResult Index()
        {
            var items = _ebaySearchRepo.GetSearchItemResults("Tube Tester");
            return View(items);
        }
    }
}