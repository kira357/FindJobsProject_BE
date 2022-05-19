using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
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
    public class CandidateJobController : ControllerBase
    {
        private readonly IReposityCandidate _repo;

        public CandidateJobController(IReposityCandidate repo)
        {
            _repo = repo;
        }

        [HttpPost("Apply-job")]
        public async Task<IActionResult> CreateCandidateJob(VMCandidateJob vMCandidateJob)
        {
            try
            {
                var create = await _repo.ApplyJob(vMCandidateJob);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpGet("get-list-CandidateJob")]
        public async Task<IActionResult> GetListCandidate(int PageIndex , int PageSize , Guid Id)
        {
            try
            {
                var getList = await _repo.GetListCandidate(PageIndex,PageSize,Id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        
        [HttpPut("update-CandidateJob")]
        public async Task<IActionResult> UpdateCandidate(VMUpdateCandidateJob vMUpdateCandidateJob)
        {
            try
            {
                var getList = await _repo.UpdateCandidate(vMUpdateCandidateJob);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }




    }
}
