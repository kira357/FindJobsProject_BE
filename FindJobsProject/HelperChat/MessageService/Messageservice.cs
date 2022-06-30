using FindJobsProject.Database;
using FindJobsProject.Database.Entities;

namespace FindJobsProject.HelperChat.MessageService
{
    public class MessageService : IMessageService
    {
        protected FindJobsContext Context;
        public MessageService(FindJobsContext context)
        {
            Context = context;
        }

        public void Add(ChatRecruitment message)
        {
            Context.chatRecruitments.Add(message);
            Context.SaveChanges();
        }
    }
}
