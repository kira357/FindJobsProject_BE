using FindJobsProject.DI;
using FindJobsProject.Helper;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMComment;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMReply;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace FindJobsProject.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IReposityComment _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CommentController(IReposityComment repo, IWebHostEnvironment webHostEnvironment)
        {
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("create-comment")]
        public async Task<IActionResult> CreateComment(VMCreateComment vMCreateComment)
        {
            try
            {
                var create = await _repo.CreateComment(vMCreateComment);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpPost("reply-comment")]
        public async Task<IActionResult> ReplyComment(VMReplyComment vMReply)
        {
            try
            {
                var create = await _repo.ReplyComment(vMReply);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpGet("get-all-list-comment")]
        public async Task<IActionResult> GetAllListComment([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getList = await _repo.GetAllListComment(filter, Request);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpGet("get-comment-user/{id}")]
        public async Task<IActionResult> GetCommentUserOnJobs([FromQuery] PaginationFilter filter, Guid id)
        {
            try
            {
                var getList = await _repo.GetCommentUserOnJobs(filter, Request, id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }

    }
}
