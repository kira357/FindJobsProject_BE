using FindJobsProject.Database.Entities;
using FindJobsProject.HelperChat.Core.Business_Interface.ServiceQuery;
using FindJobsProject.HelperChat.Core.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindJobsProject.HelperChat.Infrastructure.ServiceQuery
{
    public class MessageServiceQuery : IMessageServiceQuery
    {
        private readonly IUnitOfWork unitOfWork;
        public MessageServiceQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
                var messages = this.unitOfWork.Repository<ChatRecruitment>().Get().Where(x => x.IdReceiver == Guid.Parse(userId)).ToList();
                return messages;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }
    }
}
