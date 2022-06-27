using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMChatRecruitment;
using FindJobsProject.ViewModels.VMMajor;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityMessage : IReposityMessage
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ReposityMessage(IMapper mapper,
                            UserManager<AppUser> userManager,
                            RoleManager<AppRole> roleManager,
                            SignInManager<AppUser> signInManager,
                            FindJobsContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }


        public async Task<Respone> CreateMessage(VMCreateChatRecruitment vMMessage)
        {
            try
            {
                var message = _mapper.Map<ChatRecruitment>(vMMessage);
                var createMajor = await _context.chatRecruitments.AddAsync(message);

                await _context.SaveChangesAsync();

                return new Respone
                {
                    Ok = "Success"
                };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return null;
       
        }


        public async Task<PagedResponse<IEnumerable<VMGetChatRecruitment>>> GetMessage(PaginationFilter filter)
        {

            var data = (from user in _context.chatRecruitments.AsQueryable()
                        select new VMGetChatRecruitment
                        {
                           IdChat = user.IdChat,
                           IdReceiver = user.IdReceiver,
                           IdSender = user.IdSender,
                           ConnectionId = user.ConnectionId,
                           Messages = user.Messages,
                           Photo = user.Photo,
                           TimeSend = user.TimeSend,
                        });

            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetChatRecruitment>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();

            return new PagedResponse<IEnumerable<VMGetChatRecruitment>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        }

        public async Task<IEnumerable<ChatRecruitment>> GetReceivedMessages(Guid userId)
        {
            try
            {
                var messages = _context.chatRecruitments.Where(x => x.IdReceiver == userId).ToList();
                return messages;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
