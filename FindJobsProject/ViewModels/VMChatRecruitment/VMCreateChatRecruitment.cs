using System;

namespace FindJobsProject.ViewModels.VMChatRecruitment
{
    public class VMCreateChatRecruitment
    {
        public Guid IdChat { get; set; }

        public string IdSender { get; set; }
        public string IdReceiver { get; set; }

        public string Messages { get; set; }

        public DateTime TimeSend { get; set; }

        public string ConnectionId { get; set; }
        public string Type { get; set; }

    }
}
