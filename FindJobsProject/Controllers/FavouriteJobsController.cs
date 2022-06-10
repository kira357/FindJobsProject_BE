using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMFavourite;
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
    public class FavouriteJobsController : ControllerBase
    {
        private readonly IReposityFavourite _repo;

        public FavouriteJobsController(IReposityFavourite repo)
        {
            _repo = repo;
        }

        [HttpPost("create-favourite")] 
        public async Task<IActionResult> CreateFavourite(VMCreateFavourite vMJob)
        {
            try
            {
                var create = await _repo.CreateFavourite(vMJob);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
      


    }
}
