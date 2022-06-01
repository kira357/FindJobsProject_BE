using FindJobsProject.Database.Entities;
using System;

namespace FindJobsProject.ViewModels.VMReply
{
    public class VMReply
    {
        public long Id { get; set; }
        public long? IdComment { get; set; }
        public string ReplyMsg { get; set; }
        public DateTime? CreateOn { get; set; }
        public Guid? IdUser { get; set; }
        public Guid IdPostion { get; set; }

    }
}
