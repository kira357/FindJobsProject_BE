using FindJobsProject.Database.Entities;
using System;
using System.Collections.Generic;

namespace FindJobsProject.HelperChat.MessageServiceQuery
{
    public interface IMessageServiceQuery
    {
        IEnumerable<ChatRecruitment> GetAll();
        IEnumerable<ChatRecruitment> GetReceivedMessages(Guid userId);
    }
}
