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

            var check = _context.FavouritesJobs.SingleOrDefault(x => x.IdUser == vMCreateFavourite.IdUser && x.idJob == vMCreateFavourite.idJob);
            if (check == null)
            {
                vMCreateFavourite = new VMCreateFavourite
                {
                    IdUser = vMCreateFavourite.IdUser,
                    idJob = vMCreateFavourite.idJob,
                    isLike = vMCreateFavourite.isLike,
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
            else
            {
                check.isLike = vMCreateFavourite.isLike;
                var favourite = _mapper.Map<FavouritesJob>(check);
                await _context.SaveChangesAsync();
                return new Respone
                {
                    Ok = "Success",
                };
            }
           
        }

        public async Task<PagedResponse<IEnumerable<VMGetFavourite>>> GetListFavouriteJobs(PaginationFilter filter, HttpRequest request, Guid Id)
        {
            var favouriteTable = _context.FavouritesJobs.AsQueryable();
            var jobTable = _context.Jobs.AsQueryable();
            var recruitmentJob = _context.recruitmentJob.AsQueryable();
            var major = _context.Majors.AsQueryable();
            var user = _context.AppUsers.AsQueryable();
            var getJob = (from fj in favouriteTable
                          join r in recruitmentJob
                          on fj.idJob equals r.IdJob
                          join j in jobTable
                          on r.IdJob equals j.IdJob
                          select new VMGetFavourite
                          {
                              IdJob = fj.idJob,
                              IdUser = fj.IdUser,
                              CompanyOfJobs = fj.Jobs.CompanyOfJobs,
                              Position = fj.Jobs.Position,
                              Name = fj.Jobs.Name,
                              JobImage = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, fj.Jobs.JobImage),
                              JobDetail = fj.Jobs.JobDetail,
                              Amount = fj.Jobs.Amount,
                              Experience = fj.Jobs.Experience,
                              SalaryMin = fj.Jobs.SalaryMin,
                              SalaryMax = fj.Jobs.SalaryMax,
                              WorkTime = fj.Jobs.WorkTime,
                              idMajor = fj.Jobs.IdMajor,
                              Address = fj.Jobs.Address,
                              DateExpire = fj.Jobs.DateExpire,
                              isLike = fj.isLike
                          }).Where(x => x.IdUser == Id);

            var query = (from m in major
                         join j in getJob
                         on m.IdMajor equals j.idMajor
                         select new VMGetFavourite
                         {
                             IdJob = j.IdJob,
                             IdUser = j.IdUser,
                             CompanyOfJobs = j.CompanyOfJobs,
                             Position = j.Position,
                             Name = j.Name,
                             JobImage = j.JobImage,
                             JobDetail = j.JobDetail,
                             Amount = j.Amount,
                             Experience = j.Experience,
                             SalaryMin = j.SalaryMin,
                             SalaryMax = j.SalaryMax,
                             WorkTime = j.WorkTime,
                             idMajor = j.idMajor,
                             NameMajor = m.Name,
                             Address = j.Address,
                             DateExpire = j.DateExpire,
                             isLike = j.isLike
                         }).Where(x => x.isLike == true);



            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetFavourite>.CreatePages(query, validFilter.IndexPage, validFilter.PageSize);
            var count = query.Count();
            return new PagedResponse<IEnumerable<VMGetFavourite>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        }

        public async Task<Respone> UpdateFavourite(VMUpdateFavourite vMUpdateFavourite)
        {

            var check = _context.FavouritesJobs.SingleOrDefault(x => x.IdUser == vMUpdateFavourite.IdUser && x.idJob == vMUpdateFavourite.idJob);
            if (check == null)
            {
                var favourite = _mapper.Map<FavouritesJob>(vMUpdateFavourite);
                _context.FavouritesJobs.Remove(favourite);
                await _context.SaveChangesAsync();
                return new Respone
                {
                    Ok = "Success",
                };
            }
            return new Respone
            {
                Fail = "Fail",
            };
        }
    }
}

