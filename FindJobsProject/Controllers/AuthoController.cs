using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserParam
{
    public string username { get; set; }
}

namespace FindJobsProject.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class AuthoController : ControllerBase
    {
        private readonly IReposityAutho _repo;
        private readonly IReposityEmployee _repoEm;

        public AuthoController(IReposityAutho repo, IReposityEmployee repoEm)
        {
            _repo = repo;
            _repoEm = repoEm;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(VMUserRegister vMUserRegister)
        {
            try
            {
                var create = await _repo.RegisterUser(vMUserRegister);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(VMUserLogin vMUserLogin)
        {
            try
            {
                var login = await _repo.LoginUser(vMUserLogin);
                return Ok(login);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var getAll = await _repo.GetAllAcc();
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }
        [HttpGet("getallemployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var getAll = await _repo.GetAllEmployee();
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }

        [HttpPost("createdefaultrole")]
        public async Task<IActionResult> AddDefaultRole(string role)
        {
            try
            {
                var defaultRole = await _repo.AddDefaultRole(role);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        [HttpPost("adduserrole")]
        public async Task<IActionResult> AddUserToRole(User user, string role)
        {
            try
            {
                var defaultRole = await _repo.AddUserToRole(user,role);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }

        [HttpPut("update_approved")]
        public async Task<IActionResult> UpdateUser(VMUserUpdate[] vMUserUpdates)
        {
            try
            {
                var result = await _repo.UpdateApprove(vMUserUpdates);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        [HttpDelete("detele_account")]
        public async Task<IActionResult> DeleteUser(VMDelete[] vMDeletes)
        {
            try
            {
                var result = await _repo.DeteleAccount(vMDeletes);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        [HttpPost("create_employee")]
        public async Task<IActionResult> CreateEmployee(VMUserRegister vMUserRegister)
        {
            try
            {
                var defaultRole = await _repo.CreateEmployee(vMUserRegister);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }

        [HttpPut("update_employee")]
        public async Task<IActionResult> UpdateEmployee(VMUserUpdate vMUserUpdates)
        {
            try
            {
                var defaultRole = await _repo.UpdateEmployee(vMUserUpdates);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }

        [HttpDelete("detele_employee")]
        public async Task<IActionResult> DeleteEmployee(VMDelete[] vMDeletes)
        {
            try
            {
                var result = await _repo.DeteleEmployee(vMDeletes);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }


        [HttpPost("get_information")]
        public async Task<IActionResult> GetInfomations(UserParam user)
        {
            try
            {
                var result = await _repo.GetInformationEmployee(user.username);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

    }
}
