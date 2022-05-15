﻿using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.VMMajor;

namespace FindJobsProject.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User and role 
            CreateMap<VMUserRegister, AppUser>();
            CreateMap<VMRole, AppRole>();

            // Major 
            CreateMap<VMMajor, Major>();
        }
    }
}
