using System;
using AutoMapper;
using EF.DAL.Model;
using projet_WebApi_1.Dtos;

namespace projet_WebApi_1.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
        }
    }
}
