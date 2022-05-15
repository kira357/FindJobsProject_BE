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
    public class JobController : ControllerBase
    {
        private readonly IReposityJob _repo;

        public JobController(IReposityJob repo)
        {
            _repo = repo;
        }

        [HttpPost("create-Job")]
        public async Task<IActionResult> CreateJob(VMJob vMJob)
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




    }
}
