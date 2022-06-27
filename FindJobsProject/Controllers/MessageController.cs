﻿using FindJobsProject.Database.Entities;
using FindJobsProject.DI;
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

        public MessageController(IReposityMessage repo)
        {
            _repo = repo;
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
        public IActionResult GetUserReceivedMessages(Guid userId)
        {
            var messages = _repo.GetReceivedMessages(userId);
            return Ok(messages);
        }
        
        [HttpGet("received-messages")]
        public IActionResult GetMessage([FromQuery] PaginationFilter filter)
        {
            var messages = _repo.GetMessage(filter);
            return Ok(messages);
        }


    }
}
