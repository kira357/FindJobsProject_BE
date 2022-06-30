using FindJobsProject.Database.Entities;
using System.Collections.Generic;

namespace FindJobsProject.HelperChat.Core.Business_Interface.ServiceQuery
{
    public interface IMessageServiceQuery
    {
        IEnumerable<ChatRecruitment> GetAll();
        IEnumerable<ChatRecruitment> GetReceivedMessages(string userId);
    }
}
