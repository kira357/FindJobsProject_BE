using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMUser;
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


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getAll = await _repo.GetAllAcc(filter, Request);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        [HttpGet("getAllListWithNoRole")]
        public async Task<IActionResult> GetAllListWithNoRole([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getAll = await _repo.GetListUserWillChat(filter, Request);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        
        
        [HttpGet("getcurrent-user/{id}")]
        public async Task<IActionResult> GetCurrentUser(Guid id)
        {
            try
            {
                var getAll = await _repo.GetCurrentUser(id, Request);
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
        public async Task<IActionResult> CreateUser(VMCreateUser vMUserRegister)
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
        [HttpPut("update-user/{Id}")]
        public async Task<IActionResult> UpdateUser(VMUserUpdate user , Guid Id)
        {
            try
            {
               var defaultRole = await _repo.UpdateUser(user,Id);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        
        [HttpPut("update-information/{Id}")]
        public async Task<IActionResult> UpdateInfoUser([FromForm] VMUserUpdate user , Guid Id)
        {
            try
            {
               var defaultRole = await _repo.UpdateInfoUser(user,Id);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }  
        
        [HttpDelete("delete-user/{Id}")]
        public async Task<IActionResult> DeleteUser(VMUserDelete user , Guid Id)
        {
            try
            {
               var defaultRole = await _repo.DeleteUser(user,Id);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }

        [HttpPut("update-active")]
        public async Task<IActionResult> UpdateActivie(VMUpdateJob vMUpdateJob)
        {
            try
            {
                var defaultRole = await _repo.ActiveJobs(vMUpdateJob);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }


    }
}
