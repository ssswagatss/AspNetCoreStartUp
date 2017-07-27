using Demo.Entity;
using Demo.Services.Models;
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

        /// <summary>
        /// Returns an Student by StudentId
        /// </summary>
        /// <param name="id">Id of the Student</param>
        /// <returns>An Student Object</returns>
        Student GetStudentById(int id);

        /// <summary>
        /// Edits a Student
        /// </summary>
        /// <param name="id">Id of the Student</param>
        /// <param name="firstName">First Name of the Student</param>
        /// <param name="lastname">Last Name of the Student</param>
        /// <returns></returns>
        Result<Student> Edit(int id, string firstName, string lastname);
    }
}
