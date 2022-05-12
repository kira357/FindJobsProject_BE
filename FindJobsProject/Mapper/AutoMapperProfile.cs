using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using FindJobsProject.ViewModels;

namespace FindJobsProject.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VMUserRegister, AppUser>();
            CreateMap<VMRole, AppRole>();
        }
    }
}
