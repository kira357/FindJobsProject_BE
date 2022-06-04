using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Helper;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMUser;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReposityUser(IMapper mapper,
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

        public async Task<Respone> AddUserToRole(VMCreateUser user)
        {

            var check = _userManager.Users.SingleOrDefault(u => u.Email == user.Email);
            if (check != null)
            {
                try
                {
                    var createRole = await _userManager.AddToRoleAsync(check, user.RoleName);
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

        public async Task<PagedResponse<IEnumerable<VMGetUser>>> GetAllAcc(PaginationFilter filter , HttpRequest request)
        {
            var getList =  _userManager.Users.AsQueryable();
            var data = getList.Join(_context.UserRoles,
                                    idUser => idUser.Id,
                                    idRole => idRole.UserId,
                                    (idUser, idRole) => new { idUser, idRole })
                                    .Join(_roleManager.Roles,
                                    userrole => userrole.idRole.RoleId,
                                    role => role.Id,
                                    (userrole, role) => new VMGetUser
                                    {
                                        Id = userrole.idUser.Id,
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
                                        Description = userrole.idUser.Description,
                                        IsActive = userrole.idUser.IsActive
                                    });

            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetUser>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();

            return new PagedResponse<IEnumerable<VMGetUser>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        }

      
        public async Task<Respone> CreateUser(VMCreateUser vMUserRegister)
        {
            MediaFile mediaFile = new MediaFile();
            var check = _userManager.Users.SingleOrDefault(x => x.Email.Trim() == vMUserRegister.Email.Trim());
            //vMUserRegister.UrlAvatar = await mediaFile.SaveFile(vMUserRegister.imageFile , _webHostEnvironment );
            try
            {
                vMUserRegister = new VMCreateUser
                {
                    LastName = vMUserRegister.LastName.Trim(),
                    FirstName = vMUserRegister.FirstName.Trim(),
                    UserName = vMUserRegister.UserName,
                    FullName = vMUserRegister.LastName +" "+ vMUserRegister.FirstName,
                    Gender = vMUserRegister.Gender,
                    Email = vMUserRegister.Email,
                    IdMajor = vMUserRegister.IdMajor,
                    Password = vMUserRegister.Password,
                    RoleName = vMUserRegister.RoleName,
                    Description = vMUserRegister.Description,
                    Address = vMUserRegister.Address,
                    PhoneNumber = vMUserRegister.PhoneNumber,
                    IsActive = true,
                };
                var user = _mapper.Map<AppUser>(vMUserRegister);
                var CreateAccount = await _userManager.CreateAsync(user, vMUserRegister.Password);
                if (CreateAccount.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    var addUserRole = await AddUserToRole(vMUserRegister);
                    return new Respone { Ok = "Success" };
                }

                return new Respone { Fail = "Fail" };


            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<Respone> UpdateUser(VMUserUpdate vMUserUpdate , Guid Id)
        {
            //MediaFile mediaFile = new MediaFile();
            //vMUserUpdate.UrlAvatar = await mediaFile.SaveFile(vMUserUpdate.imageFile, _webHostEnvironment);
            var check = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == Id);
            var getRole = _roleManager.FindByNameAsync(vMUserUpdate.RoleName);

            try
            {
                    check.LastName = vMUserUpdate.LastName.Trim();
                    check.FirstName = vMUserUpdate.FirstName.Trim();
                    check.UserName = vMUserUpdate.UserName;
                    check.FullName = vMUserUpdate.LastName +" "+ vMUserUpdate.FirstName;
                    check.Gender = vMUserUpdate.Gender;
                    check.Email = vMUserUpdate.Email;
                    check.PhoneNumber = vMUserUpdate.PhoneNumber;
                    check.IdMajor = vMUserUpdate.IdMajor;
                    check.Description = vMUserUpdate.Description;
                    check.Address = vMUserUpdate.Address;
                    check.IsActive = vMUserUpdate.IsActive;


                var user = _mapper.Map<AppUser>(check);
                var CreateAccount = await _userManager.UpdateAsync(user);
                if (CreateAccount.Succeeded)
                {
                    var checkGetRole = await _context.UserRoles.SingleOrDefaultAsync(x => x.UserId == user.Id);
                    if(checkGetRole != null)
                    {
                        _context.UserRoles.Remove(checkGetRole);
                        AppUserRole userRole = new AppUserRole
                        {
                            RoleId = getRole.Result.Id,
                            UserId = user.Id
                        };
                        await _context.UserRoles.AddAsync(userRole);
                        await _context.SaveChangesAsync();
                        return new Respone { Ok = "Success" };
                    }
                    else
                    {   
                        var createRole = await _userManager.AddToRoleAsync(check, vMUserUpdate.RoleName);
                    return new Respone
                    {
                        Ok = "set Role Success"
                    };
          
                    }
                }

                return new Respone { Fail = "Fail" };


            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        
        public async Task<Respone> DeleteUser(VMUserDelete vMUserDelete , Guid Id)
        {

            var check = _userManager.Users.SingleOrDefault(x => x.Id == Id);
            var checkGetRole = _context.UserRoles.SingleOrDefault(x => x.UserId == Id);
            var checkGetJob = _context.recruitmentJob.SingleOrDefault(x => x.IdRecruitment == Id);
            try
            {
                 if(check != null)
                {
                    var user = _mapper.Map<AppUser>(check);
                    var remove = await _userManager.DeleteAsync(user);
                    if (remove.Succeeded)
                    {
                        if(checkGetJob != null)
                        {
                            _context.recruitmentJob.Remove(checkGetJob);
                        }
                        if (checkGetRole != null)
                        {
                            _context.UserRoles.Remove(checkGetRole);
                        }
                        await _context.SaveChangesAsync();
                        return new Respone { Ok = "Success" };
                    }
                    return new Respone { Ok = "Success" };
                }

                return new Respone { Fail = "Fail" };


            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<Respone> ActiveJobs(VMUpdateJob vMUpdateJob)
        {
            try
            {
                var check = await _context.recruitmentJob.SingleOrDefaultAsync(x => x.IdJob == vMUpdateJob.IdJob);
                if (check != null)
                {
                    check.IsActive = vMUpdateJob.IsActive;
                    check.UpdatedOn = DateTimeOffset.UtcNow.Date;
                    await _context.SaveChangesAsync();
                    return new Respone { Ok = "Success", Active = true };
                }
                return new Respone { Fail = "Fail", Active = false };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<List<VMGetUser>> GetCurrentUser(Guid id, HttpRequest request)
        {
            var idUser = _context.AppUsers.AsQueryable();
            var idUserRole = _context.UserRoles.AsQueryable();
            var idRole = _context.AppRoles.AsQueryable();
            var idMajor = _context.Majors.AsQueryable();

            var currentUser = await (from user in idUser
                               join userrole in idUserRole
                               on user.Id equals userrole.UserId into urt
                               from userandrole in urt.DefaultIfEmpty()
                               join role in idRole 
                               on userandrole.RoleId equals role.Id into r
                               from rolename in r.DefaultIfEmpty()
                               join major in idMajor
                               on user.IdMajor equals major.IdMajor into mrt
                               from usermajor in mrt.DefaultIfEmpty()
                               select new VMGetUser
                               {
                                   Id = user.Id,
                                   FullName = user.FullName,
                                   UrlAvatar = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, user.UrlAvatar),
                                   RoleName = rolename.Name,
                                   NameMajor = usermajor.Name,
                               }).Where(x => x.Id == id).ToListAsync();

            return currentUser;
        }
    }
}
