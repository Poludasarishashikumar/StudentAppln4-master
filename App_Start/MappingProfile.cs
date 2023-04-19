using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StudentAppln4.Models;
using StudentAppln4.Dtos;

namespace StudentAppln4.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Student1, StudentDto>();
            Mapper.CreateMap<StudentDto, Student1>();
            Mapper.CreateMap<Login, LoginDto>();
            Mapper.CreateMap<LoginDto, Login>();
        }
    }
}