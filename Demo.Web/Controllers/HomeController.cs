using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.Entity;
using Demo.DAL.Interfaces;
using Demo.Services.Interfaces;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IStudentRepository _studentRepository;
        private readonly IStudentService _studentService;

        //private readonly DemoContext _context;

        public HomeController(IStudentService studentService)
        {
            // _context = context;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            //DemoContext db = new DemoContext();
            var students = _studentService.GetAll();
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
