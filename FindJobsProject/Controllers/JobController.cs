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

        [HttpPost("create-job")] 
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
        [HttpGet("getlist-job")]
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
        
        
        [HttpGet("getitem-job/{Id}")]
        public async Task<IActionResult> GetItemJob([FromQuery] PaginationFilter filter,Guid Id)
        {
            try
            {
                var getList = await _repo.GetItemJob(filter, Request,Id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 


        [HttpGet("get-job-filter-major")]
        public async Task<IActionResult> GetJobFilterByMajor([FromQuery] PaginationFilter filter, long idMajor, string experience)
        {
            try
            {
                var getList = await _repo.GetJobFilterByMajor(filter, Request, idMajor, experience);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }


        [HttpGet("getlist-job-active")]
        public async Task<IActionResult> GetListJobActive([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getList = await _repo.GetListJobActive(filter, Request);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        
        [HttpPut("update-job")]
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
        [HttpDelete("delete-job")]
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
