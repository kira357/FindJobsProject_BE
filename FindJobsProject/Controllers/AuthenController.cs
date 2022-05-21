using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindJobsProject.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class   AuthenController : ControllerBase
    {
        private readonly IReposityAuthen _repo;

        public AuthenController(IReposityAuthen repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(VMUserRegister vMUserRegister)
        {
            try
            {
                var create = await _repo.RegisterUser(vMUserRegister);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(VMUserLogin vMUserLogin)
        {
            try
            {
                var login = await _repo.LoginUser(vMUserLogin);
                return Ok(login);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }
        }
   
    }
}
