using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.Entity;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DemoContext _context;

        public HomeController(DemoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //DemoContext db = new DemoContext();

            var students = _context.Students.ToList();
            return Ok(students);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
