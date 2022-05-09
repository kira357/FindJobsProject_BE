using FindJobsProject.Database;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityAutho : IReposityAutho
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context; 
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public ReposityAutho(IMapper mapper, 
                            UserManager<User> userManager, 
                            RoleManager<Role> roleManager, 
                            SignInManager<User> signInManager,
                            FindJobsContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;

        }

        public async Task<Respone> RegisterUser(VMUserRegister vMUserRegister)
        {
            var Id = Guid.NewGuid();
            vMUserRegister = new VMUserRegister
            {
               Name = vMUserRegister.Name,
               Email = vMUserRegister.Email ,
               Approve = vMUserRegister.Approve,
               Password = vMUserRegister.Password,
               Position = vMUserRegister.Position ,
               UserName = vMUserRegister.UserName,
               IdEmployee = Id,
            };
            Employees employees = new Employees
            {
                Id = Id,
                email = vMUserRegister.Email,
                PostionEmployee = vMUserRegister.Position,
                NameEmployee = vMUserRegister.Name
            };

            var user = _mapper.Map<VMUserRegister, User>(vMUserRegister);

            var check = _userManager.Users.SingleOrDefault(x => x.Email.Trim() == vMUserRegister.Email.Trim());
            try
            {
                if (check != null)
                {
                    return await UpdateInforEmployee(vMUserRegister);
               
                }
                else
                {
                    var checkEmployee = _context.employees.SingleOrDefault(x => x.email.Trim() == vMUserRegister.Email.Trim() &&
                                                                           x.NameEmployee.Trim() == vMUserRegister.Name.Trim());
                    
                    if (checkEmployee != null)
                    {
                        vMUserRegister = new VMUserRegister
                        {
                            Name = vMUserRegister.Name,
                            Email = vMUserRegister.Email,
                            Approve = vMUserRegister.Approve,
                            Password = vMUserRegister.Password,
                            Position = vMUserRegister.Position,
                            UserName = vMUserRegister.UserName,
                            IdEmployee = checkEmployee.Id,
                        };
                        user = _mapper.Map<VMUserRegister, User>(vMUserRegister);
                        var CreateAccount = await _userManager.CreateAsync(user, vMUserRegister.Password);
                        if (CreateAccount.Succeeded)
                        {
                            var addUserRole = await AddUserToRole(user, vMUserRegister.Position);
                            return new Respone { Ok = "Success" };
                        }
                    }
                    if(checkEmployee == null && check == null)
                    {
                        var CreateEmployee = _context.employees.Add(employees);
                        await _context.SaveChangesAsync();
                    }
                    var CreateUser = await _userManager.CreateAsync(user, vMUserRegister.Password);
                    if (CreateUser.Succeeded)
                    {
                        var addUserRole =await AddUserToRole(user, vMUserRegister.Position);
                        return new Respone { Ok = "Success" };
                    }
                    return new Respone { Fail = "Fail" };
                }


            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            
        }


        public async Task<Respone> LoginUser(VMUserLogin vMUserLogin)
        {
            var admin = new Organization();
            var check = _userManager.Users.SingleOrDefault(x => x.UserName.Trim() == vMUserLogin.UserName.Trim());
            try
            {
                if (check == null)
                {
                    if (vMUserLogin.UserName.Trim() == admin.Username && vMUserLogin.Password.Trim() == admin.Password)
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
                        if(check.Approve)
                        {
                            return new Respone
                            {
                                Ok = "Member",
                                Active = true

                            };

                        }
                        else
                        {
                            return new Respone
                            {
                                Fail = "this account not allow to login ",
                                Active = false

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

        public async Task<IEnumerable<Respone>> LogOutUser()
        {
           
            return null;
        }
        public async Task<Respone> AddDefaultRole(string role)
        {
            try
            {
                var newRole = new Role
                {
                    Name = role
                };

                var createRole = await _roleManager.CreateAsync(newRole);

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

        public async Task<Respone> AddUserToRole (User user, string role )
        {
            //var checkRole =  await _roleManager.RoleExistsAsync(role);
            //if (!checkRole)
            //{
            //    var newRole = await AddDefaultRole(role);
            //    return newRole;
            //}

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
            return new Respone { 
            Fail = "set Role Fail"};
        }


        public async Task<IEnumerable> GetAllAcc()
        {

            var test = await _userManager.Users.Join(_context.employees, x => x.IdEmployee
                                                                  , u => u.Id
                                                                  , (x, u) => new
                                                                  {
                                                                      userName = x.UserName,
                                                                      Email = u.email,
                                                                      Position = u.PostionEmployee,
                                                                      Approve = x.Approve,
                                                                      Name = x.Name,
                                                                      Address = u.address
                                                                  }).ToListAsync();


            return test;
        }

        public async Task<IEnumerable> GetAllEmployee()
        {
           
            List<Employees> employeesAccountNull = new List<Employees>();
            List<Employees> employeesAccountHas = new List<Employees>();

            var check = await _context.employees.Select(x => new
            {
                id = x.Id,
                email = x.email,
                address = x.address,
                name = x.NameEmployee,
                position = x.PostionEmployee,
                user = x.user
            })
            .ToListAsync();
            foreach (var item in check)
            {
                if (item.user == null)
                {
                    employeesAccountNull.Add(new Employees
                    {
                        Id = item.id,
                        NameEmployee = item.name,
                        PostionEmployee = item.position,
                        email = item.email,
                        address = item.address,
                        user = null
                    });
                }
                else
                {
                    employeesAccountHas.Add(new Employees
                    {
                        Id = item.id,
                        NameEmployee = item.name,
                        PostionEmployee = item.position,
                        email = item.email,
                        address = item.address,
                        user = item.user
                    });
                }
            }
            employeesAccountNull.AddRange(employeesAccountHas);

            return employeesAccountNull;
        }

        public async Task<Respone> DeteleAccount(VMDelete[] vMDeletes)
        {
            foreach (var item in vMDeletes)
            {
                var check = await _userManager.FindByEmailAsync(item.email);
                if (check != null)
                {
                    if(item.email == check.Email)
                    {
                        check.Email = item.email;
                        await _userManager.DeleteAsync(check);
                    }
                }
                else
                {
                    return new Respone { Fail = "fail" };
                }
            }
            await _context.SaveChangesAsync();
            return new Respone { Ok = "Success" };
        }

        public async Task<Respone> UpdateApprove(VMUserUpdate[] vMUserUpdates)
        {
            List<User> userUpdate = new List<User>();
            User user = new User();
            foreach (var item in vMUserUpdates)
            {
                var check =await _userManager.FindByEmailAsync(item.email);
                if(check != null)
                {
                        check.Email = item.email;
                        check.Approve = item.approve;
                        check.Position = item.position;
                        check.UserName = item.userName;
                        check.Name = item.name;

                    await _userManager.UpdateAsync(check);
                }
                else
                {
                    return new Respone { Fail = "fail" };
                }
            }
            await _context.SaveChangesAsync();
            return new Respone { Ok = "Success" };
        }

        public async Task<Respone> UpdateInforEmployee(VMUserRegister vMUserRegister)
        {
            var check = await _userManager.FindByEmailAsync(vMUserRegister.Email);
            var checkId = _context.employees.SingleOrDefault(x => x.Id == check.IdEmployee);

            if(check != null && checkId != null)
            {
                check.Email = vMUserRegister.Email;
                check.Approve = vMUserRegister.Approve;
                check.Position = vMUserRegister.Position;
                check.UserName = vMUserRegister.UserName;
                check.Name = vMUserRegister.Name;

                checkId.NameEmployee = vMUserRegister.Name;
                checkId.PostionEmployee = vMUserRegister.Position;
                checkId.email = vMUserRegister.Email;

                await _userManager.UpdateAsync(check);
                _context.employees.Update(checkId);
                await _context.SaveChangesAsync();
            }
            else
            {
                return new Respone { Fail = "Fail" };
            }
            return new Respone { Ok= "Success"};
        }



        public async Task<Respone> DeteleEmployee(VMDelete[] vMDeletes)
        {
            List<Employees> em = new List<Employees>();
            foreach (var item in vMDeletes)
            {
                var check = await _context.employees.SingleOrDefaultAsync(x => x.Id == item.id);
                if (check != null)
                {

                    check.Id = item.id;
                    check.email = item.email;
                    check.NameEmployee = item.name;
                    check.PostionEmployee = item.position;

                    _context.employees.RemoveRange(check);

                }
                else
                {
                    return new Respone { Fail = "fail" };
                }
            }
     
            await _context.SaveChangesAsync();
            return new Respone { Ok = "Success" };
        }

        public async Task<Respone> UpdateEmployee(VMUserUpdate vMUserUpdates)
        {

            var check = await _context.employees.SingleOrDefaultAsync(x => x.email.Trim() == vMUserUpdates.email.Trim());
            var CheckUser = await _userManager.Users.SingleOrDefaultAsync(x => x.Email.Trim() == check.email.Trim());

            if (check != null && CheckUser == null)
            {
                check.email = vMUserUpdates.email;
                check.NameEmployee = vMUserUpdates.name;
                check.PostionEmployee = vMUserUpdates.position;
                check.address = vMUserUpdates.address;

                _context.employees.Update(check);
            }
           
            else if (check != null && CheckUser != null)
            {
                check.email = vMUserUpdates.email;
                check.NameEmployee = vMUserUpdates.name;
                check.PostionEmployee = vMUserUpdates.position;
                check.address = vMUserUpdates.address;

                CheckUser.Name = vMUserUpdates.name;
                CheckUser.Position = vMUserUpdates.position;
                CheckUser.Email = vMUserUpdates.email;

                await _userManager.UpdateAsync(CheckUser);
                _context.employees.Update(check);

            }
            await _context.SaveChangesAsync();
            return new Respone { Ok = "Success" };
        }


        public async Task<Respone> CreateEmployee(VMUserRegister vMUserRegister)
        {
            var Id = Guid.NewGuid();
            vMUserRegister = new VMUserRegister
            {
                Name = vMUserRegister.Name,
                Email = vMUserRegister.Email,
                Approve = vMUserRegister.Approve,
                Password = vMUserRegister.Password,
                Position = vMUserRegister.Position,
                UserName = vMUserRegister.UserName,
                Address = vMUserRegister.Address,
                IdEmployee = Id,
            };
            Employees employees = new Employees
            {
                Id = Id,
                email = vMUserRegister.Email,
                PostionEmployee = vMUserRegister.Position,
                NameEmployee = vMUserRegister.Name,
                address = vMUserRegister.Address,
                
            };

            var user = _mapper.Map<VMUserRegister, User>(vMUserRegister);

            var check = _userManager.Users.SingleOrDefault(x => x.Email.Trim() == vMUserRegister.Email.Trim());
            try
            { 
                    var checkEmployee = _context.employees.SingleOrDefault(x => x.email.Trim() == vMUserRegister.Email.Trim());
            
                    if (checkEmployee == null && check == null)
                    {
                        var CreateEmployee = _context.employees.Add(employees);
                        await _context.SaveChangesAsync();
                    }
                    //var CreateUser = await _userManager.CreateAsync(user, vMUserRegister.Password);
                    //if (CreateUser.Succeeded)
                    //{
                    //    var addUserRole = await AddUserToRole(user, vMUserRegister.Position);
                    //    return new Respone { Ok = "Success" };
                    //}
                    return new Respone { Fail = "Fail" };
       
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }

        public  async Task<IEnumerable> GetInformationEmployee(string username)
        {
            if(username != null)
            {
                 var check =  await _userManager.FindByNameAsync(username);

                var getID = _context.employees.SingleOrDefault(x => x.Id == check.IdEmployee);
                try
                {
                    if (getID != null)
                    {
                        var getAll = await _context.employees.Select(x => new
                        {
                            NameEmployee = x.NameEmployee,
                            PostionEmployee = x.PostionEmployee,
                            address = x.address,
                            email = x.email,
                            id = x.Id
                        })
                                                            .Where(x => x.id == check.IdEmployee)
                                                            .ToListAsync();
                        return getAll;
                    }
                }
                catch (Exception ex)
                {

                    throw ex.InnerException;
                }

            }
            return "12345";
        }
    }
}
