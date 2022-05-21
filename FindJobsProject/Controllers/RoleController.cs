using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMMajor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindJobsProject.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IReposityRole _repo;

        public RoleController(IReposityRole repo)
        {
            _repo = repo;
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(VMRole vMRole)
        {
            try
            {
                var create = await _repo.CreateRole(vMRole);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpGet("getlist-role")]
        public async Task<IActionResult> GetListRole([FromQuery] PaginationFilter filter)
        {
            try
            {
                var create = await _repo.GetListRole(filter);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpPut("update-role")]
        public async Task<IActionResult> UpdateRole(VMUpdateRole vMUpdateRole)
        {
            try
            {
                var create = await _repo.UpdateRole(vMUpdateRole);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 
        [HttpDelete("detele-role")]
        public async Task<IActionResult> DeleteRole(VMDeleteRole vMRole)
        {
            try
            {
                var create = await _repo.DeteleRole(vMRole);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }




    }
}
