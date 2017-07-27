using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DAL.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        /// <summary>
        /// Returns an Student by StudentId
        /// </summary>
        /// <param name="id">Id of the Student</param>
        /// <returns>An Student Object</returns>
        Student GetStudentById(int id);
    }
}
