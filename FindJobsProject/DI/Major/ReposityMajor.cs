using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
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
    public class ReposityMajor : IReposityMajor
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ReposityMajor(IMapper mapper,
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

        public async Task<Respone> CreateMajor(VMMajor vMMajor)
        {
            try
            {
                var user = _mapper.Map<Major>(vMMajor);
                var createMajor = await _context.Majors.AddAsync(user);

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


        public async Task<IEnumerable> GetListMajor(int pageIndex , int pageSize )
        {
            var getList =  _context.Majors.AsQueryable();
            var data = await getList.Select(x => new VMMajor
            {
                IdMajor = x.IdMajor,
                Name = x.Name ,
                Description = x.Description,
                IsActive = x.IsActive

            }).ToListAsync();
            var result = PaginatedList<Major>.CreatePages(getList, pageIndex, pageSize);
            var count = data.Count();
            return result;

        }

        public async Task<Respone> UpdateMajor(VMUpdateMajor vMUpdateMajor)
        {
            var checkId = await _context.Majors.SingleOrDefaultAsync(x => x.IdMajor == vMUpdateMajor.IdMajor);
            if (checkId != null)
            {
                checkId.Name = vMUpdateMajor.Name;
                checkId.Description = vMUpdateMajor.Description;
                checkId.IsActive = vMUpdateMajor.IsActive;

               await _context.SaveChangesAsync();
            }
            return new Respone
            {
                Ok= "Success"
            };
        }

        public async Task<Respone> DeteleMajor(VMDeleteMajor vMDeteleMajor)
        {
            var checkId = await _context.Majors.SingleOrDefaultAsync(x => x.IdMajor == vMDeteleMajor.IdMajor);
            if (checkId != null)
            {
                _context.Majors.Remove(checkId);
                await _context.SaveChangesAsync();
            }
            return new Respone
            {
                Ok = "Success"
            };
        }
    }
}
