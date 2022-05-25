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
    public class RecruitmentController : ControllerBase
    {
        private readonly IReposityRecruitment _repo;

        public RecruitmentController(IReposityRecruitment repo)
        {
            _repo = repo;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter , Guid IdRecruiment)
        {
            try
            {
                var getAll = await _repo.GetListRecruiment(filter, Request , IdRecruiment);
                return Ok(getAll);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }


        [HttpPut("update-recruiment")]
        public async Task<IActionResult> UpdateRecruiment(List<VMRecruitmentJob> vMRecruitmentJobs)
        {
            try
            {
               var defaultRole = await _repo.UpdateActiveJobs(vMRecruitmentJobs);
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
