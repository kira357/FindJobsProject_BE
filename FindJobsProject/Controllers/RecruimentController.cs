using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMRecruitment;
using FindJobsProject.ViewModels.VMUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindJobsProject.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentController : ControllerBase
    {
        private readonly IReposityRecruitment _repo;

        public RecruitmentController(IReposityRecruitment repo)
        {
            _repo = repo;
        }


        [HttpGet("getlist-recruiment/{Id}")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter , Guid Id)
        {
            try
            {
                var getAll = await _repo.GetListRecruiment(filter, Request , Id);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        [HttpGet("get-current-recruitment/{Id}")]
        public async Task<IActionResult> GetCurrentRecruitment( Guid Id)
        {
            try
            {
                var getAll = await _repo.GetCurrentRecruitment(Id,Request);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        
        [HttpGet("get-list-company")]
        public async Task<IActionResult> GetListCompany([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getAll = await _repo.GetListCompany(filter, Request);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }  
        [HttpGet("get-detail-company/{id}")]
        public async Task<IActionResult> GetDetailCompany(Guid id)
        {
            try
            {
                var getAll = await _repo.GetDetailCompany(Request, id);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        
        [HttpGet("get-all-jobs-company/{id}")]
        public async Task<IActionResult> GetAllJobsInCompany([FromQuery] PaginationFilter filter, Guid id)
        {
            try
            {
                var getAll = await _repo.GetAllJobsInCompany(filter, Request, id);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }


        [HttpPut("update-recruiment/{id}")]
        public async Task<IActionResult> UpdateRecruiment([FromForm]VMUpdateRecruitment vMRecruitmentJobs,Guid id)
        {
            try
            {
               var defaultRole = await _repo.UpdateRecruiment(vMRecruitmentJobs,id);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }   
       
        
        [HttpDelete("delete-recruiment/{Id}")]
        public async Task<IActionResult> DeleteRecruiment(Guid Idjob)
        {
            try
            {
               var defaultRole = await _repo.DeleteRecruiment(Idjob);
                return Ok(defaultRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        } 
        



    }
}
