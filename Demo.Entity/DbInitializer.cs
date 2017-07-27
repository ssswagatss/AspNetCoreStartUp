using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Demo.Entity
{
    public static class DbInitializer
    {
        public static void Initialize(DemoContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstName="Carson",LastName="Alexander"},
            new Student{FirstName="Meredith",LastName="Alonso"},
            new Student{FirstName="Arturo",LastName="Anand"},
            new Student{FirstName="Gytis",LastName="Barzdukas"},
            new Student{FirstName="Nino",LastName="Olivetto"}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
        }
    }
}
