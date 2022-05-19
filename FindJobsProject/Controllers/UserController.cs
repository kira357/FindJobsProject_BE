using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindJobsProject.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IReposityUser _repo;

        public UserController(IReposityUser repo)
        {
            _repo = repo;
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
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getAll = await _repo.GetAllAcc(filter);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }


        [HttpPost("createdefaultrole")]
        public async Task<IActionResult> AddDefaultRole(VMRole roleVM)
        {
            try
            {
                var defaultRole = await _repo.CreateRole(roleVM);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(VMUserRegister vMUserRegister)
        {
            try
            {
                var defaultRole = await _repo.CreateUser(vMUserRegister);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        [HttpPost("adduserrole")]
        public async Task<IActionResult> AddUserToRole(VMUserRegister user , string role)
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



    }
}
