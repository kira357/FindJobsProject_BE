using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
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
    public class ReposityRole : IReposityRole
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ReposityRole(IMapper mapper,
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

        public async Task<Respone> CreateRole(VMRole vMRole)
        {
            try
            {
                vMRole = new VMRole
                {
                    Name = vMRole.Name,
                    NormalizedName = vMRole.Name.ToUpper(),
                    Description = vMRole.Description,
                };
                var user = _mapper.Map<AppRole>(vMRole);
                var createRole = await _context.AppRoles.AddAsync(user);

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
       
        }


        public async Task<PagedResponse<IEnumerable<AppRole>>> GetListRole(PaginationFilter filter)
        {
            var getList =  _context.Roles.AsQueryable();
            var data = await getList.Select(x => new VMRole
            {
                Id = x.Id,
                Name = x.Name ,
                Description = x.Description,

            }).ToListAsync();
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<AppRole>.CreatePages(getList, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            return new PagedResponse<IEnumerable<AppRole>>(result, validFilter.IndexPage, validFilter.PageSize, count); ;

        }

        public async Task<Respone> UpdateRole(VMUpdateRole vMUpdateRole)
        {
            var checkId = await _context.Roles.SingleOrDefaultAsync(x => x.Id == vMUpdateRole.Id);
            if (checkId != null)
            {
                checkId.Name = vMUpdateRole.Name;
                checkId.NormalizedName = checkId.Name.ToUpper();
                checkId.Description = vMUpdateRole.Description;

               await _context.SaveChangesAsync();
            }
            return new Respone
            {
                Ok= "Success"
            };
        }

        public async Task<Respone> DeteleRole(VMDeleteRole vMDeteleRole)
        {
            var checkId = await _context.Roles.SingleOrDefaultAsync(x => x.Id == vMDeteleRole.Id);
            if (checkId != null)
            {
                _context.Roles.Remove(checkId);
                await _context.SaveChangesAsync();
            }
            return new Respone
            {
                Ok = "Success"
            };
        }
    }
}
