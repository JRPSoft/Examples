using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTest.GostosuraViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreTest.Controllers
{
    public class GostosurasController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            var model = new IndexViewModel
            {
                Nome = "Hot Niga Of APIs",
                Id = 1
            };
            return View(model);
        }
    }
}
