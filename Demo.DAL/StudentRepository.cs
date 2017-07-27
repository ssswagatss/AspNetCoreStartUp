using Demo.DAL.Interfaces;
using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DAL
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DemoContext context):base(context)
        {

        }

        public Student GetStudentById(int id)
        {
            return FirstOrDefault(x => x.StudentId == id);
        }
    }
}
