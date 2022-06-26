using System;

namespace FindJobsProject.ViewModels.VMChatRecruitment
{
    public class VMCreateChatRecruitment
    {
        public long IdChat { get; set; }

        public string IdSender { get; set; }
        public string IdReceiver { get; set; }

        public string Messages { get; set; }

        public string TimeSend { get; set; }

        public string ConnectionId { get; set; }
        public string Type { get; set; }

    }
}
