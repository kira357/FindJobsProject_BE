using FindJobsProject.Database.Entities;
using System;
using System.Collections.Generic;

namespace FindJobsProject.ViewModels.VMComment
{
    public class VMCreateComment
    {

        public string CommentMsg { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentOn { get; set; }

        public Guid IdUser { get; set; }

        public Guid IdPosition { get; set; }

        //public ICollection<ReplyComment> Replies { get; set; }
        //public ICollection<AppUser> Users { get; set; }
    }
}
