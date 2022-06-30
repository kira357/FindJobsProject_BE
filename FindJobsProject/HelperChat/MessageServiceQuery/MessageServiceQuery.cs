using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FindJobsProject.HelperChat.MessageServiceQuery
{
    public class MessageServiceQuery : IMessageServiceQuery
    {
        protected FindJobsContext Context;
        public MessageServiceQuery(FindJobsContext context)
        {
            Context = context;
        }
        public IEnumerable<ChatRecruitment> GetAll()
        {
            return Context.chatRecruitments.AsNoTracking().ToList().OrderBy(x => x.TimeSend); ;
        }
        public IEnumerable<ChatRecruitment> GetReceivedMessages(Guid Id)
        {
            return (IEnumerable<ChatRecruitment>)Context.chatRecruitments.AsNoTracking().FirstOrDefault(x => x.IdChat == Id);
        }

       
    }
}