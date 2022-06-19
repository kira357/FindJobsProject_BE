using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMMajor;
using FindJobsProject.ViewModels.VMMessage;
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
    public class ReposityMessage : IReposityMessage
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ReposityMessage(IMapper mapper,
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

        public async Task<Respone> CreateMessage(VMCreateMessage vMMessage)
        {
            try
            {
                var message = _mapper.Map<Message>(vMMessage);
                var createMajor = await _context.Messages.AddAsync(message);

                await _context.SaveChangesAsync();

                return new Respone
                {
                    Ok = "Success"
                };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return null;
       
        }


        public async Task<PagedResponse<IEnumerable<Message>>> GetMessage(PaginationFilter filter)
        {
            //var getList =  _context.Majors.AsQueryable();
            //var data = await getList.Select(x => new VMMajor
            //{
            //    IdMajor = x.IdMajor,
            //    Name = x.Name ,
            //    Description = x.Description,
            //    IsActive = x.IsActive

            //}).ToListAsync();
            //var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            //var result = PaginatedList<Major>.CreatePages(getList, validFilter.IndexPage, validFilter.PageSize);
            //var count = data.Count();
            //return new PagedResponse<IEnumerable<Major>>(result, validFilter.IndexPage, validFilter.PageSize, count);
            return null;
        }


    }
}
