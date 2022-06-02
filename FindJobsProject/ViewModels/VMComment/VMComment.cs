using FindJobsProject.Database.Entities;
using FindJobsProject.ViewModels.VMReply;
using System;
using System.Collections.Generic;

namespace FindJobsProject.ViewModels.VMComment
{
    public class VMComment
    {
        public long Id { get; set; }
        public string CommentMsg { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentOn { get; set; }
        public string UrlAvatar { get; set; }
        public string UserName { get; set; }

        public Guid IdUser { get; set; }

        public Guid IdPosition { get; set; }

        public ICollection<VMReplyComment> Replies { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
