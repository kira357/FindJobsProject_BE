
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FindJobsProject.HelperChat.Core.Business_Interface;
using FindJobsProject.HelperChat.Core.Repository_Interfaces;
using FindJobsProject.Database.Entities;

namespace FindJobsProject.HelperChat.Infrastructure
{
    public class MessageService: IMessageService
    {
        private readonly IUnitOfWork unitOfWork;
        public MessageService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(ChatRecruitment message)
        {
            this.unitOfWork.Repository<ChatRecruitment>().Add(message);
            this.unitOfWork.SaveChanges();
        }

    }
}
