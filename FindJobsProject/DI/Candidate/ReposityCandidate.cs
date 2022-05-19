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
using System.Collections.Generic;
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
        public ReposityCandidate(IMapper mapper,
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


        public async Task<Respone> ApplyJob(VMCandidateJob vMCandidate)
        {
            try
            {
                var checkIdJob = await _context.Jobs.SingleOrDefaultAsync(x => x.IdJob == vMCandidate.IdJob);
                var checkIdCandidate = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == vMCandidate.IdCandicate);
                var checkIdRecruiment = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == vMCandidate.IdRecruitment);
                if(checkIdJob != null && checkIdCandidate!= null && checkIdRecruiment != null)
                {
                    vMCandidate = new VMCandidateJob
                    {
                        IdRecruitment = vMCandidate.IdRecruitment,
                        IdCandicate = vMCandidate.IdCandicate,
                        IdJob = vMCandidate.IdJob,
                        Introduction = vMCandidate.Introduction,
                        DateApply = vMCandidate.DateApply,
                        Resume = vMCandidate.Resume,
                        IsActive = false,
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

        public Task<Respone> DeteleCandidate(VMDeleteCandidateJob vMDeteleJob)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<IEnumerable<VMGetCandidateJob>>> GetListCandidate(int pageIndex, int pageSize , Guid Id)
        {
            //var checkId = _userManager.Users.SingleOrDefault(x => x.Id == Id);
            //if (checkId != null)
            //{
            //    var getList = _userManager.Users.AsQueryable();
            //    //var data = getList.Join(_context.CandidateJobs,
            //    //                        iduser => iduser.Id,
            //    //                        idrecruitment => idrecruitment.IdRecruitment,
            //    //                        (iduser, idrecruitment) => new { iduser, idrecruitment }) .Where(x => x.iduser.Id == Id)
            //    //                   .Join(_context.Jobs,
            //    //                        user => user.idrecruitment.IdJob,
            //    //                        job => job.IdJob,
            //    //                        (user, job) =>
            //    //                        new VMGetCandidateJob
            //    //                        {
            //    //                            NameJob = job.Name,
            //    //                            NameRecruitment = checkId.FullName,

            //    //                        });
            //    var data = _context.CandidateJobs.ToList().Where(x => x.IdRecruitment == Id); 

            //    var result = PaginatedList<VMGetCandidateJob>.CreatePages(data, pageIndex, pageSize);
            //    var count = data.Count();
            //    return new PagedResponse<IEnumerable<VMGetCandidateJob>>(result, pageIndex, pageSize, count);
            //}
            return null;
            
        }

        public Task<Respone> UpdateCandidate(VMUpdateCandidateJob vMUpdateJob)
        {
            throw new NotImplementedException();
        }
    }
}
