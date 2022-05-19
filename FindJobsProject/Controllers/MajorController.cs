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
    public class MajorController : ControllerBase
    {
        private readonly IReposityMajor _repo;

        public MajorController(IReposityMajor repo)
        {
            _repo = repo;
        }

        [HttpPost("create-major")]
        public async Task<IActionResult> CreateMajor(VMMajor vMMajor)
        {
            try
            {
                var create = await _repo.CreateMajor(vMMajor);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpGet("getlist-major")]
        public async Task<IActionResult> GetListMajor([FromQuery] PaginationFilter filter)
        {
            try
            {
                var create = await _repo.GetListMajor(filter);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpPut("update-major")]
        public async Task<IActionResult> UpdateMajor(VMUpdateMajor vMUpdateMajor)
        {
            try
            {
                var create = await _repo.UpdateMajor(vMUpdateMajor);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 
        [HttpDelete("detele-major")]
        public async Task<IActionResult> DeleteMajor(VMDeleteMajor vMMajor)
        {
            try
            {
                var create = await _repo.DeteleMajor(vMMajor);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }




    }
}
