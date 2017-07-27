using Demo.DAL.Interfaces;
using Demo.Entity;
using Demo.Services.Interfaces;
using Demo.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Services
{
    public class StudentService : EntityService<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IUnitOfWork unitOfWork, IStudentRepository repository) : 
            base(unitOfWork, repository)
        {
            UnitOfWork = unitOfWork;
            _studentRepository = repository;
        }
        public List<Student> GetStudentsByName(string name)
        {
            //Your logic goes here
            return _studentRepository.FindBy(x => x.FirstName.ToLower() == name.ToLower()).ToList();
        }

        public Student GetStudentById(int id)
        {
            //return _studentRepository.FirstOrDefault(x=>x.StudentId==id);
            return _studentRepository.GetStudentById(id);
        }

        public Result<Student> Edit(int id, string firstName, string lastname)
        {
            var res = new Result<Student>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            var student= _studentRepository.GetStudentById(id);
            if (student == null)
            {
                res.Errors.Add($"We could not find the Student with id = {id.ToString()}");
                return res;
            }
            //Other validation code goes here

            //If you come to this far, this means the request is valid. Go ahead add the Object
            student.LastName = firstName;
            student.LastName = lastname;
            Update(student);
            //Create(new Student() { FirstName = "Swagat",LastName="Swain" });
            if (UnitOfWork.Commit() > 0)
            {
                res.IsSuccess = true;
                res.Data = student;
            }
            return res;
        }
    }
}
