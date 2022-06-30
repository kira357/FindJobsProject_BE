using FindJobsProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FindJobsProject.HelperChat.Core.Business_Interface
{
    public interface IMessageService
    {
        void Add(ChatRecruitment message);
    }
}
