using FindJobsProject.Database;
using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindJobsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IReposityEmployee _repoEm;
        private readonly FindJobsContext _context;
        public CompanyController(IReposityEmployee repoEm, FindJobsContext context)
        {
            _repoEm = repoEm;
            _context = context;
        }

        [HttpPost("create_company")]
        public async Task<IActionResult> CreateCompany([FromForm] VMCompany vMCompany)
        {

            try
            {
                var result = await _repoEm.CreateCompany(vMCompany);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        [HttpGet("get_company")]
        public async Task<IActionResult> ShowListCompany()
        {
            try
            {
                var showlist =await _repoEm.ShowListCompany(Request);
                return Ok(showlist);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }


        [HttpGet("get_jobs")]
        public async Task<IActionResult> ShowListJobs()
        {

            try
            {
                var getList =await _repoEm.ShowListJobs(Request);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return BadRequest() ;
        }  
        
        
        [HttpGet("get_jobsByCompany/{id}")]
        public async Task<IActionResult> ShowJobsByCompany(Guid id)
        {

            try
            {
                var getList =await _repoEm.ShowListJobsAndCompany(Request , id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return BadRequest() ;
        }
        [HttpGet("get_detailjob/{id}")]
        public async Task<IActionResult> ShowListJobsDetail(Guid id)
        {

            try
            {
                var getList =await _repoEm.ShowListJobsDetail(Request , id);
                return Ok(getList);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return BadRequest() ;
        }
        
        
        
        [HttpGet("showjobs")]
        public async Task<IActionResult> ShowAllJobs(int page, int pageSize)
        {
            try
            {
                var getList = await _context.companies.Join(_context.companyJobs,
                                                      company => company.id,
                                                      companyJobs => companyJobs.companyId,
                                                      (company, companyJobs) => new
                                                      {
                                                          name = company.name,
                                                          nameJobs = companyJobs.jobs.name,
                                                          imageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, company.logo),
                                                          type = company.type,
                                                          active = companyJobs.jobs.active,
                                                          Tag = companyJobs.jobs.Tag,
                                                          dayLeft = companyJobs.jobs.daysLeft,
                                                          idCompany = companyJobs.companyId,
                                                          idJobs = companyJobs.jobsId,

                                                      }).ToListAsync();
            //try { 

            //var AllJobs = _context.companyJobs.Include(x => x.jobs).AsQueryable();
            //var result = PaginatedList<CompanyJobs>.CreatePages(AllJobs, page, pageSize);

            //var data = result.Select(x => new VMCompanyJobs
            //{
            //    idJobs = x.jobsId,
            //    idCompany = x.companyId,
            //    imageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.company.logo),
            //    type = x.company.type,
            //    dateWork = x.company.dateWork,
            //    dayLeft = x.jobs.daysLeft,
            //    name = x.company.name,
            //    active = x.jobs.active,
            //    Tag = x.jobs.Tag

            //}).ToList().Count();

            return Ok(getList);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return BadRequest() ;
        }



        [HttpPost("create_jobs")]
        public async Task<IActionResult> CreateJobs(VMJobs vMJobs)
        {

            try
            {
                var result = await _repoEm.CreateJob(vMJobs);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        } 
        
        
        [HttpDelete("delete_jobs/{id}")]
        public async Task<IActionResult> DeleteJobs(Guid id)
        {

            try
            {
                var result = await _repoEm.DeleteJobs(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }  
        [HttpDelete("delete_company/{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {

            try
            {
                var result = await _repoEm.DeleteCompany(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        
        [HttpPut("active_jobs/{id}")]
        public async Task<IActionResult> ActiveJobs(Guid id , VMJobs vMJobs)
        {

            try
            {
                var result = await _repoEm.ActiveJobs(id , vMJobs);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

       
    }
}
