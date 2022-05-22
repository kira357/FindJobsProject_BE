using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindJobsProject.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IReposityJob _repo;

        public JobController(IReposityJob repo)
        {
            _repo = repo;
        }

        [HttpPost("create-Job")] 
        public async Task<IActionResult> CreateJob([FromForm]VMJob vMJob)
        {
            try
            {
                var create = await _repo.CreateJob(vMJob);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpGet("getlist-Job")]
        public async Task<IActionResult> GetListJob([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getList = await _repo.GetListJob(filter, Request);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        
        [HttpPut("update-Job")]
        public async Task<IActionResult> UpdateJob([FromForm]VMUpdateJob vMUpdateJob)
        {
            try
            {
                var getList = await _repo.UpdateJob(vMUpdateJob);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 
        [HttpDelete("delete-Job")]
        public async Task<IActionResult> DeleteJob(VMDeleteJob vMDeleteJob)
        {
            try
            {
                var getList = await _repo.DeleteJob(vMDeleteJob);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }




    }
}
