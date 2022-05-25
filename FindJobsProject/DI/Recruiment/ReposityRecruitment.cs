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
    public class ReposityRecruitment : IReposityRecruitment
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReposityRecruitment(IMapper mapper,
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

     


        public async Task<PagedResponse<IEnumerable<VMGetJob>>> GetListRecruiment(PaginationFilter filter, HttpRequest request, Guid Id)
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
                                    }).Where(x => x.IdRecruitment == Id);

var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetJob>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            return new PagedResponse<IEnumerable<VMGetJob>>(result, validFilter.IndexPage, validFilter.PageSize, count);

        }

        public async Task<Respone> UpdateRecruiment(VMUpdateJob vMUpdateJob)
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
                        checkIdJob.JobImage = vMUpdateJob.JobImage;
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

        public async Task<Respone> DeleteRecruiment(Guid Idjob)
        {
            try
            {
                var checkId = await _context.Jobs.SingleOrDefaultAsync(x => x.IdJob == Idjob);
                var checkIdRecruitmentJob = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdJob == Idjob);
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

        public async Task<Respone> UpdateActiveJobs(List<VMRecruitmentJob> vMRecruitmentJobs)
        {
            try
            {
                if (vMRecruitmentJobs.Count > 0)
                {
                    foreach (var job in vMRecruitmentJobs)
                    {
                        var checkIdRecruitmentJob = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdRecruitment == job.IdRecruitment);

                        if (checkIdRecruitmentJob != null)
                        {
                            checkIdRecruitmentJob.IsActive = job.IsActive;
                            checkIdRecruitmentJob.UpdatedOn = DateTimeOffset.UtcNow.Date;
                            await _context.SaveChangesAsync();
                        }

                    }
                    return new Respone
                    {
                        Ok = "Success"
                    };
                }
                return new Respone
                {
                    Fail = "Fail"
                };

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public  async Task<Respone> ActiveJobs(VMUpdateJob vMUpdateJob)
        {
            try
            {
                var check = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdJob == vMUpdateJob.IdJob);
                if(check != null)
                {
                    check.IsActive = vMUpdateJob.IsActive;
                    check.UpdatedOn = DateTimeOffset.UtcNow.Date;
                    await _context.SaveChangesAsync();
                    return new Respone { Ok = "Success", Active = true };
                }
                return new Respone { Fail = "Fail", Active = false };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
