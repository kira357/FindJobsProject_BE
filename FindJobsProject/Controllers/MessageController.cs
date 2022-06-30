using FindJobsProject.Database.Entities;
using FindJobsProject.DI;
using FindJobsProject.HelperChat.Core.Business_Interface;
using FindJobsProject.HelperChat.Core.Business_Interface.ServiceQuery;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMChatRecruitment;
using FindJobsProject.ViewModels.VMMajor;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindJobsProject.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IReposityMessage _repo;

        private readonly IMessageServiceQuery messageServiceQuery;
        private readonly IMessageService messageService;

        public MessageController(IReposityMessage repo, 
            IMessageServiceQuery messageServiceQuery, 
            IMessageService messageService)
        {
            _repo = repo;
            this.messageServiceQuery = messageServiceQuery;
            this.messageService = messageService;
        }

        [HttpPost("create-message")]
        public async Task<IActionResult> CreateMessage(VMCreateChatRecruitment vMMessage)
        {
            try
            {
                var create = await _repo.CreateMessage(vMMessage);
                return Ok(create);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
            }

        }

        [HttpGet("received-messages/{userId}")]
        public IActionResult GetUserReceivedMessages(string userId)
        {
            var messages = this.messageServiceQuery.GetReceivedMessages(userId);
            return Ok(messages);
        }
        
        [HttpGet("received-messages")]
        public IActionResult GetMessage([FromQuery] PaginationFilter filter)
        {
            var messages = _repo.GetMessage(filter);
            return Ok(messages);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var messages = this.messageServiceQuery.GetAll();
                return Ok(messages);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }

    }
}
