using FindJobsProject.DI;
using FindJobsProject.Helper;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
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
    public class CandidateJobController : ControllerBase
    {
        private readonly IReposityCandidate _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidateJobController(IReposityCandidate repo , IWebHostEnvironment webHostEnvironment)
        {
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("apply-job")]
        public async Task<IActionResult> ApplyJob([FromForm]VMCandidateJob vMCandidateJob)
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
        [HttpGet("get-alllist-apply")]
        public async Task<IActionResult> GetListAllCandidate([FromQuery] PaginationFilter filter)
        {
            try
            {
                var getList = await _repo.GetListApplyJob(filter, Request);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 
        [HttpGet("get-list-apply/{id}")]
        public async Task<IActionResult> GetListCandidate([FromQuery] PaginationFilter filter,Guid id)
        {
            try
            {
                var getList = await _repo.GetItemApplyJob(filter, Request, id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        } 
        
        [HttpGet("is-apply-and-like/{id}")]
        public async Task<IActionResult> CheckIsApplyAndFavourite(Guid id,Guid IdJob)
        {
            try
            {
                var getList = await _repo.CheckIsApplyAndFavourite(id,IdJob);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpPut("is-approved/{id}")]
        public async Task<IActionResult> UpdateApproved(VMUpdateCandidateJob vMUpdateCandidateJob, Guid id)
        {
            try
            {
                var getList = await _repo.ApprovedCandidate(vMUpdateCandidateJob, id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpPut("is-delete/{id}")]
        public async Task<IActionResult> DeleteCandidate(VMDeleteCandidateJob vMDetelecCandidateJob , Guid id)
        {
            try
            {
                var getList = await _repo.DeteleCandidate(vMDetelecCandidateJob, id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        
        [HttpGet("download-file")]
        public async Task<IActionResult> DownloadFile([FromQuery]string fileName)
        {
            try
            {
                var uploads = Path.Combine(_webHostEnvironment.ContentRootPath, "Files");
                var filePath = Path.Combine(uploads, fileName);
                if (!System.IO.File.Exists(filePath))
                    return NoContent();

                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
 
                return File(memory, GetContentType(filePath), Path.GetFileName(filePath));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        // Get mime types
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
    {
        {".txt", "text/plain"},
        {".pdf", "application/pdf"},
        {".doc", "application/vnd.ms-word"},
        {".docx", "application/vnd.ms-word"},
        {".xls", "application/vnd.ms-excel"},
        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
        {".png", "image/png"},
        {".jpg", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".gif", "image/gif"},
        {".csv", "text/csv"}
    };
        }


    }
}
