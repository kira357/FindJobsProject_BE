using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityAuthen : IReposityAuthen
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ReposityAuthen(IMapper mapper,
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
       

        public async Task<Respone> LoginUser(VMUserLogin vMUserLogin)
        {
            var admin = new Organization();
            var check = _userManager.Users.SingleOrDefault(x => x.Email.Trim() == vMUserLogin.Email.Trim());
            try
            {
                if (check == null)
                {
                    if (vMUserLogin.Email.Trim() == admin.Username && vMUserLogin.Password.Trim() == admin.Password)
                    {
                        return new Respone { Ok = "Admin" };
                    }
                    return new Respone
                    {
                        Fail = "user name is wrong "
                    };
                }
                else
                {
                    var check2 = await _signInManager.PasswordSignInAsync(check.UserName.Trim(), vMUserLogin.Password.Trim(), true, false);
                    if (check2.Succeeded)
                    {
                            return new Respone
                            {
                                Ok = "Member",
                                Active = true

                            };

                    }

                    return new Respone
                    {
                        Fail = "Login Fail"
                    };
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<Respone> RegisterUser(VMUserRegister vMUserRegister)
        {

            var check = _userManager.Users.SingleOrDefault(x => x.Email.Trim() == vMUserRegister.Email.Trim());
            try
            {
                        vMUserRegister = new VMUserRegister
                        {
                            LastName = vMUserRegister.LastName,
                            FirstName = vMUserRegister.FirstName,
                            Gender = vMUserRegister.Gender,
                            Email = vMUserRegister.Email,
                            Major = vMUserRegister.Major,
                            Password = vMUserRegister.Password,
                            RoleName = "memeber",
                            Address = vMUserRegister.Address,
                            UserName = vMUserRegister.Email,
                            FullName= vMUserRegister.LastName + vMUserRegister.FirstName,
                        };
                        var user = _mapper.Map<AppUser>(vMUserRegister);
                        var CreateAccount = await _userManager.CreateAsync(user, vMUserRegister.Password);
                        if (CreateAccount.Succeeded)
                        {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        //var addUserRole = await AddUserToRole(vMUserRegister, vMUserRegister.RoleName);
                        return new Respone { Ok = "Success" };
                        }
                     
                    return new Respone { Fail = "Fail" };
               
                 
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
