using System;

namespace FindJobsProject.ViewModels.VMChatRecruitment
{
    public class VMGetChatRecruitment
    {
        public Guid IdChat { get; set; }

        public Guid? IdSender { get; set; }
        public Guid? IdReceiver { get; set; }

        public string Messages { get; set; }

        public DateTime TimeSend { get; set; }

        public string ConnectionId { get; set; }

        public string Photo { get; set; }
    }
}
