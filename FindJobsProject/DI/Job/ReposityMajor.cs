﻿using AutoMapper;
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
            //try
            //{
            //    var user = _mapper.Map<Job>(vMJob);
            //    var createJob = await _context.Jobs.AddAsync(user);

            //    await _context.SaveChangesAsync();

            //    return new Respone
            //    {
            //        Ok = "Success"
            //    };
            //}
            //catch (Exception ex)
            //{

            //    throw ex.InnerException;
            //}
            return null;

        }


        public async Task<IEnumerable> GetListJob(int pageIndex, int pageSize)
        {
            var getList = _context.Jobs.AsQueryable();
            var data = await getList.Select(x => new VMJob
            {
                Id = x.Id,
                CompanyOfJobs = x.CompanyOfJobs,
                Position = x.Position,
                JobImage = x.JobImage,
                JobDetail = x.JobDetail,
                Amount = x.Amount,
                Experience = x.Experience,
                SalaryMin = x.SalaryMin,
                SalaryMax = x.SalaryMax,
                SalaryUnit = x.SalaryUnit,
                WorkTime = x.WorkTime,
                Address = x.Address,
                DealineForSubmission = x.DealineForSubmission,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                IsActive = x.IsActive


            }).ToListAsync();
            var result = PaginatedList<Job>.CreatePages(getList, pageIndex, pageSize);
            var count = data.Count();
            return result;

        }

        public async Task<Respone> UpdateJob(VMUpdateJob vMUpdateJob)
        {
            //var checkId = await _context.Jobs.SingleOrDefaultAsync(x => x.IdJob == vMUpdateJob.IdJob);
            //if (checkId != null)
            //{
            //    checkId.Name = vMUpdateJob.Name;
            //    checkId.Description = vMUpdateJob.Description;
            //    checkId.IsActive = vMUpdateJob.IsActive;

            //    await _context.SaveChangesAsync();
            //}
            //return new Respone
            //{
            //    Ok = "Success"
            //};
            return null;
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
