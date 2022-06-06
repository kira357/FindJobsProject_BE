using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMBlog;
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
    public class BlogController : ControllerBase
    {
        private readonly IReposityBlog _repo;

        public BlogController(IReposityBlog repo)
        {
            _repo = repo;
        }

        [HttpPost("create-post")] 
        public async Task<IActionResult> CreateJob([FromForm]VMCreateBlog vMJob)
        {
            try
            {
                var create = await _repo.CreateBlog(vMJob);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpGet("getlist-post/{Id}")]
        public async Task<IActionResult> GetListJob([FromQuery] PaginationFilter filter, Guid Id)
        {
            try
            {
                var getList = await _repo.GetListBlog(filter, Request , Id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 
        [HttpGet("getitem-post/{Id}")]
        public async Task<IActionResult> GetItemBlog([FromQuery] PaginationFilter filter, Guid Id)
        {
            try
            {
                var getList = await _repo.GetItemBlog(filter, Request , Id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }

        [HttpGet("get-blog-filter-major")]
        public async Task<IActionResult> GetBlogFilterByMajor([FromQuery] PaginationFilter filter, long idMajor)
        {
            try
            {
                var getList = await _repo.GetBlogFilterByMajor(filter, Request, idMajor);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }

        [HttpGet("getlist-post")]
        public async Task<IActionResult> GetListAllBlog([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getList = await _repo.GetListAllBlog(filter, Request);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 
        
        [HttpGet("getlist-post-active")]
        public async Task<IActionResult> GetListBlogActive([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getList = await _repo.GetListBlogActive(filter, Request);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        
        [HttpPut("update-post")]
        public async Task<IActionResult> UpdateJob([FromForm]VMUpdateBlog vMUpdateJob)
        {
            try
            {
                var getList = await _repo.UpdateBlog(vMUpdateJob);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpPut("update-approved")]
        public async Task<IActionResult> UpdateApproved(VMUpdateBlog vMUpdateJob)
        {
            try
            {
                var getList = await _repo.UpdateApproved(vMUpdateJob);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 
        [HttpDelete("delete-post")]
        public async Task<IActionResult> DeleteBlog(VMDeleteBlog vMDeleteJob)
        {
            try
            {
                var getList = await _repo.DeleteBlog(vMDeleteJob);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }




    }
}
