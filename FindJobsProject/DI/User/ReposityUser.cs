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

        public async Task<PagedResponse<IEnumerable<VMGetUser>>> GetAllAcc(PaginationFilter filter)
        {
            var getList =  _userManager.Users.AsQueryable();
            var data =  getList.Join(_context.UserRoles,
                                    idUser => idUser.Id,
                                    idRole => idRole.UserId,
                                    (idUser, idRole) => new { idUser, idRole })
                                    .Join(_roleManager.Roles,
                                    userrole => userrole.idRole.RoleId,
                                    role => role.Id,
                                    (userrole, role) => new VMGetUser
                                    { 
                                        UserName = userrole.idUser.UserName,
                                        LastName = userrole.idUser.LastName,
                                        FirstName = userrole.idUser.FirstName,
                                        FullName = userrole.idUser.FullName,
                                        Address = userrole.idUser.Address,
                                        PhoneNumber = userrole.idUser.PhoneNumber,
                                        Email = userrole.idUser.Email,
                                        DateOfBirth = userrole.idUser.DateOfBirth,
                                        RoleName = role.Name,
                                        Gender = userrole.idUser.Gender,
                                        IdMajor = userrole.idUser.IdMajor,
                                        UrlAvatar = userrole.idUser.UrlAvatar,
                                        Description = userrole.idUser.Description,
                                        IsActive = userrole.idUser.IsActive
                                    });

    
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetUser>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();

            return new PagedResponse<IEnumerable<VMGetUser>>(result, validFilter.IndexPage, validFilter.PageSize, count); ;
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
