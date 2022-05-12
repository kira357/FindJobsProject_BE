using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityUser : IReposityUser
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ReposityUser(IMapper mapper,
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
        public async Task<Respone> CreateRole(VMRole roleVM)
        {
            try
            {
                var newRole = new VMRole
                {
                    Name = roleVM.Name,
                    Description = roleVM.Description
                };
                var role = _mapper.Map<AppRole>(newRole);
                var createRole = await _roleManager.CreateAsync(role);

                if (createRole.Succeeded)
                {
                    return new Respone { Ok = "Success" };

                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return new Respone
            {
                Fail = "Create role fail"
            };
        }

        public async Task<Respone> AddUserToRole(VMUserRegister user, string role)
        {

            var check = _userManager.Users.SingleOrDefault(u => u.Email == user.Email);
            if (check != null)
            {
                try
                {
                    var createRole = await _userManager.AddToRoleAsync(check, role);
                    return new Respone
                    {
                        Ok = "set Role Success"
                    };
                }
                catch (Exception ex)
                {

                    throw ex.InnerException;
                }

            }
            return new Respone
            {
                Fail = "set Role Fail"
            };
        }

        public async Task<IEnumerable> GetAllAcc()
        {
            var getALL = await _context.recruitmentJob.ToListAsync();
            return getALL;
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

        public async Task<Respone> CreateUser(VMUserRegister vMUserRegister)
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
                    RoleName = vMUserRegister.RoleName,
                    Description = vMUserRegister.Description,
                    Address = vMUserRegister.Address,
                    UserName = vMUserRegister.Email,
                    FullName = vMUserRegister.LastName + vMUserRegister.FirstName,
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
