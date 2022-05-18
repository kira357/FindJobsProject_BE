using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMMajor;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityJob : IReposityJob
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ReposityJob(IMapper mapper,
                            UserManager<AppUser> userManager,
                            RoleManager<AppRole> roleManager,
                            SignInManager<AppUser> signInManager,
                            FindJobsContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<Respone> CreateJob(VMJob vMJob)
        {
            try
            {
                var id = Guid.NewGuid();
                vMJob = new VMJob
                {
                    IdRecruitment = vMJob.IdRecruitment,
                    IdJob = id,
                    JobImage = vMJob.JobImage,
                    Name = vMJob.Name,
                    CompanyOfJobs = vMJob.CompanyOfJobs,
                    Position = vMJob.Position,
                    MajorId = vMJob.MajorId,
                    Amount = vMJob.Amount,
                    Experience = vMJob.Experience,
                    WorkTime = vMJob.WorkTime,
                    SalaryMin = vMJob.SalaryMin,
                    SalaryMax = vMJob.SalaryMax,
                    Address = vMJob.Address,
                    DateExpire = vMJob.DateExpire,
                    JobDetail = vMJob.JobDetail,
                    CreatedOn = DateTimeOffset.UtcNow,     
                };

                var jobsMaps = _mapper.Map<Job>(vMJob);

                VMRecruitmentJob vMRecruitmentJob = new VMRecruitmentJob
                {
                    IdJob = vMJob.IdJob,
                    IdRecruitment = vMJob.IdRecruitment,
                    IsActive = false,
                };
                var recruitmentJob = _mapper.Map<RecruitmentJob>(vMRecruitmentJob);
                await _context.Jobs.AddAsync(jobsMaps);
                await _context.recruitmentJob.AddAsync(recruitmentJob);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
                return new Respone { Ok = "Success" };
      
            return new Respone { Fail = "Fails" };
    }


        public async Task<IEnumerable> GetListJob(int pageIndex, int pageSize)
        {
            var getList = _context.Jobs.AsQueryable();
            var data = getList.Join(_context.recruitmentJob,
                                    job => job.IdJob,
                                    recruitment => recruitment.IdJob,
                                    (job, recruitment) => new { job, recruitment })
                               .Join(_context.AppUsers,
                                    user => user.recruitment.IdRecruitment,
                                    job => job.Id,
                                    (user, job) =>
                                    new VMJob
                                    {
                                        IdJob = user.recruitment.IdJob,
                                        IdRecruitment = user.recruitment.IdRecruitment,
                                        CompanyOfJobs = user.job.CompanyOfJobs,
                                        Position = user.job.Position,
                                        Name = user.job.Name,
                                        JobImage = user.job.JobImage,
                                        JobDetail = user.job.JobDetail,
                                        Amount = user.job.Amount,
                                        Experience = user.job.Experience,
                                        SalaryMin = user.job.SalaryMin,
                                        SalaryMax = user.job.SalaryMax,
                                        WorkTime = user.job.WorkTime,
                                        Address = user.job.Address,
                                        DateExpire = user.job.DateExpire,
                                        IsActive = user.recruitment.IsActive,
                                        CreatedOn = user.job.CreatedOn,
                                        UpdatedOn = user.job.UpdatedOn,
                                    });

            var result = PaginatedList<VMJob>.CreatePages(data, pageIndex, pageSize);
            var count = data.Count();
            return result;

        }

        public async Task<Respone> UpdateJob(VMUpdateJob vMUpdateJob)
        {
            try
            {
                var checkId = await _context.Jobs.SingleOrDefaultAsync(x => x.IdJob == vMUpdateJob.IdJob);
                var checkIdRecruitment = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdJob == vMUpdateJob.IdJob);
                if (checkId != null && checkIdRecruitment != null)
                {
                    checkId.Name = vMUpdateJob.Name;
                    checkIdRecruitment.IsActive = vMUpdateJob.IsActive;
                    checkIdRecruitment.UpdatedOn = DateTimeOffset.UtcNow;    

                    await _context.SaveChangesAsync();
                }
                return new Respone
                {
                    Ok = "Success"
                };

            }
            catch (Exception ex )
            {

                throw ex.InnerException;
            }
            
        }

        public async Task<Respone> DeteleJob(VMDeleteJob vMDeleteJob)
        {
            //var checkId = await _context.Jobs.SingleOrDefaultAsync(x => x.IdJob == vMDeteleJob.IdJob);
            //if (checkId != null)
            //{
            //    _context.Jobs.Remove(checkId);
            //    await _context.SaveChangesAsync();
            //}
            //return new Respone
            //{
            //    Ok = "Success"
            //};
            return null;
        }
    }
}
