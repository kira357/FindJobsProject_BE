using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsProject.Database.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string CommentMsg { get; set; }
        public DateTime CommentDate { get; set; }
        public string  CommentOn { get; set; }

        public Guid IdUser { get; set; }
        public AppUser UserComment { get; set; }

        public Guid IdPosition { get; set; }

        public ICollection<ReplyComment> Replies { get; set; }
        public ICollection<AppUser> Users { get; set; }

    }
}
