using FindJobsProject.Database.Entities;
using FindJobsProject.DI;
using FindJobsProject.HelperChat.MessageService;
using FindJobsProject.HelperChat.MessageServiceQuery;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMChatRecruitment;
using FindJobsProject.ViewModels.VMMajor;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMessageServiceQuery messageServiceQuery;
        private readonly IMessageService messageService;
        public MessageController(IMessageServiceQuery _messageServiceQuery, IMessageService _messageService)
        {
            this.messageServiceQuery = _messageServiceQuery;
            this.messageService = _messageService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var messages = this.messageServiceQuery.GetAll();
            return Ok(messages);
        }
        [HttpGet("received-messages/{userId}")]
        public IActionResult GetUserReceivedMessages(Guid userId)
        {
            var messages = this.messageServiceQuery.GetReceivedMessages(userId);
            return Ok(messages);
        }
    }
}
