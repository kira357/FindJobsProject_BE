using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Helper;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMFavourite;
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
    public class ReposityFavourite : IReposityFavourite
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReposityFavourite(IMapper mapper,
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

        public async Task<Respone> CreateFavourite(VMCreateFavourite vMCreateFavourite)
        {
            if (vMCreateFavourite != null)
            {
                vMCreateFavourite = new VMCreateFavourite
                {
                    IdUser = vMCreateFavourite.IdUser,
                    idJob = vMCreateFavourite.idJob,
                    isLike = true,
                    CreatedOn = DateTime.Now,

                };
                var favourite = _mapper.Map<FavouritesJob>(vMCreateFavourite);
                _context.FavouritesJobs.Add(favourite);
                await _context.SaveChangesAsync();
                return new Respone
                {
                    Ok = "Success",
                };
            }
            return new Respone
            {
                Fail = "Fail"
            };
        }

        public async Task<PagedResponse<IEnumerable<VMGetFavourite>>> GetItemIsFavourite(PaginationFilter filter, HttpRequest request, Guid Id)
        {
            var favouriteTable = _context.FavouritesJobs.AsQueryable();
            var jobTable = _context.Jobs.AsQueryable();
            var recruitmentJob  = _context.recruitmentJob.AsQueryable();
            var getAll = (from r in recruitmentJob
                          join j in jobTable
                          on r.IdJob equals j.IdJob
                          join fj in favouriteTable
                          on r.IdJob equals fj.idJob into c 
                          from getjob in c.DefaultIfEmpty()
                          select new VMGetFavourite
                          {
                              IdJob = getjob.idJob,
                              IdUser = getjob.IdUser,
                              UserName = getjob.Users.FullName,
                              CompanyOfJobs = getjob.Jobs.CompanyOfJobs,
                              Position = getjob.Jobs.Position,
                              Name = getjob.Jobs.Name,
                              JobImage = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, getjob.Jobs.JobImage),
                              JobDetail = getjob.Jobs.JobDetail,
                              Amount = getjob.Jobs.Amount,
                              Experience = getjob.Jobs.Experience,
                              SalaryMin = getjob.Jobs.SalaryMin,
                              SalaryMax = getjob.Jobs.SalaryMax,
                              WorkTime = getjob.Jobs.WorkTime,
                              idMajor = getjob.Jobs.IdMajor,
                              Address = getjob.Jobs.Address,
                              DateExpire = getjob.Jobs.DateExpire,
                              isLike = getjob.isLike,
                              IsActive = getjob.Jobs.RecruitmentJobTable.FirstOrDefault().IsActive,
                              
                          }).Where(x => x.IdUser == Id && x.IsActive == true);


            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetFavourite>.CreatePages(getAll, validFilter.IndexPage, validFilter.PageSize);
            var count = getAll.Count();
            return new PagedResponse<IEnumerable<VMGetFavourite>>(result, validFilter.IndexPage, validFilter.PageSize, count);

        }

        public Task<PagedResponse<IEnumerable<VMGetFavourite>>> GetListFavouriteJobs(PaginationFilter filter, HttpRequest request, Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Respone> UpdateFavourite(VMUpdateFavourite vMUpdateFavourite)
        {
            throw new NotImplementedException();
        }
    }
}

