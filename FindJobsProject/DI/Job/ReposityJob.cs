using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Helper;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMMajor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReposityJob(IMapper mapper,
                            UserManager<AppUser> userManager,
                            RoleManager<AppRole> roleManager,
                            SignInManager<AppUser> signInManager,
                            FindJobsContext context ,
                             IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Respone> CreateJob( VMJob vMJob)
        {
            MediaFile mediaFile = new MediaFile();
            var image = await mediaFile.SaveFile(vMJob.imageFile, _webHostEnvironment);
            try
            {
                var id = Guid.NewGuid();
                vMJob = new VMJob
                {
                    IdRecruitment = vMJob.IdRecruitment,
                    IdJob = id,
                    JobImage = image,
                    Name = vMJob.Name,
                    CompanyOfJobs = vMJob.CompanyOfJobs,
                    Position = vMJob.Position,
                    idMajor = vMJob.idMajor,
                    Amount = vMJob.Amount,
                    Experience = vMJob.Experience,
                    WorkTime = vMJob.WorkTime,
                    SalaryMin = vMJob.SalaryMin,
                    SalaryMax = vMJob.SalaryMax,
                    Address = vMJob.Address,
                    DateExpire = vMJob.DateExpire,
                    JobDetail = vMJob.JobDetail,
                    CreatedOn = DateTimeOffset.UtcNow.Date,     
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


        public async Task<PagedResponse<IEnumerable<VMGetJob>>> GetListJob(PaginationFilter filter, HttpRequest request)
        {
            var getList = _context.Jobs.AsQueryable();
            var data = getList.Join(_context.recruitmentJob,
                                    job => job.IdJob,
                                    recruitment => recruitment.IdJob,
                                    (job, recruitment) => new { job, recruitment })
                               .Join(_context.AppUsers,
                                    user => user.recruitment.IdRecruitment,
                                    job => job.Id,
                                    (user, job) => new { user , job})
                               .Join(_context.Majors,
                                    userrole => userrole.user.job.IdMajor,
                                    major => major.IdMajor,
                                    (userrole , major) => new VMGetJob
                                    {
                                        IdJob = userrole.user.recruitment.IdJob,
                                        IdRecruitment = userrole.user.recruitment.IdRecruitment,
                                        RecruitmentName = userrole.job.FullName,
                                        CompanyOfJobs = userrole.user.job.CompanyOfJobs,
                                        Position = userrole.user.job.Position,
                                        Name = userrole.user.job.Name,
                                        JobImage = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, userrole.user.job.JobImage),
                                        JobDetail = userrole.user.job.JobDetail,
                                        Amount = userrole.user.job.Amount,
                                        Experience = userrole.user.job.Experience,
                                        SalaryMin = userrole.user.job.SalaryMin,
                                        SalaryMax = userrole.user.job.SalaryMax,
                                        WorkTime = userrole.user.job.WorkTime,
                                        idMajor = userrole.user.job.IdMajor,
                                        NameMajor = major.Name,
                                        Address = userrole.user.job.Address,
                                        DateExpire = userrole.user.job.DateExpire,
                                        IsActive = userrole.user.recruitment.IsActive,
                                        CreatedOn = userrole.user.job.CreatedOn,
                                        UpdatedOn = userrole.user.job.UpdatedOn,
                                    }
                                   );
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetJob>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            return new PagedResponse<IEnumerable<VMGetJob>>(result, validFilter.IndexPage, validFilter.PageSize, count);

        }
        public async Task<PagedResponse<IEnumerable<VMGetJob>>> GetListJobActive(PaginationFilter filter, HttpRequest request)
        {
            var getList = _context.Jobs.AsQueryable();
            var data = getList.Join(_context.recruitmentJob,
                                    job => job.IdJob,
                                    recruitment => recruitment.IdJob,
                                    (job, recruitment) => new { job, recruitment })
                               .Join(_context.AppUsers,
                                    user => user.recruitment.IdRecruitment,
                                    job => job.Id,
                                    (user, job) => new { user , job})
                               .Join(_context.Majors,
                                    userrole => userrole.user.job.IdMajor,
                                    major => major.IdMajor,
                                    (userrole , major) => new VMGetJob
                                    {
                                        IdJob = userrole.user.recruitment.IdJob,
                                        IdRecruitment = userrole.user.recruitment.IdRecruitment,
                                        RecruitmentName = userrole.job.FullName,
                                        CompanyOfJobs = userrole.user.job.CompanyOfJobs,
                                        Position = userrole.user.job.Position,
                                        Name = userrole.user.job.Name,
                                        JobImage = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, userrole.user.job.JobImage),
                                        JobDetail = userrole.user.job.JobDetail,
                                        Amount = userrole.user.job.Amount,
                                        Experience = userrole.user.job.Experience,
                                        SalaryMin = userrole.user.job.SalaryMin,
                                        SalaryMax = userrole.user.job.SalaryMax,
                                        WorkTime = userrole.user.job.WorkTime,
                                        idMajor = userrole.user.job.IdMajor,
                                        NameMajor = major.Name,
                                        Address = userrole.user.job.Address,
                                        DateExpire = userrole.user.job.DateExpire,
                                        IsActive = userrole.user.recruitment.IsActive,
                                        CreatedOn = userrole.user.job.CreatedOn,
                                        UpdatedOn = userrole.user.job.UpdatedOn,
                                    }
                                   ).Where(x => x.IsActive == true);
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetJob>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            return new PagedResponse<IEnumerable<VMGetJob>>(result, validFilter.IndexPage, validFilter.PageSize, count);

        }


        public async Task<PagedResponse<IEnumerable<VMGetJob>>> GetItemJob(PaginationFilter filter, HttpRequest request, Guid Id)
        {
            var getList = _context.Jobs.AsQueryable();
            var data = getList.Join(_context.recruitmentJob,
                                    job => job.IdJob,
                                    recruitment => recruitment.IdJob,
                                    (job, recruitment) => new { job, recruitment })
                               .Join(_context.AppUsers,
                                    user => user.recruitment.IdRecruitment,
                                    job => job.Id,
                                    (user, job) => new { user, job })
                               .Join(_context.Majors,
                                    userrole => userrole.user.job.IdMajor,
                                    major => major.IdMajor,
                                    (userrole, major) => new VMGetJob
                                    {
                                        IdJob = userrole.user.recruitment.IdJob,
                                        IdRecruitment = userrole.user.recruitment.IdRecruitment,
                                        RecruitmentName = userrole.job.FullName,
                                        CompanyOfJobs = userrole.user.job.CompanyOfJobs,
                                        Position = userrole.user.job.Position,
                                        Name = userrole.user.job.Name,
                                        JobImage = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, userrole.user.job.JobImage),
                                        JobDetail = userrole.user.job.JobDetail,
                                        Amount = userrole.user.job.Amount,
                                        Experience = userrole.user.job.Experience,
                                        SalaryMin = userrole.user.job.SalaryMin,
                                        SalaryMax = userrole.user.job.SalaryMax,
                                        WorkTime = userrole.user.job.WorkTime,
                                        idMajor = userrole.user.job.IdMajor,
                                        NameMajor = major.Name,
                                        Address = userrole.user.job.Address,
                                        DateExpire = userrole.user.job.DateExpire,
                                        IsActive = userrole.user.recruitment.IsActive,
                                        CreatedOn = userrole.user.job.CreatedOn,
                                        UpdatedOn = userrole.user.job.UpdatedOn,
                                    }
                                   ).Where(x => x.IdJob == Id);
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetJob>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var idRecruitment = result.Select(x => x.IdRecruitment).Distinct();
                if (idRecruitment.Any())
                {
                    var recruitmentData = _context.AppUsers.AsQueryable()
                      .Where(x => idRecruitment.Contains(x.Id)).Select(x => new { x.Id, x.UrlAvatar }).ToList();
                    result.ForEach(x => x.ImageUser = recruitmentData.FirstOrDefault(v => v.Id == x.IdRecruitment)?.UrlAvatar);
                }
            }
            return new PagedResponse<IEnumerable<VMGetJob>>(result, validFilter.IndexPage, validFilter.PageSize, count);

        }
            public async Task<Respone> UpdateJob(VMUpdateJob vMUpdateJob)
        {
            try
            {
                var checkIdJob = await _context.Jobs.SingleOrDefaultAsync(x => x.IdJob == vMUpdateJob.IdJob);
                var checkIdRecruitmentJob = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdJob == vMUpdateJob.IdJob);

                if (checkIdJob != null && checkIdRecruitmentJob != null)
                {
                    if (vMUpdateJob.imageFile != null)
                    {
                        MediaFile mediaFile = new MediaFile();
                        var image = await mediaFile.SaveFile(vMUpdateJob.imageFile, _webHostEnvironment);
                        checkIdJob.Name = vMUpdateJob.Name;
                        checkIdJob.CompanyOfJobs = vMUpdateJob.CompanyOfJobs;
                        checkIdJob.Position = vMUpdateJob.Position;
                        checkIdJob.JobImage = image;
                        checkIdJob.JobDetail = vMUpdateJob.JobDetail;
                        checkIdJob.Amount = vMUpdateJob.Amount;
                        checkIdJob.Experience = vMUpdateJob.Experience;
                        checkIdJob.SalaryMin = vMUpdateJob.SalaryMin;
                        checkIdJob.SalaryMax = vMUpdateJob.SalaryMax;
                        checkIdJob.WorkTime = vMUpdateJob.WorkTime;
                        checkIdJob.Address = vMUpdateJob.Address;
                        checkIdJob.DateExpire = vMUpdateJob.DateExpire;
                        checkIdJob.IdMajor = vMUpdateJob.IdMajor;
                        checkIdJob.UpdatedOn = DateTimeOffset.UtcNow.Date;
                    }
                    else
                    {
                        checkIdJob.Name = vMUpdateJob.Name;
                        checkIdJob.CompanyOfJobs = vMUpdateJob.CompanyOfJobs;
                        checkIdJob.Position = vMUpdateJob.Position;
                        checkIdJob.JobDetail = vMUpdateJob.JobDetail;
                        checkIdJob.Amount = vMUpdateJob.Amount;
                        checkIdJob.Experience = vMUpdateJob.Experience;
                        checkIdJob.SalaryMin = vMUpdateJob.SalaryMin;
                        checkIdJob.SalaryMax = vMUpdateJob.SalaryMax;
                        checkIdJob.WorkTime = vMUpdateJob.WorkTime;
                        checkIdJob.Address = vMUpdateJob.Address;
                        checkIdJob.DateExpire = vMUpdateJob.DateExpire;
                        checkIdJob.IdMajor = vMUpdateJob.IdMajor;
                        checkIdJob.UpdatedOn = DateTimeOffset.UtcNow.Date;
                    }
                    checkIdRecruitmentJob.IsActive = vMUpdateJob.IsActive;
                    checkIdRecruitmentJob.UpdatedOn = DateTimeOffset.UtcNow.Date;
                    await _context.SaveChangesAsync();
                    return new Respone
                    {
                        Ok = "Success"
                    };
                }
                return new Respone
                {
                    Ok = "Fail"
                };
            }
            catch (Exception ex )
            {

                throw ex.InnerException;
            }
            
        }

        public async Task<Respone> DeleteJob(VMDeleteJob vMDeleteJob)
        {
            try
            {
                var checkId = await _context.Jobs.SingleOrDefaultAsync(x => x.IdJob == vMDeleteJob.IdJob);
                var checkIdRecruitmentJob = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdJob == vMDeleteJob.IdJob);
                if (checkId != null)
                {
                    _context.recruitmentJob.Remove(checkIdRecruitmentJob);
                    _context.Jobs.Remove(checkId);
                    await _context.SaveChangesAsync();
                }
                return new Respone
                {
                    Ok = "Success"
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
      
        }
    }
}
