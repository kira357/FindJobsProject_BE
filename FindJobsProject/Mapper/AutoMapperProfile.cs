using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMMajor;
using FindJobsProject.ViewModels.VMUser;

namespace FindJobsProject.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User and role 
            CreateMap<VMUserRegister, AppUser>();
            CreateMap<VMRole, AppRole>();
            CreateMap<VMUpdateRole, AppRole>();
            CreateMap<VMDeleteRole, AppRole>();
            CreateMap<VMUserRole, AppUserRole>();

            //User 
            CreateMap<VMCreateUser, AppUser>();
            CreateMap<VMUserUpdate, AppUser>();
            CreateMap<VMUserDelete, AppUser>();
            CreateMap<VMGetUser, AppUser>();

            // Major 
            CreateMap<VMMajor, Major>();

            //job 
            CreateMap<VMJob, Job>();

            //RecruitmentJob
            CreateMap<VMRecruitmentJob, RecruitmentJob>();
        

            //Candidate Job 
             CreateMap<VMGetCandidateJob, CandidateJob>();
             CreateMap<VMCandidateJob, CandidateJob>();
             CreateMap<VMUpdateCandidateJob, CandidateJob>();
             CreateMap<VMDeleteCandidateJob, CandidateJob>();
        }
    }
}
