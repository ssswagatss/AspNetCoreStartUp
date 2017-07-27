using AutoMapper;
using Demo.Entity;
using Demo.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentVM>()
                .ForMember(cv => cv.StudentId, m => m.MapFrom(s => s.StudentId))
                .ForMember(cv => cv.FirstName, m => m.MapFrom(s => s.FirstName))
                .ForMember(cv => cv.LastName, m => m.MapFrom(s => s.LastName));


            CreateMap<StudentVM, Student>()
                .ForMember(cv => cv.StudentId, m => m.MapFrom(s => s.StudentId))
                .ForMember(cv => cv.FirstName, m => m.MapFrom(s => s.FirstName))
                .ForMember(cv => cv.LastName, m => m.MapFrom(s => s.LastName));
        }
    }
}
