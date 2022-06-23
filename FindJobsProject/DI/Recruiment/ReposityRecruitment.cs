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
using FindJobsProject.ViewModels.VMRecruitment;
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

        public async Task<Respone> UpdateRecruiment(VMUpdateRecruitment vMUpdateRecruitment, Guid id)
        {
            try
            {
                var checkId = await _context.Recruitment.SingleOrDefaultAsync(x => x.IdRecruitment == id);
                var checkIdJob = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdRecruitment == id);

                if (checkId != null && checkIdJob != null)
                {
                    if (vMUpdateRecruitment.imageFile != null)
                    {
                        MediaFile mediaFile = new MediaFile();
                        var image = await mediaFile.SaveFile(vMUpdateRecruitment.imageFile, _webHostEnvironment);
                        checkId.Logo = image;
                        checkId.NameCompany = vMUpdateRecruitment.NameCompany;
                        checkId.Summary = vMUpdateRecruitment.Summary;
                        checkId.Descriptions = vMUpdateRecruitment.Descriptions;
                        checkId.TypeCompany = vMUpdateRecruitment.TypeCompany;
                        checkId.Address = vMUpdateRecruitment.Address;
                        checkId.Amount = vMUpdateRecruitment.Amount;
                        checkId.TypeOfWork = vMUpdateRecruitment.TypeOfWork;

                        checkIdJob.Jobs.JobImage = image;

                    }
                    else
                    {
                        checkId.NameCompany = vMUpdateRecruitment.NameCompany;
                        checkId.Summary = vMUpdateRecruitment.Summary;
                        checkId.Descriptions = vMUpdateRecruitment.Descriptions;
                        checkId.TypeCompany = vMUpdateRecruitment.TypeCompany;
                        checkId.Address = vMUpdateRecruitment.Address;
                        checkId.Amount = vMUpdateRecruitment.Amount;
                        checkId.TypeOfWork = vMUpdateRecruitment.TypeOfWork;
                    }
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

        public async Task<Respone> ActiveJobs(VMUpdateJob vMUpdateJob)
        {
            try
            {
                var check = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdJob == vMUpdateJob.IdJob);
                if (check != null)
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

        public async Task<VMGetRecruitment> GetCurrentRecruitment(Guid id, HttpRequest request)
        {
            var getCurrent = await _context.Recruitment.SingleOrDefaultAsync(x => x.IdRecruitment == id); 
            if(getCurrent != null)
            {
                VMGetRecruitment vMGetRecruitment = new VMGetRecruitment
                {
                    IdRecruitment = getCurrent.IdRecruitment,
                    NameCompany = getCurrent.NameCompany,
                    Address = getCurrent.Address,   
                    Amount = getCurrent.Amount, 
                    Descriptions=  getCurrent.Descriptions,
                    Logo   = getCurrent.Logo,
                    UrlLogo = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, getCurrent.Logo),
                    Fax = getCurrent.Fax,
                    Website = getCurrent.Website,
                    Summary = getCurrent.Summary,
                    TypeCompany = getCurrent.TypeCompany,
                    TypeOfWork = getCurrent.TypeOfWork,

                };
                return vMGetRecruitment;
            }
            return null; ;
        }

    }
}
