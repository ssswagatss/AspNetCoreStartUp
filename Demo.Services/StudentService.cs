using Demo.DAL.Interfaces;
using Demo.Entity;
using Demo.Services.Interfaces;
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
    }
}
