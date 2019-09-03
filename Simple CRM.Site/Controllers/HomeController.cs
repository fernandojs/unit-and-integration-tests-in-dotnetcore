using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple_CRM.Site.Models;
using Simple_CRM.Infra.Data.Repositories.Interfaces;
using Simple_CRM.Infra.Data.Repositories;

namespace Simple_CRM.Site.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IBusinessRepository _businessRepository;
        public HomeController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public IActionResult Index()
        {
            var first = _businessRepository.GetAll().FirstOrDefault();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
