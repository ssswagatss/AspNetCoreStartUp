using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Entity;
using Demo.Services.Interfaces;
using AutoMapper;
using Demo.Web.ViewModels;

namespace Demo.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DemoContext _context;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(DemoContext context,IStudentService studentService, IMapper mapper)
        {
            _context = context;
            _studentService = studentService;
            _mapper = mapper;
        }

        // GET: Students
        public  IActionResult Index()
        {
            return View( _mapper.Map<List<StudentVM>>(_studentService.GetAll().ToList()));
        }

        // GET: Students/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _mapper.Map<StudentVM>(_studentService.GetStudentById(id.Value));
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName")] StudentVM student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _mapper.Map<StudentVM>(_studentService.GetStudentById(id.Value));
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("StudentId,FirstName,LastName")] StudentVM student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var res = _studentService.Edit(id, student.FirstName, student.LastName);

                if (res.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(student);
                }
                
            }
            return View(student);
        }
    }
}
