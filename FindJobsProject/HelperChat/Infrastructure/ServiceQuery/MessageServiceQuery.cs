using FindJobsProject.Database.Entities;
using FindJobsProject.HelperChat.Core.Business_Interface.ServiceQuery;
using FindJobsProject.HelperChat.Core.Repository_Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FindJobsProject.HelperChat.Infrastructure.ServiceQuery
{
    public class MessageServiceQuery : IMessageServiceQuery
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;
        public MessageServiceQuery(IUnitOfWork unitOfWork , IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }   
        IEnumerable<ChatRecruitment> IMessageServiceQuery.GetAll()
        {
            try
            {
                var messages = this.unitOfWork.Repository<ChatRecruitment>().Get().ToList();
                return messages;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }
        IEnumerable<ChatRecruitment> IMessageServiceQuery.GetReceivedMessages(string userId)
        {
            try
            {
                var currentUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var messages = this.unitOfWork.Repository<ChatRecruitment>().Get().Where(x => x.IdReceiver == Guid.Parse(userId)
                                                                                        || x.IdSender == Guid.Parse(userId)).ToList();
                return messages;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }
    }
}
