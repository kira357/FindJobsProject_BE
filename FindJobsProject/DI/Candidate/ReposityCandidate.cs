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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityCandidate : IReposityCandidate
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReposityCandidate(IMapper mapper,
                            UserManager<AppUser> userManager,
                            RoleManager<AppRole> roleManager,
                            SignInManager<AppUser> signInManager,
                            FindJobsContext context,
                            IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<Respone> ApplyJob(VMCandidateJob vMCandidate)
        {
            try
            {
                MediaFile mediaFile = new MediaFile();
                var checkIdJob = await _context.Jobs.SingleOrDefaultAsync(x => x.IdJob == vMCandidate.IdJob);
                var checkIdCandidate = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == vMCandidate.IdCandicate);
                var checkIdRecruiment = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == vMCandidate.IdRecruitment);
                if(checkIdJob != null && checkIdCandidate!= null && checkIdRecruiment != null)
                {
                    var file = await mediaFile.SaveFileApply(vMCandidate.FileApply, _webHostEnvironment);
                    vMCandidate = new VMCandidateJob
                    {
                        IdRecruitment = vMCandidate.IdRecruitment,
                        IdCandicate = vMCandidate.IdCandicate,
                        IdJob = vMCandidate.IdJob,
                        Introduction = vMCandidate.Introduction,
                        DateApply = vMCandidate.DateApply,
                        Resume = file,
                        IsActive = true,
                        IsPending = true,
                        IsDelete= false,
                        CreatedOn = vMCandidate.DateApply,
                    };
                    var user = _mapper.Map<CandidateJob>(vMCandidate);
                    var ApplyJobs = await _context.CandidateJobs.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return new Respone { Ok = "Success" };
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
      
            return new Respone { Fail = "Fails" };
    }



        public async Task<PagedResponse<IEnumerable<VMGetCandidateJob>>> GetListApplyJob(PaginationFilter filter, HttpRequest request)
        {
            var getList = _context.AppUsers.AsQueryable();
            var data = getList.Join(_context.CandidateJobs,
                                    user => user.Id,
                                    candidate => candidate.IdCandicate,
                                    (user, candidate) => new { user, candidate })
                               .Join(_context.Jobs,
                                    candidatejob => candidatejob.candidate.IdJob,
                                    job => job.IdJob,
                                    (candidatejob, job) => new VMGetCandidateJob
                                    {
                                        IdJob = job.IdJob,
                                        IdRecruitment = candidatejob.candidate.IdRecruitment,
                                        IdCandicate = candidatejob.candidate.IdCandicate,
                                        NameJob = job.Name,
                                        IsActive = candidatejob.candidate.IsActive,
                                        Introduction = candidatejob.candidate.Introduction,
                                        Resume = candidatejob.candidate.Resume,
                                    }
                                   );

            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetCandidateJob>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var idRecruitment = result.Select(x => x.IdRecruitment).Distinct();
                var idCadidate = result.Select(x => x.IdCandicate).Distinct();
                if (idRecruitment.Any() || idCadidate.Any())
                {
                    var recruitmentData = _context.AppUsers.AsQueryable()
                      .Where(x => idRecruitment.Contains(x.Id)).Select(x => new { x.Id, x.FullName }).ToList();
                    result.ForEach(x => x.NameRecruitment = recruitmentData.FirstOrDefault(v => v.Id == x.IdRecruitment)?.FullName);

                    var candidateData = _context.AppUsers.AsQueryable()
                     .Where(x => idCadidate.Contains(x.Id)).Select(x => new { x.Id, x.FullName }).ToList();
                    result.ForEach(x => x.NameCandidate = candidateData.FirstOrDefault(v => v.Id == x.IdCandicate)?.FullName);
                }
            }
            return new PagedResponse<IEnumerable<VMGetCandidateJob>>(result, validFilter.IndexPage, validFilter.PageSize, count);

        }


        public async Task<PagedResponse<IEnumerable<VMGetCandidateJob>>> GetItemApplyJob(PaginationFilter filter, HttpRequest request, Guid Id)
        {
            var getList = _context.AppUsers.AsQueryable();
            var data = getList.Join(_context.CandidateJobs,
                                    user => user.Id,
                                    candidate => candidate.IdCandicate,
                                    (user, candidate) => new { user, candidate })
                               .Join(_context.Jobs,
                                    candidatejob => candidatejob.candidate.IdJob,
                                    job => job.IdJob,
                                    (candidatejob, job) => new VMGetCandidateJob
                                    {
                                        IdJob = job.IdJob,
                                        IdRecruitment =candidatejob.candidate.IdRecruitment,
                                        IdCandicate = candidatejob.candidate.IdCandicate,
                                        NameJob = job.Name,
                                        IsActive = candidatejob.candidate.IsActive,
                                        IsPending = candidatejob.candidate.IsPending,
                                        IsDelete  = candidatejob.candidate.IsDelete,
                                        Introduction = candidatejob.candidate.Introduction,
                                        Resume = candidatejob.candidate.Resume,
                                    }
                                   ).Where(x => x.IdRecruitment == Id);

            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetCandidateJob>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var idRecruitment = result.Select(x => x.IdRecruitment).Distinct();
                var idCadidate  = result.Select(x => x.IdCandicate).Distinct();
                if (idRecruitment.Any() || idCadidate.Any())
                {

                    var candidateData = _context.AppUsers.AsQueryable()
                     .Where(x => idCadidate.Contains(x.Id)).Select(x => new { x.Id, x.FullName }).ToList();
                    result.ForEach(x => x.NameCandidate = candidateData.FirstOrDefault(v => v.Id == x.IdCandicate)?.FullName);
                }
            }
            return new PagedResponse<IEnumerable<VMGetCandidateJob>>(result, validFilter.IndexPage, validFilter.PageSize, count);

        }

        public async Task<PagedResponse<IEnumerable<VMGetCandidateJob>>> GetItemApplyJobOfCandidate(PaginationFilter filter, HttpRequest request, Guid Id)
        {
            var getList = _context.AppUsers.AsQueryable();
            var data = getList.Join(_context.CandidateJobs,
                                    user => user.Id,
                                    candidate => candidate.IdCandicate,
                                    (user, candidate) => new { user, candidate })
                               .Join(_context.Jobs,
                                    candidatejob => candidatejob.candidate.IdJob,
                                    job => job.IdJob,
                                    (candidatejob, job) => new VMGetCandidateJob
                                    {
                                        IdJob = job.IdJob,
                                        IdRecruitment = candidatejob.candidate.IdRecruitment,
                                        IdCandicate = candidatejob.candidate.IdCandicate,
                                        NameJob = job.Name,
                                        Experience = job.Experience,
                                        SalaryMin = job.SalaryMin,
                                        SalaryMax = job.SalaryMax,
                                        JobImage = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, job.JobImage),
                                        IsActive = candidatejob.candidate.IsActive,
                                        IsPending = candidatejob.candidate.IsPending,
                                        Introduction = candidatejob.candidate.Introduction,
                                    }
                                   ).Where(x => x.IdCandicate == Id);

            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetCandidateJob>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var idRecruitment = result.Select(x => x.IdRecruitment).Distinct();
                var idCadidate = result.Select(x => x.IdCandicate).Distinct();
                if (idRecruitment.Any() || idCadidate.Any())
                {

                    var candidateData = _context.AppUsers.AsQueryable()
                     .Where(x => idCadidate.Contains(x.Id)).Select(x => new { x.Id, x.FullName }).ToList();
                    result.ForEach(x => x.NameCandidate = candidateData.FirstOrDefault(v => v.Id == x.IdCandicate)?.FullName);
                }
            }
            return new PagedResponse<IEnumerable<VMGetCandidateJob>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        }

        public async Task<VMGetCandidateJob> CheckIsApplyAndFavourite(Guid Id,Guid IdJob)
        {
            var check = await _context.CandidateJobs.SingleOrDefaultAsync(x => x.IdCandicate == Id && x.IdJob == IdJob);
            var checkIsLike = await _context.FavouritesJobs.SingleOrDefaultAsync(x => x.IdUser == Id && x.idJob == IdJob);

                return new VMGetCandidateJob
                {
                    IsActive = check != null ? check.IsActive : false,
                    Islike = checkIsLike != null ? checkIsLike.isLike : false 
                };
   
        }

        public async Task<Respone> ApprovedCandidate(VMUpdateCandidateJob vMUpdateCandidateJob , Guid id)
        {
            var check =  _context.CandidateJobs.SingleOrDefault(x => x.IdCandicate == vMUpdateCandidateJob.IdCandicate && 
                                                                    x.IdJob == vMUpdateCandidateJob.IdJob && x.IdRecruitment == id);
            try
            {
                if (check != null)
                {
                    check.IsPending = false;
                    await _context.SaveChangesAsync();
                    return new Respone
                    {
                        Ok = "Success"
                    };
                };
                return new Respone
                {
                    Fail = "fail"
                };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            
        }

        public async Task<Respone> DeteleCandidate(VMDeleteCandidateJob vMDetelecCandidateJob, Guid id)
        {
            var check = _context.CandidateJobs.SingleOrDefault(x => x.IdCandicate == vMDetelecCandidateJob.IdCandicate &&
                                                                    x.IdJob == vMDetelecCandidateJob.IdJob);
            try
            {
                if (check != null)
                {
                    check.IsDelete = true;
                    check.IsPending = true;
                    await _context.SaveChangesAsync();
                    return new Respone
                    {
                        Ok = "Success"
                    };
                };
                return new Respone
                {
                    Fail = "fail"
                };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

   
    }
}
