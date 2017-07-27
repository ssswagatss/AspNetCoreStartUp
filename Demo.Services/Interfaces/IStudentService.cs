using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Services.Interfaces
{
    public interface IStudentService : IEntityService<Student>
    {
        /// <summary>
        /// Returns an Students by Name
        /// </summary>
        /// <param name="name">name of the Student</param>
        /// <returns>List Student Object</returns>
        List<Student> GetStudentsByName(string name);
    }
}
