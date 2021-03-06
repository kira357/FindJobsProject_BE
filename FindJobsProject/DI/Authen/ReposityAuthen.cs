using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Helper;
using FindJobsProject.Helpers;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMRecruitment;
using FindJobsProject.ViewModels.VMUser;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly jwtToken _jwt;
        public ReposityAuthen(IMapper mapper,
                            UserManager<AppUser> userManager,
                            RoleManager<AppRole> roleManager,
                            SignInManager<AppUser> signInManager,
                            FindJobsContext context,
                            IWebHostEnvironment webHostEnvironment,
                            jwtToken jwt
                            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _jwt = jwt;
        }
       

        public async Task<Respone> LoginUser(VMUserLogin vMUserLogin)
        {
            var admin = new Organization();
            var check = await _userManager.Users.SingleOrDefaultAsync(x => x.Email.Trim() == vMUserLogin.Email.Trim());
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
                        var userId = await _userManager.GetUserIdAsync(check);
                        var checkRoleId = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == check.Id);
                        var checkUser = _context.AppUsers.SingleOrDefault(x => x.Id.ToString() == userId);
                        var token = _jwt.GenerateToken(vMUserLogin);
                        if (checkUser != null && checkRoleId !=null)
                        {
                            var getRole = await _context.AppRoles.FirstOrDefaultAsync(x => x.Id == checkRoleId.RoleId);
                            if (checkUser.IsActive == true && getRole.Name.ToLower().Equals("recruitment"))
                            {
                        
                                return new Respone
                                {
                                    Ok = "Success",
                                    Mess = "Wellcome back",
                                    Active = checkUser.IsActive,
                                    Token = token,
                                    Id = userId,
                                    RoleName = getRole.Name,
                                    UserName = check.FullName,
                                    Name = check.UserName

                                };
                            }
                            else if(checkUser.IsActive != true && getRole.Name.ToLower().Equals("recruitment"))
                            {
                                return new Respone
                                {
                                    Ok = "Warning",
                                    Mess = "this account is not approved",
                                    Active = false,
                                    Token = "",
                                    Id = userId,
                                    RoleName = getRole.Name,
                                    UserName = check.FullName,
                                    Name = check.UserName

                                };
                            }
                            else if (getRole.Name.ToLower().Equals("admin"))
                            {
                                return new Respone
                                {
                                    Ok = "Success",
                                    Mess = "Wellcome back admin",
                                    Active = false,
                                    Token = token,
                                    Id = userId,
                                    RoleName = getRole.Name,
                                    UserName = check.FullName,
                                    Name = check.UserName

                                };
                            }
                            else if (getRole.Name.ToLower().Equals("student"))
                            {
                                return new Respone
                                {
                                    Ok = "Success",
                                    Mess = "Wellcome back ",
                                    Active = false,
                                    Token = token,
                                    Id = userId,
                                    RoleName = getRole.Name,
                                    UserName = check.FullName,
                                    Name = check.UserName

                                };
                            }
                        }
                        else if ((checkUser != null && checkRoleId == null))
                        {
                            return new Respone
                            {
                                Ok = "Success",
                                Mess = "Wellcome back to website",
                                Active = false,
                                Token = token,
                                Id = userId,
                                RoleName = "",
                                UserName = check.FullName,
                                Name = check.UserName

                            };
                        }
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

        public async Task<Respone> RegisterRecruitment(VMUserRegister vMUserRegister)
        {
            var check = _userManager.Users.SingleOrDefault(x => x.Email.Trim() == vMUserRegister.Email.Trim());
            MediaFile mediaFile = new MediaFile();
            var image = await mediaFile.SaveFile(vMUserRegister.imageFile, _webHostEnvironment);
            try
            {
                if (check == null)
                {
                    vMUserRegister = new VMUserRegister
                    {
                        LastName = vMUserRegister.LastName,
                        FirstName = vMUserRegister.FirstName,
                        Email = vMUserRegister.Email,
                        Password = vMUserRegister.Password,
                        RoleName = "Recruitment",
                        UserName = vMUserRegister.Email,
                        Logo = image,
                        Fax = vMUserRegister.Fax,
                        Website = vMUserRegister.Website,
                        FullName = vMUserRegister.LastName + vMUserRegister.FirstName,
                        NameCompany = vMUserRegister.NameCompany,
                        IsActive = false,
                    };
                    var user = _mapper.Map<AppUser>(vMUserRegister);
                    var CreateAccount = await _userManager.CreateAsync(user, vMUserRegister.Password);
                    if (CreateAccount.Succeeded)
                    {
                         await _signInManager.SignInAsync(user, isPersistent: false);
                        var roleExist = await _roleManager.RoleExistsAsync("Recruitment");
                        if (roleExist)
                        {
                            var createRole = await _userManager.AddToRoleAsync(user, "Recruitment");
                        }
                        var getId = await _context.AppUsers.SingleOrDefaultAsync(x => x.Email.Trim() == user.Email.Trim());
                        if (getId != null)
                        {
                            VMCreateRecruitment vMCreateRecruitment = new VMCreateRecruitment
                            {
                                IdRecruitment = getId.Id,
                                NameCompany =  vMUserRegister.NameCompany,
                                Logo = vMUserRegister.Logo,
                                Fax = vMUserRegister?.Fax,
                                Website = vMUserRegister?.Website,
                                  
                                
                            };
                            var recruiment = _mapper.Map<Recruitment>(vMCreateRecruitment);
                            await _context.Recruitment.AddAsync(recruiment);
                        }
                        await _context.SaveChangesAsync();

                        return new Respone { Ok = "Success" };
                    }
                }
                return new Respone { Fail = "Fail" };

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
                if(check == null)
                {
                    vMUserRegister = new VMUserRegister
                    {
                        LastName = vMUserRegister.LastName,
                        FirstName = vMUserRegister.FirstName,
                        Email = vMUserRegister.Email,
                        Password = vMUserRegister.Password,
                        RoleName = "Student",
                        UserName = vMUserRegister.Email,
                        FullName = vMUserRegister.LastName + vMUserRegister.FirstName,
                        IsActive = true,
                    };
                    var user = _mapper.Map<AppUser>(vMUserRegister);
                    var CreateAccount = await _userManager.CreateAsync(user, vMUserRegister.Password);
                    if (CreateAccount.Succeeded)
                    {
                        var roleExist = await _roleManager.RoleExistsAsync("Student");
                        if (roleExist)
                        {
                            var createRole = await _userManager.AddToRoleAsync(user, "Student");
                        }
                        return new Respone { Ok = "Success" };
                    }
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
